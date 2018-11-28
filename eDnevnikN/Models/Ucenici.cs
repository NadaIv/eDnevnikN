using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eDnevnikN.Models
{
	public class Ucenici
	{
		public int ID { get; set; }
		public string Ime { get; set; }
		public string Prezime { get; set; }
		public string Adresa { get; set; }
		public DateTime DatumRodjenja { get; set; }
		public DateTime GodinaUpisa { get; set; }
		public int RedBrUOdeljenju { get; set; }

		public virtual ICollection<Ucen_Predm_Ocena> Ucen_Predm_Ocenas { get; set; }
	}
}