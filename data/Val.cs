using System;
using System.Collections.Generic;

namespace App.data {
	class Val {

		// static method
		/// <summary>
		/// Get list.
		/// </summary>
		/// <param name="a">String list.</param>
		/// <param name="i">Index.</param>
		/// <param name="s">Separators.</param>
		/// <returns>List value.</returns>
		public static IList<string> List(IList<string> a, int i, string[] s = null) {
			s = s == null ? new string[] { "," } : s;
			return a.Count > i ? a[i].Split(s, StringSplitOptions.None) : new string[0];
		}

		/// <summary>
		/// Get index.
		/// </summary>
		/// <param name="a">String list.</param>
		/// <param name="i">Index.</param>
		/// <param name="l">Length bound.</param>
		/// <returns>Index value.</returns>
		public static int Index(IList<string> a, int i, int l = 1, int vd = 0) {
			int v = Int(a, i, vd);
			if (v < 0) v = 0;
			if (v > l) v = l;
			return v;
		}

		/// <summary>
		/// Get integer.
		/// </summary>
		/// <param name="a">String list.</param>
		/// <param name="i">Index.</param>
		/// <param name="vd">Default value.</param>
		/// <returns>Integer value.</returns>
		public static int Int(IList<string> a, int i, int vd = 0) {
			int v = vd;
			if (a.Count > i) int.TryParse(a[i], out v);
			return v;
		}

		/// <summary>
		/// Get string.
		/// </summary>
		/// <param name="a">String list.</param>
		/// <param name="i">Index.</param>
		/// <param name="vd">Default value.</param>
		/// <returns>String value.</returns>
		public static string String(IList<string> a, int i, string vd = "") {
			return a.Count > i ? a[i] : vd;
		}
	}
}
