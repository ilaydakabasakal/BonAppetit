using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YemekSitesi.Models.Tables;
using YemekSitesi.Models;
using System.IO;
using System.Web.Security;

namespace YemekSitesi.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        DatabaseContext db = new DatabaseContext();


       

        public ActionResult Admin()
        {
            List<tbl_uye> uyeListe = db.uyeTable.ToList();
            return View(uyeListe);
        }
        public ActionResult UyeEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UyeEkle(tbl_uye yeni)
        {
            db.uyeTable.Add(yeni);
            db.SaveChanges();
            return RedirectToAction("Admin","Home");
        }
        
        public ActionResult UyeGuncelle2(int? uyeID)
        {
            tbl_uye uye = db.uyeTable.Where(x => x.uyeID == uyeID).FirstOrDefault();
            ViewBag.uye = uye;
            return View(uye);

        }
        [HttpPost]
        public ActionResult UyeGuncelle2(int? uyeID, tbl_uye guncel)
        {
            tbl_uye mevcut = db.uyeTable.Where(x => x.uyeID == uyeID).FirstOrDefault();
            mevcut.uyeAd = guncel.uyeAd;
            mevcut.uyeSoyad = guncel.uyeSoyad;
            mevcut.uyeKullaniciAd = guncel.uyeKullaniciAd;
            mevcut.uyeEposta = guncel.uyeEposta;
            mevcut.UyeTipi = guncel.UyeTipi;
            db.SaveChanges();
            return RedirectToAction("Admin","Home");

        }
        public ActionResult Kategori()
        {
            List<tbl_kategori> kategoriListe = db.kategoriTABLE.ToList();
            return View(kategoriListe);
        }
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(tbl_kategori yeniK)
        {
            db.kategoriTABLE.Add(yeniK);
            db.SaveChanges();
            return RedirectToAction("Kategori", "Home");
        }
        public ActionResult KategoriSil2(int? kategoriID)
        {
            tbl_kategori kategori = db.kategoriTABLE.Where(x => x.kategoriID == kategoriID).FirstOrDefault();
            db.kategoriTABLE.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Kategori", "Home");
        }
        public ActionResult KategoriGuncelle2(int? kategoriID)
        {
            tbl_kategori kategori = db.kategoriTABLE.Where(x => x.kategoriID == kategoriID).FirstOrDefault();
            return View(kategori);

        }
        [HttpPost]
        public ActionResult KategoriGuncelle2(int? kategoriID, tbl_kategori guncelK)
        {
            tbl_kategori mevcut = db.kategoriTABLE.Where(x => x.kategoriID == kategoriID).FirstOrDefault();
            mevcut.kategoriAd = guncelK.kategoriAd;
            db.SaveChanges();
            return RedirectToAction("Kategori", "Home");

        }
        public ActionResult Tarif()
        {
            List<tbl_tarif> tarifListe = db.tarifTABLE.ToList();
            return View(tarifListe);
        }
        public ActionResult TarifEkle()
        {

            var kategoriler = db.kategoriTABLE.ToList();

            ViewBag.Kategoriler = kategoriler;

            return View();
        }
        [HttpPost]
        public ActionResult TarifEkle(tbl_tarif yeniT)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                //string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Images/" + dosyaAdi ;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                yeniT.resim = "/Images/" + dosyaAdi ; ;
            }

            
            
            
            db.tarifTABLE.Add(yeniT);
            db.SaveChanges();
            return RedirectToAction("Tarif", "Home");
        }
        public ActionResult TarifSil2(int? tarifID)
        {
            tbl_tarif tarif = db.tarifTABLE.Where(x => x.tarifID == tarifID).FirstOrDefault();
            db.tarifTABLE.Remove(tarif);
            db.SaveChanges();
            return RedirectToAction("Tarif", "Home");
        }
        public ActionResult TarifGuncelle2(int? tarifID)
        {
            tbl_tarif tarif = db.tarifTABLE.Where(x => x.tarifID == tarifID).FirstOrDefault();
            return View(tarif);

        }
        [HttpPost]
        public ActionResult TarifGuncelle2(int? tarifID, tbl_tarif guncelT)
        {
            tbl_tarif mevcut = db.tarifTABLE.Where(x => x.tarifID == tarifID).FirstOrDefault();
            mevcut.baslik = guncelT.baslik;
            mevcut.malzemeler = guncelT.malzemeler;
            mevcut.metin = guncelT.metin;
            mevcut.resim = guncelT.resim;
            mevcut.kategori = guncelT.kategori;
            db.SaveChanges();
            return RedirectToAction("Tarif", "Home");

        }
        public ActionResult Begeni()
        {
            List<tbl_begeni> begeniListe = db.begeniTABLE.ToList();
            return View(begeniListe);
        }
        [HttpPost]
        public ActionResult BegeniEkle(int tarifID, int uyeID)
        {
            try
            {
                // İlgili tarifi ve üyeyi bul - burası ekleme kısmı sen tarifleri listelediğin kısımda yapman gerek bak şimdi
                var tarif = db.tarifTABLE.Find(tarifID);
                var uye = db.uyeTable.Find(uyeID);

                // Eğer tarif ve üye varsa beğeni ekleyebiliriz
                if (tarif != null && uye != null)
                {
                    // Tarife beğeni ekle
                    var begeni = new tbl_begeni { tarifID = tarifID, uyeID = uyeID };
                    db.begeniTABLE.Add(begeni);
                    db.SaveChanges();

                    return Json(new { success = true, message = "Beğeni başarıyla eklendi.", begenildi = true });
                }
                else
                {
                    return Json(new { success = false, message = "Tarif veya üye bulunamadı.", begenildi = false });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Bir hata oluştu: " + ex.Message, begenildi = false });
            }
        }
        [HttpPost]
        public ActionResult BegeniSil(int tarifID, int uyeID)
        {

            tbl_begeni begeni = db.begeniTABLE.Where(x => x.tarifID == tarifID && x.uyeID==uyeID).FirstOrDefault();
            db.begeniTABLE.Remove(begeni);
            db.SaveChanges();
            return Json(new { success = true, message = "Beğeni başarıyla silindi."});
            //return View(begeni);
        }
        public ActionResult Yorum()
        {
            List<tbl_yorum> yorumListe = db.yorumTable.ToList();
            return View(yorumListe);
        }
        public ActionResult Mesaj()
        {
            List<tbl_iletisim> iletisimListe = db.iletisimTABLE.ToList();
            return View(iletisimListe);
        }
        public ActionResult MesajSil2(int? mesajID)
        {
            tbl_iletisim mesaj = db.iletisimTABLE.Where(x => x.mesajID == mesajID).FirstOrDefault();
            db.iletisimTABLE.Remove(mesaj);
            db.SaveChanges();
            return RedirectToAction("Mesaj", "Home");
        }
        public ActionResult AdminCikis()
        {
            FormsAuthentication.SignOut();
            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName)
            {
                Expires = DateTime.Now.AddDays(-1)
            };
            Response.Cookies.Add(authCookie);

            return RedirectToAction("Giris", "Ana");
        }



    }
}