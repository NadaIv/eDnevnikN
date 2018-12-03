using eDnevnikN.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace eDnevnikN.DAL
{
	public class SchoolContext : DbContext
	{
		public SchoolContext() : base("SchoolContext")
		{
		}

		public DbSet<Ucenici> Ucenicis { get; set; }
		public DbSet<Ucen_Predm_Ocena> Ucen_Predm_Ocenas { get; set; }
		public DbSet<Predmeti> Predmetis { get; set; }
		public DbSet<Profesori> Profesoris { get; set; }
		public DbSet<Odeljenja> Odeljenjas { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}

		
	}
}