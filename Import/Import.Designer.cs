namespace STBLXMLEditor {
	partial class Import {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Import));
			this.FormCancelButton = new System.Windows.Forms.Button();
			this.FormOkButton = new System.Windows.Forms.Button();
			this.OpenSTBLXMLDialog = new System.Windows.Forms.OpenFileDialog();
			this.FilePathTextBox = new System.Windows.Forms.TextBox();
			this.FilePathSelectButton = new System.Windows.Forms.Button();
			this.TextPriorityExistingRadioButton = new System.Windows.Forms.RadioButton();
			this.TextPriorityGroupBox = new System.Windows.Forms.GroupBox();
			this.TextPriorityNewRadioButton = new System.Windows.Forms.RadioButton();
			this.LanguagesButton = new System.Windows.Forms.Button();
			this.FilePathLabel = new System.Windows.Forms.Label();
			this.CreateMissingEntriesCheckBox = new System.Windows.Forms.CheckBox();
			this.TextPriorityGroupBox.SuspendLayout();
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
			// OpenSTBLXMLDialog
			// 
			this.OpenSTBLXMLDialog.DefaultExt = "xml";
			resources.ApplyResources(this.OpenSTBLXMLDialog, "OpenSTBLXMLDialog");
			// 
			// FilePathTextBox
			// 
			resources.ApplyResources(this.FilePathTextBox, "FilePathTextBox");
			this.FilePathTextBox.Name = "FilePathTextBox";
			// 
			// FilePathSelectButton
			// 
			resources.ApplyResources(this.FilePathSelectButton, "FilePathSelectButton");
			this.FilePathSelectButton.Name = "FilePathSelectButton";
			this.FilePathSelectButton.UseVisualStyleBackColor = true;
			this.FilePathSelectButton.Click += new System.EventHandler(this.FilePathSelectButton_Click);
			// 
			// TextPriorityExistingRadioButton
			// 
			resources.ApplyResources(this.TextPriorityExistingRadioButton, "TextPriorityExistingRadioButton");
			this.TextPriorityExistingRadioButton.Checked = true;
			this.TextPriorityExistingRadioButton.Name = "TextPriorityExistingRadioButton";
			this.TextPriorityExistingRadioButton.TabStop = true;
			this.TextPriorityExistingRadioButton.UseVisualStyleBackColor = true;
			// 
			// TextPriorityGroupBox
			// 
			resources.ApplyResources(this.TextPriorityGroupBox, "TextPriorityGroupBox");
			this.TextPriorityGroupBox.Controls.Add(this.TextPriorityNewRadioButton);
			this.TextPriorityGroupBox.Controls.Add(this.TextPriorityExistingRadioButton);
			this.TextPriorityGroupBox.Name = "TextPriorityGroupBox";
			this.TextPriorityGroupBox.TabStop = false;
			// 
			// TextPriorityNewRadioButton
			// 
			resources.ApplyResources(this.TextPriorityNewRadioButton, "TextPriorityNewRadioButton");
			this.TextPriorityNewRadioButton.Name = "TextPriorityNewRadioButton";
			this.TextPriorityNewRadioButton.UseVisualStyleBackColor = true;
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
			// CreateMissingEntriesCheckBox
			// 
			resources.ApplyResources(this.CreateMissingEntriesCheckBox, "CreateMissingEntriesCheckBox");
			this.CreateMissingEntriesCheckBox.Checked = true;
			this.CreateMissingEntriesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.CreateMissingEntriesCheckBox.Name = "CreateMissingEntriesCheckBox";
			this.CreateMissingEntriesCheckBox.UseVisualStyleBackColor = true;
			// 
			// Import
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.FormCancelButton;
			this.Controls.Add(this.CreateMissingEntriesCheckBox);
			this.Controls.Add(this.FilePathLabel);
			this.Controls.Add(this.LanguagesButton);
			this.Controls.Add(this.TextPriorityGroupBox);
			this.Controls.Add(this.FilePathSelectButton);
			this.Controls.Add(this.FilePathTextBox);
			this.Controls.Add(this.FormCancelButton);
			this.Controls.Add(this.FormOkButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Import";
			this.ShowIcon = false;
			this.TextPriorityGroupBox.ResumeLayout(false);
			this.TextPriorityGroupBox.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.Button FormCancelButton;
		public System.Windows.Forms.Button FormOkButton;
		private System.Windows.Forms.OpenFileDialog OpenSTBLXMLDialog;
		private System.Windows.Forms.TextBox FilePathTextBox;
		private System.Windows.Forms.Button FilePathSelectButton;
		private System.Windows.Forms.RadioButton TextPriorityExistingRadioButton;
		private System.Windows.Forms.GroupBox TextPriorityGroupBox;
		private System.Windows.Forms.RadioButton TextPriorityNewRadioButton;
		private System.Windows.Forms.Button LanguagesButton;
		private System.Windows.Forms.Label FilePathLabel;
		private System.Windows.Forms.CheckBox CreateMissingEntriesCheckBox;
	}
}