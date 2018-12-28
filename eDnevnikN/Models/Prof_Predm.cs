using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eDnevnikN.Models
{
	public class Prof_Predm
	{
		public int Prof_PredmID { get; set; }
		public int ProfesoriID { get; set; }
		public int PredmetiID { get; set; }


		public virtual Profesori Profesori { get; set; }
		public virtual Predmeti Predmeti { get; set; }
		
	}
}