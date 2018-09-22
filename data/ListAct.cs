using System;
using System.Text;
using System.Collections.Generic;
using static App.data.Val;

namespace App.data {
	class ListAct {

		// type
		/// <summary>
		/// List function delegate.
		/// </summary>
		/// <param name="l">List.</param>
		/// <param name="a">Input arguments.</param>
		/// <returns>Output list.</returns>
		public delegate IList<string> oFn(List<string> l, string[] a);


		// static data
		/// <summary>
		/// Separators for input arguments.
		/// </summary>
		public static string[] Sep = DefSep;
		/// <summary>
		/// Default separators.
		/// </summary>
		public static string[] DefSep = new string[] { "\r\n", "\n", "\r" };
		/// <summary>
		/// Points to list functions.
		/// </summary>
		public static Dictionary<string, oFn> Fn = new Dictionary<string, oFn>() {
			["size"] = Size, ["get"] = Get, ["set"] = Set, ["add"] = Add, ["remove"] = Remove, ["reverse"] = Reverse,
			["find"] = Find, ["replace"] = Replace, ["sort"] = Sort
		};

		
		// static method
		/// <summary>
		/// Create new list from string.
		/// </summary>
		/// <param name="v">String value.</param>
		/// <param name="s">Separators.</param>
		/// <returns>List.</returns>
		public static List<string> New(string v, string[] s) {
			return new List<string>(v.Split(s, StringSplitOptions.None));
		}

		/// <summary>
		/// Get string representation of list.
		/// </summary>
		/// <param name="l">List.</param>
		/// <param name="s">Separator.</param>
		/// <returns>String value.</returns>
		public static string ToString(IList<string> l, string s) {
			StringBuilder v = new StringBuilder();
			foreach (var e in l)
				v.Append(e).Append(s);
			if (v.Length > 0) v.Remove(v.Length - s.Length, s.Length);
			return v.ToString();
		}

        /// <summary>
        /// Get size of list.
        /// </summary>
        /// <param name="l">List.</param>
        /// <param name="a">.</param>
        /// <returns>List size.</returns>
        public static IList<string> Size(IList<string> l, string[] a) {
            return new string[] { l.Count.ToString() };
        }

		/// <summary>
		/// Get values.
		/// </summary>
		/// <param name="l">List.</param>
		/// <param name="a">[bgn],[end].</param>
		/// <returns>Get list.</returns>
		public static IList<string> Get(List<string> l, string[] a) {
			int bgn = Index(a, 0, l.Count);
			int end = Index(a, 1, l.Count, bgn + 1);
			return l.GetRange(bgn, end - bgn);
		}

		/// <summary>
		/// Set values.
		/// </summary>
		/// <param name="l">List.</param>
		/// <param name="a">[val],[bgn],[end].</param>
		/// <returns>Set list.</returns>
		public static IList<string> Set(List<string> l, string[] a) {
			IList<string> set = List(a, 0, Sep);
			int bgn = Index(a, 1, l.Count);
			int end = Index(a, 2, l.Count, bgn + 1);
			for (int i = end - 1; i >= bgn; i--) {
				l.RemoveAt(i);
				l.InsertRange(i, set);
			}
			return l;
		}

		/// <summary>
		/// Add values.
		/// </summary>
		/// <param name="l">List.</param>
		/// <param name="a">[add],[off],[num].</param>
		/// <returns>Added list.</returns>
		public static IList<string> Add(List<string> l, string[] a) {
			IList<string> add = List(a, 0, Sep);
			int off = Index(a, 1, l.Count, l.Count);
			int num = Int(a, 2, 1);
			for (int i = 0; i < num; i++)
				l.InsertRange(off, add);
			return l;
		}

		/// <summary>
		/// Remove values.
		/// </summary>
		/// <param name="l">List.</param>
		/// <param name="a">[bgn],[end].</param>
		/// <returns>Removed list.</returns>
		public static IList<string> Remove(List<string> l, string[] a) {
			int bgn = Index(a, 0, l.Count, l.Count - 1);
			int end = Index(a, 1, l.Count, bgn + 1);
			l.RemoveRange(bgn, end - bgn);
			return l;
		}

		/// <summary>
		/// Reverse values.
		/// </summary>
		/// <param name="l">List.</param>
		/// <param name="a">[bgn],[end].</param>
		/// <returns>Reversed list.</returns>
		public static IList<string> Reverse(List<string> l, string[] a) {
			int bgn = Index(a, 0, l.Count);
			int end = Index(a, 1, l.Count, l.Count);
			l.Reverse(bgn, end - bgn);
			return l;
		}

		/// <summary>
		/// Find values.
		/// </summary>
		/// <param name="l">List.</param>
		/// <param name="a">[fnd].</param>
		/// <returns>Index list.</returns>
		public static IList<string> Find(List<string> l, string[] a) {
			IList<string> val = new List<string>();
			IList<string> fnd = List(a, 0, Sep);
			for (int i = 0; i < l.Count; i++)
				if (fnd.Contains(l[i])) val.Add(i.ToString());
			return val;
		}

		/// <summary>
		/// Find and replace values.
		/// </summary>
		/// <param name="l">List.</param>
		/// <param name="a">[fnd],[rep].</param>
		/// <returns>Replaced list.</returns>
		public static IList<string> Replace(List<string> l, string[] a) {
			IList<string> fnd = List(a, 0, Sep);
			IList<string> rep = List(a, 1, Sep);
			for (int i = l.Count - 1; i >= 0; i--)
				if (fnd.Contains(l[i])) { l.RemoveAt(i); l.InsertRange(i, rep); }
			return l;
		}

		/// <summary>
		/// Sort list.
		/// </summary>
		/// <param name="l">List.</param>
		/// <param name="a">[opt(di)].</param>
		/// <returns>Sorted list.</returns>
		public static IList<string> Sort(List<string> l, string[] a) {
			string opt = String(a, 0).ToLower();
			bool c = opt.Contains("i");
			int s = opt.Contains("d")? -1 : 1;
			l.Sort((x, y) => s * (c ? x.ToLower() : x).CompareTo(c ? y.ToLower() : y));
			return l;
		}
	}
}
