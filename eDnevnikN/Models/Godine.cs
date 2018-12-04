using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eDnevnikN.Models
{
	public class Godine
	{
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int GodineID { get; set; }

		[StringLength(20, ErrorMessage = "Ne može biti duže od 20 karaktera.")]
		public string Opis { get; set; }
		

		public virtual ICollection<Odeljenja> Odeljenjas { get; set; }
		public virtual ICollection<Predmeti> Predmetis { get; set; }
	}
}