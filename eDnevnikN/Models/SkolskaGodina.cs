﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eDnevnikN.Models
{
	public class SkolskaGodina
	{
		[DisplayName("ID skolske godine")]
		public int SkolskaGodinaID { get; set; }

		[StringLength(4, ErrorMessage = "Ne može biti duže od 4 karaktera.")]
		[DisplayName("Opis")]
		public string Opis_sg { get; set; }


		public virtual ICollection<Odeljenja> Odeljenjas { get; set; }
	//	public virtual ICollection<Ucenici> Ucenicis { get; set; }


	}
}