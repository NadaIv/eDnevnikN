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
    public class SkolskaGodinaController : Controller
    {
        private SchoolContext db = new SchoolContext();

		// GET: SkolskaGodina
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult IndexProf()
		{
			return View();
		}

		public ActionResult GetSkolskaGodinas()
		{
			using (SchoolContext db = new SchoolContext())
			{
				db.Configuration.LazyLoadingEnabled = false;
				var skolskaGodinas = db.SkolskaGodinas.OrderBy(a => a.Opis_sg).ToList();
				return Json(new { data = skolskaGodinas }, JsonRequestBehavior.AllowGet);
			}
		}

		// GET: SkolskaGodina/Details/5
		public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SkolskaGodina skolskaGodina = db.SkolskaGodinas.Find(id);
            if (skolskaGodina == null)
            {
                return HttpNotFound();
            }
            return View(skolskaGodina);
        }

        // GET: SkolskaGodina/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SkolskaGodina/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Opis_sg")] SkolskaGodina skolskaGodina)
        {
			try
			{
				if (ModelState.IsValid)
            {
                db.SkolskaGodinas.Add(skolskaGodina);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
			}
			catch (DataException /* dex */)
			{
				//Prijavi gresku

				ModelState.AddModelError("", "Ne mogu da sacuvam promene. Pokusajte ponovo,a ako se problem i dalje javlja, obratite se administratoru.");
			}

			return View(skolskaGodina);
        }

        // GET: SkolskaGodina/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SkolskaGodina skolskaGodina = db.SkolskaGodinas.Find(id);
            if (skolskaGodina == null)
            {
                return HttpNotFound();
            }
            return View(skolskaGodina);
        }

		// POST: SkolskaGodina/Edit/5
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
			var skgodinaToUpdate = db.SkolskaGodinas.Find(id);
			if (TryUpdateModel(skgodinaToUpdate, "",
			   new string[] {  "Opis_sg" }))
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
			return View(skgodinaToUpdate);
		}

        // GET: SkolskaGodina/Delete/5
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
			SkolskaGodina skolskaGodina = db.SkolskaGodinas.Find(id);
            if (skolskaGodina == null)
            {
                return HttpNotFound();
            }
            return View(skolskaGodina);
        }

        // POST: SkolskaGodina/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
			try
			{
				SkolskaGodina skolskaGodina = db.SkolskaGodinas.Find(id);
            db.SkolskaGodinas.Remove(skolskaGodina);
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
