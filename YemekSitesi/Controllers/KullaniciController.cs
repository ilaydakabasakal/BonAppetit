using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YemekSitesi.Models.Tables;
using YemekSitesi.Models;
using System.IO;

namespace YemekSitesi.Controllers
{
    [Authorize]
    public class KullaniciController : Controller
    {
        DatabaseContext db = new DatabaseContext();

        // GET: Kullanici
        public ActionResult Kullanici()
        {
            return View();
        }
        public ActionResult Akis()
        {
            List<tbl_tarif> akisListe = db.tarifTABLE.ToList();
            return View(akisListe);
        }
        public ActionResult TarifGonder()
        {
            var kategoriler = db.kategoriTABLE.ToList();

            ViewBag.Kategoriler = kategoriler;

            return View();
        }
        [HttpPost]
        public ActionResult TarifGonder(tbl_tarif yeniT)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                //string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Images/" + dosyaAdi;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                yeniT.resim = "/Images/" + dosyaAdi; ;
            }

            db.tarifTABLE.Add(yeniT);
            db.SaveChanges();
            return RedirectToAction("TarifGonder", "Kullanici");
        }
        
    }
}