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
    public class UceniciController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: Ucenici
        public ActionResult Index()
        {
			var ucenicis = db.Ucenicis.Include(u => u.SkolskaGodina);
			return View(db.Ucenicis.ToList());
        }

        // GET: Ucenici/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ucenici ucenici = db.Ucenicis.Find(id);
            if (ucenici == null)
            {
                return HttpNotFound();
            }
            return View(ucenici);
        }

        // GET: Ucenici/Create
        public ActionResult Create()
        {
			ViewBag.SkolskaGodinaID = new SelectList(db.SkolskaGodinas, "SkolskaGodinaID", "Opis");
			return View();
        }

        // POST: Ucenici/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Ime,Prezime,Adresa,DatumRodjenja,SkolskaGodinaID,RedBrUOdeljenju")] Ucenici ucenici)
        {
			try
			{
				if (ModelState.IsValid)
            {
                db.Ucenicis.Add(ucenici);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
			}
			catch (DataException /* dex */)
			{
				//Log the error (uncomment dex variable name and add a line here to write a log.
				ModelState.AddModelError("", "Nije moguće sačuvati izmene. Pokušajte ponovo, i ako problem i dalje postoji, pozovite svog administratora sistema.");
			}
			ViewBag.SkolskaGodinaID = new SelectList(db.SkolskaGodinas, "SkolskaGodinaID", "Opis", ucenici.SkolskaGodinaID);

			return View(ucenici);
        }

		// GET: Ucenici/Edit/5


		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Ucenici ucenici = db.Ucenicis.Find(id);
			if (ucenici == null)
			{
				return HttpNotFound();
			}
			ViewBag.SkolskaGodinaID = new SelectList(db.SkolskaGodinas, "SkolskaGodinaID", "Opis", ucenici.SkolskaGodinaID);
			return View(ucenici);
		}

		// POST: Ucenici/Edit/5
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
			var uceniciToUpdate = db.Ucenicis.Find(id);
			if (TryUpdateModel(uceniciToUpdate, "",
			   new string[] { "Ime", "Prezime", "Adresa","DatumRodjenja", "GodinaUpisa","RedBrUOdeljenju" }))
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
			return View(uceniciToUpdate);
		}

		//[HttpPost]
		//      [ValidateAntiForgeryToken]
		//      public ActionResult Edit([Bind(Include = "ID,Ime,Prezime,Adresa,DatumRodjenja,GodinaUpisa,RedBrUOdeljenju")] Ucenici ucenici)
		//      {
		//          if (ModelState.IsValid)
		//          {
		//              db.Entry(ucenici).State = EntityState.Modified;
		//              db.SaveChanges();
		//              return RedirectToAction("Index");
		//          }
		//          return View(ucenici);
		//      }

		// GET: Ucenici/Delete/5

		public ActionResult Delete(int? id, bool? saveChangesError = false)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			if (saveChangesError.GetValueOrDefault())
			{
				ViewBag.ErrorMessage = "Brisanje nije uspelo. Pokušajte ponovo, i ako problem i dalje postoji, pozovite svog administratora sistema.";
			}
			Ucenici ucenici = db.Ucenicis.Find(id);
			if (ucenici == null)
			{
				return HttpNotFound();
			}
			return View(ucenici);
		}

		//public ActionResult Delete(int? id)
		//      {
		//          if (id == null)
		//          {
		//              return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
		//          }
		//          Ucenici ucenici = db.Ucenicis.Find(id);
		//          if (ucenici == null)
		//          {
		//              return HttpNotFound();
		//          }
		//          return View(ucenici);
		//      }

		// POST: Ucenici/Delete/5

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id)
		{
			try
			{
				Ucenici ucenici = db.Ucenicis.Find(id);
				db.Ucenicis.Remove(ucenici);
				db.SaveChanges();
			}
			catch (DataException/* dex */)
			{
				//Log the error (uncomment dex variable name and add a line here to write a log.
				return RedirectToAction("Delete", new { id = id, saveChangesError = true });
			}
			return RedirectToAction("Index");
		}

		//[HttpPost, ActionName("Delete")]
		//      [ValidateAntiForgeryToken]
		//      public ActionResult DeleteConfirmed(int id)
		//      {
		//          Ucenici ucenici = db.Ucenicis.Find(id);
		//          db.Ucenicis.Remove(ucenici);
		//          db.SaveChanges();
		//          return RedirectToAction("Index");
		//      }

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
