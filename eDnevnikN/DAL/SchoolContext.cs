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
		public DbSet<Godine> Godines { get; set; }
		public DbSet<SkolskaGodina> SkolskaGodinas { get; set; }
		public DbSet<Prof_Predm> Prof_Predms { get; set; }
		


		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

			//modelBuilder.Entity<Predmeti>()
			//.HasMany(c => c.Profesoris).WithMany(i => i.Predmetis)
			//.Map(t => t.MapLeftKey("PredmetiID")
			//	.MapRightKey("ProfesoriID")
			//	.ToTable("Predm_Prof"));
		}


	}
}