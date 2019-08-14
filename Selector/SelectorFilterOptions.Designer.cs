namespace STBLXMLEditor {
	partial class SelectorFilterOptions {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectorFilterOptions));
			this.UntranslatedToSelector = new System.Windows.Forms.ComboBox();
			this.UntranslatedToLabel = new System.Windows.Forms.Label();
			this.FormOkButton = new System.Windows.Forms.Button();
			this.KeyLabel = new System.Windows.Forms.Label();
			this.KeyTextBox = new System.Windows.Forms.TextBox();
			this.IdentifierLabel = new System.Windows.Forms.Label();
			this.IdentifierTextBox = new System.Windows.Forms.TextBox();
			this.IdentifierMatchCaseCheckBox = new System.Windows.Forms.CheckBox();
			this.IdentifierUseRegexCheckBox = new System.Windows.Forms.CheckBox();
			this.TextUseRegexCheckBox = new System.Windows.Forms.CheckBox();
			this.TextMatchCaseCheckBox = new System.Windows.Forms.CheckBox();
			this.TextTextBox = new System.Windows.Forms.TextBox();
			this.TextLabel = new System.Windows.Forms.Label();
			this.FormCancelButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// UntranslatedToSelector
			// 
			this.UntranslatedToSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.UntranslatedToSelector.FormattingEnabled = true;
			resources.ApplyResources(this.UntranslatedToSelector, "UntranslatedToSelector");
			this.UntranslatedToSelector.Name = "UntranslatedToSelector";
			// 
			// UntranslatedToLabel
			// 
			resources.ApplyResources(this.UntranslatedToLabel, "UntranslatedToLabel");
			this.UntranslatedToLabel.Name = "UntranslatedToLabel";
			// 
			// FormOkButton
			// 
			resources.ApplyResources(this.FormOkButton, "FormOkButton");
			this.FormOkButton.Name = "FormOkButton";
			this.FormOkButton.UseVisualStyleBackColor = true;
			this.FormOkButton.Click += new System.EventHandler(this.FormOkButton_Click);
			// 
			// KeyLabel
			// 
			resources.ApplyResources(this.KeyLabel, "KeyLabel");
			this.KeyLabel.Name = "KeyLabel";
			// 
			// KeyTextBox
			// 
			this.KeyTextBox.BackColor = System.Drawing.SystemColors.Window;
			resources.ApplyResources(this.KeyTextBox, "KeyTextBox");
			this.KeyTextBox.Name = "KeyTextBox";
			// 
			// IdentifierLabel
			// 
			resources.ApplyResources(this.IdentifierLabel, "IdentifierLabel");
			this.IdentifierLabel.Name = "IdentifierLabel";
			// 
			// IdentifierTextBox
			// 
			resources.ApplyResources(this.IdentifierTextBox, "IdentifierTextBox");
			this.IdentifierTextBox.Name = "IdentifierTextBox";
			// 
			// IdentifierMatchCaseCheckBox
			// 
			resources.ApplyResources(this.IdentifierMatchCaseCheckBox, "IdentifierMatchCaseCheckBox");
			this.IdentifierMatchCaseCheckBox.Name = "IdentifierMatchCaseCheckBox";
			this.IdentifierMatchCaseCheckBox.UseVisualStyleBackColor = true;
			// 
			// IdentifierUseRegexCheckBox
			// 
			resources.ApplyResources(this.IdentifierUseRegexCheckBox, "IdentifierUseRegexCheckBox");
			this.IdentifierUseRegexCheckBox.Name = "IdentifierUseRegexCheckBox";
			this.IdentifierUseRegexCheckBox.UseVisualStyleBackColor = true;
			// 
			// TextUseRegexCheckBox
			// 
			resources.ApplyResources(this.TextUseRegexCheckBox, "TextUseRegexCheckBox");
			this.TextUseRegexCheckBox.Name = "TextUseRegexCheckBox";
			this.TextUseRegexCheckBox.UseVisualStyleBackColor = true;
			// 
			// TextMatchCaseCheckBox
			// 
			resources.ApplyResources(this.TextMatchCaseCheckBox, "TextMatchCaseCheckBox");
			this.TextMatchCaseCheckBox.Name = "TextMatchCaseCheckBox";
			this.TextMatchCaseCheckBox.UseVisualStyleBackColor = true;
			// 
			// TextTextBox
			// 
			resources.ApplyResources(this.TextTextBox, "TextTextBox");
			this.TextTextBox.Name = "TextTextBox";
			// 
			// TextLabel
			// 
			resources.ApplyResources(this.TextLabel, "TextLabel");
			this.TextLabel.Name = "TextLabel";
			// 
			// FormCancelButton
			// 
			resources.ApplyResources(this.FormCancelButton, "FormCancelButton");
			this.FormCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.FormCancelButton.Name = "FormCancelButton";
			this.FormCancelButton.UseVisualStyleBackColor = true;
			this.FormCancelButton.Click += new System.EventHandler(this.FormCancelButton_Click);
			// 
			// SelectorFilterOptions
			// 
			this.AcceptButton = this.FormOkButton;
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.FormCancelButton;
			this.Controls.Add(this.FormCancelButton);
			this.Controls.Add(this.TextUseRegexCheckBox);
			this.Controls.Add(this.TextMatchCaseCheckBox);
			this.Controls.Add(this.TextTextBox);
			this.Controls.Add(this.TextLabel);
			this.Controls.Add(this.IdentifierUseRegexCheckBox);
			this.Controls.Add(this.IdentifierMatchCaseCheckBox);
			this.Controls.Add(this.IdentifierTextBox);
			this.Controls.Add(this.IdentifierLabel);
			this.Controls.Add(this.KeyTextBox);
			this.Controls.Add(this.KeyLabel);
			this.Controls.Add(this.FormOkButton);
			this.Controls.Add(this.UntranslatedToLabel);
			this.Controls.Add(this.UntranslatedToSelector);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SelectorFilterOptions";
			this.ShowIcon = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.Label KeyLabel;
		public System.Windows.Forms.TextBox KeyTextBox;
		public System.Windows.Forms.TextBox IdentifierTextBox;
		public System.Windows.Forms.Label IdentifierLabel;
		public System.Windows.Forms.CheckBox IdentifierMatchCaseCheckBox;
		public System.Windows.Forms.CheckBox IdentifierUseRegexCheckBox;
		public System.Windows.Forms.CheckBox TextUseRegexCheckBox;
		public System.Windows.Forms.CheckBox TextMatchCaseCheckBox;
		public System.Windows.Forms.TextBox TextTextBox;
		public System.Windows.Forms.Label TextLabel;
		public System.Windows.Forms.ComboBox UntranslatedToSelector;
		public System.Windows.Forms.Label UntranslatedToLabel;
		public System.Windows.Forms.Button FormOkButton;
		public System.Windows.Forms.Button FormCancelButton;
	}
}