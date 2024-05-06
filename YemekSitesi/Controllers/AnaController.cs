using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YemekSitesi.Models.Tables;
using YemekSitesi.Models;
using System.Web.Security;

namespace YemekSitesi.Controllers
{
    public class AnaController : Controller
    {
        DatabaseContext db = new DatabaseContext();

        // GET: Ana
        public ActionResult Anasayfa()
        {
            return View();
        }
        public ActionResult Hakkimizda()
        {
            return View();
        }
        public ActionResult iletisim()
        {
            return View();
        }
        [HttpPost]
        public ActionResult iletisim(tbl_iletisim yeniI)
        {
            db.iletisimTABLE.Add(yeniI);
            db.SaveChanges();
            return RedirectToAction("iletisim", "Ana");
        }
        public ActionResult Giris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Giris(tbl_uye gelenUye)
        {

            var user = db.uyeTable.FirstOrDefault(u => u.uyeKullaniciAd == gelenUye.uyeKullaniciAd && u.uyeParola == gelenUye.uyeParola);
            if (user == null)
            {
                return RedirectToAction("Kayit", "Ana");
            }
            FormsAuthentication.SetAuthCookie(user.uyeAd, true);

            //if (user == null)
            //{
            //    return RedirectToAction("Kayit", "Ana");
            //}

            if (user.UyeTipi != 1)
            {
                return RedirectToAction("Kullanici", "Kullanici");

            }
            if (user.UyeTipi != 0)
            {
                return RedirectToAction("Admin", "Home");
            }
            

            return RedirectToAction("Giris", "Ana");

        }

        //[HttpPost]
        //public ActionResult CikisYap()
        //{
        //    return RedirectToAction("Giris", "Ana");

        //}
        [HttpGet]
        public ActionResult CikisYap()
        {
            FormsAuthentication.SignOut();
            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName)
            {
                Expires = DateTime.Now.AddDays(-1)
            };
            Response.Cookies.Add(authCookie);

            return RedirectToAction("Giris", "Ana");

        }
        public ActionResult Kayit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KayitOl(tbl_uye yeninUye)
        {
            yeninUye.UyeTipi = 0;
            db.uyeTable.Add(yeninUye);
            db.SaveChanges();
            return RedirectToAction("Giris", "Ana");
        }

    }
}