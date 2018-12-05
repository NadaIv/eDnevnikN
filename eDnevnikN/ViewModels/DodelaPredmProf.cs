using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eDnevnikN.ViewModels
{
	public class DodelaPredmProf
	{
		public int PredmetiID { get; set; }
		public string NazivPredmeta { get; set; }
		public bool Dodela { get; set; }
	}
}