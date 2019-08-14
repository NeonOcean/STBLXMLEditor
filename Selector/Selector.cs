﻿using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace STBLXMLEditor {
	public partial class Selector : Form {
		public EntryBrowserFilter CurrentBrowserFilter = null;

		private string statusBarItemsTextIdentifier = "SelectorStatusBarItemsText";
		private string statusBarSelectedTextIdentifier = "SelectorStatusBarSelectedText";

		public Selector () {
			InitializeComponent();

			EntryBrowser.SetupRows();

			UpdateStatusBarItemsLabel();
			UpdateStatusBarSelectedLabel();

			Loading.FileChanged += Loading_Changed;
			Loading.BecameClean += Loading_Changed;
			Loading.BecameDirty += Loading_Changed;

			EntryBrowser.ItemCountUpdate += EntryBrowser_ItemCountUpdate;
			EntryBrowser.SelectedCountUpdate += EntryBrowser_SelectedCountUpdate;
		}

		public static bool ShowConfirmUnsavedExitDialog () {
			MessageBoxButtons dialogButtons = MessageBoxButtons.YesNo;
			DialogResult dialogResult = MessageBox.Show(Localization.GetString("ConfirmUnsavedExitText"), Localization.GetString("ConfirmUnsavedTitle"), dialogButtons, MessageBoxIcon.Warning);
			return (dialogResult == DialogResult.Yes) ? true : false;
		}

		public static bool ShowConfirmUnsavedNewFileDialog () {
			MessageBoxButtons dialogButtons = MessageBoxButtons.YesNo;
			DialogResult dialogResult = MessageBox.Show(Localization.GetString("ConfirmUnsavedNewFileText"), Localization.GetString("ConfirmUnsavedTitle"), dialogButtons, MessageBoxIcon.Warning);
			return (dialogResult == DialogResult.Yes) ? true : false;
		}

		public static bool ShowConfirmUnsavedOpenFileDialog () {
			MessageBoxButtons dialogButtons = MessageBoxButtons.YesNo;
			DialogResult dialogResult = MessageBox.Show(Localization.GetString("ConfirmUnsavedOpenFileText"), Localization.GetString("ConfirmUnsavedTitle"), dialogButtons, MessageBoxIcon.Warning);
			return (dialogResult == DialogResult.Yes) ? true : false;
		}

		public static void ShowOpenFailureDialog (Exception failureException) {
			Error errorDialog = new Error(Localization.GetString("OpenFailureMessage"), failureException.ToString());
			errorDialog.Show();
		}

		public static void ShowSaveFailureDialog (Exception failureException) {
			Error errorDialog = new Error(Localization.GetString("SaveFailureMessage"), failureException.ToString());
			errorDialog.Show();
		}

		public void UpdateFormTitle () {
			string FormTitle = "STBL XML Editor";

			if(Loading.FilePath != null) {
				FormTitle = Path.GetFileName(Loading.FilePath) + " - " + FormTitle;

				if(Loading.IsDirty) {
					FormTitle = "*" + FormTitle;
				}
			} else {
				if(Loading.IsDirty) {
					FormTitle = "* " + FormTitle;
				}
			}

			Text = FormTitle;
		}

		public void UpdateStatusBarItemsLabel () {
			FormStatusStripItemsCount.Text = string.Format(Localization.GetString(statusBarItemsTextIdentifier), EntryBrowser.GetItemCount());
		}

		public void UpdateStatusBarSelectedLabel () {
			FormStatusStripSelectedCount.Text = string.Format(Localization.GetString(statusBarSelectedTextIdentifier), EntryBrowser.GetSelectedItemCount());
		}

		private void Selector_FormClosing (object sender, FormClosingEventArgs e) {
			if(Loading.IsDirty) {
				e.Cancel = !ShowConfirmUnsavedExitDialog();
			}
		}

		private void MenuStripNewItem_Click (object sender, EventArgs e) {
			if(Loading.IsDirty) {
				if(!ShowConfirmUnsavedNewFileDialog()) {
					return;
				}
			}

			Loading.NewFile();
			EntryBrowser.SetupRows();
		}

		private void MenuStripOpenItem_Click (object sender, EventArgs e) {
			if(Loading.IsDirty) {
				if(!ShowConfirmUnsavedOpenFileDialog()) {
					return;
				}
			}

			if(Loading.FilePath != null) {
				OpenSTBLXMLDialog.InitialDirectory = Path.GetDirectoryName(Loading.FilePath);
			}

			if(OpenSTBLXMLDialog.ShowDialog() == DialogResult.Cancel) {
				return;
			}

			string openFilePath = OpenSTBLXMLDialog.FileName;

			OpenSTBLXMLDialog.InitialDirectory = "";
			OpenSTBLXMLDialog.FileName = "";

			try {
				Loading.OpenFile(openFilePath);
			} catch(Exception openException) {
				ShowOpenFailureDialog(openException);
			}

			EntryBrowser.SetupRows();
		}

		private void MenuStripSaveItem_Click (object sender, EventArgs e) {
			string saveFilePath = Loading.FilePath;

			if(saveFilePath == null) {
				if(SaveSTBLXMLDialog.ShowDialog() == DialogResult.Cancel) {
					return;
				}

				saveFilePath = SaveSTBLXMLDialog.FileName;

				SaveSTBLXMLDialog.InitialDirectory = "";
				SaveSTBLXMLDialog.FileName = "";
			}

			try {
				Loading.SaveFile(saveFilePath);
			} catch(Exception saveException) {
				ShowSaveFailureDialog(saveException);
			}
		}

		private void MenuStripSaveAsItem_Click (object sender, EventArgs e) {
			if(Loading.FilePath != null) {
				SaveSTBLXMLDialog.InitialDirectory = Path.GetDirectoryName(Loading.FilePath);
				SaveSTBLXMLDialog.FileName = Path.GetFileName(Loading.FilePath);
			}

			if(SaveSTBLXMLDialog.ShowDialog() == DialogResult.Cancel) {
				return;
			}

			string saveFilePath = SaveSTBLXMLDialog.FileName;

			SaveSTBLXMLDialog.InitialDirectory = "";
			SaveSTBLXMLDialog.FileName = "";

			try {
				Loading.SaveFile(saveFilePath);
			} catch(Exception saveException) {
				ShowSaveFailureDialog(saveException);
			}
		}

		private void MenuStripFileMergeItem_Click (object sender, EventArgs e) {
			MergeWith mergeForm = new MergeWith();
			mergeForm.ShowDialog();

			EntryBrowser.SetupRows();
		}

		private void MenuStripFileEditMetaDataItem_Click (object sender, EventArgs e) {
			MetaData metaDataForm = new MetaData(stblFile: Loading.Data);
			metaDataForm.ShowDialog();
		}

		private void MenuStripExitItem_Click (object sender, EventArgs e) {
			Close();
		}

		private void MenuStripEditSelectAllItem_Click (object sender, EventArgs e) {
			EntryBrowser.SelectAllItems();
		}

		private void MenuStripEditDeselectAllItem_Click (object sender, EventArgs e) {
			EntryBrowser.DeselectAllItems();
		}

		private void MenuStripEditSelectedRemoveAllItem_Click (object sender, EventArgs e) {
			EntryBrowser.RemoveSelectedItems();
		}

		private void MenuStripEditSelectedResetKeysItem_Click (object sender, EventArgs e) {
			foreach(DataGridViewRow selectedEntryRow in EntryBrowser.GetAllSelectedItems()) {
				STBLXMLEntry entry = EntryBrowser.FindEntry(selectedEntryRow);

				if(entry != null) {
					continue;
				}

				entry.Key = STBL.GetRandomUIntKey(blockedKeys: Loading.GetAllEntryKeys());
			}

			EntryBrowser.RefreshItems();
		}

		private void AddEntryButton_Click (object sender, EventArgs e) {
			SelectorNew selectorNewForm = new SelectorNew();
			selectorNewForm.ShowDialog();

			STBLXMLEntry createdEntry = selectorNewForm.CreatedEntry;

			if(createdEntry == null) {
				return;
			}

			EntryBrowser.SetupRows();
			EntryBrowser.ScrollToItem(createdEntry, selectItem: true);
		}

		private void FilterAdvancedButton_Click (object sender, EventArgs e) {
			SelectorFilterOptions filterOptionsForm = new SelectorFilterOptions();
			filterOptionsForm.ShowDialog();

			if(filterOptionsForm.GeneratedFilter != null) {
				CurrentBrowserFilter = filterOptionsForm.GeneratedFilter;

				if(FilterActiveCheckBox.Checked) {
					EntryBrowser.FilterItems(CurrentBrowserFilter.GetFilterPredicate());
				}
			}
		}

		private void FilterActiveCheckBox_CheckedChanged (object sender, EventArgs e) {
			if(FilterActiveCheckBox.Checked) {
				if(CurrentBrowserFilter != null) {
					EntryBrowser.FilterItems(CurrentBrowserFilter.GetFilterPredicate());
				}
			} else {
				EntryBrowser.UnfilterAll();
			}
		}

		private void Loading_Changed (object sender, EventArgs e) {
			UpdateFormTitle();
		}

		private void EntryBrowser_ItemCountUpdate (object sender, EventArgs e) {
			UpdateStatusBarItemsLabel();
		}

		private void EntryBrowser_SelectedCountUpdate (object sender, EventArgs e) {
			UpdateStatusBarSelectedLabel();
		}
	}
}