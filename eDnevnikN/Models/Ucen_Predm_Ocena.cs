using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eDnevnikN.Models
{
	
		public enum Ocene
		{
			Nedovoljan,
			Dovoljan,
			Dobar,
			Vrlodobar,
			Odlican
		}

		public class Ucen_Predm_Ocena
		{
			public int Ucen_Predm_OcenaID { get; set; }
			public int PredmetiID { get; set; }
			public int UceniciID { get; set; }
			public Ocene? Ocene { get; set; }
			public DateTime DatumOcenjivanja { get; set; }

			public virtual Predmeti Predmeti { get; set; }
			public virtual Ucenici Ucenici { get; set; }
		}
	
}