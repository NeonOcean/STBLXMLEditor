namespace STBLXMLEditor {
	partial class Editor {
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editor));
			this.LanguageSelector = new System.Windows.Forms.ComboBox();
			this.FormOkButton = new System.Windows.Forms.Button();
			this.FormCancelButton = new System.Windows.Forms.Button();
			this.IdentifierTextBox = new System.Windows.Forms.TextBox();
			this.IdentifierLabel = new System.Windows.Forms.Label();
			this.KeyLabel = new System.Windows.Forms.Label();
			this.KeyDecimalTextBox = new System.Windows.Forms.TextBox();
			this.KeyHexadecimalTextBox = new System.Windows.Forms.TextBox();
			this.KeyDecimalLabel = new System.Windows.Forms.Label();
			this.KeyHexadecimalLabel = new System.Windows.Forms.Label();
			this.KeyRandomizeButton = new System.Windows.Forms.Button();
			this.EditorToolTip = new System.Windows.Forms.ToolTip(this.components);
			this.EditDefaultLanguageButton = new System.Windows.Forms.Button();
			this.ResetLanguageButton = new System.Windows.Forms.Button();
			this.LanguageTextBox = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// LanguageSelector
			// 
			resources.ApplyResources(this.LanguageSelector, "LanguageSelector");
			this.LanguageSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.LanguageSelector.FormattingEnabled = true;
			this.LanguageSelector.Name = "LanguageSelector";
			this.LanguageSelector.SelectedIndexChanged += new System.EventHandler(this.LanguageSelector_SelectedIndexChanged);
			// 
			// FormOkButton
			// 
			resources.ApplyResources(this.FormOkButton, "FormOkButton");
			this.FormOkButton.Name = "FormOkButton";
			this.FormOkButton.UseVisualStyleBackColor = true;
			this.FormOkButton.Click += new System.EventHandler(this.FormOkButton_Click);
			// 
			// FormCancelButton
			// 
			resources.ApplyResources(this.FormCancelButton, "FormCancelButton");
			this.FormCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.FormCancelButton.Name = "FormCancelButton";
			this.FormCancelButton.UseVisualStyleBackColor = true;
			this.FormCancelButton.Click += new System.EventHandler(this.FormCancelButton_Click);
			// 
			// IdentifierTextBox
			// 
			resources.ApplyResources(this.IdentifierTextBox, "IdentifierTextBox");
			this.IdentifierTextBox.Name = "IdentifierTextBox";
			// 
			// IdentifierLabel
			// 
			resources.ApplyResources(this.IdentifierLabel, "IdentifierLabel");
			this.IdentifierLabel.Name = "IdentifierLabel";
			// 
			// KeyLabel
			// 
			resources.ApplyResources(this.KeyLabel, "KeyLabel");
			this.KeyLabel.Name = "KeyLabel";
			// 
			// KeyDecimalTextBox
			// 
			this.KeyDecimalTextBox.BackColor = System.Drawing.SystemColors.Window;
			resources.ApplyResources(this.KeyDecimalTextBox, "KeyDecimalTextBox");
			this.KeyDecimalTextBox.Name = "KeyDecimalTextBox";
			this.KeyDecimalTextBox.TextChanged += new System.EventHandler(this.KeyDecimalTextBox_TextChanged);
			this.KeyDecimalTextBox.Leave += new System.EventHandler(this.KeyDecimalTextBox_Leave);
			// 
			// KeyHexadecimalTextBox
			// 
			this.KeyHexadecimalTextBox.BackColor = System.Drawing.SystemColors.Window;
			resources.ApplyResources(this.KeyHexadecimalTextBox, "KeyHexadecimalTextBox");
			this.KeyHexadecimalTextBox.Name = "KeyHexadecimalTextBox";
			this.KeyHexadecimalTextBox.TextChanged += new System.EventHandler(this.KeyHexadecimalTextBox_TextChanged);
			this.KeyHexadecimalTextBox.Leave += new System.EventHandler(this.KeyHexadecimalTextBox_Leave);
			// 
			// KeyDecimalLabel
			// 
			resources.ApplyResources(this.KeyDecimalLabel, "KeyDecimalLabel");
			this.KeyDecimalLabel.Name = "KeyDecimalLabel";
			// 
			// KeyHexadecimalLabel
			// 
			resources.ApplyResources(this.KeyHexadecimalLabel, "KeyHexadecimalLabel");
			this.KeyHexadecimalLabel.Name = "KeyHexadecimalLabel";
			// 
			// KeyRandomizeButton
			// 
			resources.ApplyResources(this.KeyRandomizeButton, "KeyRandomizeButton");
			this.KeyRandomizeButton.Name = "KeyRandomizeButton";
			this.KeyRandomizeButton.UseVisualStyleBackColor = true;
			this.KeyRandomizeButton.Click += new System.EventHandler(this.KeyRandomizeButton_Click);
			// 
			// EditDefaultLanguageButton
			// 
			resources.ApplyResources(this.EditDefaultLanguageButton, "EditDefaultLanguageButton");
			this.EditDefaultLanguageButton.Name = "EditDefaultLanguageButton";
			this.EditDefaultLanguageButton.TabStop = false;
			this.EditorToolTip.SetToolTip(this.EditDefaultLanguageButton, resources.GetString("EditDefaultLanguageButton.ToolTip"));
			this.EditDefaultLanguageButton.UseVisualStyleBackColor = true;
			this.EditDefaultLanguageButton.Click += new System.EventHandler(this.EditDefaultLanguageButton_Click);
			// 
			// ResetLanguageButton
			// 
			resources.ApplyResources(this.ResetLanguageButton, "ResetLanguageButton");
			this.ResetLanguageButton.Name = "ResetLanguageButton";
			this.ResetLanguageButton.UseVisualStyleBackColor = true;
			this.ResetLanguageButton.Click += new System.EventHandler(this.ResetLanguageButton_Click);
			// 
			// LanguageTextBox
			// 
			this.LanguageTextBox.AcceptsTab = true;
			resources.ApplyResources(this.LanguageTextBox, "LanguageTextBox");
			this.LanguageTextBox.AutoWordSelection = true;
			this.LanguageTextBox.Name = "LanguageTextBox";
			this.LanguageTextBox.TextChanged += new System.EventHandler(this.LanguageTextBox_TextChanged);
			// 
			// Editor
			// 
			this.AcceptButton = this.FormOkButton;
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.EditDefaultLanguageButton);
			this.Controls.Add(this.LanguageTextBox);
			this.Controls.Add(this.ResetLanguageButton);
			this.Controls.Add(this.KeyRandomizeButton);
			this.Controls.Add(this.KeyHexadecimalLabel);
			this.Controls.Add(this.KeyDecimalLabel);
			this.Controls.Add(this.KeyHexadecimalTextBox);
			this.Controls.Add(this.KeyDecimalTextBox);
			this.Controls.Add(this.KeyLabel);
			this.Controls.Add(this.IdentifierLabel);
			this.Controls.Add(this.IdentifierTextBox);
			this.Controls.Add(this.FormCancelButton);
			this.Controls.Add(this.FormOkButton);
			this.Controls.Add(this.LanguageSelector);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Editor";
			this.ShowIcon = false;
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.ComboBox LanguageSelector;
		public System.Windows.Forms.Button FormOkButton;
		public System.Windows.Forms.Button FormCancelButton;
		public System.Windows.Forms.TextBox IdentifierTextBox;
		public System.Windows.Forms.Label IdentifierLabel;
		public System.Windows.Forms.Label KeyLabel;
		public System.Windows.Forms.TextBox KeyDecimalTextBox;
		public System.Windows.Forms.TextBox KeyHexadecimalTextBox;
		public System.Windows.Forms.Label KeyDecimalLabel;
		public System.Windows.Forms.Label KeyHexadecimalLabel;
		public System.Windows.Forms.Button KeyRandomizeButton;
		public System.Windows.Forms.ToolTip EditorToolTip;
		public System.Windows.Forms.Button ResetLanguageButton;
		public System.Windows.Forms.RichTextBox LanguageTextBox;
		public System.Windows.Forms.Button EditDefaultLanguageButton;
	}
}