using System;
using System.Collections.Generic;
using orez.olist.data;

namespace orez.olist {
	class Program {

		// static method
		/// <summary>
		/// When in doubt, flee.
		/// : Unggoy philosophy.
		/// </summary>
		/// <param name="args">Input arguments.</param>
		static void Main(string[] args) {
			oParams p = DefParams(new oParams(args));
			List<string> li = oListAct.New(p.Input, p.InpSep.ToArray());
			oListAct.Sep = p.ArgSep.ToArray();
			IList<string> lo = oListAct.Fn.ContainsKey(p.Fn) ? oListAct.Fn[p.Fn](li, p.Args.ToArray()) : li;
			Console.WriteLine(oListAct.ToString(lo, p.OutSep[0]));
		}

		/// <summary>
		/// Set default values for parameters if not specified.
		/// </summary>
		/// <param name="p">Parameters.</param>
		private static oParams DefParams(oParams p) {
			List<string> sep = new List<string>(oListAct.DefSep);
			if (p.Input == null) p.Input = Console.In.ReadToEnd();
			if (p.InpSep.Count == 0) p.InpSep = sep;
			if (p.ArgSep.Count == 0) p.ArgSep = sep;
			if (p.OutSep.Count == 0) p.OutSep = sep;
			if (p.Fn == null) p.Fn = "";
			return p;
		}
	}
}
