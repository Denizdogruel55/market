using MarketOtomasyonSistemi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarketOtomasyonSistemi.Controllers
{
    public class SatısController : Controller
    {
        // GET: Satıs
        MvcDbStokEntities1 db = new MvcDbStokEntities1();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SatısEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SatısEkle(TBLSATISLAR p)
        {
            db.TBLSATISLAR.Add(p);
            db.SaveChanges();

            return View("Index");
        }
    }
}