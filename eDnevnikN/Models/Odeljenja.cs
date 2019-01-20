using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eDnevnikN.Models
{
	public class Odeljenja
	{
		[DisplayName("ID odeljenja")]
		public int OdeljenjaID { get; set; }
		
		
		public int GodineID { get; set; }

		[Required]
		[StringLength(50, ErrorMessage = "Ne može biti duže od 50 karaktera.")]
		[DisplayName("Broj odeljenja")]
		public string BrojOdeljenja { get; set; }

		
		public int SkolskaGodinaID { get; set; }

		
		public int ProfesoriID { get; set; }

		[Display(Name = "Maticni broj odeljenja")]
		public string MatBrOdeljenja
		{
			get
			{
				return GodineID + "/" + BrojOdeljenja + "/" + SkolskaGodinaID;
			}
		}

		public virtual Profesori Profesori { get; set; }
		public virtual Godine Godine { get; set; }
		public virtual SkolskaGodina SkolskaGodina { get; set; }
	}
}