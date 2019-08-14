using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace STBLXMLEditor {
	public partial class Translator : Form {
		public STBLXMLEntry STBLEntry = null;

		public static STBL.Languages DefaultReferenceLanguage = STBL.Languages.English;
		public static STBL.Languages DefaultEditingLanguage = STBL.Languages.English;

		public Dictionary<STBL.Languages, string> CurrentLanguageStrings = new Dictionary<STBL.Languages, string>();
		public Dictionary<STBL.Languages, bool> CurrentLanguageStates = new Dictionary<STBL.Languages, bool>();

		public Translator (STBLXMLEntry stblEntry = null) {
			if(stblEntry != null) {
				STBLEntry = stblEntry;
			}

			InitializeComponent();

			IdentifierTextBox.Text = STBLEntry.Identifier;

			foreach(STBL.Languages language in STBL.GetAllLanguages()) {
				string languageText = STBLEntry.GetText(language);

				CurrentLanguageStrings[language] = Tools.NormalizeLineEndings(languageText);
				CurrentLanguageStates[language] = languageText != null ? true : false;
			}

			Forms.SetupLanguageComboBox(ReferencingLanguageSelector, DefaultReferenceLanguage);
			Forms.SetupLanguageComboBox(EditingLanguageSelector, DefaultEditingLanguage);
		}

		public void ChangeEditingLanguageTextBoxState (bool enabled) {
			if(enabled) {
				EditingLanguageTextBox.Enabled = true;
				EditingLanguageTextBox.BackColor = SystemColors.Window;
				EditDefaultEditingLanguageButton.Visible = false;
			} else {
				EditingLanguageTextBox.Enabled = false;
				EditingLanguageTextBox.BackColor = Color.Gainsboro;
				EditDefaultEditingLanguageButton.Visible = true;
			}
		}

		private void ReferencingLanguageSelector_SelectedIndexChanged (object sender, EventArgs e) {
			if(!(ReferencingLanguageSelector.SelectedItem is Forms.LanguageComboBoxItem languageSelected)) {
				return;
			}

			ReferencingLanguageTextBox.Text = Tools.NormalizeLineEndings(STBLEntry.GetText((STBL.Languages)languageSelected.Language));
			DefaultReferenceLanguage = (STBL.Languages)languageSelected.Language;
		}

		private void EditingLanguageSelector_SelectedIndexChanged (object sender, EventArgs e) {
			if(!(EditingLanguageSelector.SelectedItem is Forms.LanguageComboBoxItem languageSelected)) {
				return;
			}

			if(CurrentLanguageStates[(STBL.Languages)languageSelected.Language]) {
				EditingLanguageTextBox.Text = CurrentLanguageStrings[(STBL.Languages)languageSelected.Language];
				ChangeEditingLanguageTextBoxState(true);
			} else {
				EditingLanguageTextBox.Text = "";
				ChangeEditingLanguageTextBoxState(false);
			}

			DefaultEditingLanguage = (STBL.Languages)languageSelected.Language;
		}

		private void ResetEditingLanguageButton_Click (object sender, EventArgs e) {
			if(!(EditingLanguageSelector.SelectedItem is Forms.LanguageComboBoxItem languageSelected)) {
				return;
			}

			EditingLanguageTextBox.Text = null;
			CurrentLanguageStrings[(STBL.Languages)languageSelected.Language] = null;
			CurrentLanguageStates[(STBL.Languages)languageSelected.Language] = false;
			ChangeEditingLanguageTextBoxState(false);
		}

		private void EditDefaultEditingLanguageButton_Click (object sender, EventArgs e) {
			if(!(EditingLanguageSelector.SelectedItem is Forms.LanguageComboBoxItem languageSelected)) {
				return;
			}

			CurrentLanguageStrings[(STBL.Languages)languageSelected.Language] = "";
			CurrentLanguageStates[(STBL.Languages)languageSelected.Language] = true;
			ChangeEditingLanguageTextBoxState(true);
		}

		private void EditingLanguageTextBox_TextChanged (object sender, EventArgs e) {
			if(!(EditingLanguageSelector.SelectedItem is Forms.LanguageComboBoxItem languageSelected)) {
				return;
			}

			if(!CurrentLanguageStates[(STBL.Languages)languageSelected.Language]) {
				return;
			}

			CurrentLanguageStrings[(STBL.Languages)languageSelected.Language] = EditingLanguageTextBox.Text;
		}

		private void FormOkButton_Click (object sender, EventArgs e) {
			if(STBLEntry == null) {
				Close();
				return;
			}

			foreach(KeyValuePair<STBL.Languages, string> nextLanguageStringPair in CurrentLanguageStrings) {
				string currentLanguageString = Tools.NormalizeLineEndings(STBLEntry.GetText(nextLanguageStringPair.Key));

				if(currentLanguageString != nextLanguageStringPair.Value) {
					STBLEntry.SetText(nextLanguageStringPair.Key, nextLanguageStringPair.Value);
				}
			}

			Close();
		}

		private void FormCancelButton_Click (object sender, EventArgs e) {
			Close();
		}
	}
}
