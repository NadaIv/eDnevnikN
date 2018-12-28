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
    public class Prof_PredmController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: Prof_Predm
        public ActionResult Index()
        {
            var prof_Predms = db.Prof_Predms.Include(p => p.Predmeti).Include(p => p.Profesori);
            return View(prof_Predms.ToList());
        }

        // GET: Prof_Predm/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prof_Predm prof_Predm = db.Prof_Predms.Find(id);
            if (prof_Predm == null)
            {
                return HttpNotFound();
            }
            return View(prof_Predm);
        }

        // GET: Prof_Predm/Create
        public ActionResult Create()
        {
            ViewBag.PredmetiID = new SelectList(db.Predmetis, "PredmetiID", "NazivPredmeta");
            ViewBag.ProfesoriID = new SelectList(db.Profesoris, "ID", "Ime");
            return View();
        }

        // POST: Prof_Predm/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Prof_PredmID,ProfesoriID,PredmetiID")] Prof_Predm prof_Predm)
        {
            if (ModelState.IsValid)
            {
                db.Prof_Predms.Add(prof_Predm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PredmetiID = new SelectList(db.Predmetis, "PredmetiID", "NazivPredmeta", prof_Predm.PredmetiID);
            ViewBag.ProfesoriID = new SelectList(db.Profesoris, "ID", "Ime", prof_Predm.ProfesoriID);
            return View(prof_Predm);
        }

		// GET: Prof_Predm/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Prof_Predm prof_Predm = db.Prof_Predms.Find(id);
			if (prof_Predm == null)
			{
				return HttpNotFound();
			}
			ViewBag.PredmetiID = new SelectList(db.Predmetis, "PredmetiID", "NazivPredmeta", prof_Predm.PredmetiID);
			ViewBag.ProfesoriID = new SelectList(db.Profesoris, "ID", "Ime", prof_Predm.ProfesoriID);
			return View(prof_Predm);
		}

		// POST: Prof_Predm/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Prof_PredmID,ProfesoriID,PredmetiID")] Prof_Predm prof_Predm)
		{
			if (ModelState.IsValid)
			{
				db.Entry(prof_Predm).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.PredmetiID = new SelectList(db.Predmetis, "PredmetiID", "NazivPredmeta", prof_Predm.PredmetiID);
			ViewBag.ProfesoriID = new SelectList(db.Profesoris, "ID", "Ime", prof_Predm.ProfesoriID);
			return View(prof_Predm);
		}

		


		// GET: Prof_Predm/Delete/5
		public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prof_Predm prof_Predm = db.Prof_Predms.Find(id);
            if (prof_Predm == null)
            {
                return HttpNotFound();
            }
            return View(prof_Predm);
        }

        // POST: Prof_Predm/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prof_Predm prof_Predm = db.Prof_Predms.Find(id);
            db.Prof_Predms.Remove(prof_Predm);
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
