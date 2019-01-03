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

        // GET: Ucenici1
        public ActionResult Index()
        {  
            return View();
        }

		public ActionResult GetUcenicis()
		{
			using (SchoolContext db = new SchoolContext())
			{
				
				var ucen = (from o in db.Ucenicis
							 join p in db.SkolskaGodinas
							 on o.SkolskaGodinaID equals p.SkolskaGodinaID
							 select new { o.ID,
										  o.Ime,
							       	      o.Prezime,
								          o.Adresa,
								          o.DatumRodjenja,
								          o.RedBrUOdeljenju,
								          p.SkolskaGodinaID,
								          p.Opis_sg}).ToList();


				return Json(new { data = ucen }, JsonRequestBehavior.AllowGet);



			}
		}
		// GET: Ucenici1/Details/5
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
			ViewBag.SkolskaGodinaID = new SelectList(db.SkolskaGodinas, "SkolskaGodinaID", "Opis_sg");
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
			ViewBag.SkolskaGodinaID = new SelectList(db.SkolskaGodinas, "SkolskaGodinaID", "Opis_sg", ucenici.SkolskaGodinaID);

			return View(ucenici);
		}


		//// GET: Ucenici1/Create
		//public ActionResult Create()
		//{
		//    ViewBag.SkolskaGodinaID = new SelectList(db.SkolskaGodinas, "SkolskaGodinaID", "Opis");
		//    return View();
		//}

		//// POST: Ucenici1/Create
		//// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		//// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public ActionResult Create([Bind(Include = "ID,Ime,Prezime,Adresa,DatumRodjenja,SkolskaGodinaID,RedBrUOdeljenju")] Ucenici ucenici)
		//{
		//    if (ModelState.IsValid)
		//    {
		//        db.Ucenicis.Add(ucenici);
		//        db.SaveChanges();
		//        return RedirectToAction("Index");
		//    }

		//    ViewBag.SkolskaGodinaID = new SelectList(db.SkolskaGodinas, "SkolskaGodinaID", "Opis", ucenici.SkolskaGodinaID);
		//    return View(ucenici);
		//}

		// GET: Ucenici1/Edit/5
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
            ViewBag.SkolskaGodinaID = new SelectList(db.SkolskaGodinas, "SkolskaGodinaID", "Opis_sg", ucenici.SkolskaGodinaID);
            return View(ucenici);
        }

        // POST: Ucenici1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Ime,Prezime,Adresa,DatumRodjenja,SkolskaGodinaID,RedBrUOdeljenju")] Ucenici ucenici)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ucenici).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SkolskaGodinaID = new SelectList(db.SkolskaGodinas, "SkolskaGodinaID", "Opis_sg", ucenici.SkolskaGodinaID);
            return View(ucenici);
        }

        // GET: Ucenici1/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Ucenici1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ucenici ucenici = db.Ucenicis.Find(id);
            db.Ucenicis.Remove(ucenici);
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
