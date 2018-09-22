using System;
using System.Collections.Generic;
using App.data;

namespace App {
	class Program {

		// static method
		/// <summary>
		/// When in doubt, flee.
		/// : Unggoy philosophy.
		/// </summary>
		/// <param name="args">Input arguments.</param>
		static void Main(string[] args) {
			Params p = DefParams(new Params(args));
			List<string> li = ListAct.New(p.Input, p.InpSep.ToArray());
			ListAct.Sep = p.ArgSep.ToArray();
			IList<string> lo = ListAct.Fn.ContainsKey(p.Fn) ? ListAct.Fn[p.Fn](li, p.Args.ToArray()) : li;
			Console.WriteLine(ListAct.ToString(lo, p.OutSep[0]));
		}

		/// <summary>
		/// Set default values for parameters if not specified.
		/// </summary>
		/// <param name="p">Parameters.</param>
		private static Params DefParams(Params p) {
			List<string> sep = new List<string>(ListAct.DefSep);
			if (p.Input == null) p.Input = Console.In.ReadToEnd();
			if (p.InpSep.Count == 0) p.InpSep = sep;
			if (p.ArgSep.Count == 0) p.ArgSep = sep;
			if (p.OutSep.Count == 0) p.OutSep = sep;
			if (p.Fn == null) p.Fn = "";
			return p;
		}
	}
}
