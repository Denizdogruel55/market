using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MarketOtomasyonSistemi.Models.Entity;
namespace MarketOtomasyonSistemi.Controllers
{
    public class ÜrünController : Controller
    {
        MvcDbStokEntities1 db = new MvcDbStokEntities1();
        public ActionResult Index()
        {
            var degerler = db.TBLURUNLER.ToList();

            return View(degerler);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            List<SelectListItem> deger1 = (from x in db.TBLKATEGORİLER.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KATEGORIAD,
                                               Value = x.KATEGORIID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(TBLURUNLER p)
        {
            var ktg = db.TBLKATEGORİLER.Where(x => x.KATEGORIID == p.TBLKATEGORİLER.KATEGORIID).FirstOrDefault();
            p.TBLKATEGORİLER = ktg; // Kategori ilişkisini ayarlıyoruz
            db.TBLURUNLER.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var urun = db.TBLURUNLER.Find(id);
            db.TBLURUNLER.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ÜrünGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in db.TBLKATEGORİLER.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KATEGORIAD,
                                               Value = x.KATEGORIID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            var ktg = db.TBLURUNLER.Find(id);
            return View("ÜrünGetir", ktg);
        }
    
        public ActionResult Güncelle(TBLURUNLER p1)
        {
            var urunler = db.TBLURUNLER.Find(p1.URUNID);
            urunler.URUNAD = p1.URUNAD;
            urunler.MARKA = p1.MARKA;
            urunler.Fiyat = p1.Fiyat;
            var ktg = db.TBLKATEGORİLER.Where(x => x.KATEGORIID == p1.TBLKATEGORİLER.KATEGORIID).FirstOrDefault();
          
            urunler.ÜRÜNKATEGORİ=ktg.KATEGORIID; // Kategori ilişkisini ayarlıyoruz


            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}