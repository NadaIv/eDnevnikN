using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using eDnevnikN.DAL;
using eDnevnikN.Models;

namespace eDnevnikN.Controllers
{
    public class PredmetiController : Controller
    {
        private SchoolContext db = new SchoolContext();

		// GET: Predmeti

		public ActionResult Index()
		{
			return View();
		}


		public ActionResult GetPredmetis()
		{
			using (SchoolContext db = new SchoolContext())
			{

				var predmetis = (from p in db.Predmetis
								 join g in db.Godines
								 on p.GodineID equals g.GodineID
								 select new
								 {
									 p.PredmetiID,
									 p.NazivPredmeta,
									 p.GodineID,
									 g.Opis,
									 p.Redosled
								 }).ToList();
											
								return Json(new { data = predmetis }, JsonRequestBehavior.AllowGet);
			}
		}

		

		// GET: Predmeti/Details/5
		public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Predmeti predmeti = db.Predmetis.Find(id);
            if (predmeti == null)
            {
                return HttpNotFound();
            }
            return View(predmeti);
        }

        // GET: Predmeti/Create
        public ActionResult Create()
        {
			ViewBag.GodineID = new SelectList(db.Godines, "GodineID", "Opis");
			return View();
        }

        // POST: Predmeti/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PredmetiID,NazivPredmeta,GodineID,Redosled")] Predmeti predmeti)
        {
			try
			{
				if (ModelState.IsValid)
				{
					db.Predmetis.Add(predmeti);
					db.SaveChanges();
					return RedirectToAction("Index");
				}
				ViewBag.GodineID = new SelectList(db.Godines, "GodineID", "Opis", predmeti.PredmetiID);
			}
			catch (DataException /* dex */)
			{
				//Prijavi gresku

				ModelState.AddModelError("", "Ne mogu da sacuvam promene. Pokusajte ponovo,a ako se problem i dalje javlja, obratite se administratoru.");
			}
			return View(predmeti);
        }

        // GET: Predmeti/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Predmeti predmeti = db.Predmetis.Find(id);
            if (predmeti == null)
            {
                return HttpNotFound();
            }
			ViewBag.GodineID = new SelectList(db.Godines, "GodineID", "Opis",predmeti.PredmetiID);
			return View(predmeti);
        }

		// POST: Predmeti/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.

		[HttpPost, ActionName("Edit")]
		[ValidateAntiForgeryToken]
		public ActionResult EditPost(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var predmetiToUpdate = db.Predmetis.Find(id);
			if (TryUpdateModel(predmetiToUpdate, "",
			   new string[] { "PredmetiID", "NazivPredmeta","GodineID", "Redosled" }))
			{
				try
				{
					db.SaveChanges();

					return RedirectToAction("Index");
				}
				catch (DataException /* dex */)
				{
					//Log the error (uncomment dex variable name and add a line here to write a log.
					ModelState.AddModelError("", "Nije moguće sačuvati izmene. Pokušajte ponovo, a ako se problem i dalje održi, pozovite svog administratora sistema.");
				}
			}
			return View(predmetiToUpdate);
		}

		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public ActionResult Edit([Bind(Include = "PredmetiID,NazivPredmeta,Redosled")] Predmeti predmeti)
		//{
		//    if (ModelState.IsValid)
		//    {
		//        db.Entry(predmeti).State = EntityState.Modified;
		//        db.SaveChanges();
		//        return RedirectToAction("Index");
		//    }
		//    return View(predmeti);
		//}

		// GET: Predmeti/Delete/5
		public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			if (saveChangesError.GetValueOrDefault())
			{
				ViewBag.ErrorMessage = "Brisanje nije uspelo. Pokušajte ponovo, i ako problem i dalje postoji, pozovite vaseg administratora sistema.";
			}
			Predmeti predmeti = db.Predmetis.Find(id);
            if (predmeti == null)
            {
                return HttpNotFound();
            }
            return View(predmeti);
        }

		// POST: Predmeti/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id)
		{
			try
			{
				Predmeti predmeti = db.Predmetis.Find(id);
				db.Predmetis.Remove(predmeti);
				db.SaveChanges();

			}
			catch (DataException/* dex */)
			{
				//Log the error (uncomment dex variable name and add a line here to write a log.
				return RedirectToAction("Delete", new { id = id, saveChangesError = true });
			}

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
