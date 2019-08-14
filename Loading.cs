using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace STBLXMLEditor {
	public static class Loading {
		public static STBLXMLFile Data {
			get; private set;
		} = new STBLXMLFile();

		public static string FilePath {
			get; private set;
		} = null;

		public static bool IsDirty {
			get {
				return Data.IsDirty;
			}
		}

		public static event EventHandler FileChanged;
		public static event EventHandler BecameDirty;
		public static event EventHandler BecameClean;

		public static void NewFile () {
			RemoveEvents(Data);

			Data = new STBLXMLFile();
			AddEvents(Data);

			FilePath = null;

			Data.IsDirtyable = true;

			for(int entryIndex = 0; entryIndex < Data.Entries.Count; entryIndex++) {
				Data.Entries[entryIndex].IsDirtyable = true;
			}

			InvokeFileChangedEvent();
		}

		public static void OpenFile (string filePath) {
			RemoveEvents(Data);

			Data = (STBLXMLFile)Tools.ReadXML<STBLXMLFile>(filePath);
			AddEvents(Data);

			FilePath = new IO.PathContainer(filePath).ToString();

			SortEntries();

			Data.IsDirtyable = true;

			for(int entryIndex = 0; entryIndex < Data.Entries.Count; entryIndex++) {
				Data.Entries[entryIndex].IsDirtyable = true;
			}

			InvokeFileChangedEvent();
		}

		public static void SaveFile (string filePath) {
			Tools.WriteXML(filePath, Data);

			IO.PathContainer newFilePath = new IO.PathContainer(filePath);
			IO.PathContainer oldFilePath = FilePath != null ? new IO.PathContainer(FilePath) : null;

			if(newFilePath != oldFilePath) {
				FilePath = new IO.PathContainer(filePath).ToString();
			}

			for(int entryIndex = 0; entryIndex < Data.Entries.Count; entryIndex++) {
				Data.Entries[entryIndex].EntryIsDirty = false;
			}

			Data.FileIsDirty = false;

			if(newFilePath != oldFilePath) {
				InvokeFileChangedEvent();
			}
		}

		public static void AddEntry (STBLXMLEntry entry) {
			entry.IsDirtyable = true;
			entry.EntryIsDirty = true;

			Data.Entries.Add(entry);

			SortEntries();
		}

		public static STBLXMLEntry AddNewEntry (uint? key = null, string identifier = "") {
			if(key == null) {
				key = STBL.GetRandomUIntKey(blockedKeys: GetAllEntryKeys());
			}

			STBLXMLEntry newEntry = new STBLXMLEntry() {
				Key = (uint)key,
				Identifier = identifier
			};

			newEntry.IsDirtyable = true;
			newEntry.EntryIsDirty = true;

			Data.Entries.Add(newEntry);
			SortEntries();

			return newEntry;
		}

		public static uint[] GetAllEntryKeys () {
			uint[] entryKeys = new uint[Data.Entries.Count];

			for(int entryIndex = 0; entryIndex < Data.Entries.Count; entryIndex++) {
				entryKeys[entryIndex] = Data.Entries[entryIndex].Key;
			}

			return entryKeys;
		}

		public static bool EntryKeyCollides (uint entryKey, STBLXMLEntry ignoringEntry) {
			for(int entryIndex = 0; entryIndex < Data.Entries.Count; entryIndex++) {
				if(Data.Entries[entryIndex] == ignoringEntry) {
					continue;
				}

				if(Data.Entries[entryIndex].Key == entryKey) {
					return true;
				}
			}

			return false;
		}

		private static void AddEvents (STBLXMLFile file) {
			file.BecameClean += Data_BecameClean;
			file.BecameDirty += Data_BecameDirty;
		}

		private static void RemoveEvents (STBLXMLFile file) {
			file.BecameClean -= Data_BecameClean;
			file.BecameDirty -= Data_BecameDirty;
		}

		private static void SortEntries () {
			Data.Entries = new ObservableCollection<STBLXMLEntry>(Data.Entries.OrderBy(x => x.Identifier));
		}

		private static void InvokeFileChangedEvent () {
			FileChanged?.Invoke(null, new EventArgs());
		}

		private static void InvokeBecameCleanEvent () {
			BecameClean?.Invoke(null, new EventArgs());
		}

		private static void InvokeBecameDirtyEvent () {
			BecameDirty?.Invoke(null, new EventArgs());
		}

		private static void Data_BecameClean (object sender, EventArgs e) {
			InvokeBecameCleanEvent();
		}

		private static void Data_BecameDirty (object sender, EventArgs e) {
			InvokeBecameDirtyEvent();
		}
	}
}
