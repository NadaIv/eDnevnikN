using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eDnevnikN.Models
{
	public class Ucenici
	{
		[DisplayName("ID ucenika")]
		public int ID { get; set; }

		[Required]
		[StringLength(50, ErrorMessage = "Ne može biti duže od 50 karaktera.")]
		public string Ime { get; set; }

		[Required]
		[StringLength(50, ErrorMessage = "Ne može biti duže od 50 karaktera.")]
		public string Prezime { get; set; }


		[StringLength(50, ErrorMessage = "Ne može biti duže od 50 karaktera.")]
		public string Adresa { get; set; }

		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		//public string FormattedDate => DatumRodjenja.ToShortDateString();
		[Display(Name = "Datum rodjenja")]
		public DateTime DatumRodjenja { get; set; }

	
		public int SkolskaGodinaID { get; set; }

		[DisplayName("Redni broj u odeljenju")]
		public int RedBrUOdeljenju { get; set; }

		[Display(Name = "Ime i prezime")]
		public string ImeIPrezime
		{
			get
			{
				return Ime + " " + Prezime;
			}
		}

		public virtual ICollection<Ucen_Predm_Ocena> Ucen_Predm_Ocenas { get; set; }
		public virtual SkolskaGodina SkolskaGodina { get; set; }
	}
}