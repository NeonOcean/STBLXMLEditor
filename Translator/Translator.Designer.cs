namespace STBLXMLEditor {
	partial class Translator {
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
			this.EditingLanguageTextBox = new System.Windows.Forms.RichTextBox();
			this.ResetEditingLanguageButton = new System.Windows.Forms.Button();
			this.FormCancelButton = new System.Windows.Forms.Button();
			this.FormOkButton = new System.Windows.Forms.Button();
			this.EditingLanguageSelector = new System.Windows.Forms.ComboBox();
			this.ReferencingLanguageTextBox = new System.Windows.Forms.RichTextBox();
			this.ReferencingLanguageSelector = new System.Windows.Forms.ComboBox();
			this.IdentifierTextBox = new System.Windows.Forms.TextBox();
			this.EditDefaultEditingLanguageButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// EditingLanguageTextBox
			// 
			this.EditingLanguageTextBox.AcceptsTab = true;
			this.EditingLanguageTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.EditingLanguageTextBox.AutoWordSelection = true;
			this.EditingLanguageTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.EditingLanguageTextBox.Location = new System.Drawing.Point(12, 348);
			this.EditingLanguageTextBox.Name = "EditingLanguageTextBox";
			this.EditingLanguageTextBox.Size = new System.Drawing.Size(785, 275);
			this.EditingLanguageTextBox.TabIndex = 5;
			this.EditingLanguageTextBox.Text = "";
			this.EditingLanguageTextBox.TextChanged += new System.EventHandler(this.EditingLanguageTextBox_TextChanged);
			// 
			// ResetEditingLanguageButton
			// 
			this.ResetEditingLanguageButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.ResetEditingLanguageButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.ResetEditingLanguageButton.Location = new System.Drawing.Point(716, 319);
			this.ResetEditingLanguageButton.Name = "ResetEditingLanguageButton";
			this.ResetEditingLanguageButton.Size = new System.Drawing.Size(81, 23);
			this.ResetEditingLanguageButton.TabIndex = 4;
			this.ResetEditingLanguageButton.Text = "Reset";
			this.ResetEditingLanguageButton.UseVisualStyleBackColor = true;
			this.ResetEditingLanguageButton.Click += new System.EventHandler(this.ResetEditingLanguageButton_Click);
			// 
			// FormCancelButton
			// 
			this.FormCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.FormCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.FormCancelButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.FormCancelButton.Location = new System.Drawing.Point(697, 629);
			this.FormCancelButton.Name = "FormCancelButton";
			this.FormCancelButton.Size = new System.Drawing.Size(100, 30);
			this.FormCancelButton.TabIndex = 7;
			this.FormCancelButton.Text = "Cancel";
			this.FormCancelButton.UseVisualStyleBackColor = true;
			this.FormCancelButton.Click += new System.EventHandler(this.FormCancelButton_Click);
			// 
			// FormOkButton
			// 
			this.FormOkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.FormOkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.FormOkButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.FormOkButton.Location = new System.Drawing.Point(591, 629);
			this.FormOkButton.Name = "FormOkButton";
			this.FormOkButton.Size = new System.Drawing.Size(100, 30);
			this.FormOkButton.TabIndex = 6;
			this.FormOkButton.Text = "Ok";
			this.FormOkButton.UseVisualStyleBackColor = true;
			this.FormOkButton.Click += new System.EventHandler(this.FormOkButton_Click);
			// 
			// EditingLanguageSelector
			// 
			this.EditingLanguageSelector.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.EditingLanguageSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.EditingLanguageSelector.FormattingEnabled = true;
			this.EditingLanguageSelector.Location = new System.Drawing.Point(482, 321);
			this.EditingLanguageSelector.MaxDropDownItems = 25;
			this.EditingLanguageSelector.Name = "EditingLanguageSelector";
			this.EditingLanguageSelector.Size = new System.Drawing.Size(228, 21);
			this.EditingLanguageSelector.TabIndex = 3;
			this.EditingLanguageSelector.SelectedIndexChanged += new System.EventHandler(this.EditingLanguageSelector_SelectedIndexChanged);
			// 
			// ReferencingLanguageTextBox
			// 
			this.ReferencingLanguageTextBox.AcceptsTab = true;
			this.ReferencingLanguageTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ReferencingLanguageTextBox.AutoWordSelection = true;
			this.ReferencingLanguageTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.ReferencingLanguageTextBox.Location = new System.Drawing.Point(12, 40);
			this.ReferencingLanguageTextBox.Name = "ReferencingLanguageTextBox";
			this.ReferencingLanguageTextBox.ReadOnly = true;
			this.ReferencingLanguageTextBox.Size = new System.Drawing.Size(785, 275);
			this.ReferencingLanguageTextBox.TabIndex = 2;
			this.ReferencingLanguageTextBox.Text = "";
			// 
			// ReferencingLanguageSelector
			// 
			this.ReferencingLanguageSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ReferencingLanguageSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ReferencingLanguageSelector.FormattingEnabled = true;
			this.ReferencingLanguageSelector.Location = new System.Drawing.Point(569, 13);
			this.ReferencingLanguageSelector.MaxDropDownItems = 25;
			this.ReferencingLanguageSelector.Name = "ReferencingLanguageSelector";
			this.ReferencingLanguageSelector.Size = new System.Drawing.Size(228, 21);
			this.ReferencingLanguageSelector.TabIndex = 1;
			this.ReferencingLanguageSelector.SelectedIndexChanged += new System.EventHandler(this.ReferencingLanguageSelector_SelectedIndexChanged);
			// 
			// IdentifierTextBox
			// 
			this.IdentifierTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.IdentifierTextBox.Location = new System.Drawing.Point(12, 14);
			this.IdentifierTextBox.Name = "IdentifierTextBox";
			this.IdentifierTextBox.ReadOnly = true;
			this.IdentifierTextBox.Size = new System.Drawing.Size(551, 20);
			this.IdentifierTextBox.TabIndex = 0;
			// 
			// EditDefaultEditingLanguageButton
			// 
			this.EditDefaultEditingLanguageButton.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.EditDefaultEditingLanguageButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.EditDefaultEditingLanguageButton.Location = new System.Drawing.Point(354, 470);
			this.EditDefaultEditingLanguageButton.Name = "EditDefaultEditingLanguageButton";
			this.EditDefaultEditingLanguageButton.Size = new System.Drawing.Size(100, 30);
			this.EditDefaultEditingLanguageButton.TabIndex = 0;
			this.EditDefaultEditingLanguageButton.TabStop = false;
			this.EditDefaultEditingLanguageButton.Text = "Edit Language";
			this.EditDefaultEditingLanguageButton.UseVisualStyleBackColor = true;
			this.EditDefaultEditingLanguageButton.Click += new System.EventHandler(this.EditDefaultEditingLanguageButton_Click);
			// 
			// Translator
			// 
			this.AcceptButton = this.FormOkButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.FormCancelButton;
			this.ClientSize = new System.Drawing.Size(809, 671);
			this.Controls.Add(this.EditDefaultEditingLanguageButton);
			this.Controls.Add(this.IdentifierTextBox);
			this.Controls.Add(this.ReferencingLanguageSelector);
			this.Controls.Add(this.ReferencingLanguageTextBox);
			this.Controls.Add(this.EditingLanguageTextBox);
			this.Controls.Add(this.ResetEditingLanguageButton);
			this.Controls.Add(this.FormCancelButton);
			this.Controls.Add(this.FormOkButton);
			this.Controls.Add(this.EditingLanguageSelector);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(825, 710);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(825, 710);
			this.Name = "Translator";
			this.ShowIcon = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Translator";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		public System.Windows.Forms.RichTextBox EditingLanguageTextBox;
		public System.Windows.Forms.Button ResetEditingLanguageButton;
		public System.Windows.Forms.Button FormCancelButton;
		public System.Windows.Forms.Button FormOkButton;
		public System.Windows.Forms.ComboBox EditingLanguageSelector;
		public System.Windows.Forms.RichTextBox ReferencingLanguageTextBox;
		public System.Windows.Forms.ComboBox ReferencingLanguageSelector;
		private System.Windows.Forms.TextBox IdentifierTextBox;
		public System.Windows.Forms.Button EditDefaultEditingLanguageButton;
	}
}