namespace STBLXMLEditor {
	partial class Selector {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Selector));
			this.MenuStrip = new System.Windows.Forms.MenuStrip();
			this.MenuStripFileItem = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuStripFileNewItem = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuStripFileOpenItem = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuStripFileSaveItem = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuStripFileSaveAsItem = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuStripFileSpearator1 = new System.Windows.Forms.ToolStripSeparator();
			this.MenuStripFileEditMetaDataItem = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuStripFileSpearator2 = new System.Windows.Forms.ToolStripSeparator();
			this.MenuStripFileMergeItem = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuStripFileImportFromPackageFileItem = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuStripFileExportToPackageFilesItem = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuStripFileSpearator3 = new System.Windows.Forms.ToolStripSeparator();
			this.MenuStripFileExitItem = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuStripEditItem = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuStripEditSelectAllItem = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuStripEditDeselectAllItem = new System.Windows.Forms.ToolStripMenuItem();
			this.OpenSTBLXMLDialog = new System.Windows.Forms.OpenFileDialog();
			this.SaveSTBLXMLDialog = new System.Windows.Forms.SaveFileDialog();
			this.AddEntryButton = new System.Windows.Forms.Button();
			this.FilterOptionsButton = new System.Windows.Forms.Button();
			this.FilterActiveCheckBox = new System.Windows.Forms.CheckBox();
			this.FormStatusStrip = new System.Windows.Forms.StatusStrip();
			this.FormStatusStripItemsCount = new System.Windows.Forms.ToolStripStatusLabel();
			this.FormStatusStripSelectedCount = new System.Windows.Forms.ToolStripStatusLabel();
			this.ImportFromPackageFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.ExportToPackgeFilesDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.DoubleClickModeBox = new System.Windows.Forms.Panel();
			this.DoubleClickModeLabel = new System.Windows.Forms.Label();
			this.DoubleClickModeOpenEditorButton = new System.Windows.Forms.RadioButton();
			this.DoubleClickModeOpenTranslatorButton = new System.Windows.Forms.RadioButton();
			this.EntryBrowser = new STBLXMLEditor.EntryBrowser();
			this.MenuStrip.SuspendLayout();
			this.FormStatusStrip.SuspendLayout();
			this.DoubleClickModeBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// MenuStrip
			// 
			this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuStripFileItem,
            this.MenuStripEditItem});
			resources.ApplyResources(this.MenuStrip, "MenuStrip");
			this.MenuStrip.Name = "MenuStrip";
			this.MenuStrip.TabStop = true;
			// 
			// MenuStripFileItem
			// 
			this.MenuStripFileItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuStripFileNewItem,
            this.MenuStripFileOpenItem,
            this.MenuStripFileSaveItem,
            this.MenuStripFileSaveAsItem,
            this.MenuStripFileSpearator1,
            this.MenuStripFileEditMetaDataItem,
            this.MenuStripFileSpearator2,
            this.MenuStripFileMergeItem,
            this.MenuStripFileImportFromPackageFileItem,
            this.MenuStripFileExportToPackageFilesItem,
            this.MenuStripFileSpearator3,
            this.MenuStripFileExitItem});
			this.MenuStripFileItem.Name = "MenuStripFileItem";
			resources.ApplyResources(this.MenuStripFileItem, "MenuStripFileItem");
			// 
			// MenuStripFileNewItem
			// 
			this.MenuStripFileNewItem.Name = "MenuStripFileNewItem";
			resources.ApplyResources(this.MenuStripFileNewItem, "MenuStripFileNewItem");
			this.MenuStripFileNewItem.Click += new System.EventHandler(this.MenuStripFileNewItem_Click);
			// 
			// MenuStripFileOpenItem
			// 
			this.MenuStripFileOpenItem.Name = "MenuStripFileOpenItem";
			resources.ApplyResources(this.MenuStripFileOpenItem, "MenuStripFileOpenItem");
			this.MenuStripFileOpenItem.Click += new System.EventHandler(this.MenuStripFileOpenItem_Click);
			// 
			// MenuStripFileSaveItem
			// 
			this.MenuStripFileSaveItem.Name = "MenuStripFileSaveItem";
			resources.ApplyResources(this.MenuStripFileSaveItem, "MenuStripFileSaveItem");
			this.MenuStripFileSaveItem.Click += new System.EventHandler(this.MenuStripFileSaveItem_Click);
			// 
			// MenuStripFileSaveAsItem
			// 
			this.MenuStripFileSaveAsItem.Name = "MenuStripFileSaveAsItem";
			resources.ApplyResources(this.MenuStripFileSaveAsItem, "MenuStripFileSaveAsItem");
			this.MenuStripFileSaveAsItem.Click += new System.EventHandler(this.MenuStripFileSaveAsItem_Click);
			// 
			// MenuStripFileSpearator1
			// 
			this.MenuStripFileSpearator1.Name = "MenuStripFileSpearator1";
			resources.ApplyResources(this.MenuStripFileSpearator1, "MenuStripFileSpearator1");
			// 
			// MenuStripFileEditMetaDataItem
			// 
			this.MenuStripFileEditMetaDataItem.Name = "MenuStripFileEditMetaDataItem";
			resources.ApplyResources(this.MenuStripFileEditMetaDataItem, "MenuStripFileEditMetaDataItem");
			this.MenuStripFileEditMetaDataItem.Click += new System.EventHandler(this.MenuStripFileEditMetaDataItem_Click);
			// 
			// MenuStripFileSpearator2
			// 
			this.MenuStripFileSpearator2.Name = "MenuStripFileSpearator2";
			resources.ApplyResources(this.MenuStripFileSpearator2, "MenuStripFileSpearator2");
			// 
			// MenuStripFileMergeItem
			// 
			this.MenuStripFileMergeItem.Name = "MenuStripFileMergeItem";
			resources.ApplyResources(this.MenuStripFileMergeItem, "MenuStripFileMergeItem");
			this.MenuStripFileMergeItem.Click += new System.EventHandler(this.MenuStripFileMergeItem_Click);
			// 
			// MenuStripFileImportFromPackageFileItem
			// 
			this.MenuStripFileImportFromPackageFileItem.Name = "MenuStripFileImportFromPackageFileItem";
			resources.ApplyResources(this.MenuStripFileImportFromPackageFileItem, "MenuStripFileImportFromPackageFileItem");
			this.MenuStripFileImportFromPackageFileItem.Click += new System.EventHandler(this.MenuStripFileImportFromPackageFileItem_Click);
			// 
			// MenuStripFileExportToPackageFilesItem
			// 
			this.MenuStripFileExportToPackageFilesItem.Name = "MenuStripFileExportToPackageFilesItem";
			resources.ApplyResources(this.MenuStripFileExportToPackageFilesItem, "MenuStripFileExportToPackageFilesItem");
			this.MenuStripFileExportToPackageFilesItem.Click += new System.EventHandler(this.MenuStripFileExportToPackageFilesItem_Click);
			// 
			// MenuStripFileSpearator3
			// 
			this.MenuStripFileSpearator3.Name = "MenuStripFileSpearator3";
			resources.ApplyResources(this.MenuStripFileSpearator3, "MenuStripFileSpearator3");
			// 
			// MenuStripFileExitItem
			// 
			this.MenuStripFileExitItem.Name = "MenuStripFileExitItem";
			resources.ApplyResources(this.MenuStripFileExitItem, "MenuStripFileExitItem");
			this.MenuStripFileExitItem.Click += new System.EventHandler(this.MenuStripExitItem_Click);
			// 
			// MenuStripEditItem
			// 
			this.MenuStripEditItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuStripEditSelectAllItem,
            this.MenuStripEditDeselectAllItem});
			this.MenuStripEditItem.Name = "MenuStripEditItem";
			resources.ApplyResources(this.MenuStripEditItem, "MenuStripEditItem");
			// 
			// MenuStripEditSelectAllItem
			// 
			this.MenuStripEditSelectAllItem.Name = "MenuStripEditSelectAllItem";
			resources.ApplyResources(this.MenuStripEditSelectAllItem, "MenuStripEditSelectAllItem");
			this.MenuStripEditSelectAllItem.Click += new System.EventHandler(this.MenuStripEditSelectAllItem_Click);
			// 
			// MenuStripEditDeselectAllItem
			// 
			this.MenuStripEditDeselectAllItem.Name = "MenuStripEditDeselectAllItem";
			resources.ApplyResources(this.MenuStripEditDeselectAllItem, "MenuStripEditDeselectAllItem");
			this.MenuStripEditDeselectAllItem.Click += new System.EventHandler(this.MenuStripEditDeselectAllItem_Click);
			// 
			// OpenSTBLXMLDialog
			// 
			this.OpenSTBLXMLDialog.DefaultExt = "xml";
			resources.ApplyResources(this.OpenSTBLXMLDialog, "OpenSTBLXMLDialog");
			// 
			// SaveSTBLXMLDialog
			// 
			this.SaveSTBLXMLDialog.DefaultExt = "xml";
			resources.ApplyResources(this.SaveSTBLXMLDialog, "SaveSTBLXMLDialog");
			// 
			// AddEntryButton
			// 
			resources.ApplyResources(this.AddEntryButton, "AddEntryButton");
			this.AddEntryButton.Name = "AddEntryButton";
			this.AddEntryButton.UseVisualStyleBackColor = true;
			this.AddEntryButton.Click += new System.EventHandler(this.AddEntryButton_Click);
			// 
			// FilterOptionsButton
			// 
			resources.ApplyResources(this.FilterOptionsButton, "FilterOptionsButton");
			this.FilterOptionsButton.Name = "FilterOptionsButton";
			this.FilterOptionsButton.UseVisualStyleBackColor = true;
			this.FilterOptionsButton.Click += new System.EventHandler(this.FilterAdvancedButton_Click);
			// 
			// FilterActiveCheckBox
			// 
			resources.ApplyResources(this.FilterActiveCheckBox, "FilterActiveCheckBox");
			this.FilterActiveCheckBox.Name = "FilterActiveCheckBox";
			this.FilterActiveCheckBox.UseVisualStyleBackColor = true;
			this.FilterActiveCheckBox.CheckedChanged += new System.EventHandler(this.FilterActiveCheckBox_CheckedChanged);
			// 
			// FormStatusStrip
			// 
			this.FormStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FormStatusStripItemsCount,
            this.FormStatusStripSelectedCount});
			resources.ApplyResources(this.FormStatusStrip, "FormStatusStrip");
			this.FormStatusStrip.Name = "FormStatusStrip";
			this.FormStatusStrip.SizingGrip = false;
			// 
			// FormStatusStripItemsCount
			// 
			this.FormStatusStripItemsCount.Name = "FormStatusStripItemsCount";
			resources.ApplyResources(this.FormStatusStripItemsCount, "FormStatusStripItemsCount");
			// 
			// FormStatusStripSelectedCount
			// 
			this.FormStatusStripSelectedCount.Name = "FormStatusStripSelectedCount";
			resources.ApplyResources(this.FormStatusStripSelectedCount, "FormStatusStripSelectedCount");
			// 
			// ImportFromPackageFileDialog
			// 
			resources.ApplyResources(this.ImportFromPackageFileDialog, "ImportFromPackageFileDialog");
			// 
			// ExportToPackgeFilesDialog
			// 
			resources.ApplyResources(this.ExportToPackgeFilesDialog, "ExportToPackgeFilesDialog");
			this.ExportToPackgeFilesDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
			// 
			// DoubleClickModeBox
			// 
			this.DoubleClickModeBox.Controls.Add(this.DoubleClickModeOpenTranslatorButton);
			this.DoubleClickModeBox.Controls.Add(this.DoubleClickModeOpenEditorButton);
			this.DoubleClickModeBox.Controls.Add(this.DoubleClickModeLabel);
			resources.ApplyResources(this.DoubleClickModeBox, "DoubleClickModeBox");
			this.DoubleClickModeBox.Name = "DoubleClickModeBox";
			// 
			// DoubleClickModeLabel
			// 
			resources.ApplyResources(this.DoubleClickModeLabel, "DoubleClickModeLabel");
			this.DoubleClickModeLabel.Name = "DoubleClickModeLabel";
			// 
			// DoubleClickModeOpenEditorButton
			// 
			resources.ApplyResources(this.DoubleClickModeOpenEditorButton, "DoubleClickModeOpenEditorButton");
			this.DoubleClickModeOpenEditorButton.Checked = true;
			this.DoubleClickModeOpenEditorButton.Name = "DoubleClickModeOpenEditorButton";
			this.DoubleClickModeOpenEditorButton.TabStop = true;
			this.DoubleClickModeOpenEditorButton.UseVisualStyleBackColor = true;
			// 
			// DoubleClickModeOpenTranslatorButton
			// 
			resources.ApplyResources(this.DoubleClickModeOpenTranslatorButton, "DoubleClickModeOpenTranslatorButton");
			this.DoubleClickModeOpenTranslatorButton.Name = "DoubleClickModeOpenTranslatorButton";
			this.DoubleClickModeOpenTranslatorButton.TabStop = true;
			this.DoubleClickModeOpenTranslatorButton.UseVisualStyleBackColor = true;
			// 
			// EntryBrowser
			// 
			resources.ApplyResources(this.EntryBrowser, "EntryBrowser");
			this.EntryBrowser.Name = "EntryBrowser";
			// 
			// Selector
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.DoubleClickModeBox);
			this.Controls.Add(this.EntryBrowser);
			this.Controls.Add(this.FormStatusStrip);
			this.Controls.Add(this.FilterActiveCheckBox);
			this.Controls.Add(this.FilterOptionsButton);
			this.Controls.Add(this.AddEntryButton);
			this.Controls.Add(this.MenuStrip);
			this.MainMenuStrip = this.MenuStrip;
			this.Name = "Selector";
			this.ShowIcon = false;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Selector_FormClosing);
			this.Load += new System.EventHandler(this.Selector_Load);
			this.MenuStrip.ResumeLayout(false);
			this.MenuStrip.PerformLayout();
			this.FormStatusStrip.ResumeLayout(false);
			this.FormStatusStrip.PerformLayout();
			this.DoubleClickModeBox.ResumeLayout(false);
			this.DoubleClickModeBox.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.MenuStrip MenuStrip;
		public System.Windows.Forms.ToolStripMenuItem MenuStripFileItem;
		public System.Windows.Forms.ToolStripMenuItem MenuStripFileNewItem;
		public System.Windows.Forms.ToolStripMenuItem MenuStripFileOpenItem;
		public System.Windows.Forms.ToolStripMenuItem MenuStripFileSaveItem;
		public System.Windows.Forms.ToolStripMenuItem MenuStripFileExitItem;
		public System.Windows.Forms.OpenFileDialog OpenSTBLXMLDialog;
		public System.Windows.Forms.SaveFileDialog SaveSTBLXMLDialog;
		public System.Windows.Forms.ToolStripMenuItem MenuStripEditItem;
		public System.Windows.Forms.ToolStripSeparator MenuStripFileSpearator1;
		public System.Windows.Forms.ToolStripMenuItem MenuStripEditSelectAllItem;
		public System.Windows.Forms.ToolStripMenuItem MenuStripEditDeselectAllItem;
		public System.Windows.Forms.ToolStripMenuItem MenuStripFileMergeItem;
		public System.Windows.Forms.ToolStripSeparator MenuStripFileSpearator2;
		public System.Windows.Forms.Button AddEntryButton;
		private System.Windows.Forms.Button FilterOptionsButton;
		private System.Windows.Forms.CheckBox FilterActiveCheckBox;
		private System.Windows.Forms.StatusStrip FormStatusStrip;
		private System.Windows.Forms.ToolStripStatusLabel FormStatusStripItemsCount;
		private System.Windows.Forms.ToolStripStatusLabel FormStatusStripSelectedCount;
		private System.Windows.Forms.ToolStripMenuItem MenuStripFileEditMetaDataItem;
		public System.Windows.Forms.ToolStripSeparator MenuStripFileSpearator3;
		private EntryBrowser EntryBrowser;
		private System.Windows.Forms.ToolStripMenuItem MenuStripFileExportToPackageFilesItem;
		private System.Windows.Forms.OpenFileDialog ImportFromPackageFileDialog;
		private System.Windows.Forms.FolderBrowserDialog ExportToPackgeFilesDialog;
		private System.Windows.Forms.ToolStripMenuItem MenuStripFileImportFromPackageFileItem;
		private System.Windows.Forms.ToolStripMenuItem MenuStripFileSaveAsItem;
		private System.Windows.Forms.Panel DoubleClickModeBox;
		private System.Windows.Forms.Label DoubleClickModeLabel;
		public System.Windows.Forms.RadioButton DoubleClickModeOpenTranslatorButton;
		public System.Windows.Forms.RadioButton DoubleClickModeOpenEditorButton;
	}
}

