namespace STBLXMLEditor {
	partial class SendTo {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose (bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent () {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SendTo));
			this.FormCancelButton = new System.Windows.Forms.Button();
			this.FormOkButton = new System.Windows.Forms.Button();
			this.FilePathSelectButton = new System.Windows.Forms.Button();
			this.FilePathTextBox = new System.Windows.Forms.TextBox();
			this.LanguagesButton = new System.Windows.Forms.Button();
			this.FilePathLabel = new System.Windows.Forms.Label();
			this.SaveSTBLXMLDialog = new System.Windows.Forms.SaveFileDialog();
			this.SuspendLayout();
			// 
			// FormCancelButton
			// 
			resources.ApplyResources(this.FormCancelButton, "FormCancelButton");
			this.FormCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.FormCancelButton.Name = "FormCancelButton";
			this.FormCancelButton.UseVisualStyleBackColor = true;
			// 
			// FormOkButton
			// 
			resources.ApplyResources(this.FormOkButton, "FormOkButton");
			this.FormOkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.FormOkButton.Name = "FormOkButton";
			this.FormOkButton.UseVisualStyleBackColor = true;
			this.FormOkButton.Click += new System.EventHandler(this.FormOkButton_Click);
			// 
			// FilePathSelectButton
			// 
			resources.ApplyResources(this.FilePathSelectButton, "FilePathSelectButton");
			this.FilePathSelectButton.Name = "FilePathSelectButton";
			this.FilePathSelectButton.UseVisualStyleBackColor = true;
			this.FilePathSelectButton.Click += new System.EventHandler(this.FilePathSelectButton_Click);
			// 
			// FilePathTextBox
			// 
			resources.ApplyResources(this.FilePathTextBox, "FilePathTextBox");
			this.FilePathTextBox.Name = "FilePathTextBox";
			// 
			// LanguagesButton
			// 
			resources.ApplyResources(this.LanguagesButton, "LanguagesButton");
			this.LanguagesButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.LanguagesButton.Name = "LanguagesButton";
			this.LanguagesButton.UseVisualStyleBackColor = true;
			this.LanguagesButton.Click += new System.EventHandler(this.LanguagesButton_Click);
			// 
			// FilePathLabel
			// 
			resources.ApplyResources(this.FilePathLabel, "FilePathLabel");
			this.FilePathLabel.Name = "FilePathLabel";
			// 
			// SaveSTBLXMLDialog
			// 
			this.SaveSTBLXMLDialog.DefaultExt = "xml";
			resources.ApplyResources(this.SaveSTBLXMLDialog, "SaveSTBLXMLDialog");
			// 
			// SendTo
			// 
			this.AcceptButton = this.FormOkButton;
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.FormCancelButton;
			this.Controls.Add(this.FilePathLabel);
			this.Controls.Add(this.LanguagesButton);
			this.Controls.Add(this.FilePathSelectButton);
			this.Controls.Add(this.FilePathTextBox);
			this.Controls.Add(this.FormCancelButton);
			this.Controls.Add(this.FormOkButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SendTo";
			this.ShowIcon = false;
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.Button FormCancelButton;
		public System.Windows.Forms.Button FormOkButton;
		private System.Windows.Forms.Button FilePathSelectButton;
		private System.Windows.Forms.TextBox FilePathTextBox;
		private System.Windows.Forms.Button LanguagesButton;
		private System.Windows.Forms.Label FilePathLabel;
		public System.Windows.Forms.SaveFileDialog SaveSTBLXMLDialog;
	}
}