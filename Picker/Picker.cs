using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace STBLXMLEditor {
	public partial class Picker : Form {
		public class PickerItem {
			public string Text = "";
			public object Value = null;

			public PickerItem (string text, object value) {
				Text = text;
				Value = value;
			}

			public override string ToString () {
				return Text;
			}
		}

		public static void SetupLanguagePicker (Picker picker, List<STBL.Languages> checkedLanguages) {
			foreach(STBL.Languages language in STBL.GetAllLanguages()) {
				bool languageIsChecked = false;

				if(checkedLanguages.Contains(language)) {
					languageIsChecked = true;
				}

				picker.AddItem(new PickerItem(STBL.GetLanguageLocalizedName(language), language), isChecked: languageIsChecked);
			}
		}

		public List<PickerItem> PickedItems = new List<PickerItem>();
		public List<object> PickedItemValues = new List<object>();

		public Picker () {
			InitializeComponent();
		}

		public void AddItem (PickerItem item, bool isChecked = false) {
			FormCheckedListBox.Items.Add(item, isChecked: isChecked);
		}

		public void RemoveItem (PickerItem item) {
			FormCheckedListBox.Items.Remove(item);
		}

		private void FormOkButton_Click (object sender, EventArgs e) {
			PickedItems = new List<PickerItem>();
			PickedItemValues = new List<object>();

			foreach(PickerItem item in FormCheckedListBox.CheckedItems) {
				PickedItems.Add(item);
				PickedItemValues.Add(item.Value);
			}
		}
	}
}
