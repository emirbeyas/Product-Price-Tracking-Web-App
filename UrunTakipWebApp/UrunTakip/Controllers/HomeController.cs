using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrunTakip.Scrap;
using UrunTakip.Models;
using _3BusinessLogicLayer.Concrete;
using _2DataAccessLayer.EntityFreamwork;
using _1EntityLayer.Concrete;
using System.Web.Security;

namespace UrunTakip.Controllers
{
    public class HomeController : Controller
    {
        KullanicilarManager km = new KullanicilarManager(new EFKullanicilarDal());
        UrunlerManager um = new UrunlerManager(new EFUrunlerDal());
        FiyatlarManager fm = new FiyatlarManager(new EFFiyatlarDal());

        public ActionResult Index()
        {

            return View();
        }
        public ActionResult Ara()
        {
            Scrap.Scrap scrap = new Scrap.Scrap();
            UrunlerListViewModel vm = new UrunlerListViewModel();

            if (Request.QueryString["UrunAra"] != null)
            {
                vm.trendyolUrunler = scrap.scrapFromTrendyol(Request.QueryString["UrunAra"]);
                vm.gittigidiyorUrunler = scrap.scrapFromGittigidiyor(Request.QueryString["UrunAra"]);
                vm.N11Urunler = scrap.scrapFromN11(Request.QueryString["UrunAra"]);
            }

            return View(vm);
        }
        public ActionResult Detay(string url, double fiyat)
        {
            Scrap.UrunDetay urunDetay = new UrunDetay(url, fiyat);
            return View(urunDetay);
        }

        [HttpPost]
        public ActionResult Detay(tbl_Urunler p, double urunFiyat)
        {
            if (Session["LoginUser"] == null)
            {
                return RedirectToAction("Login");
            }
            if (p.bildirimFiyat > 0)
            {
                p.bildirimDurum = true;
            }
            um.AddUrun(p);

            tbl_Fiyatlar tbl_Fiyatlar = new tbl_Fiyatlar();
            tbl_Fiyatlar.fiyat = urunFiyat;
            tbl_Fiyatlar.tblUrunID = p.ID;
            tbl_Fiyatlar.tarih = DateTime.Now;

            fm.AddFiyat(tbl_Fiyatlar);
            
            return RedirectToAction("index");
        }

        public ActionResult Login()
        {
            if (Session["LoginUser"] != null)
            {
                return RedirectToAction("index");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Login(tbl_Kullanicilar p)
        {

            var Kullanicilar = km.GetList();
            foreach (var item in Kullanicilar)
            {
                if (p.eMail.Equals(item.eMail) && p.sifre.Equals(item.sifre))
                {
                    FormsAuthentication.SetAuthCookie(item.ID.ToString(), false);
                    
                    Session["LoginUser"] = item.ID;
                    return RedirectToAction("index");
                }
                else
                {
                    TempData["HATA"] = "E-Mail veya Şifre Hatalı";
                    return RedirectToAction("Login");
                }

            }

            return View();
        }
        public ActionResult SignUp()
        {
            if (Session["LoginUser"] != null)
            {
                return RedirectToAction("index");
            }
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(tbl_Kullanicilar p, string sifre2)
        {
            if (!sifre2.Equals(p.sifre))
            {
                TempData["HATA"] = "Şifreler Aynı Değil!";
                return RedirectToAction("SignUp");
            }
            var kullanicilar = km.GetList();

            foreach (var item in kullanicilar)
            {
                if (item.eMail.Equals(p.eMail))
                {
                    TempData["HATA"] = "E-Mail Adresi Zaten Kayıtlı";
                    return RedirectToAction("SignUp");
                }
            }

            km.AddKullanici(p);
             
            return RedirectToAction("Login");
        }

        [Authorize]
        public ActionResult Takipedilenler()
        {
            var takipEdilenList = um.GetList();
            return View(takipEdilenList);
        }

        public ActionResult Urunler(int urunID)
        {
            List<double> FiyatList = new List<double>();
            List<string> TarihList = new List<string>();

            UrunlerVm vm = new UrunlerVm();
            vm.fiyatlars = fm.GetList(urunID);
            vm.urun = um.GetByID(urunID);

            if (Convert.ToInt32(Session["LoginUser"]) != vm.urun.TblKullaniciID)
            {
                return RedirectToAction("index");
            }

            foreach (var item in vm.fiyatlars.OrderBy(a => a.tarih))
            {
                FiyatList.Add(item.fiyat);
                TarihList.Add(item.tarih.ToString("g").Split(' ')[0]);
            }
            ViewBag.Fiyatlar = FiyatList;
            ViewBag.Tarihler = TarihList;

            return View(vm);
        }
        public ActionResult Urunsil(int urunID)
        {
            var fiyatlar = fm.GetList(urunID);
            foreach (var item in fiyatlar)
            {
                fm.DeleteFiyat(item);
            }
            um.DeleteUrun(um.GetByID(urunID));

            return RedirectToAction("Takipedilenler");
        }

    }
}