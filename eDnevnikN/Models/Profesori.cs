using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eDnevnikN.Models
{
	public class Profesori
	{
		public int ID { get; set; }

		[Required]
		[StringLength(50)]
		public string Ime { get; set; }

		[Required]
		[StringLength(50)]
		public string Prezime { get; set; }

		[Required]
		[DisplayName("Korisnicko ime")]
		[StringLength(50)]
		public string KorisnickoIme { get; set; }

		[Required]
		[StringLength(50)]
		[DataType(DataType.Password)]
		public string Lozinka { get; set; }

		[Required]
		[StringLength(50)]
		public string Status { get; set; }


		[Display(Name = "Ime i prezime")]
		public string ImeIPrezime
		{
			get { return Ime + " " + Prezime; }
		}

		
	}
}