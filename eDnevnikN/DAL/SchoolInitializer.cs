using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using eDnevnikN.Models;

namespace eDnevnikN.DAL
{
	public class SchoolInitializer : DropCreateDatabaseIfModelChanges<SchoolContext>
	{
		protected override void Seed(SchoolContext context)
		{
			var ucenicis = new List<Ucenici>
			{
			new Ucenici{Prezime="Nedic",Ime="Neda",Adresa="M.Tita bb",DatumRodjenja=DateTime.Parse("2005-09-01"),GodinaUpisa=DateTime.Parse("2017-09-01"), RedBrUOdeljenju=1},
			new Ucenici{Prezime="Milic",Ime="Mila",Adresa="M.Tita bb",DatumRodjenja=DateTime.Parse("2006-09-01"),GodinaUpisa=DateTime.Parse("2017-09-01"), RedBrUOdeljenju=2},
			new Ucenici{Prezime="Peric",Ime="Pera",Adresa="M.Tita bb",DatumRodjenja=DateTime.Parse("2000-09-01"),GodinaUpisa=DateTime.Parse("2017-09-01"), RedBrUOdeljenju=3},
			new Ucenici{Prezime="Jovic",Ime="Jovan",Adresa="M.Tita bb",DatumRodjenja=DateTime.Parse("2005-09-01"),GodinaUpisa=DateTime.Parse("2017-09-01"), RedBrUOdeljenju=4},
			new Ucenici{Prezime="Ilic",Ime="Ilija",Adresa="M.Tita bb",DatumRodjenja=DateTime.Parse("2004-09-01"),GodinaUpisa=DateTime.Parse("2018-09-01"), RedBrUOdeljenju=5},
			new Ucenici{Prezime="Milic",Ime="Milan",Adresa="M.Tita bb",DatumRodjenja=DateTime.Parse("2005-12-01"),GodinaUpisa=DateTime.Parse("2018-09-01"), RedBrUOdeljenju=6},
			new Ucenici{Prezime="Ivic",Ime="Ivana",Adresa="M.Tita bb",DatumRodjenja=DateTime.Parse("2005-10-01"),GodinaUpisa=DateTime.Parse("2018-09-01"), RedBrUOdeljenju=7},
			new Ucenici{Prezime="Zoric",Ime="Zorana",Adresa="M.Tita bb",DatumRodjenja=DateTime.Parse("2005-01-01"),GodinaUpisa=DateTime.Parse("2018-09-01"), RedBrUOdeljenju=8},
			};

			ucenicis.ForEach(s => context.Ucenicis.Add(s));
			context.SaveChanges();

			var predmetis = new List<Predmeti>
			{
			new Predmeti{PredmetiID=1050,NazivPredmeta="Srpski jezik i knjizevnost",Redosled=1,},
			new Predmeti{PredmetiID=4022,NazivPredmeta="Engleski jezik",Redosled=2,},
			new Predmeti{PredmetiID=4041,NazivPredmeta="Psihologija",Redosled=3,},
			new Predmeti{PredmetiID=1045,NazivPredmeta="Filozofija",Redosled=4,},
			new Predmeti{PredmetiID=3141,NazivPredmeta="Istorija",Redosled=5,},
			new Predmeti{PredmetiID=2021,NazivPredmeta="Fizika",Redosled=6,},
			new Predmeti{PredmetiID=2042,NazivPredmeta="Hemija",Redosled=7,},
			};

			predmetis.ForEach(s => context.Predmetis.Add(s));
			context.SaveChanges();

			var ucen_Predm_Ocenas = new List<Ucen_Predm_Ocena>
			{
			new Ucen_Predm_Ocena{PredmetiID=1050,UceniciID=1,Ocene=Ocene.Nedovoljan,DatumOcenjivanja=DateTime.Parse("2017-11-02")},
			new Ucen_Predm_Ocena{PredmetiID=4022,UceniciID=1,Ocene=Ocene.Dobar,DatumOcenjivanja=DateTime.Parse("2017-11-02")},
			new Ucen_Predm_Ocena{PredmetiID=4041,UceniciID=1,Ocene=Ocene.Dovoljan,DatumOcenjivanja=DateTime.Parse("2017-11-02")},
			new Ucen_Predm_Ocena{PredmetiID=1045,UceniciID=2,Ocene=Ocene.Dovoljan,DatumOcenjivanja=DateTime.Parse("2017-11-02")},
			new Ucen_Predm_Ocena{PredmetiID=3141,UceniciID=2,Ocene=Ocene.Vrlodobar,DatumOcenjivanja=DateTime.Parse("2017-11-02")},
			new Ucen_Predm_Ocena{PredmetiID=2021,UceniciID=2,Ocene=Ocene.Vrlodobar,DatumOcenjivanja=DateTime.Parse("2017-11-02")},
			new Ucen_Predm_Ocena{PredmetiID=1050,UceniciID=3,DatumOcenjivanja=DateTime.Parse("2017-11-02")},
			new Ucen_Predm_Ocena{PredmetiID=1050,UceniciID=4,DatumOcenjivanja=DateTime.Parse("2017-11-02")},
			new Ucen_Predm_Ocena{PredmetiID=4022,UceniciID=4,Ocene=Ocene.Odlican,DatumOcenjivanja=DateTime.Parse("2017-11-02")},
			new Ucen_Predm_Ocena{PredmetiID=4041,UceniciID=5,Ocene=Ocene.Odlican,DatumOcenjivanja=DateTime.Parse("2017-11-02")},
			new Ucen_Predm_Ocena{PredmetiID=1045,UceniciID=6,DatumOcenjivanja=DateTime.Parse("2017-11-02")},
			new Ucen_Predm_Ocena{PredmetiID=3141,UceniciID=7,Ocene=Ocene.Nedovoljan,DatumOcenjivanja=DateTime.Parse("2017-11-02")},
			};
			ucen_Predm_Ocenas.ForEach(s => context.Ucen_Predm_Ocenas.Add(s));
			context.SaveChanges();
		}
	}
}