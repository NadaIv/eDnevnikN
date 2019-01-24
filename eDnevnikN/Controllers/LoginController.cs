using eDnevnikN.DAL;
using eDnevnikN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eDnevnikN.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
		[HttpPost]
		public ActionResult Odobrenje(Profesori prof)
		{
			using (SchoolContext db = new SchoolContext())
			{
				var v = db.Profesoris.Where(a => a.KorisnickoIme == prof.KorisnickoIme && a.Lozinka == prof.Lozinka && a.Status == prof.Status).FirstOrDefault();
				if (v == null)
				{
					if (prof.KorisnickoIme != null || prof.Lozinka == null)

						prof.LoginErrorMessage = "Pogresan unos, pokusaj ponovo..."; //Ako je pogresan unos
					return View("Index", prof);
				}

				else
				{
					if (prof.KorisnickoIme == prof.KorisnickoIme && prof.Lozinka == prof.Lozinka && prof.Status.Contains("admin"))
					{
						Session["ID"] = v.ID;
						Session["KorisnickoIme"] = v.KorisnickoIme;
						Session["Status"] = v.Status;
						return RedirectToAction("Index", "Admin"); //Ako je Administrator
					}
					Session["ID"] = v.ID;
					Session["KorisnickoIme"] = v.KorisnickoIme;
					Session["Status"] = v.Status;
					return RedirectToAction("Index", "ProfLogin"); //Ako je Profesor
				}

			}
		}
		public ActionResult LogOut()
		{
			int ID = (int)Session["ID"];
			int KorisnickoIme = (int)Session["KorisnickoIme"];
			int Status = (int)Session["Status"];
			Session.Abandon();
			return RedirectToAction("Index", "Login");
		}
	}
}
    
