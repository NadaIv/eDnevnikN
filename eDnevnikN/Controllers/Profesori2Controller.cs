//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using eDnevnikN.DAL;
//using eDnevnikN.Models;
//using eDnevnikN.ViewModels;

//namespace eDnevnikN.Controllers
//{
//    public class Profesori2Controller : Controller
//    {
//        private SchoolContext db = new SchoolContext();

//        // GET: Profesori2
//        public ActionResult Index()
//        {
//			return View();

//		}

//		public ActionResult GetProfesoris(int? predmetiID)
//		{
//			using (SchoolContext db = new SchoolContext())
//			{

//				//var viewModel = new ProfesoriIndexData();
//				//viewModel.Profesoris = db.Profesoris
//				//	.Include(i => i.Predmetis.Select(c => c.Godine))
//				//	.OrderBy(i => i.Ime);

//				//if (id != null)
//				//{
//				//	ViewBag.ProfesoriID = id.Value;
//				//	viewModel.Predmetis = viewModel.Profesoris.Where(
//				//		i => i.ID == id.Value).Single().Predmetis;
//				//}

//				//if (predmetiID != null)
//				//{
//				//	ViewBag.PredmetiID = predmetiID.Value;



//				//	// Explicit loading
//				//	var selectedPredmeti = viewModel.Predmetis.Where(x => x.PredmetiID == predmetiID).Single();
//				//	db.Entry(selectedPredmeti).Collection(x => x.Ucen_Predm_Ocenas).Load();
//				//	foreach (Ucen_Predm_Ocena ucen_Predm_Ocena in selectedPredmeti.Ucen_Predm_Ocenas)
//				//	{
//				//		db.Entry(ucen_Predm_Ocena).Reference(x => x.Ucenici).Load();
//				//	}

//				//	viewModel.Ucen_Predm_Ocenas = selectedPredmeti.Ucen_Predm_Ocenas;
//				//}

//				//var profPr = from e in db.Profesoris  from p in db.Predmetis select e ;


//				db.Profesoris.Where(s => s.Predmetis.Any(c => c.PredmetiID == predmetiID));

////or without the Any method
//			var profPr = from s in db.Profesoris
//from c in s.Predmetis
//where c.PredmetiID == predmetiID
//select s;

//				//var profPr = (from profesori in db.Profesoris
//				//			  from predmeti in profesori.Predmetis
//				//			  select new
//				//			  {
//				//				  profesori.Ime,
//				//				 profesori.Prezime,
//				//				 profesori.KorisnickoIme,
//				//				profesori.Lozinka,
//				//				profesori.Status,
//				//				  predmeti.PredmetiID,
//				//				  predmeti.NazivPredmeta
//				//			  }).ToList();


//				//var profPr = (from p in db.Profesoris
//				//			  join o in db.Predmetis
//				//			  on p.ID equals o.PredmetiID
//				//			  select new
//				//			  {

//				//				  p.Ime,
//				//				  p.Prezime,
//				//				  p.KorisnickoIme,
//				//				  p.Lozinka,
//				//				 p.Status,

//				//				o.NazivPredmeta
//				//			  }).ToList();



//				//var profPr = db.Profesoris.Where(p=>p.ID==1 ).SelectMany(p=>p.Predmetis).ToList();


//				//var profPr = (from o in db.Profesoris
//				//			 join p in db.Predm_Profs
//				//			 on o.ID equals p.ProfesoriID
//				//			 join s in db.Predmetis 
//				//			 on p.PredmetiID equals s.PredmetiID
//				//			 select new { o.ID, o.Ime, o.Prezime,o.KorisnickoIme,o.Lozinka,o.Status,
//				//   s.PredmetiID, s.NazivPredmeta}).ToList();


//				return Json(new { data = profPr }, JsonRequestBehavior.AllowGet);



//			}
//		}

//		// GET: Profesori2/Details/5
//		public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Profesori profesori = db.Profesoris.Find(id);
//            if (profesori == null)
//            {
//                return HttpNotFound();
//            }
//            return View(profesori);
//        }

//        // GET: Profesori2/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: Profesori2/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "ID,Ime,Prezime,KorisnickoIme,Lozinka,Status")] Profesori profesori)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Profesoris.Add(profesori);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            return View(profesori);
//        }

//        // GET: Profesori2/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Profesori profesori = db.Profesoris.Find(id);
//            if (profesori == null)
//            {
//                return HttpNotFound();
//            }
//            return View(profesori);
//        }

//        // POST: Profesori2/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "ID,Ime,Prezime,KorisnickoIme,Lozinka,Status")] Profesori profesori)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(profesori).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(profesori);
//        }

//        // GET: Profesori2/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Profesori profesori = db.Profesoris.Find(id);
//            if (profesori == null)
//            {
//                return HttpNotFound();
//            }
//            return View(profesori);
//        }

//        // POST: Profesori2/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            Profesori profesori = db.Profesoris.Find(id);
//            db.Profesoris.Remove(profesori);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}


using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using eDnevnikN.DAL;
using eDnevnikN.Models;
using eDnevnikN.ViewModels;

namespace eDnevnikN.Controllers
{
	public class Profesori2Controller : Controller
	{
		private SchoolContext db = new SchoolContext();
		

		// GET: Profesori1
		//public ActionResult Index(int? id, int? predmetiID)
		//{
		//	var viewModel = new ProfesoriIndexData();

		//	viewModel.Profesoris = db.Profesoris
		//		.Include(i => i.Predmetis.Select(c => c.Godine))
		//		.OrderBy(i => i.Ime);

		//	if (id != null)
		//	{
		//		ViewBag.ProfesoriID = id.Value;
		//		viewModel.Predmetis = viewModel.Profesoris.Where(
		//			i => i.ID == id.Value).Single().Predmetis;
		//	}

		//	if (predmetiID != null)
		//	{
		//		ViewBag.PredmetiID = predmetiID.Value;



		//		// Explicit loading
		//		var selectedPredmeti = viewModel.Predmetis.Where(x => x.PredmetiID == predmetiID).Single();
		//		db.Entry(selectedPredmeti).Collection(x => x.Ucen_Predm_Ocenas).Load();
		//		foreach (Ucen_Predm_Ocena ucen_Predm_Ocena in selectedPredmeti.Ucen_Predm_Ocenas)
		//		{
		//			db.Entry(ucen_Predm_Ocena).Reference(x => x.Ucenici).Load();
		//		}

		//		viewModel.Ucen_Predm_Ocenas = selectedPredmeti.Ucen_Predm_Ocenas;
		//	}

		//	return View(viewModel);
		//}

		public ActionResult Index()
        {
			return View();
		}

		public ActionResult GetProfesoris(int? id, int? predmetiID)
		{

			using (SchoolContext db = new SchoolContext())
			{

				//foreach (var v in odelj)
				//{
				//	System.Diagnostics.Debug.WriteLine(v.p.Ime + v.p.Prezime + v.p.KorisnickoIme + v.p.Lozinka + v.p.Status );

				//	foreach (var s in v.o.Profesoris)
				//	{
				//		System.Diagnostics.Debug.WriteLine(s.Predmetis);
				//	}

				//}
				var odelj = (from p in db.Profesoris
							 join o in db.Predmetis
							 on p.Ime equals o.NazivPredmeta into ps
							 from pp in ps.DefaultIfEmpty()
							 orderby p.Prezime
							 select new
							 {
								 p.ID,
								 p.Ime,
								 p.Prezime,
								 p.KorisnickoIme,
								 p.Lozinka,
								 p.Status,
								 pp.NazivPredmeta
							 }).ToList();



				return Json(new { data = odelj }, JsonRequestBehavior.AllowGet);


			}
		}



		// GET: Profesori1/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Profesori profesori = db.Profesoris.Find(id);
			if (profesori == null)
			{
				return HttpNotFound();
			}
			return View(profesori);
		}

		// GET: Profesori1/Create
		public ActionResult Create()
		{
			var profesori = new Profesori();
			profesori.Predmetis = new List<Predmeti>();
			PopDodelaPredmProf(profesori);
			return View();
		}

		// POST: Profesori1/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "Ime,Prezime,KorisnickoIme,Lozinka,Status")] Profesori profesori)
		{
			if (ModelState.IsValid)
			{
				db.Profesoris.Add(profesori);
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			PopDodelaPredmProf(profesori);
			return View(profesori);
		}

		// GET: Profesori1/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Profesori profesori = db.Profesoris
				.Include(i => i.Predmetis)
				.Where(i => i.ID == id)
				.Single();
			PopDodelaPredmProf(profesori);
			if (profesori == null)
			{
				return HttpNotFound();
			}
			return View(profesori);
		}

		private void PopDodelaPredmProf(Profesori profesori)
		{
			var allPredmeti = db.Predmetis;
			var profPredm = new HashSet<int>(profesori.Predmetis.Select(c => c.PredmetiID));
			var viewModel = new List<DodelaPredmProf>();
			foreach (var predmeti in allPredmeti)
			{
				viewModel.Add(new DodelaPredmProf
				{
					PredmetiID = predmeti.PredmetiID,
					NazivPredmeta = predmeti.NazivPredmeta,
					Dodela = profPredm.Contains(predmeti.PredmetiID)
				});
			}
			ViewBag.Predmeti = viewModel;
		}

		// POST: Profesori1/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int? id, string[] selectedPredmeti)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var profesoriToUpdate = db.Profesoris
			   .Include(i => i.Predmetis)
			   .Where(i => i.ID == id)
			   .Single();

			if (TryUpdateModel(profesoriToUpdate, "",
			   new string[] { "Ime", "Prezime", "KorisnickoIme", "Lozinka", "Status" }))
			{
				try
				{

					UpdateProfPredm(selectedPredmeti, profesoriToUpdate);

					db.SaveChanges();

					return RedirectToAction("Index");
				}
				catch (RetryLimitExceededException /* dex */)
				{
					//Log the error (uncomment dex variable name and add a line here to write a log.
					ModelState.AddModelError("", "Nije moguće sačuvati izmene. Pokušajte ponovo, a ako se problem i dalje ponavlja, pozovite svog administratora sistema.");
				}
			}
			PopDodelaPredmProf(profesoriToUpdate);
			return View(profesoriToUpdate);
		}
		private void UpdateProfPredm(string[] selectedPredmeti, Profesori profesoriToUpdate)
		{
			if (selectedPredmeti == null)
			{
				profesoriToUpdate.Predmetis = new List<Predmeti>();
				return;
			}

			var selectedPredmetiHS = new HashSet<string>(selectedPredmeti);
			var profesoriPredmeti = new HashSet<int>
				(profesoriToUpdate.Predmetis.Select(c => c.PredmetiID));
			foreach (var predmeti in db.Predmetis)
			{
				if (selectedPredmetiHS.Contains(predmeti.PredmetiID.ToString()))
				{
					if (!profesoriPredmeti.Contains(predmeti.PredmetiID))
					{
						profesoriToUpdate.Predmetis.Add(predmeti);
					}
				}
				else
				{
					if (profesoriPredmeti.Contains(predmeti.PredmetiID))
					{
						profesoriToUpdate.Predmetis.Remove(predmeti);
					}
				}
			}
		}

		// GET: Profesori1/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Profesori profesori = db.Profesoris.Find(id);
			if (profesori == null)
			{
				return HttpNotFound();
			}
			return View(profesori);
		}

		// POST: Profesori1/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Profesori profesori = db.Profesoris.Find(id);
			db.Profesoris.Remove(profesori);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
