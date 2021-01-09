using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace STBLXMLEditor {
	public partial class Editor : Form {
		public static STBL.Languages DefaultLanguage = STBL.Languages.English;

		public STBLXMLEntry STBLEntry = new STBLXMLEntry();

		public Dictionary<STBL.Languages, string> CurrentLanguageStrings = new Dictionary<STBL.Languages, string>();
		public Dictionary<STBL.Languages, bool> CurrentLanguageStates = new Dictionary<STBL.Languages, bool>();

		public uint LastKeyValue = 0;

		public static bool ShowConfimCollidingEntryKey () {
			MessageBoxButtons dialogButtons = MessageBoxButtons.YesNo;
			DialogResult dialogResult = MessageBox.Show(Localization.GetString("ConfimCollidingEntryKey"), Localization.GetString("WarningMessageTitle"), dialogButtons, MessageBoxIcon.Warning);
			return (dialogResult == DialogResult.Yes) ? true : false;
		}

		public Editor (STBLXMLEntry stblEntry = null) {
			if(stblEntry != null) {
				STBLEntry = stblEntry;
			}

			InitializeComponent();

			IdentifierTextBox.Text = STBLEntry.Identifier;

			LastKeyValue = STBLEntry.Key;
			KeyDecimalTextBox.Text = STBLEntry.Key.ToString();
			KeyHexadecimalTextBox.Text = STBLEntry.Key.ToString("x").ToUpper();

			foreach(STBL.Languages language in STBL.GetAllLanguages()) {
				string languageText = STBLEntry.GetText(language);

				CurrentLanguageStrings[language] = Tools.NormalizeLineEndings(languageText);
				CurrentLanguageStates[language] = languageText != null ? true : false;
			}

			Forms.SetupLanguageComboBox(LanguageSelector, DefaultLanguage);
		}

		public void ChangeLanguageTextBoxState (bool enabled) {
			if(enabled) {
				LanguageTextBox.Enabled = true;
				LanguageTextBox.BackColor = SystemColors.Window;
				EditDefaultLanguageButton.Visible = false;
			} else {
				LanguageTextBox.Enabled = false;
				LanguageTextBox.BackColor = Color.Gainsboro;
				EditDefaultLanguageButton.Visible = true;
			}
		}

		private uint ParseUIntDecimalText (string decimalText) {
			return uint.Parse(decimalText);
		}

		private uint ParseUIntHexadecimalText (string hexadecimalText) {
			return uint.Parse(hexadecimalText, NumberStyles.HexNumber | NumberStyles.AllowHexSpecifier);
		}

		private bool VerifyUIntDecimalText (string decimalText) {
			try {
				ParseUIntDecimalText(decimalText);
			} catch {
				return false;
			}

			return true;
		}

		private bool VerifyUIntHexadecimalText (string hexadecimalText) {
			try {
				ParseUIntHexadecimalText(hexadecimalText);
			} catch {
				return false;
			}

			return true;
		}

		private void UpdateUIntDecimalTextBoxColors (TextBox decimalTextBox) {
			string decimalText = decimalTextBox.Text;

			if(!VerifyUIntDecimalText(decimalText)) {
				decimalTextBox.BackColor = Color.LightCoral;
				return;
			} else if(Loading.EntryKeyCollides(ParseUIntDecimalText(decimalTextBox.Text), STBLEntry)) {
				KeyHexadecimalTextBox.BackColor = Color.Gold;
			} else {
				decimalTextBox.BackColor = SystemColors.Window;
			}
		}

		private void UpdateUIntHexadecimalTextBoxColors (TextBox hexadecimalTextBox) {
			string hexadecimalText = hexadecimalTextBox.Text;

			if(!VerifyUIntHexadecimalText(hexadecimalText)) {
				hexadecimalTextBox.BackColor = Color.LightCoral;
				return;
			} else if(Loading.EntryKeyCollides(ParseUIntHexadecimalText(hexadecimalTextBox.Text), STBLEntry)) {
				KeyHexadecimalTextBox.BackColor = Color.Gold;
			} else {
				hexadecimalTextBox.BackColor = SystemColors.Window;
			}
		}

		private void FixUIntDecimalTextBox (TextBox decimalTextBox, string lastDecimalText) {
			string decimalText = decimalTextBox.Text;

			if(string.IsNullOrWhiteSpace(decimalText) || !VerifyUIntDecimalText(decimalText)) {
				decimalTextBox.Text = lastDecimalText;
				return;
			}
		}

		private void FixUIntHexadecimalTextBox (TextBox hexadecimalTextBox, string lastHexadecimalText) {
			string hexadecimalText = hexadecimalTextBox.Text;

			if(string.IsNullOrWhiteSpace(hexadecimalText) || !VerifyUIntHexadecimalText(hexadecimalText)) {
				hexadecimalTextBox.Text = lastHexadecimalText;
				return;
			}
		}

		private void FinalizeUIntDecimalTextBox (TextBox decimalTextBox, ref uint lastDecimalValue, TextBox hexadecimalTextBox) {
			FixUIntDecimalTextBox(decimalTextBox, lastDecimalValue.ToString("0"));

			uint textValue = uint.Parse(decimalTextBox.Text);

			hexadecimalTextBox.Text = textValue.ToString("x").ToUpper();
			lastDecimalValue = textValue;
		}

		private void FinalizeUIntHexadecimalTextBox (TextBox hexadecimalTextBox, ref uint lastHexadecimalValue, TextBox decimalTextBox) {
			FixUIntHexadecimalTextBox(hexadecimalTextBox, lastHexadecimalValue.ToString("x"));

			uint textValue = uint.Parse(hexadecimalTextBox.Text, NumberStyles.HexNumber | NumberStyles.AllowHexSpecifier);

			decimalTextBox.Text = textValue.ToString("0");
			lastHexadecimalValue = textValue;
		}

		private void KeyDecimalTextBox_TextChanged (object sender, EventArgs e) {
			UpdateUIntDecimalTextBoxColors(KeyDecimalTextBox);
		}

		private void KeyDecimalTextBox_Leave (object sender, EventArgs e) {
			FinalizeUIntDecimalTextBox(KeyDecimalTextBox, ref LastKeyValue, KeyHexadecimalTextBox);
		}

		private void KeyHexadecimalTextBox_TextChanged (object sender, EventArgs e) {
			UpdateUIntHexadecimalTextBoxColors(KeyHexadecimalTextBox);
		}

		private void KeyHexadecimalTextBox_Leave (object sender, EventArgs e) {
			FinalizeUIntHexadecimalTextBox(KeyHexadecimalTextBox, ref LastKeyValue, KeyDecimalTextBox);
		}

		private void KeyRandomizeButton_Click (object sender, EventArgs e) {
			uint randomizedKey = STBL.GetRandomUIntKey(blockedKeys: Loading.GetAllEntryKeys());

			KeyDecimalTextBox.Text = randomizedKey.ToString();
			KeyHexadecimalTextBox.Text = randomizedKey.ToString("x").ToUpper();
		}

		private void LanguageSelector_SelectedIndexChanged (object sender, EventArgs e) {
			if(!(LanguageSelector.SelectedItem is Forms.LanguageComboBoxItem languageSelected)) {
				return;
			}

			if(CurrentLanguageStates[(STBL.Languages)languageSelected.Language]) {
				LanguageTextBox.Text = CurrentLanguageStrings[(STBL.Languages)languageSelected.Language];
				ChangeLanguageTextBoxState(true);
			} else {
				LanguageTextBox.Text = "";
				ChangeLanguageTextBoxState(false);
			}

			DefaultLanguage = (STBL.Languages)languageSelected.Language;
		}

		private void ResetLanguageButton_Click (object sender, EventArgs e) {
			if(!(LanguageSelector.SelectedItem is Forms.LanguageComboBoxItem languageSelected)) {
				return;
			}

			LanguageTextBox.Text = null;
			CurrentLanguageStrings[(STBL.Languages)languageSelected.Language] = null;
			CurrentLanguageStates[(STBL.Languages)languageSelected.Language] = false;
			ChangeLanguageTextBoxState(false);
		}

		private void LanguageTextBox_TextChanged (object sender, EventArgs e) {
			if(!(LanguageSelector.SelectedItem is Forms.LanguageComboBoxItem languageSelected)) {
				return;
			}

			if(!CurrentLanguageStates[(STBL.Languages)languageSelected.Language]) {
				return;
			}

			CurrentLanguageStrings[(STBL.Languages)languageSelected.Language] = LanguageTextBox.Text;
		}

		private void EditDefaultLanguageButton_Click (object sender, EventArgs e) {
			if(!(LanguageSelector.SelectedItem is Forms.LanguageComboBoxItem languageSelected)) {
				return;
			}

			CurrentLanguageStrings[(STBL.Languages)languageSelected.Language] = "";
			CurrentLanguageStates[(STBL.Languages)languageSelected.Language] = true;
			ChangeLanguageTextBoxState(true);
		}

		private void FormOkButton_Click (object sender, EventArgs e) {
			if(STBLEntry == null) {
				Close();
				return;
			}

			uint nextKeyValue = uint.Parse(KeyDecimalTextBox.Text);

			if(Loading.EntryKeyCollides(nextKeyValue, STBLEntry)) {
				if(!ShowConfimCollidingEntryKey()) {
					return;
				}
			}

			if(nextKeyValue != STBLEntry.Key) {
				STBLEntry.Key = nextKeyValue;
			}

			string nextIdentifierValue = IdentifierTextBox.Text;

			if(nextIdentifierValue != STBLEntry.Identifier) {
				STBLEntry.Identifier = nextIdentifierValue;
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
