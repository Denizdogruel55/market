using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using MarketOtomasyonSistemi.Models.Entity;
namespace MarketOtomasyonSistemi.Controllers
{
    public class KategoriController : Controller
    {
        MvcDbStokEntities1 db = new MvcDbStokEntities1();
        public ActionResult Index()
        {
            var degerler = db.TBLKATEGORİLER.ToList().ToPagedList(1,8);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(TBLKATEGORİLER p)
        {
            if (!ModelState.IsValid)
            {
                return View("Ekle"); // Model geçersizse tekrar formu göster
            }
            db.TBLKATEGORİLER.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var ktg = db.TBLKATEGORİLER.Find(id);
            db.TBLKATEGORİLER.Remove(ktg);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktg = db.TBLKATEGORİLER.Find(id);
            return View("KategoriGetir", ktg);
        }
        public ActionResult Guncelle(TBLKATEGORİLER p)
        {
            var ktg = db.TBLKATEGORİLER.Find(p.KATEGORIID);
            ktg.KATEGORIAD = p.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}