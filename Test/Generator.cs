using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test {
	static class Generator {
		public static void Generate() {
			string[] Lines = File.ReadAllLines("functions.txt").Where(L => L.Trim().Length > 0 && !L.Trim().StartsWith("//")).ToArray();

			if (File.Exists("out.txt"))
				File.Delete("out.txt");

			StringBuilder Signature = new StringBuilder();
			File.AppendAllText("out.txt", "#region AUTO_GENERATED\n");

			foreach (var L in Lines) {
				string Line = L;

				int NameIdx = Line.IndexOf(" nvg") + 4;
				string FuncName = Line.Substring(NameIdx, Line.IndexOf('(') - NameIdx);

				Line = Line.Replace(" nvg", " ").Replace("NVGcontext* ctx", "this NanoVGContext Ctx").Replace("string", "Str").Replace("unsigned char", "byte");
				Line = Line.Replace("const char*", "byte[]").Replace("NVGcolor", "NVGColor").Replace("NVGpaint", "NVGPaint");
				Line = Line.Replace("const", "");
				Line = Line.Replace("NVGglyphPosition*", "/* NVGglyphPosition* */ IntPtr").Replace("NVGtextRow*", "/*NVGtextRow* */ IntPtr");

				if (FuncName == "TextAlign")
					Line = Line.Replace("int align", "NVGAlign align");
				else if (FuncName == "PathWinding")
					Line = Line.Replace("int dir", "NVGSolidity dir");
				else if (FuncName == "Arc")
					Line = Line.Replace("int dir", "NVGWinding dir");

				Signature.Clear();
				Signature.Append("[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(" + FuncName + "))]\npublic static extern ");

				Signature.AppendLine(Line);
				Signature.AppendLine();
				File.AppendAllText("out.txt", Signature.ToString());
			}

			File.AppendAllText("out.txt", "#endregion\n");
		}
	}
}
