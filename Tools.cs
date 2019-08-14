using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Text.RegularExpressions;

namespace STBLXMLEditor {
	public static class Tools {
		public static object ReadXML<T> (string filePath) {
			using(XmlTextReader reader = new XmlTextReader(filePath)) {
				return new XmlSerializer(typeof(T)).Deserialize(reader);
			}
		}

		public static void WriteXML (string filePath, object target) {
			Directory.CreateDirectory(Path.GetDirectoryName(filePath));

			XmlWriterSettings writerSettings = new XmlWriterSettings() {
				Indent = true,
				IndentChars = "\t"
			};

			using(XmlWriter writer = XmlWriter.Create(filePath, writerSettings)) {
				new XmlSerializer(target.GetType()).Serialize(writer, target);
			}
		}

		public static string NormalizeLineEndings (string abnormalString) {
			if(abnormalString == null) {
				return abnormalString;
			}

			return NormalizeLineEndings(abnormalString, Environment.NewLine);
		}

		public static string NormalizeLineEndings (string abnormalString, string correctLineEnding) {
			if(abnormalString == null) {
				return abnormalString;
			}

			return Regex.Replace(abnormalString, @"\r\n|\r|\n", correctLineEnding);
		}
	}
}
