using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace STBLXMLEditor {
	public partial class SendTo : Form {
		public List<STBLXMLEntry> SplittingEntries = new List<STBLXMLEntry>();

		public HashSet<STBL.Languages> SelectedLanguages = null;

		public SendTo (List<STBLXMLEntry> splittingEntries = null) {
			SelectedLanguages = new HashSet<STBL.Languages>(STBL.GetAllLanguages());

			if(splittingEntries != null) {
				SplittingEntries = splittingEntries;
			}

			InitializeComponent();
		}

		public static void ShowNoOrInvalidFileDialog () {
			MessageBoxButtons dialogButtons = MessageBoxButtons.OK;
			DialogResult dialogResult = MessageBox.Show(Localization.GetString("SendToNoOrInvalidFileText"), Localization.GetString("WarningMessageTitle"), dialogButtons, MessageBoxIcon.Warning);
		}

		public static void ShowNoLanguagesSelectedDialog () {
			MessageBoxButtons dialogButtons = MessageBoxButtons.OK;
			DialogResult dialogResult = MessageBox.Show(Localization.GetString("SendToNoLanguagesSelectedText"), Localization.GetString("WarningMessageTitle"), dialogButtons, MessageBoxIcon.Warning);
		}

		public static void ShowSaveFailureDialog (Exception failureException) {
			Error errorDialog = new Error(Localization.GetString("SaveFailureMessage"), failureException.ToString());
			errorDialog.Show();
		}

		private void FilePathSelectButton_Click (object sender, EventArgs e) {
			if(FilePathTextBox.Text != null && !string.IsNullOrWhiteSpace(FilePathTextBox.Text) && File.Exists(FilePathTextBox.Text)) {
				SaveSTBLXMLDialog.InitialDirectory = Path.GetDirectoryName(FilePathTextBox.Text);
				SaveSTBLXMLDialog.FileName = Path.GetFileName(FilePathTextBox.Text);
			}

			if(SaveSTBLXMLDialog.ShowDialog() == DialogResult.Cancel) {
				return;
			}

			FilePathTextBox.Text = SaveSTBLXMLDialog.FileName;

			SaveSTBLXMLDialog.InitialDirectory = "";
			SaveSTBLXMLDialog.FileName = "";
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
			if(FilePathTextBox.Text == null || string.IsNullOrWhiteSpace(FilePathTextBox.Text)) {
				ShowNoOrInvalidFileDialog();
				DialogResult = DialogResult.None;
				return;
			}

			if(SelectedLanguages.Count <= 0) {
				ShowNoLanguagesSelectedDialog();
				DialogResult = DialogResult.None;
				return;
			}

			STBLXMLFile splitSTBLFile = new STBLXMLFile();

			foreach(STBLXMLEntry splittingEntry in SplittingEntries) {
				STBLXMLEntry splitEntry = new STBLXMLEntry() {
					Key = splittingEntry.Key,
					Identifier = splittingEntry.Identifier
				};

				foreach(STBL.Languages language in SelectedLanguages) {
					splitEntry.SetText(language, splittingEntry.GetText(language));
				}

				splitSTBLFile.Entries.Add(splitEntry);
			}

			try {
				Tools.WriteXML(FilePathTextBox.Text, splitSTBLFile);
			} catch (Exception saveException) {
				ShowSaveFailureDialog(saveException);
				DialogResult = DialogResult.None;
				return;
			}
		}
	}
}
