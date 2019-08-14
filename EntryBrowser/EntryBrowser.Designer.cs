namespace STBLXMLEditor {
	partial class EntryBrowser {
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent () {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntryBrowser));
			this.BrowserGridView = new System.Windows.Forms.DataGridView();
			this.BrowserKeyDecimalColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.BrowserKeyHexadecimalColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.BrowserIdentifierColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.BrowserModifiedColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.ItemContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.ItemContextMenuOpenEditorItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ItemContextMenuOpenTranslatorItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ItemContextMenuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.ItemContextMenuSendToNewFileItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ItemContextMenuSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.ItemContextMenuRandomizeKeyItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ItemContextMenuDeleteItem = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.BrowserGridView)).BeginInit();
			this.ItemContextMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// BrowserGridView
			// 
			this.BrowserGridView.AllowUserToAddRows = false;
			this.BrowserGridView.AllowUserToDeleteRows = false;
			this.BrowserGridView.AllowUserToOrderColumns = true;
			this.BrowserGridView.AllowUserToResizeRows = false;
			this.BrowserGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.BrowserGridView.BackgroundColor = System.Drawing.SystemColors.Window;
			this.BrowserGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
			this.BrowserGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
			resources.ApplyResources(this.BrowserGridView, "BrowserGridView");
			this.BrowserGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.BrowserGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BrowserKeyDecimalColumn,
            this.BrowserKeyHexadecimalColumn,
            this.BrowserIdentifierColumn,
            this.BrowserModifiedColumn});
			this.BrowserGridView.Name = "BrowserGridView";
			this.BrowserGridView.ReadOnly = true;
			this.BrowserGridView.RowHeadersVisible = false;
			this.BrowserGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.BrowserGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.BrowserGridView.ShowEditingIcon = false;
			this.BrowserGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.BrowserGridView_CellDoubleClick);
			this.BrowserGridView.RowContextMenuStripNeeded += new System.Windows.Forms.DataGridViewRowContextMenuStripNeededEventHandler(this.BrowserGridView_RowContextMenuStripNeeded);
			this.BrowserGridView.SelectionChanged += new System.EventHandler(this.BrowserGridView_SelectionChanged);
			// 
			// BrowserKeyDecimalColumn
			// 
			this.BrowserKeyDecimalColumn.DataPropertyName = "KeyDecimal";
			this.BrowserKeyDecimalColumn.FillWeight = 13F;
			resources.ApplyResources(this.BrowserKeyDecimalColumn, "BrowserKeyDecimalColumn");
			this.BrowserKeyDecimalColumn.Name = "BrowserKeyDecimalColumn";
			this.BrowserKeyDecimalColumn.ReadOnly = true;
			// 
			// BrowserKeyHexadecimalColumn
			// 
			this.BrowserKeyHexadecimalColumn.DataPropertyName = "KeyHexadecimal";
			this.BrowserKeyHexadecimalColumn.FillWeight = 13F;
			resources.ApplyResources(this.BrowserKeyHexadecimalColumn, "BrowserKeyHexadecimalColumn");
			this.BrowserKeyHexadecimalColumn.Name = "BrowserKeyHexadecimalColumn";
			this.BrowserKeyHexadecimalColumn.ReadOnly = true;
			// 
			// BrowserIdentifierColumn
			// 
			this.BrowserIdentifierColumn.DataPropertyName = "Identifier";
			this.BrowserIdentifierColumn.FillWeight = 66F;
			resources.ApplyResources(this.BrowserIdentifierColumn, "BrowserIdentifierColumn");
			this.BrowserIdentifierColumn.Name = "BrowserIdentifierColumn";
			this.BrowserIdentifierColumn.ReadOnly = true;
			// 
			// BrowserModifiedColumn
			// 
			this.BrowserModifiedColumn.DataPropertyName = "Modified";
			this.BrowserModifiedColumn.FillWeight = 8F;
			resources.ApplyResources(this.BrowserModifiedColumn, "BrowserModifiedColumn");
			this.BrowserModifiedColumn.Name = "BrowserModifiedColumn";
			this.BrowserModifiedColumn.ReadOnly = true;
			this.BrowserModifiedColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.BrowserModifiedColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			// 
			// ItemContextMenu
			// 
			this.ItemContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ItemContextMenuOpenEditorItem,
            this.ItemContextMenuOpenTranslatorItem,
            this.ItemContextMenuSeparator1,
            this.ItemContextMenuSendToNewFileItem,
            this.ItemContextMenuSeparator2,
            this.ItemContextMenuRandomizeKeyItem,
            this.ItemContextMenuDeleteItem});
			this.ItemContextMenu.Name = "ItemContextMenu";
			resources.ApplyResources(this.ItemContextMenu, "ItemContextMenu");
			// 
			// ItemContextMenuOpenEditorItem
			// 
			this.ItemContextMenuOpenEditorItem.Name = "ItemContextMenuOpenEditorItem";
			resources.ApplyResources(this.ItemContextMenuOpenEditorItem, "ItemContextMenuOpenEditorItem");
			this.ItemContextMenuOpenEditorItem.Click += new System.EventHandler(this.ItemContextMenuOpenEditorItem_Click);
			// 
			// ItemContextMenuOpenTranslatorItem
			// 
			this.ItemContextMenuOpenTranslatorItem.Name = "ItemContextMenuOpenTranslatorItem";
			resources.ApplyResources(this.ItemContextMenuOpenTranslatorItem, "ItemContextMenuOpenTranslatorItem");
			this.ItemContextMenuOpenTranslatorItem.Click += new System.EventHandler(this.ItemContextMenuOpenTranslatorItem_Click);
			// 
			// ItemContextMenuSeparator1
			// 
			this.ItemContextMenuSeparator1.Name = "ItemContextMenuSeparator1";
			resources.ApplyResources(this.ItemContextMenuSeparator1, "ItemContextMenuSeparator1");
			// 
			// ItemContextMenuSendToNewFileItem
			// 
			this.ItemContextMenuSendToNewFileItem.Name = "ItemContextMenuSendToNewFileItem";
			resources.ApplyResources(this.ItemContextMenuSendToNewFileItem, "ItemContextMenuSendToNewFileItem");
			this.ItemContextMenuSendToNewFileItem.Click += new System.EventHandler(this.ItemContextMenuSendToNewFileItem_Click);
			// 
			// ItemContextMenuSeparator2
			// 
			this.ItemContextMenuSeparator2.Name = "ItemContextMenuSeparator2";
			resources.ApplyResources(this.ItemContextMenuSeparator2, "ItemContextMenuSeparator2");
			// 
			// ItemContextMenuRandomizeKeyItem
			// 
			this.ItemContextMenuRandomizeKeyItem.Name = "ItemContextMenuRandomizeKeyItem";
			resources.ApplyResources(this.ItemContextMenuRandomizeKeyItem, "ItemContextMenuRandomizeKeyItem");
			this.ItemContextMenuRandomizeKeyItem.Click += new System.EventHandler(this.ItemContextMenuRandomizeKeyItem_Click);
			// 
			// ItemContextMenuDeleteItem
			// 
			this.ItemContextMenuDeleteItem.Name = "ItemContextMenuDeleteItem";
			resources.ApplyResources(this.ItemContextMenuDeleteItem, "ItemContextMenuDeleteItem");
			this.ItemContextMenuDeleteItem.Click += new System.EventHandler(this.ItemContextMenuDeleteItem_Click);
			// 
			// EntryBrowser
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.BrowserGridView);
			this.Name = "EntryBrowser";
			((System.ComponentModel.ISupportInitialize)(this.BrowserGridView)).EndInit();
			this.ItemContextMenu.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		public System.Windows.Forms.DataGridView BrowserGridView;
		public System.Windows.Forms.ContextMenuStrip ItemContextMenu;
		public System.Windows.Forms.ToolStripMenuItem ItemContextMenuOpenEditorItem;
		public System.Windows.Forms.ToolStripMenuItem ItemContextMenuOpenTranslatorItem;
		public System.Windows.Forms.ToolStripSeparator ItemContextMenuSeparator1;
		public System.Windows.Forms.ToolStripMenuItem ItemContextMenuSendToNewFileItem;
		public System.Windows.Forms.ToolStripSeparator ItemContextMenuSeparator2;
		public System.Windows.Forms.ToolStripMenuItem ItemContextMenuRandomizeKeyItem;
		public System.Windows.Forms.ToolStripMenuItem ItemContextMenuDeleteItem;
		private System.Windows.Forms.DataGridViewTextBoxColumn BrowserKeyDecimalColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn BrowserKeyHexadecimalColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn BrowserIdentifierColumn;
		private System.Windows.Forms.DataGridViewCheckBoxColumn BrowserModifiedColumn;
	}
}
