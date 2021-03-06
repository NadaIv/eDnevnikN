﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eDnevnikN.Models
{
	public class Predmeti
	{
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		[DisplayName("Sifra predmeta")]
		public int PredmetiID { get; set; }

		[StringLength(50, ErrorMessage = "Ne može biti duže od 50 karaktera.")]
		[DisplayName("Naziv predmeta")]
		public string NazivPredmeta { get; set; }
		
	
		public int GodineID { get; set; }

		public int Redosled { get; set; }



		public virtual ICollection<Ucen_Predm_Ocena> Ucen_Predm_Ocenas { get; set; }
		public virtual Godine Godine { get; set; }
		public virtual ICollection<Profesori> Profesoris { get; set; }
	}
}