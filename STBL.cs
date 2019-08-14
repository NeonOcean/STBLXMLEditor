using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Xml.Serialization;

namespace STBLXMLEditor {
	public static class STBL {
		public enum Languages {
			English = 0,
			ChineseSimplified = 1,
			ChineseTraditional = 2,
			Czech = 3,
			Danish = 4,
			Dutch = 5,
			Finnish = 6,
			French = 7,
			German = 8,
			Greek = 9,
			Hungarian = 10,
			Italian = 11,
			Japanese = 12,
			Korean = 13,
			Norwegian = 14,
			Polish = 15,
			PortuguesePortugal = 16,
			PortugueseBrazil = 17,
			Russian = 18,
			SpanishSpain = 19,
			SpanishMexico = 20,
			Swedish = 21,
			Thai = 22
		}

		public static Random stblKeyGenerator = new Random();

		public static Languages GetLanguage (string languageIdentifier) {
			Languages language = Languages.English;

			if(!Enum.TryParse(languageIdentifier, true, out language)) {
				throw new ArgumentException("'" + languageIdentifier + "' is not a valid language.");
			}

			return language;
		}

		public static Languages GetLanguage (int languageNumber) {
			Languages language = Languages.English;

			if(!Enum.TryParse(languageNumber.ToString(), out language)) {
				throw new ArgumentException("'" + languageNumber.ToString() + "' is not a valid language number.");
			}

			return language;
		}

		public static Languages[] GetAllLanguages () {
			return (Languages[])Enum.GetValues(typeof(Languages));
		}

		public static string[] GetAllLanguageIdentifiers () {
			return Enum.GetNames(typeof(Languages));
		}

		public static int[] GetAllLanguageNumbers () {
			return (int[])Enum.GetValues(typeof(Languages));
		}

		public static bool IsLanguage (string languageIdentifier) {
			Languages language = Languages.English;
			return Enum.TryParse(languageIdentifier, true, out language);
		}

		public static bool IsLanguage (int languageNumber) {
			Languages language = Languages.English;
			return Enum.TryParse(languageNumber.ToString(), out language);
		}

		public static string GetLanguageLocalizedName (Languages language) {
			return Localization.GetString(language.ToString() + "LanguageName");
		}

		public static int[] LanguagesToLanguageNumbers (Languages[] languages) {
			int[] languageNumbers = new int[languages.Length];

			for(int languageIndex = 0; languageIndex < languages.Length; languageIndex++) {
				languageNumbers[languageIndex] = (int)languages[languageIndex];
			}

			return languageNumbers;
		}

		public static List<int> LanguagesToLanguageNumbers (List<Languages> languages) {
			List<int> languageNumbers = new List<int>(languages.Count);

			for(int languageIndex = 0; languageIndex < languages.Count; languageIndex++) {
				languageNumbers.Add((int)languages[languageIndex]);
			}

			return languageNumbers;
		}

		public static uint GetRandomUIntKey (uint[] blockedKeys = null) {
			byte[] randomizedValueBytes = new byte[4];
			stblKeyGenerator.NextBytes(randomizedValueBytes);
			uint randomizedValue = BitConverter.ToUInt32(randomizedValueBytes, 0);

			if(blockedKeys != null) {
				if(Array.Exists(blockedKeys, x => x == randomizedValue)) {
					return GetRandomUIntKey(blockedKeys: blockedKeys);
				}
			}

			return randomizedValue;
		}

		public static ulong GetRandomULongKey (ulong[] blockedKeys = null) {
			byte[] randomizedValueBytes = new byte[8];
			stblKeyGenerator.NextBytes(randomizedValueBytes);
			ulong randomizedValue = BitConverter.ToUInt64(randomizedValueBytes, 0);

			if(blockedKeys != null) {
				if(Array.Exists(blockedKeys, x => x == randomizedValue)) {
					return GetRandomULongKey(blockedKeys: blockedKeys);
				}
			}

			return randomizedValue;
		}
	}

	public class STBLXMLFile {
		public int FallbackLanguage {
			get {
				return fallbackLanguage;
			}

			set {
				HandlePropertySet(ref fallbackLanguage, value, fallbackLanguage);
			}
		}

		public uint STBLGroup {
			get {
				return stblGroup;
			}

			set {
				HandlePropertySet(ref stblGroup, value, stblGroup);
			}
		}

		public ulong STBLInstance {
			get {
				return stblInstance;
			}

			set {
				HandlePropertySet(ref stblInstance, value, stblInstance);
			}
		}

		public string STBLName {
			get {
				return stblName;
			}

			set {
				HandlePropertySet(ref stblName, value, stblName);
			}
		}

		public bool BuildIdentifiers {
			get {
				return buildIdentifiers;
			}

			set {
				HandlePropertySet(ref buildIdentifiers, value, buildIdentifiers);
			}
		}

		public uint IdentifiersGroup {
			get {
				return identifiersGroup;
			}

			set {
				HandlePropertySet(ref identifiersGroup, value, identifiersGroup);
			}
		}

		public ulong IdentifiersInstance {
			get {
				return identifiersInstance;
			}

			set {
				HandlePropertySet(ref identifiersInstance, value, identifiersInstance);
			}
		}

		public string IdentifiersName {
			get {
				return identifiersName;
			}

			set {
				HandlePropertySet(ref identifiersName, value, identifiersName);
			}
		}

		public ObservableCollection<STBLXMLEntry> Entries {
			get {
				return entries;
			}

			set {
				if(value.Equals(entries)) {
					return;
				}

				while(watchingEntries.Count != 0) {
					watchingEntries[0].Changed -= Entry_Changed;
					watchingEntries[0].BecameClean -= Entry_BecameClean;
					watchingEntries[0].BecameDirty -= Entry_BecameDirty;
					watchingEntries.RemoveAt(0);
				}

				entries = value;
				entries.CollectionChanged += Entries_CollectionChanged;

				for(int entryIndex = 0; entryIndex < entries.Count; entryIndex++) {
					entries[entryIndex].Changed += Entry_Changed;
					entries[entryIndex].BecameClean += Entry_BecameClean;
					entries[entryIndex].BecameDirty += Entry_BecameDirty;

					watchingEntries.Add(entries[entryIndex]);
				}

				FileIsDirty = true;

				InvokeChangedEvent();
			}
		}

		public bool IsDirty {
			get {
				if(FileIsDirty) {
					return true;
				}

				for(int entryIndex = 0; entryIndex < entries.Count; entryIndex++) {
					if(entries[entryIndex].EntryIsDirty) {
						return true;
					}
				}

				return false;
			}
		}

		[XmlIgnore]
		public bool FileIsDirty {
			get {
				return fileIsDirty;
			}

			set {
				fileIsDirty = IsDirtyable ? value : false;
				CheckDirtyState();
			}
		}

		[XmlIgnore]
		public bool IsDirtyable {
			get {
				return isDirtyable;
			}

			set {
				isDirtyable = value;

				if(!isDirtyable) {
					FileIsDirty = false;
				}
			}
		}

		public event EventHandler Changed;
		public event EventHandler BecameClean;
		public event EventHandler BecameDirty;

		public event EventHandler EntryChanged;

		private int fallbackLanguage = 0;
		private uint stblGroup = 0;
		private ulong stblInstance = 0;
		private string stblName = "";
		private bool buildIdentifiers = true;
		private uint identifiersGroup = 0;
		private ulong identifiersInstance = 0;
		private string identifiersName = "";
		private ObservableCollection<STBLXMLEntry> entries = new ObservableCollection<STBLXMLEntry>();
		private List<STBLXMLEntry> watchingEntries = new List<STBLXMLEntry>();

		private bool fileIsDirty = false;
		private bool isDirtyable = false;

		private bool wasDirty = false;

		private void HandlePropertySet<T> (ref T currentValue, T newValue, T oldValue, bool becomeDirty = true) {
			if(Equals(newValue, oldValue)) {
				return;
			}

			currentValue = newValue;

			if(becomeDirty && IsDirtyable) {
				FileIsDirty = true;
			}

			InvokeChangedEvent();
		}

		private void CheckDirtyState () {
			bool isDirty = IsDirty;

			if(!wasDirty && isDirty) {
				InvokeBecameDirtyEvent();
			} else if(wasDirty && !isDirty) {
				InvokeBecameCleanEvent();
			}

			wasDirty = isDirty;
		}

		private void InvokeChangedEvent () {
			Changed?.Invoke(this, new EventArgs());
		}

		private void InvokeEntryChangedEvent () {
			EntryChanged?.Invoke(this, new EventArgs());
		}

		private void InvokeBecameCleanEvent () {
			BecameClean?.Invoke(this, new EventArgs());
		}

		private void InvokeBecameDirtyEvent () {
			BecameDirty?.Invoke(this, new EventArgs());
		}

		private void Entries_CollectionChanged (object sender, NotifyCollectionChangedEventArgs e) {
			if(e.Action == NotifyCollectionChangedAction.Reset) {
				while(watchingEntries.Count != 0) {
					watchingEntries[0].Changed -= Entry_Changed;
					watchingEntries[0].BecameClean -= Entry_BecameClean;
					watchingEntries[0].BecameDirty -= Entry_BecameDirty;
					watchingEntries.RemoveAt(0);
				}

				return;
			}

			if(e.Action == NotifyCollectionChangedAction.Move) {
				return;
			}

			if(e.NewItems != null) {
				foreach(STBLXMLEntry newEntry in e.NewItems) {
					if(watchingEntries.Contains(newEntry)) {
						continue;
					} else {
						newEntry.Changed += Entry_Changed;
						newEntry.BecameClean += Entry_BecameClean;
						newEntry.BecameDirty += Entry_BecameDirty;
						watchingEntries.Add(newEntry);
					}
				}
			}

			if(e.OldItems != null) {
				foreach(STBLXMLEntry oldEntry in e.OldItems) {
					oldEntry.Changed -= Entry_Changed;
					oldEntry.BecameClean -= Entry_BecameClean;
					oldEntry.BecameDirty -= Entry_BecameDirty;
					watchingEntries.Remove(oldEntry);
				}
			}

			FileIsDirty = true;
			InvokeChangedEvent();
		}

		private void Entry_Changed (object sender, EventArgs e) {
			InvokeEntryChangedEvent();
		}

		private void Entry_BecameDirty (object sender, EventArgs e) {
			CheckDirtyState();
		}

		private void Entry_BecameClean (object sender, EventArgs e) {
			CheckDirtyState();
		}
	}

	public class STBLXMLEntry {
		public string Identifier {
			get {
				return identifier;
			}

			set {
				HandlePropertySet(ref identifier, value, identifier);
			}
		}

		public uint Key {
			get {
				return key;
			}

			set {
				HandlePropertySet(ref key, value, key);
			}
		}

		public string English {
			get {
				return english;
			}

			set {
				HandlePropertySet(ref english, value, english);
			}
		}

		public string ChineseSimplified {
			get {
				return chineseSimplified;
			}

			set {
				HandlePropertySet(ref chineseSimplified, value, chineseSimplified);
			}
		}

		public string ChineseTraditional {
			get {
				return chineseTaditional;
			}

			set {
				HandlePropertySet(ref chineseTaditional, value, chineseTaditional);
			}
		}

		public string Czech {
			get {
				return czech;
			}

			set {
				HandlePropertySet(ref czech, value, czech);
			}
		}

		public string Danish {
			get {
				return danish;
			}

			set {
				HandlePropertySet(ref danish, value, danish);
			}
		}

		public string Dutch {
			get {
				return dutch;
			}

			set {
				HandlePropertySet(ref dutch, value, dutch);
			}
		}

		public string Finnish {
			get {
				return finnish;
			}

			set {
				HandlePropertySet(ref finnish, value, finnish);
			}
		}

		public string French {
			get {
				return french;
			}

			set {
				HandlePropertySet(ref french, value, french);
			}
		}

		public string German {
			get {
				return german;
			}

			set {
				HandlePropertySet(ref german, value, german);
			}
		}

		public string Greek {
			get {
				return greek;
			}

			set {
				HandlePropertySet(ref greek, value, greek);
			}
		}

		public string Hungarian {
			get {
				return hungarian;
			}

			set {
				HandlePropertySet(ref hungarian, value, hungarian);
			}
		}

		public string Italian {
			get {
				return italian;
			}

			set {
				HandlePropertySet(ref italian, value, italian);
			}
		}

		public string Japanese {
			get {
				return japanese;
			}

			set {
				HandlePropertySet(ref japanese, value, japanese);
			}
		}

		public string Korean {
			get {
				return korean;
			}

			set {
				HandlePropertySet(ref korean, value, korean);
			}
		}

		public string Norwegian {
			get {
				return norwegian;
			}

			set {
				HandlePropertySet(ref norwegian, value, norwegian);
			}
		}

		public string Polish {
			get {
				return polish;
			}

			set {
				HandlePropertySet(ref polish, value, polish);
			}
		}

		public string PortuguesePortugal {
			get {
				return portuguesePortugal;
			}

			set {
				HandlePropertySet(ref portuguesePortugal, value, portuguesePortugal);
			}
		}

		public string PortugueseBrazil {
			get {
				return portugueseBrazil;
			}

			set {
				HandlePropertySet(ref portugueseBrazil, value, portugueseBrazil);
			}
		}

		public string Russian {
			get {
				return russian;
			}

			set {
				HandlePropertySet(ref russian, value, russian);
			}
		}

		public string SpanishSpain {
			get {
				return spanishSpain;
			}

			set {
				HandlePropertySet(ref spanishSpain, value, spanishSpain);
			}
		}

		public string SpanishMexico {
			get {
				return spanishMexico;
			}

			set {
				HandlePropertySet(ref spanishMexico, value, spanishMexico);
			}
		}

		public string Swedish {
			get {
				return swedish;
			}

			set {
				HandlePropertySet(ref swedish, value, swedish);
			}
		}

		public string Thai {
			get {
				return thai;
			}

			set {
				HandlePropertySet(ref thai, value, thai);
			}
		}

		[XmlIgnore]
		public bool EntryIsDirty {
			get {
				return entryIsDirty;
			}

			set {
				bool becameClean = entryIsDirty && (!value || !IsDirtyable);
				bool becameDirty = !entryIsDirty && value;

				entryIsDirty = IsDirtyable ? value : false;

				if(becameClean) {
					InvokeBecameCleanEvent();
				} else if(becameDirty) {
					InvokeBecameDirtyEvent();
				}
			}
		}

		[XmlIgnore]
		public bool IsDirtyable {
			get {
				return isDirtyable;
			}

			set {
				isDirtyable = value;

				if(!isDirtyable) {
					entryIsDirty = false;
				}
			}
		}

		public event EventHandler Changed;
		public event EventHandler BecameClean;
		public event EventHandler BecameDirty;

		private string identifier = "";
		private uint key = 0;
		private string english = null;
		private string chineseSimplified = null;
		private string chineseTaditional = null;
		private string czech = null;
		private string danish = null;
		private string dutch = null;
		private string finnish = null;
		private string french = null;
		private string german = null;
		private string greek = null;
		private string hungarian = null;
		private string italian = null;
		private string japanese = null;
		private string korean = null;
		private string norwegian = null;
		private string polish = null;
		private string portuguesePortugal = null;
		private string portugueseBrazil = null;
		private string russian = null;
		private string spanishSpain = null;
		private string spanishMexico = null;
		private string swedish = null;
		private string thai = null;

		private bool entryIsDirty = false;
		private bool isDirtyable = false;

		public string GetText (int languageNumber) {
			STBL.Languages language = STBL.Languages.English;

			if(!Enum.TryParse(languageNumber.ToString(), out language)) {
				throw new ArgumentException("'" + languageNumber.ToString() + "' is not a valid language number.");
			}

			return GetText(language);
		}

		public string GetText (string languageIdentifier) {
			STBL.Languages language = STBL.Languages.English;

			if(!Enum.TryParse(languageIdentifier, true, out language)) {
				throw new ArgumentException("'" + languageIdentifier + "' is not a valid language.");
			}

			return GetText(language);
		}

		public string GetText (STBL.Languages language) {
			switch(language) {
				case STBL.Languages.English:
					return English;
				case STBL.Languages.ChineseSimplified:
					return ChineseSimplified;
				case STBL.Languages.ChineseTraditional:
					return ChineseTraditional;
				case STBL.Languages.Czech:
					return Czech;
				case STBL.Languages.Danish:
					return Danish;
				case STBL.Languages.Dutch:
					return Dutch;
				case STBL.Languages.Finnish:
					return Finnish;
				case STBL.Languages.French:
					return French;
				case STBL.Languages.German:
					return German;
				case STBL.Languages.Greek:
					return Greek;
				case STBL.Languages.Hungarian:
					return Hungarian;
				case STBL.Languages.Italian:
					return Italian;
				case STBL.Languages.Japanese:
					return Japanese;
				case STBL.Languages.Korean:
					return Korean;
				case STBL.Languages.Norwegian:
					return Norwegian;
				case STBL.Languages.Polish:
					return Polish;
				case STBL.Languages.PortuguesePortugal:
					return PortuguesePortugal;
				case STBL.Languages.PortugueseBrazil:
					return PortugueseBrazil;
				case STBL.Languages.Russian:
					return Russian;
				case STBL.Languages.SpanishSpain:
					return SpanishSpain;
				case STBL.Languages.SpanishMexico:
					return SpanishMexico;
				case STBL.Languages.Swedish:
					return Swedish;
				case STBL.Languages.Thai:
					return Thai;
				default:
					throw new ArgumentException("'" + language.ToString() + "' is not a valid language");
			}
		}

		public bool HasText (int languageNumber) {
			return GetText(languageNumber) != null;
		}

		public bool HasText (string languageIdentifier) {
			return GetText(languageIdentifier) != null;
		}

		public bool HasText (STBL.Languages language) {
			return GetText(language) != null;
		}

		public void SetText (int languageNumber, string languageText) {
			STBL.Languages language = STBL.Languages.English;

			if(!Enum.TryParse(languageNumber.ToString(), out language)) {
				throw new ArgumentException("'" + languageNumber.ToString() + "' is not a valid language number.");
			}

			SetText(language, languageText);
		}

		public void SetText (string languageIdentifier, string languageText) {
			STBL.Languages language = STBL.Languages.English;

			if(!Enum.TryParse(languageIdentifier, true, out language)) {
				throw new ArgumentException("'" + languageIdentifier + "' is not a valid language.");
			}

			SetText(language, languageText);
		}

		public void SetText (STBL.Languages language, string languageText) {
			switch(language) {
				case STBL.Languages.English:
					English = languageText;
					return;
				case STBL.Languages.ChineseSimplified:
					ChineseSimplified = languageText;
					return;
				case STBL.Languages.ChineseTraditional:
					ChineseTraditional = languageText;
					return;
				case STBL.Languages.Czech:
					Czech = languageText;
					return;
				case STBL.Languages.Danish:
					Danish = languageText;
					return;
				case STBL.Languages.Dutch:
					Dutch = languageText;
					return;
				case STBL.Languages.Finnish:
					Finnish = languageText;
					return;
				case STBL.Languages.French:
					French = languageText;
					return;
				case STBL.Languages.German:
					German = languageText;
					return;
				case STBL.Languages.Greek:
					Greek = languageText;
					return;
				case STBL.Languages.Hungarian:
					Hungarian = languageText;
					return;
				case STBL.Languages.Italian:
					Italian = languageText;
					return;
				case STBL.Languages.Japanese:
					Japanese = languageText;
					return;
				case STBL.Languages.Korean:
					Korean = languageText;
					return;
				case STBL.Languages.Norwegian:
					Norwegian = languageText;
					return;
				case STBL.Languages.Polish:
					Polish = languageText;
					return;
				case STBL.Languages.PortuguesePortugal:
					PortuguesePortugal = languageText;
					return;
				case STBL.Languages.PortugueseBrazil:
					PortugueseBrazil = languageText;
					return;
				case STBL.Languages.Russian:
					Russian = languageText;
					return;
				case STBL.Languages.SpanishSpain:
					SpanishSpain = languageText;
					return;
				case STBL.Languages.SpanishMexico:
					SpanishMexico = languageText;
					return;
				case STBL.Languages.Swedish:
					Swedish = languageText;
					return;
				case STBL.Languages.Thai:
					Thai = languageText;
					return;
				default:
					throw new ArgumentException("'" + language.ToString() + "' is not a valid language.");
			}
		}

		private void HandlePropertySet<T> (ref T currentValue, T newValue, T oldValue, bool becomeDirty = true) {
			if(Equals(newValue, oldValue)) {
				return;
			}

			currentValue = newValue;

			if(becomeDirty && IsDirtyable) {
				EntryIsDirty = true;
			}

			InvokeChangedEvent();
		}

		private void InvokeChangedEvent () {
			Changed?.Invoke(this, new EventArgs());
		}

		private void InvokeBecameCleanEvent () {
			BecameClean?.Invoke(this, new EventArgs());
		}

		private void InvokeBecameDirtyEvent () {
			if(BecameDirty == null) {
				return;
			}

			BecameDirty.Invoke(this, new EventArgs());
		}
	}
}
