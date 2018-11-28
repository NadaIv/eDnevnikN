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
            return View();
        }

        // POST: Ucenici/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Ime,Prezime,Adresa,DatumRodjenja,GodinaUpisa,RedBrUOdeljenju")] Ucenici ucenici)
        {
            if (ModelState.IsValid)
            {
                db.Ucenicis.Add(ucenici);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

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
            return View(ucenici);
        }

        // POST: Ucenici/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Ime,Prezime,Adresa,DatumRodjenja,GodinaUpisa,RedBrUOdeljenju")] Ucenici ucenici)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ucenici).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ucenici);
        }

        // GET: Ucenici/Delete/5
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

        // POST: Ucenici/Delete/5
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
