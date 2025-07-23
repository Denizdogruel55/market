using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MarketOtomasyonSistemi.Models.Entity;

namespace MarketOtomasyonSistemi.Controllers
{
    public class MüsteriController : Controller
    {
        MvcDbStokEntities1 db = new MvcDbStokEntities1();
        public ActionResult Index()
        {
            var degerler = db.TBLMUSTERILER.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(TBLMUSTERILER p)
        {
            if (!ModelState.IsValid)
            {
                return View("Ekle"); // Model geçersizse tekrar formu göster
            }

            db.TBLMUSTERILER.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int? id)
        {
           
            var mus = db.TBLMUSTERILER.Find(id);
            db.TBLMUSTERILER.Remove(mus);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id)
        {
            var musteri = db.TBLMUSTERILER.Find(id);
            return View("MusteriGetir", musteri);
        }
        public ActionResult Guncelle(TBLMUSTERILER p)
        {
            var musteri = db.TBLMUSTERILER.Find(p.MUSTERID);
            musteri.MUSTERIAD = p.MUSTERIAD;
            musteri.MUSTERISOYAD = p.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}