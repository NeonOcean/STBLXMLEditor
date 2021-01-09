using System;
using System.Globalization;
using System.IO;
using System.Security;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace STBLXMLEditor {
	public class NotPackageSTBLFileException : Exception {
		public NotPackageSTBLFileException () : base() { }
		public NotPackageSTBLFileException (string message) : base(message) {}
		public NotPackageSTBLFileException (string message, Exception innerException) : base(message, innerException) { }
	}

	public static class ImportExport {
		public const string STBLFileExtension = "stbl";
		public const string IdentifiersFileExtension = "xml";
		public const string SourceInfoFileExtension = "sourceinfo";

		public class SourceInfo {
			[XmlElement(IsNullable = true)]
			public string Name {
				get; set;
			} = null;

			public uint TypeID {
				get; set;
			} = 0;

			public uint GroupID {
				get; set;
			} = 0;

			public ulong InstanceID {
				get; set;
			} = 0;
		}

		public static void ExportToPackageFiles (STBLXMLFile exportingFile, string exportDirectoryPath, bool buildSourceInfoFiles) {
			Directory.CreateDirectory(exportDirectoryPath);

			STBL.Languages fallbackLanguage = STBL.GetLanguage(exportingFile.FallbackLanguage);

			foreach(STBL.Languages language in STBL.GetAllLanguages()) {
				string languageFileName = string.Format(exportingFile.STBLName, new STBL.LanguageFileName(language));

				string stblFileName = languageFileName + "." + STBLFileExtension;
				string stblFilePath = Path.Combine(exportDirectoryPath, stblFileName);

				using(BinaryWriter exportFileWriter = new BinaryWriter(new FileStream(stblFilePath, FileMode.Create))) {
					string[] texts = new string[exportingFile.Entries.Count];
					ushort[] textsByteCounts = new ushort[exportingFile.Entries.Count];
					uint entryByteCount = 0;

					for(int entryIndex = 0; entryIndex < exportingFile.Entries.Count; entryIndex++) {
						string entryLanguageText = exportingFile.Entries[entryIndex].GetText(language);

						if(entryLanguageText == null) {
							entryLanguageText = exportingFile.Entries[entryIndex].GetText(fallbackLanguage);
						}

						if(entryLanguageText == null) {
							entryLanguageText = exportingFile.Entries[entryIndex].Identifier;
						}

						texts[entryIndex] = entryLanguageText;

						textsByteCounts[entryIndex] = (ushort)Encoding.UTF8.GetByteCount(texts[entryIndex]);
						entryByteCount += textsByteCounts[entryIndex] + 1u;
					}

					exportFileWriter.Write(Encoding.UTF8.GetBytes("STBL"));
					exportFileWriter.Write((byte)5);
					exportFileWriter.Write((ushort)0);
					exportFileWriter.Write((uint)exportingFile.Entries.Count);
					exportFileWriter.Write(0u);
					exportFileWriter.Write((ushort)0);
					exportFileWriter.Write(entryByteCount);

					for(int textsIndex = 0; textsIndex < exportingFile.Entries.Count; textsIndex++) {
						exportFileWriter.Write(exportingFile.Entries[textsIndex].Key);
						exportFileWriter.Write((byte)0);
						exportFileWriter.Write(textsByteCounts[textsIndex]);
						exportFileWriter.Write(texts[textsIndex].ToCharArray());
					}
				}

				if(buildSourceInfoFiles) {
					string sourceInfoFilePath = stblFilePath + "." + SourceInfoFileExtension;

					string languageInstanceHexadecimal = ((int)language).ToString("x2") + exportingFile.STBLInstance.ToString("x").Substring(2);
					ulong languageInstance = ulong.Parse(languageInstanceHexadecimal, NumberStyles.HexNumber);

					Tools.WriteXML(sourceInfoFilePath, new SourceInfo() {
						Name = languageFileName,
						TypeID = 570775514,
						GroupID = exportingFile.STBLGroup,
						InstanceID = languageInstance
					});
				}
			}
		}

		public static void ExportToPackageIdentifiersFiles (STBLXMLFile exportingFile, string exportDirectoryPath, bool buildSourceInfoFiles) {
			Directory.CreateDirectory(exportDirectoryPath);

			string identifiersFileName = exportingFile.IdentifiersName + "." + IdentifiersFileExtension;
			string identifiersFilePath = Path.Combine(exportDirectoryPath, identifiersFileName);

			string identifiersText = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n";
			identifiersText += "<I n=\"" + SecurityElement.Escape(exportingFile.IdentifiersName) + "\" s=\"" + exportingFile.IdentifiersInstance.ToString("0") + "\" i=\"snippet\" m=\"snippets\" c=\"NeonoceanS4GlobalLanguageIdentifiers\">\n";
			identifiersText += "\t<L n=\"value\">\n";

			for(int entryIndex = 0; entryIndex < exportingFile.Entries.Count; entryIndex++) {
				identifiersText += "\t\t<U>\n";
				identifiersText += "\t\t\t<T n=\"key\">" + SecurityElement.Escape(exportingFile.Entries[entryIndex].Identifier) + "</T>\n";
				identifiersText += "\t\t\t<T n=\"value\">" + exportingFile.Entries[entryIndex].Key.ToString("0") + "</T>\n";
				identifiersText += "\t\t</U>\n";
			}

			identifiersText += "\t</L>\n</I>";

			using(StreamWriter writer = new StreamWriter(identifiersFilePath)) {
				writer.Write(identifiersText);
			}

			if(buildSourceInfoFiles) {
				string sourceInfoFilePath = identifiersFilePath + "." + SourceInfoFileExtension;

				Tools.WriteXML(sourceInfoFilePath, new SourceInfo() {
					Name = exportingFile.IdentifiersName,
					TypeID = 2113017500,
					GroupID = exportingFile.IdentifiersGroup,
					InstanceID = exportingFile.IdentifiersInstance
				});
			}
		}

		public static STBLXMLFile ImportFromPackageFile (string importFilePath) {
			STBLXMLFile importedFile = new STBLXMLFile();


			using(BinaryReader importFileReader = new BinaryReader(new FileStream(importFilePath, FileMode.Open))) {
				string fileIdentifier = Encoding.UTF8.GetString(importFileReader.ReadBytes(4));

				if(fileIdentifier != "STBL") {
					throw new NotPackageSTBLFileException("Invalid STBL file identifier, expected 'STBL'.");
				}

				short version = importFileReader.ReadInt16();

				if(version != 5) {
					throw new NotPackageSTBLFileException("Invalid STBL file version, expected '5'.");
				}

				importFileReader.BaseStream.Seek(1, SeekOrigin.Current); // Skip the 'compressed' byte, its not used.
				ulong entryCount = importFileReader.ReadUInt64();

				importFileReader.BaseStream.Seek(6, SeekOrigin.Current); // Skip the two 'reserved' bytes and the 'string length' bytes.

				for(ulong entryIndex = 0; entryIndex < entryCount; entryIndex++) {
					uint entryKey = importFileReader.ReadUInt32();
					importFileReader.BaseStream.Seek(1, SeekOrigin.Current); // Skip the flags byte.
					ushort entryLength = importFileReader.ReadUInt16();
					string entryText = Encoding.UTF8.GetString(importFileReader.ReadBytes(entryLength));
					importedFile.Entries.Add(
						new STBLXMLEntry() {
							Key = entryKey,
							English = entryText
						}
					);
				}


			}

			return importedFile;
		}
	}
}
