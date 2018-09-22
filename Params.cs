using System.Collections.Generic;

namespace App {
	class Params {

		// data
		/// <summary>
		/// Directly specified input list.
		/// </summary>
		public string Input;
		/// <summary>
		/// Input list separator.
		/// </summary>
		public List<string> InpSep = new List<string>();
		/// <summary>
		/// Argument list separator.
		/// </summary>
		public List<string> ArgSep = new List<string>();
		/// <summary>
		/// Output list separator.
		/// </summary>
		public List<string> OutSep = new List<string>();
		/// <summary>
		/// List function called.
		/// </summary>
		public string Fn;
		/// <summary>
		/// Input arguments to list function.
		/// </summary>
		public List<string> Args = new List<string>();


		// constructor
		/// <summary>
		/// Get parameters from input arguments.
		/// </summary>
		/// <param name="a">Input arguments.</param>
		public Params(string[] a) {
			for (int i = 0; i < a.Length; i++) {
				switch (a[i]) {
					case "-i":
					case "--input":
						if (++i < a.Length) Input = a[i];
						break;
					case "-s":
					case "--input-separator":
						if (++i < a.Length) InpSep.Add(a[i]);
						break;
					case "-t":
					case "--argument-separator":
						if (++i < a.Length) ArgSep.Add(a[i]);
						break;
					case "-u":
					case "--output-separator":
						if (++i < a.Length) OutSep.Add(a[i]);
						break;
					default:
						Fn = a[i++];
						for (; i < a.Length; i++)
							Args.Add(a[i]);
						break;
				}
			}
		}
	}
}
