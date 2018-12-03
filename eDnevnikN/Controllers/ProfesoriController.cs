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
    public class ProfesoriController : Controller
    {
        private SchoolContext db = new SchoolContext();

		// GET: Profesori
		//public ActionResult Index()
		//{
		//    return View(db.Profesoris.ToList());
		//}

		public ActionResult Index()
		{
			return View();
		}


		public ActionResult GetProfesoris()
		{
			using (SchoolContext db = new SchoolContext())
			{
				db.Configuration.LazyLoadingEnabled = false;
				var profesoris = db.Profesoris.OrderBy(a => a.Ime).ToList();
				return Json(new { data = profesoris }, JsonRequestBehavior.AllowGet);
			}
		}

		// GET: Profesori/Details/5
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

        // GET: Profesori/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profesori/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Ime,Prezime,KorisnickoIme,Lozinka,Status")] Profesori profesori)
        {
			try
			{
				if (ModelState.IsValid)
            {
                db.Profesoris.Add(profesori);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
			}
			catch (DataException /* dex */)
			{
				//Prijavi gresku

				ModelState.AddModelError("", "Ne mogu da sacuvam promene. Pokusajte ponovo,a ako se problem i dalje javlja, obratite se administratoru.");
			}

			return View(profesori);
        }

        // GET: Profesori/Edit/5
        public ActionResult Edit(int? id)
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

		// POST: Profesori/Edit/5
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
			var profesoriToUpdate = db.Profesoris.Find(id);
			if (TryUpdateModel(profesoriToUpdate, "",
			   new string[] { "Ime", "Prezime", "KorisnickoIme", "Lozinka", "Status" }))
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
			return View(profesoriToUpdate);
		}

		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public ActionResult Edit([Bind(Include = "Ime,Prezime,KorisnickoIme,Lozinka,Status")] Profesori profesori)
		//{
		//    if (ModelState.IsValid)
		//    {
		//        db.Entry(profesori).State = EntityState.Modified;
		//        db.SaveChanges();
		//        return RedirectToAction("Index");
		//    }
		//    return View(profesori);
		//}

		// GET: Profesori/Delete/5
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
			Profesori profesori = db.Profesoris.Find(id);
            if (profesori == null)
            {
                return HttpNotFound();
            }
            return View(profesori);
        }

        // POST: Profesori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
			try
			{
				Profesori profesori = db.Profesoris.Find(id);
            db.Profesoris.Remove(profesori);
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
