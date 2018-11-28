using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eDnevnikN.Models
{
	public class Predmeti
	{
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int PredmetiID { get; set; }
		public string NazivPredmeta { get; set; }
		public int Redosled { get; set; }

		public virtual ICollection<Ucen_Predm_Ocena> Ucen_Predm_Ocenas { get; set; }
	}
}