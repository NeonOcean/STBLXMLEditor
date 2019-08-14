namespace STBLXMLEditor {
	partial class Error {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Error));
			this.FormOkButton = new System.Windows.Forms.Button();
			this.ErrorTextBox = new System.Windows.Forms.RichTextBox();
			this.MessageTextPanel = new System.Windows.Forms.Panel();
			this.MessageText = new System.Windows.Forms.Label();
			this.MessageTextPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// FormOkButton
			// 
			resources.ApplyResources(this.FormOkButton, "FormOkButton");
			this.FormOkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.FormOkButton.Name = "FormOkButton";
			this.FormOkButton.UseVisualStyleBackColor = true;
			this.FormOkButton.Click += new System.EventHandler(this.FormOkButton_Click);
			// 
			// ErrorTextBox
			// 
			resources.ApplyResources(this.ErrorTextBox, "ErrorTextBox");
			this.ErrorTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.ErrorTextBox.DetectUrls = false;
			this.ErrorTextBox.Name = "ErrorTextBox";
			this.ErrorTextBox.ReadOnly = true;
			// 
			// MessageTextPanel
			// 
			resources.ApplyResources(this.MessageTextPanel, "MessageTextPanel");
			this.MessageTextPanel.Controls.Add(this.MessageText);
			this.MessageTextPanel.Name = "MessageTextPanel";
			// 
			// MessageText
			// 
			resources.ApplyResources(this.MessageText, "MessageText");
			this.MessageText.Name = "MessageText";
			// 
			// Error
			// 
			this.AcceptButton = this.FormOkButton;
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.FormOkButton;
			this.Controls.Add(this.MessageTextPanel);
			this.Controls.Add(this.ErrorTextBox);
			this.Controls.Add(this.FormOkButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Error";
			this.ShowIcon = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.MessageTextPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		public System.Windows.Forms.Button FormOkButton;
		public System.Windows.Forms.RichTextBox ErrorTextBox;
		public System.Windows.Forms.Panel MessageTextPanel;
		public System.Windows.Forms.Label MessageText;
	}
}