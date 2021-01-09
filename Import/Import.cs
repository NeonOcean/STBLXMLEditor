using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STBLXMLEditor {
	public partial class Import : Form {
		public HashSet<STBL.Languages> SelectedLanguages = new HashSet<STBL.Languages>();

		public Import () {
			InitializeComponent();

			if(Loading.FilePath != null) {
				OpenSTBLXMLDialog.InitialDirectory = Path.GetDirectoryName(Loading.FilePath);
			}
		}

		public static void ShowNoOrInvalidFileDialog () {
			MessageBoxButtons dialogButtons = MessageBoxButtons.OK;
			MessageBox.Show(Localization.GetString("ImportNoOrInvalidFileText"), Localization.GetString("WarningMessageTitle"), dialogButtons, MessageBoxIcon.Warning);
		}

		public static void ShowNoLanguagesSelectedDialog () {
			MessageBoxButtons dialogButtons = MessageBoxButtons.OK;
			MessageBox.Show(Localization.GetString("ImportWithNoLanguagesSelectedText"), Localization.GetString("WarningMessageTitle"), dialogButtons, MessageBoxIcon.Warning);
		}

		public static void ShowOpenFailureDialog (Exception failureException) {
			Error errorDialog = new Error(Localization.GetString("OpenFailureMessage"), failureException.ToString());
			errorDialog.Show();
		}

		private void FilePathSelectButton_Click (object sender, EventArgs e) {
			if(FilePathTextBox.Text != null && !string.IsNullOrWhiteSpace(FilePathTextBox.Text) && File.Exists(FilePathTextBox.Text)) {
				OpenSTBLXMLDialog.InitialDirectory = Path.GetDirectoryName(FilePathTextBox.Text);
				OpenSTBLXMLDialog.FileName = Path.GetFileName(FilePathTextBox.Text);
			}

			if(OpenSTBLXMLDialog.ShowDialog() == DialogResult.Cancel) {
				return;
			}

			FilePathTextBox.Text = OpenSTBLXMLDialog.FileName;

			OpenSTBLXMLDialog.InitialDirectory = "";
			OpenSTBLXMLDialog.FileName = "";
		}

		private void LanguagesButton_Click (object sender, EventArgs e) {
			Picker languagePicker = new Picker();
			Picker.SetupLanguagePicker(languagePicker, SelectedLanguages.ToList());

			if(languagePicker.ShowDialog() == DialogResult.Cancel) {
				return;
			}

			DialogResult = DialogResult.None;

			SelectedLanguages = new HashSet<STBL.Languages>(languagePicker.PickedItemValues.Cast<STBL.Languages>().ToList());
		}

		private void FormOkButton_Click (object sender, EventArgs e) {
			if(FilePathTextBox.Text == null || string.IsNullOrWhiteSpace(FilePathTextBox.Text) || !File.Exists(FilePathTextBox.Text)) {
				ShowNoOrInvalidFileDialog();
				DialogResult = DialogResult.None;
				return;
			}

			if(SelectedLanguages.Count <= 0) {
				ShowNoLanguagesSelectedDialog();
				DialogResult = DialogResult.None;
				return;
			}

			STBLXMLFile mergingFile = null;

			try {
				mergingFile = ImportExport.ImportFromPackageFile(FilePathTextBox.Text);
			} catch(Exception readException) {
				ShowOpenFailureDialog(readException);
				DialogResult = DialogResult.None;
				return;
			}

			HashSet<uint> existingEntryKeys = new HashSet<uint>();

			if(CreateMissingEntriesCheckBox.Checked) {
				foreach(STBLXMLEntry existingEntry in Loading.Data.Entries) {
					existingEntryKeys.Add(existingEntry.Key);
				}
			}

			Dictionary<string, Dictionary<STBL.Languages, string>> mergingLanguagesIdentifier = new Dictionary<string, Dictionary<STBL.Languages, string>>();
			Dictionary<uint, Dictionary<STBL.Languages, string>> mergingLanguagesKey = new Dictionary<uint, Dictionary<STBL.Languages, string>>();

			foreach(STBLXMLEntry mergingEntry in mergingFile.Entries) {
				string mergingEntryIdentifier = mergingEntry.Identifier;

				if(CreateMissingEntriesCheckBox.Checked) {
					if(!existingEntryKeys.Contains(mergingEntry.Key)) {
						Loading.AddNewEntry(key: mergingEntry.Key, identifier: mergingEntry.Identifier);
						existingEntryKeys.Add(mergingEntry.Key);
					}
				}

				if(!mergingLanguagesKey.ContainsKey(mergingEntry.Key)) {
					mergingLanguagesKey[mergingEntry.Key] = new Dictionary<STBL.Languages, string>();
				}

				foreach(STBL.Languages language in SelectedLanguages) {
					string mergingEntryLanguageText = mergingEntry.GetText(language);

					if(mergingEntryLanguageText == null) {
						continue;
					}

					mergingLanguagesKey[mergingEntry.Key][language] = mergingEntryLanguageText;
				}
			}

			List<uint> unmergedKeys = mergingLanguagesKey.Keys.ToList();
			List<string> unmergedIdentifiers = mergingLanguagesIdentifier.Keys.ToList();

			
			foreach(STBLXMLEntry existingEntry in Loading.Data.Entries) {
				if(!mergingLanguagesKey.ContainsKey(existingEntry.Key)) {
					continue;
				}

				foreach(KeyValuePair<STBL.Languages, string> languageTextPair in mergingLanguagesKey[existingEntry.Key]) {
					if(TextPriorityExistingRadioButton.Checked) {
						if(existingEntry.HasText(languageTextPair.Key)) {
							continue;
						}

						existingEntry.SetText(languageTextPair.Key, languageTextPair.Value);
					} else {
						existingEntry.SetText(languageTextPair.Key, languageTextPair.Value);
					}
				}
			}
		}
	}
}
