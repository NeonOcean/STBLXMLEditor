using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace STBLXMLEditor {
	public partial class EntryBrowser : UserControl {
		public class EntryWrapper {
			public string KeyDecimal {
				get {
					return STBLEntry.Key.ToString("0");
				}
			}

			public string KeyHexadecimal {
				get {
					return "0x" + STBLEntry.Key.ToString("x8").ToUpper();
				}
			}

			public string Identifier {
				get {
					return STBLEntry.Identifier;
				}
			}

			public bool Modified {
				get {
					return STBLEntry.EntryIsDirty;
				}
			}

			[Browsable(false)]
			public STBLXMLEntry STBLEntry {
				get; set;
			}

			public EntryWrapper (STBLXMLEntry entry) {
				STBLEntry = entry;
			}
		}

		public class EntryBinding : BindingList<EntryWrapper> {
			private bool isSorted = false;
			private PropertyDescriptor sortProperty = null;
			private ListSortDirection sortDirection = ListSortDirection.Ascending;

			protected override bool SupportsSortingCore => true;
			protected override bool IsSortedCore => isSorted;
			protected override PropertyDescriptor SortPropertyCore => sortProperty;
			protected override ListSortDirection SortDirectionCore => sortDirection;

			protected override void ApplySortCore (PropertyDescriptor prop, ListSortDirection direction) {
				sortProperty = prop;
				sortDirection = direction;
				isSorted = true;
				
				List<EntryWrapper> SortedItems = new List<EntryWrapper>(Items);
				SortedItems.Sort(delegate (EntryWrapper firstItem, EntryWrapper secondItem) {
					int comparisonValue = 0;

					if(prop.Name == "KeyDecimal" || prop.Name == "KeyHexadecimal") {
						comparisonValue = firstItem.STBLEntry.Key.CompareTo(secondItem.STBLEntry.Key);
					} else if(prop.Name == "Identifier") {
						comparisonValue = firstItem.STBLEntry.Identifier.CompareTo(secondItem.STBLEntry.Identifier);
					} else if(prop.Name == "Modified") {
						comparisonValue = firstItem.STBLEntry.EntryIsDirty.CompareTo(secondItem.STBLEntry.EntryIsDirty);
					}

					return direction == ListSortDirection.Ascending ? comparisonValue : -comparisonValue;
				});

				Items.Clear();

				for(int sortedIndex = 0; sortedIndex < SortedItems.Count; sortedIndex++) {
					Items.Add(SortedItems[sortedIndex]);
				}

				ResetBindings();
			}

			protected override void RemoveSortCore () {
				sortProperty = null;
				sortDirection = ListSortDirection.Ascending;
				isSorted = false;
			}
		}

		public Predicate<STBLXMLEntry> CurrentFilter = null;

		public event EventHandler ItemCountUpdate;
		public event EventHandler SelectedCountUpdate;

		public EntryBrowser () {
			InitializeComponent();
		}

		public void SetupRows () {
			ResetRows();

			EntryBinding entriesBindingList = new EntryBinding();

			foreach(STBLXMLEntry entry in Loading.Data.Entries) {
				if(CurrentFilter == null || !CurrentFilter.Invoke(entry)) {
					entriesBindingList.Add(new EntryWrapper(entry));
				}
			}

			BrowserGridView.DataSource = new BindingSource {
				DataSource = entriesBindingList
			};

			InvokeItemCountUpdateEvent();
			InvokeSelectedCountUpdateEvent();
		}

		public void ResetRows () {
			for(int entryRowIndex = 0; entryRowIndex < BrowserGridView.Rows.Count; entryRowIndex++) {
				BrowserGridView.Rows.RemoveAt(entryRowIndex);
				entryRowIndex--;
			}

			InvokeItemCountUpdateEvent();
			InvokeSelectedCountUpdateEvent();
		}

		public void RemoveItem (DataGridViewRow entryRow) {
			STBLXMLEntry entry = FindEntry(entryRow);

			Loading.Data.Entries.Remove(entry);

			BrowserGridView.Rows.Remove(entryRow);

			InvokeItemCountUpdateEvent();
			InvokeSelectedCountUpdateEvent();
		}

		public void RemoveSelectedItems () {
			DataGridViewSelectedRowCollection selectedEntryRows = BrowserGridView.SelectedRows;

			for(int entryRowIndex = 0; entryRowIndex < selectedEntryRows.Count; entryRowIndex++) {
				STBLXMLEntry entry = FindEntry(selectedEntryRows[entryRowIndex]);

				Loading.Data.Entries.Remove(entry);

				BrowserGridView.Rows.Remove(selectedEntryRows[entryRowIndex]);
			}

			InvokeItemCountUpdateEvent();
			InvokeSelectedCountUpdateEvent();
		}

		public DataGridViewRow FindRow (STBLXMLEntry entry) {
			for(int entryRowIndex = 0; entryRowIndex < BrowserGridView.Rows.Count; entryRowIndex++) {
				if((BrowserGridView.Rows[entryRowIndex].DataBoundItem as EntryWrapper)?.STBLEntry == entry) {
					return BrowserGridView.Rows[entryRowIndex];
				}
			}

			return null;
		}

		public STBLXMLEntry FindEntry (DataGridViewRow entryRow) {
			return (entryRow.DataBoundItem as EntryWrapper)?.STBLEntry;
		}

		public void ScrollToItem (STBLXMLEntry entry, bool selectItem = false) {
			DataGridViewRow entryRow = FindRow(entry);

			if(entryRow != null) {
				ScrollToItem(entryRow, selectItem: selectItem);
			}
		}

		public void ScrollToItem (DataGridViewRow entryRow, bool selectItem = false) {
			if(!entryRow.Visible) {
				return;
			}

			int entryRowIndex = BrowserGridView.Rows.IndexOf(entryRow);

			if(entryRowIndex == -1) {
				return;
			}

			BrowserGridView.FirstDisplayedScrollingRowIndex = entryRowIndex;
			DeselectAllItems();
			entryRow.Selected = true;
		}

		public void RefreshItems () {
			BrowserGridView.Refresh();
		}

		public void FilterItems (Predicate<STBLXMLEntry> filterPredicate) {
			CurrentFilter = filterPredicate;
			RefreshFilter();
		}

		public void UnfilterAll () {
			CurrentFilter = null;
			RefreshFilter();
		}

		public void RefreshFilter () {
			SetupRows();
		}

		public void SelectAllItems () {
			BrowserGridView.SelectAll();
		}

		public void DeselectAllItems () {
			foreach(DataGridViewRow entryRow in BrowserGridView.SelectedRows) {
				entryRow.Selected = false;
			}

			InvokeSelectedCountUpdateEvent();
		}

		public List<DataGridViewRow> GetAllSelectedItems () {
			List<DataGridViewRow> selectedRows = new List<DataGridViewRow>();

			foreach(DataGridViewRow entryRow in BrowserGridView.SelectedRows) {
				selectedRows.Add(entryRow);
			}

			return selectedRows;
		}

		public List<STBLXMLEntry> GetAllSelectedItemEntries () {
			List<STBLXMLEntry> selectedEntries = new List<STBLXMLEntry>();

			foreach(DataGridViewRow entryRow in BrowserGridView.SelectedRows) {
				STBLXMLEntry entry = FindEntry(entryRow);

				if(entry != null) {
					selectedEntries.Add(entry);
				}
			}

			return selectedEntries;
		}

		public void SendSelectedEntriesToNewFile () {
			SendTo splitForm = new SendTo(splittingEntries: GetAllSelectedItemEntries());
			splitForm.ShowDialog();
		}

		public int GetItemCount () {
			return BrowserGridView.Rows.Count;
		}

		public int GetSelectedItemCount () {
			return BrowserGridView.SelectedRows.Count;
		}

		public void InvokeItemCountUpdateEvent () {
			if(ItemCountUpdate == null) {
				return;
			}

			ItemCountUpdate.Invoke(this, new EventArgs());
		}

		public void InvokeSelectedCountUpdateEvent () {
			if(SelectedCountUpdate == null) {
				return;
			}

			SelectedCountUpdate.Invoke(this, new EventArgs());
		}

		private void BrowserGridView_CellDoubleClick (object sender, DataGridViewCellEventArgs e) {
			if(e.RowIndex == -1) {
				return;
			}

			if(((Selector)Parent).DoubleClickModeOpenEditorButton.Checked) {
				Editor editorDialog = new Editor(stblEntry: FindEntry(BrowserGridView.Rows[e.RowIndex]));
				editorDialog.ShowDialog();
				RefreshItems();
			} else {
				Translator translatorDialog = new Translator(stblEntry: FindEntry(BrowserGridView.Rows[e.RowIndex]));
				translatorDialog.ShowDialog();
				RefreshItems();
			}
		}

		private void BrowserGridView_SelectionChanged (object sender, EventArgs e) {
			InvokeSelectedCountUpdateEvent();
		}

		private void BrowserGridView_RowContextMenuStripNeeded (object sender, DataGridViewRowContextMenuStripNeededEventArgs e) {
			if(e.RowIndex == -1) {
				return;
			}

			DataGridViewRow entryRow = BrowserGridView.Rows[e.RowIndex];

			if(!entryRow.Selected) {
				DeselectAllItems();
				entryRow.Selected = true;
			}

			e.ContextMenuStrip = ItemContextMenu;
		}

		private void ItemContextMenuOpenEditorItem_Click (object sender, EventArgs e) {
			ToolStrip sendingMenu = ((ToolStripMenuItem)sender).Owner;
			Point sendingMenuRelativeLocation = PointToClient(sendingMenu.Location);

			DataGridView.HitTestInfo sendingMenuHitInfo = BrowserGridView.HitTest(sendingMenuRelativeLocation.X, sendingMenuRelativeLocation.Y);

			if(sendingMenuHitInfo.RowIndex <= -1) {
				return;
			}

			Editor editorDialog = new Editor(stblEntry: FindEntry(BrowserGridView.Rows[sendingMenuHitInfo.RowIndex]));
			editorDialog.ShowDialog();

			RefreshItems();
		}

		private void ItemContextMenuOpenTranslatorItem_Click (object sender, EventArgs e) {
			ToolStrip sendingMenu = ((ToolStripMenuItem)sender).Owner;
			Point sendingMenuRelativeLocation = PointToClient(sendingMenu.Location);

			DataGridView.HitTestInfo sendingMenuHitInfo = BrowserGridView.HitTest(sendingMenuRelativeLocation.X, sendingMenuRelativeLocation.Y);

			if(sendingMenuHitInfo.RowIndex <= -1) {
				return;
			}

			Translator translatorDialog = new Translator(stblEntry: FindEntry(BrowserGridView.Rows[sendingMenuHitInfo.RowIndex]));
			translatorDialog.ShowDialog();

			RefreshItems();
		}

		private void ItemContextMenuSendToNewFileItem_Click (object sender, EventArgs e) {
			SendSelectedEntriesToNewFile();
		}

		private void ItemContextMenuRandomizeKeyItem_Click (object sender, EventArgs e) {
			foreach(DataGridViewRow selectedRow in GetAllSelectedItems()) {
				if(!(selectedRow.DataBoundItem is EntryWrapper selectedRowSource)) {
					continue;
				}

				selectedRowSource.STBLEntry.Key = STBL.GetRandomUIntKey(blockedKeys: Loading.GetAllEntryKeys());
			}

			RefreshItems();
		}

		private void ItemContextMenuDeleteItem_Click (object sender, EventArgs e) {
			RemoveSelectedItems();
		}
	}
}
