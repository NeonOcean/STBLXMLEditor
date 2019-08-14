using System;
using System.IO;
using System.Windows.Forms;

namespace STBLXMLEditor {
	public static class Entry {
		public static string Namespace {
			get; private set;
		}

		public static string TargetFilePath {
			get; set;
		} = null;
		
		[STAThread]
		static void Main () {
			Namespace = "STBLXMLEditor";

			try {
				ReadArguments();

				if(TargetFilePath != null) {
					Loading.OpenFile(TargetFilePath);
				}
			} catch{ }

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Selector());
		}

		private static bool ReadArguments () {
			string[] arguments = Environment.GetCommandLineArgs();

			for(int argumentIndex = 1; argumentIndex < arguments.Length; argumentIndex++) {
				TargetFilePath = arguments[argumentIndex];
			}

			try {
				if(TargetFilePath != null) {
					TargetFilePath = Path.GetFullPath(TargetFilePath);
					FileInfo targetFileInfo = new FileInfo(TargetFilePath);

					if(!targetFileInfo.Exists) {
						return false;
					}
				}
			} catch {
				TargetFilePath = null;
			}

			return true;
		}
	}
}
