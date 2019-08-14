using System;
using System.Windows.Forms;

namespace STBLXMLEditor {
	public partial class Error : Form {
		public Error (string message, string errorInformation) {
			InitializeComponent();

			MessageText.Text = message;
			ErrorTextBox.Text = errorInformation;
		}

		private void FormOkButton_Click (object sender, EventArgs e) {
			Close();
		}
	}
}
