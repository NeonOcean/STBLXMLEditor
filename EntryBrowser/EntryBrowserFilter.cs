using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace STBLXMLEditor {
	public class EntryBrowserFilter {
		public string KeyFilter {
			get; set;
		} = null;

		public string IdentifierFilter {
			get; set;
		} = null;

		public bool IdentifierFilterMatchCase {
			get; set;
		} = false;

		public bool IdentifierFilterUseRegex {
			get; set;
		} = false;

		public string TextFilter {
			get; set;
		} = null;

		public bool TextFilterMatchCase {
			get; set;
		} = false;

		public bool TextFilterUseRegex {
			get; set;
		} = false;

		public int? UntranslatedFilter {
			get; set;
		} = null;

		public Predicate<STBLXMLEntry> GetFilterPredicate () {
			string keyFilterLower = KeyFilter?.ToLower();

			Regex identifierFilterRegex = null;

			if(IdentifierFilterUseRegex) {

				identifierFilterRegex = new Regex(IdentifierFilter, RegexOptions.Multiline | (IdentifierFilterMatchCase ? RegexOptions.None : RegexOptions.IgnoreCase));
			}

			Regex textFilterRegex = null;

			if(TextFilterUseRegex) {
				textFilterRegex = new Regex(TextFilter, RegexOptions.Multiline | (TextFilterMatchCase ? RegexOptions.None : RegexOptions.IgnoreCase));
			}

			return delegate (STBLXMLEntry entry) {
				if(KeyFilter != null) {
					string itemKeyDecimal = entry.Key.ToString();
					string itemKeyHexadecimal = "0x" + entry.Key.ToString("x");

					if(!itemKeyDecimal.Contains(keyFilterLower) && !itemKeyHexadecimal.Contains(keyFilterLower)) return true;
				}

				if(IdentifierFilter != null) {
					if(!IdentifierFilterUseRegex || identifierFilterRegex == null) {
						if(entry.Identifier.IndexOf(IdentifierFilter, IdentifierFilterMatchCase ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase) < 0) return true;
					} else {
						if(!identifierFilterRegex.IsMatch(entry.Identifier)) return true;
					}
				}

				if(TextFilter != null) {
					foreach(STBL.Languages languague in STBL.GetAllLanguages()) {
						string languageText = entry.GetText(languague);

						if(languageText == null) {
							continue;
						}

						if(!TextFilterUseRegex || textFilterRegex == null) {
							if(languageText.IndexOf(TextFilter, TextFilterMatchCase ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase) < 0) return true;
						} else {
							if(!textFilterRegex.IsMatch(languageText)) return true;
						}
					}
				}


				if(UntranslatedFilter != null) {
					try {
						STBL.Languages untranslatedFilterLanguague = STBL.GetLanguage((int)UntranslatedFilter);
						
						if(entry.GetText(untranslatedFilterLanguague) != null) {
							return true;
						}
					} catch { }
				}

				return false;
			};
		}
	}
}
