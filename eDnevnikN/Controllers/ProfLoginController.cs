using eDnevnikN.DAL;
using eDnevnikN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eDnevnikN.Controllers
{
    public class ProfLoginController : Controller
    {
        // GET: ProfLogin
        public ActionResult Index()
        {
            return View();
        }

		public ActionResult GetUcenicis()
		{
			using (SchoolContext db = new SchoolContext())
			{
				db.Configuration.LazyLoadingEnabled = false;
				var ucen = db.Ucenicis.OrderBy(a => a.ID).ToList();
				return Json(new { data = ucen }, JsonRequestBehavior.AllowGet);
			}
		}
		public ActionResult ListaOd()
		{
			SchoolContext db = new SchoolContext();
			List<Odeljenja> odeljenjas = db.Odeljenjas.ToList();
			return View(odeljenjas);
		}
		public ActionResult ListaUc(int odeljenjaId)
		{
			SchoolContext db = new SchoolContext();
			List<Ucenici> ucenicis = db.Ucenicis.Where(a => a.OdeljenjaID == odeljenjaId).ToList();
			return View(ucenicis);
		}
		public ActionResult Details(int id)
		{
			SchoolContext db = new SchoolContext();
			Ucenici ucenici = db.Ucenicis.Single(a => a.ID == id);
			return View(ucenici);
		}
	}
}