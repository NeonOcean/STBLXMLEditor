namespace STBLXMLEditor {
	partial class SelectorNew {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectorNew));
			this.KeyRandomizeButton = new System.Windows.Forms.Button();
			this.KeyHexadecimalLabel = new System.Windows.Forms.Label();
			this.KeyDecimalLabel = new System.Windows.Forms.Label();
			this.KeyHexadecimalTextBox = new System.Windows.Forms.TextBox();
			this.KeyDecimalTextBox = new System.Windows.Forms.TextBox();
			this.KeyLabel = new System.Windows.Forms.Label();
			this.IdentifierLabel = new System.Windows.Forms.Label();
			this.IdentifierTextBox = new System.Windows.Forms.TextBox();
			this.FormCancelButton = new System.Windows.Forms.Button();
			this.FormOkButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// KeyRandomizeButton
			// 
			resources.ApplyResources(this.KeyRandomizeButton, "KeyRandomizeButton");
			this.KeyRandomizeButton.Name = "KeyRandomizeButton";
			this.KeyRandomizeButton.UseVisualStyleBackColor = true;
			this.KeyRandomizeButton.Click += new System.EventHandler(this.KeyRandomizeButton_Click);
			// 
			// KeyHexadecimalLabel
			// 
			resources.ApplyResources(this.KeyHexadecimalLabel, "KeyHexadecimalLabel");
			this.KeyHexadecimalLabel.Name = "KeyHexadecimalLabel";
			// 
			// KeyDecimalLabel
			// 
			resources.ApplyResources(this.KeyDecimalLabel, "KeyDecimalLabel");
			this.KeyDecimalLabel.Name = "KeyDecimalLabel";
			// 
			// KeyHexadecimalTextBox
			// 
			this.KeyHexadecimalTextBox.BackColor = System.Drawing.SystemColors.Window;
			resources.ApplyResources(this.KeyHexadecimalTextBox, "KeyHexadecimalTextBox");
			this.KeyHexadecimalTextBox.Name = "KeyHexadecimalTextBox";
			this.KeyHexadecimalTextBox.TextChanged += new System.EventHandler(this.KeyHexadecimalTextBox_TextChanged);
			this.KeyHexadecimalTextBox.Leave += new System.EventHandler(this.KeyHexadecimalTextBox_Leave);
			// 
			// KeyDecimalTextBox
			// 
			resources.ApplyResources(this.KeyDecimalTextBox, "KeyDecimalTextBox");
			this.KeyDecimalTextBox.Name = "KeyDecimalTextBox";
			this.KeyDecimalTextBox.TextChanged += new System.EventHandler(this.KeyDecimalTextBox_TextChanged);
			this.KeyDecimalTextBox.Leave += new System.EventHandler(this.KeyDecimalTextBox_Leave);
			// 
			// KeyLabel
			// 
			resources.ApplyResources(this.KeyLabel, "KeyLabel");
			this.KeyLabel.Name = "KeyLabel";
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
			// FormCancelButton
			// 
			resources.ApplyResources(this.FormCancelButton, "FormCancelButton");
			this.FormCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.FormCancelButton.Name = "FormCancelButton";
			this.FormCancelButton.UseVisualStyleBackColor = true;
			this.FormCancelButton.Click += new System.EventHandler(this.FormCancelButton_Click);
			// 
			// FormOkButton
			// 
			resources.ApplyResources(this.FormOkButton, "FormOkButton");
			this.FormOkButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.FormOkButton.Name = "FormOkButton";
			this.FormOkButton.UseVisualStyleBackColor = true;
			this.FormOkButton.Click += new System.EventHandler(this.FormOkButton_Click);
			// 
			// SelectorNew
			// 
			this.AcceptButton = this.FormOkButton;
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.FormCancelButton;
			this.Controls.Add(this.FormCancelButton);
			this.Controls.Add(this.FormOkButton);
			this.Controls.Add(this.KeyRandomizeButton);
			this.Controls.Add(this.KeyHexadecimalLabel);
			this.Controls.Add(this.KeyDecimalLabel);
			this.Controls.Add(this.KeyHexadecimalTextBox);
			this.Controls.Add(this.KeyDecimalTextBox);
			this.Controls.Add(this.KeyLabel);
			this.Controls.Add(this.IdentifierLabel);
			this.Controls.Add(this.IdentifierTextBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SelectorNew";
			this.ShowIcon = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.Button KeyRandomizeButton;
		public System.Windows.Forms.Label KeyHexadecimalLabel;
		public System.Windows.Forms.Label KeyDecimalLabel;
		public System.Windows.Forms.TextBox KeyHexadecimalTextBox;
		public System.Windows.Forms.TextBox KeyDecimalTextBox;
		public System.Windows.Forms.Label KeyLabel;
		public System.Windows.Forms.Label IdentifierLabel;
		public System.Windows.Forms.TextBox IdentifierTextBox;
		public System.Windows.Forms.Button FormCancelButton;
		public System.Windows.Forms.Button FormOkButton;
	}
}