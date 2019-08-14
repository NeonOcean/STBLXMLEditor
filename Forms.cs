using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STBLXMLEditor {
	public static class Forms {
		public class LanguageComboBoxItem {
			public STBL.Languages? Language = STBL.Languages.English;

			public LanguageComboBoxItem (STBL.Languages? language) {
				Language = language;
			}

			public override string ToString () {
				if(Language == null) {
					return "";
				} else {
					return STBL.GetLanguageLocalizedName((STBL.Languages)Language);
				}
			}
		}

		public static void SetupLanguageComboBox (ComboBox comboBox, STBL.Languages? defaultLanguage, bool includeNullLanguage = false) {
			LanguageComboBoxItem selectedLanguageItem = null;
			List<LanguageComboBoxItem> languageItems = new List<LanguageComboBoxItem>();

			if(includeNullLanguage) {
				LanguageComboBoxItem languageNullItem = new LanguageComboBoxItem(null);

				languageItems.Add(languageNullItem);

				if(defaultLanguage == null) {
					selectedLanguageItem = languageNullItem;
				}
			}

			foreach(STBL.Languages language in STBL.GetAllLanguages()) {
				LanguageComboBoxItem languageItem = new LanguageComboBoxItem(language);

				if(defaultLanguage == language) {
					selectedLanguageItem = languageItem;
				}

				languageItems.Add(languageItem);
			}

			comboBox.DataSource = languageItems;

			if(selectedLanguageItem != null) {
				comboBox.SelectedItem = selectedLanguageItem;
			}
		}
	}
}
