using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace STBLXMLEditor {
	public partial class SelectorNew : Form {
		public SelectorNew () {
			InitializeComponent();

			uint randomEntryKey = STBL.GetRandomUIntKey(blockedKeys: Loading.GetAllEntryKeys());
			KeyDecimalTextBox.Text = randomEntryKey.ToString();
			KeyHexadecimalTextBox.Text = randomEntryKey.ToString("x");
		}

		public string LastKeyDecimalString = "";
		public string LastKeyHexadecimalString = "";

		public STBLXMLEntry CreatedEntry = null;

		public bool VerifyKeyDecimalText (string decimalText) {
			return uint.TryParse(decimalText, out uint result);
		}

		public bool VerifyKeyHexadecimalText (string hexadecimalText) {
			return uint.TryParse(hexadecimalText, NumberStyles.HexNumber | NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture, out uint result);
		}

		public void FixKeyDecimalTextBox () {
			string keyDecimalText = KeyDecimalTextBox.Text;

			if(string.IsNullOrWhiteSpace(keyDecimalText) || !VerifyKeyDecimalText(keyDecimalText)) {
				KeyDecimalTextBox.Text = LastKeyDecimalString;
				return;
			}
		}

		public void FixKeyHexadecimalTextBox () {
			string keyHexadecimalText = KeyHexadecimalTextBox.Text;

			if(string.IsNullOrWhiteSpace(keyHexadecimalText) || !VerifyKeyHexadecimalText(keyHexadecimalText)) {
				KeyHexadecimalTextBox.Text = LastKeyHexadecimalString;
				return;
			}
		}

		private void KeyDecimalTextBox_TextChanged (object sender, EventArgs e) {
			string keyDecimalText = KeyDecimalTextBox.Text;

			if(!VerifyKeyDecimalText(keyDecimalText)) {
				KeyDecimalTextBox.BackColor = Color.LightCoral;
				return;
			}

			KeyDecimalTextBox.BackColor = Color.White;
		}

		private void KeyDecimalTextBox_Leave (object sender, EventArgs e) {
			FixKeyDecimalTextBox();

			KeyHexadecimalTextBox.Text = uint.Parse(KeyDecimalTextBox.Text).ToString("x");
			KeyDecimalTextBox.BackColor = Color.White;
			LastKeyDecimalString = KeyDecimalTextBox.Text;
		}

		private void KeyHexadecimalTextBox_TextChanged (object sender, EventArgs e) {
			string keyHexadecimalText = KeyHexadecimalTextBox.Text;

			if(!VerifyKeyHexadecimalText(keyHexadecimalText)) {
				KeyHexadecimalTextBox.BackColor = Color.LightCoral;
				return;
			}

			KeyHexadecimalTextBox.BackColor = Color.White;
		}

		private void KeyHexadecimalTextBox_Leave (object sender, EventArgs e) {
			FixKeyHexadecimalTextBox();

			KeyDecimalTextBox.Text = uint.Parse(KeyHexadecimalTextBox.Text, NumberStyles.HexNumber | NumberStyles.AllowHexSpecifier).ToString();
			KeyHexadecimalTextBox.BackColor = Color.White;
			LastKeyHexadecimalString = KeyHexadecimalTextBox.Text;
		}

		private void KeyRandomizeButton_Click (object sender, EventArgs e) {
			uint randomizedKey = STBL.GetRandomUIntKey(blockedKeys: Loading.GetAllEntryKeys());

			KeyDecimalTextBox.Text = randomizedKey.ToString();
			KeyHexadecimalTextBox.Text = randomizedKey.ToString("x");
		}

		private void FormOkButton_Click (object sender, EventArgs e) {
			uint entryKey = uint.Parse(KeyDecimalTextBox.Text);

			CreatedEntry = Loading.AddNewEntry(key: entryKey, identifier: IdentifierTextBox.Text);
		}

		private void FormCancelButton_Click (object sender, EventArgs e) {
			Close();
		}
	}
}
