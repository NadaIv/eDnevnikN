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
    public class OdeljenjaController : Controller
    {
        private SchoolContext db = new SchoolContext();

		// GET: Odeljenja

		public ActionResult Index()
		{
			
			return View();
			
		}

		public ActionResult IndexProf()
		{

			return View();

		}

		public ActionResult GetOdeljenjas()
		{
			using (SchoolContext db = new SchoolContext())
			{

				var odelj = (from o in db.Odeljenjas
							 join p in db.Profesoris
							 on o.ProfesoriID equals p.ID
							 join g in db.Godines
							 on o.GodineID equals g.GodineID
							 join sg in db.SkolskaGodinas
							 on o.SkolskaGodinaID equals sg.SkolskaGodinaID
							 select new {
								 o.OdeljenjaID,
								 o.GodineID,
								 o.BrojOdeljenja,
								 o.SkolskaGodinaID,
								 g.Opis,
								 sg.Opis_sg,
								 p.Ime,
								 p.Prezime
							 }).ToList();


				return Json(new { data = odelj }, JsonRequestBehavior.AllowGet);
				


				}
			}

		//public ActionResult Index()
		//{
		//    var odeljenjas = db.Odeljenjas.Include(o => o.Profesori);
		//    return View(odeljenjas.ToList());
		//}

		// GET: Odeljenja/Details/5
		public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Odeljenja odeljenja = db.Odeljenjas.Find(id);
            if (odeljenja == null)
            {
                return HttpNotFound();
            }
            return View(odeljenja);
        }

        // GET: Odeljenja/Create
        public ActionResult Create()
        {
            ViewBag.ProfesoriID = new SelectList(db.Profesoris, "ID", "ImeIPrezime");
			ViewBag.SkolskaGodinaID = new SelectList(db.SkolskaGodinas, "SkolskaGodinaID", "Opis_sg");
			ViewBag.GodineID = new SelectList(db.Godines, "GodineID", "Opis");
			return View();
        }

        // POST: Odeljenja/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OdeljenjaID,GodineID,BrojOdeljenja,SkolskaGodinaID,ProfesoriID")] Odeljenja odeljenja)
        {
            if (ModelState.IsValid)
            {
                db.Odeljenjas.Add(odeljenja);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProfesoriID = new SelectList(db.Profesoris, "ID", "ImeIPrezime", odeljenja.ProfesoriID);
			ViewBag.SkolskaGodinaID = new SelectList(db.SkolskaGodinas, "SkolskaGodinaID", "Opis_sg");
			ViewBag.GodineID = new SelectList(db.Godines, "GodineID", "Opis");
			return View(odeljenja);
        }

        // GET: Odeljenja/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Odeljenja odeljenja = db.Odeljenjas.Find(id);
            if (odeljenja == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProfesoriID = new SelectList(db.Profesoris, "ID", "ImeIPrezime", odeljenja.ProfesoriID);
			ViewBag.SkolskaGodinaID = new SelectList(db.SkolskaGodinas, "SkolskaGodinaID", "Opis_sg");
			ViewBag.GodineID = new SelectList(db.Godines, "GodineID", "Opis");
			return View(odeljenja);
        }

        // POST: Odeljenja/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OdeljenjaID,GodineID,BrojOdeljenja,SkolskaGodinaID,ProfesoriID")] Odeljenja odeljenja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(odeljenja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProfesoriID = new SelectList(db.Profesoris, "ID", "ImeIPrezime", odeljenja.ProfesoriID);
			ViewBag.SkolskaGodinaID = new SelectList(db.SkolskaGodinas, "SkolskaGodinaID", "Opis_sg");
			ViewBag.GodineID = new SelectList(db.Godines, "GodineID", "Opis");
			return View(odeljenja);
        }

        // GET: Odeljenja/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Odeljenja odeljenja = db.Odeljenjas.Find(id);
            if (odeljenja == null)
            {
                return HttpNotFound();
            }
            return View(odeljenja);
        }

        // POST: Odeljenja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Odeljenja odeljenja = db.Odeljenjas.Find(id);
            db.Odeljenjas.Remove(odeljenja);
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
