namespace STBLXMLEditor {
	partial class Picker {
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
			this.FormCheckedListBox = new System.Windows.Forms.CheckedListBox();
			this.FormCancelButton = new System.Windows.Forms.Button();
			this.FormOkButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// FormCheckedListBox
			// 
			this.FormCheckedListBox.CheckOnClick = true;
			this.FormCheckedListBox.FormattingEnabled = true;
			this.FormCheckedListBox.Location = new System.Drawing.Point(12, 12);
			this.FormCheckedListBox.Name = "FormCheckedListBox";
			this.FormCheckedListBox.Size = new System.Drawing.Size(255, 214);
			this.FormCheckedListBox.TabIndex = 0;
			// 
			// FormCancelButton
			// 
			this.FormCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.FormCancelButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.FormCancelButton.Location = new System.Drawing.Point(167, 239);
			this.FormCancelButton.Name = "FormCancelButton";
			this.FormCancelButton.Size = new System.Drawing.Size(100, 30);
			this.FormCancelButton.TabIndex = 8;
			this.FormCancelButton.Text = "Cancel";
			this.FormCancelButton.UseVisualStyleBackColor = true;
			// 
			// FormOkButton
			// 
			this.FormOkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.FormOkButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.FormOkButton.Location = new System.Drawing.Point(61, 239);
			this.FormOkButton.Name = "FormOkButton";
			this.FormOkButton.Size = new System.Drawing.Size(100, 30);
			this.FormOkButton.TabIndex = 7;
			this.FormOkButton.Text = "Ok";
			this.FormOkButton.UseVisualStyleBackColor = true;
			this.FormOkButton.Click += new System.EventHandler(this.FormOkButton_Click);
			// 
			// Picker
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(279, 281);
			this.Controls.Add(this.FormCancelButton);
			this.Controls.Add(this.FormOkButton);
			this.Controls.Add(this.FormCheckedListBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(295, 320);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(295, 320);
			this.Name = "Picker";
			this.ShowIcon = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Picker";
			this.ResumeLayout(false);

		}

		#endregion
		public System.Windows.Forms.Button FormCancelButton;
		public System.Windows.Forms.Button FormOkButton;
		private System.Windows.Forms.CheckedListBox FormCheckedListBox;
	}
}