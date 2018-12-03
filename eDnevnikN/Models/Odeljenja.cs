using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eDnevnikN.Models
{
	public class Odeljenja
	{
		public int OdeljenjaID { get; set; }

		[Required]
		[StringLength(50, ErrorMessage = "Ne može biti duže od 50 karaktera.")]
		public string Razred { get; set; }

		[Required]
		[StringLength(50, ErrorMessage = "Ne može biti duže od 50 karaktera.")]
		public string BrojOdeljenja { get; set; }

		
		public string GodinaUpisa { get; set; }

		public int ProfesoriID { get; set; }

		[Display(Name = "Maticni broj odeljenja")]
		public string MatBrOdeljenja
		{
			get
			{
				return Razred + "/" + BrojOdeljenja + "/" + GodinaUpisa;
			}
		}

		public virtual Profesori Profesori { get; set; }
	}
}