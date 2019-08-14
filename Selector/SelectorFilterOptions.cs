using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace STBLXMLEditor {
	public partial class SelectorFilterOptions : Form {
		private static string lastKeyString = "";
		private static string lastIdentifierString = "";
		private static bool lastIdentifierMatchCaseState = false;
		private static bool lastIdentifierUseRegexState = false;
		private static string lastTextString = "";
		private static bool lastTextMatchCaseState = false;
		private static bool lastTextUseRegexState = false;
		private static STBL.Languages? lastUntranslatedToLanguage = null;

		public EntryBrowserFilter GeneratedFilter = null;

		public SelectorFilterOptions () {
			InitializeComponent();

			KeyTextBox.Text = lastKeyString;
			IdentifierTextBox.Text = lastIdentifierString;
			IdentifierMatchCaseCheckBox.Checked = lastIdentifierMatchCaseState;
			IdentifierUseRegexCheckBox.Checked = lastIdentifierUseRegexState;
			TextTextBox.Text = lastTextString;
			TextMatchCaseCheckBox.Checked = lastTextMatchCaseState;
			TextUseRegexCheckBox.Checked = lastTextUseRegexState;

			Forms.SetupLanguageComboBox(UntranslatedToSelector, lastUntranslatedToLanguage, includeNullLanguage: true);
		}

		private void FormOkButton_Click (object sender, EventArgs e) {
			lastKeyString = KeyTextBox.Text;
			lastIdentifierString = IdentifierTextBox.Text;
			lastIdentifierMatchCaseState = IdentifierMatchCaseCheckBox.Checked;
			lastIdentifierUseRegexState = IdentifierUseRegexCheckBox.Checked;
			lastTextString = TextTextBox.Text;
			lastTextMatchCaseState = TextMatchCaseCheckBox.Checked;
			lastTextUseRegexState = TextUseRegexCheckBox.Checked;
			lastUntranslatedToLanguage = ((Forms.LanguageComboBoxItem)UntranslatedToSelector.SelectedItem).Language;

			GeneratedFilter = new EntryBrowserFilter() {
				KeyFilter = lastKeyString,
				IdentifierFilter = lastIdentifierString,
				IdentifierFilterMatchCase = lastIdentifierMatchCaseState,
				IdentifierFilterUseRegex = lastIdentifierUseRegexState,
				TextFilter = lastTextString,
				TextFilterMatchCase = lastTextMatchCaseState,
				TextFilterUseRegex = lastTextUseRegexState,
				UntranslatedFilter = (int?)lastUntranslatedToLanguage
			};

			Close();
		}

		private void FormCancelButton_Click (object sender, EventArgs e) {
			Close();
		}
	}
}
