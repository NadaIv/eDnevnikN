
using eDnevnikN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eDnevnikN.ViewModels
{
	public class ProfesoriIndexData
	{
		public IEnumerable<Profesori> Profesoris { get; set; }
		public IEnumerable<Predmeti> Predmetis { get; set; }
		public IEnumerable<Ucen_Predm_Ocena> Ucen_Predm_Ocenas {get; set; }

	}
}