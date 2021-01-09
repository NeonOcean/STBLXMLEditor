using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace STBLXMLEditor {
	public partial class MetaData : Form {
		public STBLXMLFile STBLFile = new STBLXMLFile();

		private uint LastSTBLGroupValue = 0;
		private ulong LastSTBLInstanceValue = 0;

		private uint LastIdentifiersGroupValue = 0;
		private ulong LastIdentifiersInstanceValue = 0;

		public MetaData (STBLXMLFile stblFile = null) {
			if(stblFile != null) {
				STBLFile = stblFile;
			}

			InitializeComponent();

			Forms.SetupLanguageComboBox(FallbackLanguageSelector, STBL.GetLanguage(STBLFile.FallbackLanguage));

			LastSTBLGroupValue = STBLFile.STBLGroup;
			STBLGroupDecimalTextBox.Text = STBLFile.STBLGroup.ToString("0");
			STBLGroupHexadecimalTextBox.Text = STBLFile.STBLGroup.ToString("x").ToUpper();

			LastSTBLInstanceValue = STBLFile.STBLInstance;
			STBLInstanceDecimalTextBox.Text = STBLFile.STBLInstance.ToString("0");
			STBLInstanceHexadecimalTextBox.Text = STBLFile.STBLInstance.ToString("x").ToUpper();

			STBLNameTextBox.Text = STBLFile.STBLName;

			if(STBLFile.STBLName == "") {
				UpdateSTBLNameTextBoxColors(STBLNameTextBox);
			}

			BuildIdentifiersCheckBox.Checked = STBLFile.BuildIdentifiers;

			LastIdentifiersGroupValue = STBLFile.IdentifiersGroup;
			IdentifiersGroupDecimalTextBox.Text = STBLFile.IdentifiersGroup.ToString("0");
			IdentifiersGroupHexadecimalTextBox.Text = STBLFile.IdentifiersGroup.ToString("x").ToUpper();

			LastIdentifiersInstanceValue = STBLFile.IdentifiersInstance;
			IdentifiersInstanceDecimalTextBox.Text = STBLFile.IdentifiersInstance.ToString("0");
			IdentifiersInstanceHexadecimalTextBox.Text = STBLFile.IdentifiersInstance.ToString("x").ToUpper();

			IdentifiersNameTextBox.Text = STBLFile.IdentifiersName;
		}

		public static bool ShowConfimSTBLNameMissingFormatting () {
			MessageBoxButtons dialogButtons = MessageBoxButtons.YesNo;
			DialogResult dialogResult = MessageBox.Show(Localization.GetString("ConfimSTBLNameMissingFormatting"), Localization.GetString("WarningMessageTitle"), dialogButtons, MessageBoxIcon.Warning);
			return (dialogResult == DialogResult.Yes) ? true : false;
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
			} else {
				decimalTextBox.BackColor = SystemColors.Window;
			}
		}

		private void UpdateUIntHexadecimalTextBoxColors (TextBox hexadecimalTextBox) {
			string hexadecimalText = hexadecimalTextBox.Text;

			if(!VerifyUIntHexadecimalText(hexadecimalText)) {
				hexadecimalTextBox.BackColor = Color.LightCoral;
				return;
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
			FixUIntHexadecimalTextBox(hexadecimalTextBox, lastHexadecimalValue.ToString("x").ToUpper());

			uint textValue = uint.Parse(hexadecimalTextBox.Text, NumberStyles.HexNumber | NumberStyles.AllowHexSpecifier);

			decimalTextBox.Text = textValue.ToString("0");
			lastHexadecimalValue = textValue;
		}

		private ulong ParseULongDecimalText (string decimalText) {
			return ulong.Parse(decimalText);
		}

		private ulong ParseULongHexadecimalText (string hexadecimalText) {
			return ulong.Parse(hexadecimalText, NumberStyles.HexNumber | NumberStyles.AllowHexSpecifier);
		}

		private bool VerifyULongDecimalText (string decimalText) {
			try {
				ParseULongDecimalText(decimalText);
			} catch {
				return false;
			}

			return true;
		}

		private bool VerifyULongHexadecimalText (string hexadecimalText) {
			try {
				ParseULongHexadecimalText(hexadecimalText);
			} catch {
				return false;
			}

			return true;
		}

		public void UpdateULongDecimalTextBoxColors (TextBox decimalTextBox) {
			string decimalText = decimalTextBox.Text;

			if(!VerifyULongDecimalText(decimalText)) {
				decimalTextBox.BackColor = Color.LightCoral;
				return;
			} else {
				decimalTextBox.BackColor = SystemColors.Window;
			}
		}

		public void UpdateULongHexadecimalTextBoxColors (TextBox hexadecimalTextBox) {
			string hexadecimalText = hexadecimalTextBox.Text;

			if(!VerifyULongHexadecimalText(hexadecimalText)) {
				hexadecimalTextBox.BackColor = Color.LightCoral;
				return;
			} else {
				hexadecimalTextBox.BackColor = SystemColors.Window;
			}
		}

		private void FixULongDecimalTextBox (TextBox decimalTextBox, string lastDecimalText) {
			string decimalText = decimalTextBox.Text;

			if(string.IsNullOrWhiteSpace(decimalText) || !VerifyULongDecimalText(decimalText)) {
				decimalTextBox.Text = lastDecimalText;
				return;
			}
		}

		private void FixULongHexadecimalTextBox (TextBox hexadecimalTextBox, string lastHexadecimalText) {
			string hexadecimalText = hexadecimalTextBox.Text;

			if(string.IsNullOrWhiteSpace(hexadecimalText) || !VerifyULongHexadecimalText(hexadecimalText)) {
				hexadecimalTextBox.Text = lastHexadecimalText;
				return;
			}
		}

		private void FinalizeULongDecimalTextBox (TextBox decimalTextBox, ref ulong lastDecimalValue, TextBox hexadecimalTextBox) {
			FixULongDecimalTextBox(decimalTextBox, lastDecimalValue.ToString("0"));

			ulong textValue = ulong.Parse(decimalTextBox.Text);

			hexadecimalTextBox.Text = textValue.ToString("x").ToUpper();
			lastDecimalValue = textValue;
		}

		private void FinalizeULongHexadecimalTextBox (TextBox hexadecimalTextBox, ref ulong lastHexadecimalValue, TextBox decimalTextBox) {
			FixULongHexadecimalTextBox(hexadecimalTextBox, lastHexadecimalValue.ToString("x").ToUpper());

			ulong textValue = ulong.Parse(hexadecimalTextBox.Text, NumberStyles.HexNumber | NumberStyles.AllowHexSpecifier);

			decimalTextBox.Text = textValue.ToString("0");
			lastHexadecimalValue = textValue;
		}

		public bool CorrectSTBLName (string stblName) {
			string[] validFormattingPlaceholders = {
				"{0}",
				"{0:Spaced}",
				"{0:Normal}",
				"{0:Underscored}",
				"{0:Hyphenated}"
			};

			foreach(string validFormattingPlaceholder in validFormattingPlaceholders) {
				if(stblName.Contains(validFormattingPlaceholder)) {
					return true;
				}
			}

			return false;
		}

		private void UpdateSTBLNameTextBoxColors (TextBox stblNameTextBox) {
			if(!CorrectSTBLName(stblNameTextBox.Text)) {
				stblNameTextBox.BackColor = Color.Gold;
			} else {
				stblNameTextBox.BackColor = SystemColors.Window;
			}
		}

		private void STBLGroupDecimalTextBox_TextChanged (object sender, EventArgs e) {
			UpdateUIntDecimalTextBoxColors(STBLGroupDecimalTextBox);
		}

		private void STBLGroupDecimalTextBox_Leave (object sender, EventArgs e) {
			FinalizeUIntDecimalTextBox(STBLGroupDecimalTextBox, ref LastSTBLGroupValue, STBLGroupHexadecimalTextBox);
		}

		private void STBLGroupHexadecimalTextBox_TextChanged (object sender, EventArgs e) {
			UpdateUIntHexadecimalTextBoxColors(STBLGroupHexadecimalTextBox);
		}

		private void STBLGroupHexadecimalTextBox_Leave (object sender, EventArgs e) {
			FinalizeUIntHexadecimalTextBox(STBLGroupHexadecimalTextBox, ref LastSTBLGroupValue, STBLGroupDecimalTextBox);
		}

		private void STBLInstanceDecimalTextBox_TextChanged (object sender, EventArgs e) {
			UpdateULongDecimalTextBoxColors(STBLInstanceDecimalTextBox);
		}

		private void STBLInstanceDecimalTextBox_Leave (object sender, EventArgs e) {
			FinalizeULongDecimalTextBox(STBLInstanceDecimalTextBox, ref LastSTBLInstanceValue, STBLInstanceHexadecimalTextBox);
		}

		private void STBLInstanceHexadecimalTextBox_TextChanged (object sender, EventArgs e) {
			UpdateULongHexadecimalTextBoxColors(STBLInstanceHexadecimalTextBox);
		}

		private void STBLInstanceHexadecimalTextBox_Leave (object sender, EventArgs e) {
			FinalizeULongHexadecimalTextBox(STBLInstanceHexadecimalTextBox, ref LastSTBLInstanceValue, STBLInstanceDecimalTextBox);
		}

		private void STBLInstanceRandomizeButton_Click (object sender, EventArgs e) {
			ulong randomizedKey = STBL.GetRandomULongKey();

			STBLInstanceDecimalTextBox.Text = randomizedKey.ToString("0");
			STBLInstanceHexadecimalTextBox.Text = randomizedKey.ToString("x").ToUpper();
		}

		private void STBLNameTextBox_TextChanged (object sender, EventArgs e) {
			UpdateSTBLNameTextBoxColors(STBLNameTextBox);
		}

		private void IdentifiersGroupDecimalTextBox_TextChanged (object sender, EventArgs e) {
			UpdateUIntDecimalTextBoxColors(IdentifiersGroupDecimalTextBox);
		}

		private void IdentifiersGroupDecimalTextBox_Leave (object sender, EventArgs e) {
			FinalizeUIntDecimalTextBox(IdentifiersGroupDecimalTextBox, ref LastIdentifiersGroupValue, IdentifiersGroupHexadecimalTextBox);
		}

		private void IdentifiersGroupHexadecimalTextBox_TextChanged (object sender, EventArgs e) {
			UpdateUIntHexadecimalTextBoxColors(IdentifiersGroupHexadecimalTextBox);
		}

		private void IdentifiersGroupHexadecimalTextBox_Leave (object sender, EventArgs e) {
			FinalizeUIntHexadecimalTextBox(IdentifiersGroupHexadecimalTextBox, ref LastIdentifiersGroupValue, IdentifiersGroupDecimalTextBox);
		}

		private void IdentifiersInstanceDecimalTextBox_TextChanged (object sender, EventArgs e) {
			UpdateULongDecimalTextBoxColors(IdentifiersInstanceDecimalTextBox);
		}

		private void IdentifiersInstanceDecimalTextBox_Leave (object sender, EventArgs e) {
			FinalizeULongDecimalTextBox(IdentifiersInstanceDecimalTextBox, ref LastIdentifiersInstanceValue, IdentifiersInstanceHexadecimalTextBox);
		}

		private void IdentifiersInstanceHexadecimalTextBox_TextChanged (object sender, EventArgs e) {
			UpdateULongHexadecimalTextBoxColors(IdentifiersInstanceHexadecimalTextBox);
		}

		private void IdentifiersInstanceHexadecimalTextBox_Leave (object sender, EventArgs e) {
			FinalizeULongHexadecimalTextBox(IdentifiersInstanceHexadecimalTextBox, ref LastIdentifiersInstanceValue, IdentifiersInstanceDecimalTextBox);
		}

		private void IdentifiersInstanceRandomizeButton_Click (object sender, EventArgs e) {
			ulong randomizedKey = STBL.GetRandomULongKey();

			IdentifiersInstanceDecimalTextBox.Text = randomizedKey.ToString("0");
			IdentifiersInstanceHexadecimalTextBox.Text = randomizedKey.ToString("x").ToUpper();
		}

		private void FormOkButton_Click (object sender, EventArgs e) {
			if(!CorrectSTBLName(STBLNameTextBox.Text)) {
				if(!ShowConfimSTBLNameMissingFormatting()) {
					DialogResult = DialogResult.None;
					return;
				}
			}

			STBLFile.FallbackLanguage = (int)((Forms.LanguageComboBoxItem)FallbackLanguageSelector.SelectedItem).Language;

			STBLFile.STBLGroup = ParseUIntDecimalText(STBLGroupDecimalTextBox.Text);
			STBLFile.STBLInstance = ParseULongDecimalText(STBLInstanceDecimalTextBox.Text);
			STBLFile.STBLName = STBLNameTextBox.Text;

			STBLFile.BuildIdentifiers = BuildIdentifiersCheckBox.Checked;
			STBLFile.IdentifiersGroup = ParseUIntDecimalText(IdentifiersGroupDecimalTextBox.Text);
			STBLFile.IdentifiersInstance = ParseULongDecimalText(IdentifiersInstanceDecimalTextBox.Text);
			STBLFile.IdentifiersName = IdentifiersNameTextBox.Text;

			Close();
		}

		private void FormCancelButton_Click (object sender, EventArgs e) {
			Close();
		}
	}
}
