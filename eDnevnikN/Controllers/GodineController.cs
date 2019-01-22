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
    public class GodineController : Controller
    {
        private SchoolContext db = new SchoolContext();

		//// GET: Godine
		//public ActionResult Index()
		//{
		//    return View(db.Godines.ToList());
		//}

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult IndexProf()
		{
			return View();
		}

		public ActionResult GetGodines()
		{
			using (SchoolContext db = new SchoolContext())
			{
				db.Configuration.LazyLoadingEnabled = false;
				var godines = db.Godines.OrderBy(a => a.Opis).ToList();
				return Json(new { data = godines }, JsonRequestBehavior.AllowGet);
			}
		}

		// GET: Godine/Details/5
		public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Godine godine = db.Godines.Find(id);
            if (godine == null)
            {
                return HttpNotFound();
            }
            return View(godine);
        }

        // GET: Godine/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Godine/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GodineID,Opis")] Godine godine)
        {
			try
			{
				if (ModelState.IsValid)
            {
                db.Godines.Add(godine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
			}
			catch (DataException /* dex */)
			{
				//Prijavi gresku

				ModelState.AddModelError("", "Ne mogu da sacuvam promene. Pokusajte ponovo,a ako se problem i dalje javlja, obratite se administratoru.");
			}

			return View(godine);
        }


        // GET: Godine/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Godine godine = db.Godines.Find(id);
            if (godine == null)
            {
                return HttpNotFound();
            }
            return View(godine);
        }

		// POST: Godine/Edit/5
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
			var godineToUpdate = db.Godines.Find(id);
			if (TryUpdateModel(godineToUpdate, "",
			   new string[] { "GodineID", "Opis"}))
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
			return View(godineToUpdate);
		}

			//[HttpPost]
			//[ValidateAntiForgeryToken]
			//public ActionResult Edit([Bind(Include = "GodineID,Opis")] Godine godine)
			//{
			//    if (ModelState.IsValid)
			//    {
			//        db.Entry(godine).State = EntityState.Modified;
			//        db.SaveChanges();
			//        return RedirectToAction("Index");
			//    }
			//    return View(godine);
			//}

			// GET: Godine/Delete/5
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
			Godine godine = db.Godines.Find(id);
            if (godine == null)
            {
                return HttpNotFound();
            }
            return View(godine);
        }

        // POST: Godine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
			try
			{
				Godine godine = db.Godines.Find(id);
				db.Godines.Remove(godine);
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
