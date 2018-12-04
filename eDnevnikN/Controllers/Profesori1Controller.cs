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
    public class Profesori1Controller : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: Profesori1
        public ActionResult Index()
        {
            return View(db.Profesoris.ToList());
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
            return View();
        }

        // POST: Profesori1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Ime,Prezime,KorisnickoIme,Lozinka,Status")] Profesori profesori)
        {
            if (ModelState.IsValid)
            {
                db.Profesoris.Add(profesori);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(profesori);
        }

        // GET: Profesori1/Edit/5
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

        // POST: Profesori1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Ime,Prezime,KorisnickoIme,Lozinka,Status")] Profesori profesori)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profesori).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profesori);
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
