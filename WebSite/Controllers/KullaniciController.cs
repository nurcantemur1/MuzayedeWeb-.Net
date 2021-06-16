using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web.Security;
using System.Web.Mvc;
using WebService.DB;
using WebService;
using WebService.Model;

namespace WebSite.Controllers
{
    [Authorize]
    public class KullaniciController : Controller
    {
        private SecurityController security = new SecurityController();
        KullaniciService kulaniciService = new KullaniciService();
        private KullaniciPeyService kullaniciPeyService = new KullaniciPeyService();
        private MuzayedeService muzayedeService = new MuzayedeService();
        private MUrunleriService mUrunleriService = new MUrunleriService();
        private UrunlerServis urunlerServis = new UrunlerServis();
        // GET: Kullanici
  
        public ActionResult KullaniciB()
        {
            var model = kulaniciService.Get(security.KullaniciId());

            return View(model);
        }
        
        [HttpPost]
        public ActionResult Kaydet(Kullanici kullanici)
        {
            kullanici.KullaniciID = security.KullaniciId();
            kulaniciService.Update(kullanici);
            return Redirect("KullaniciB");
        }

        public ActionResult Muzayedelerim()
        {
            int id = security.KullaniciId();
            var list = muzayedeService.KMGetAll(id);
            return View(list);
        }
        public ActionResult MuzayedeDetay(int muzayedeId)
        {
            security.CookieCreate("muzayedeId", muzayedeId.ToString());
            var model = new MuzayedeModel();
            model.muzayede = muzayedeService.Get(muzayedeId);
            model.muzayedeUrunleri = new List<MurunleriModel>();
            var list = mUrunleriService.MUList(model.muzayede.MuzayedeID);
            foreach (var item in list)
            {
                var murun = new MurunleriModel();
                murun.urun = urunlerServis.Get(item.UrunID);
                murun.ID = item.ID;
                model.muzayedeUrunleri.Add(murun);
            }
            return View(model);
        }

        public ActionResult MurunDelete(int murunId)
        {
            var muzayedeId = mUrunleriService.Get(murunId).muzayede.MuzayedeID;
            mUrunleriService.Delete(murunId);
            return RedirectToAction("MuzayedeDetay", "Kullanici", new {muzayedeId});
        }

        public ActionResult Urunlerim()
        {
            security.CookieDelete("muzayedeId");
            int id = security.KullaniciId();
            var list = urunlerServis.GetList(id);
            return View(list);
        }

        [Authorize]
        public ActionResult PeyVerilenler()
        {
            var model = kullaniciPeyService.GetPeyList(security.KullaniciId());
            return View(model);
        }

        [Authorize]
        public ActionResult Siparis()
        {
            var model = kullaniciPeyService.SiparisList(security.KullaniciId());
            
            return View(model);
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session["KullaniciID"] = null;
            Session.Abandon();//sonlandırmak için sessionları
            return RedirectToAction("Index", "Home");
        }
        public ActionResult KartBilgileri()
        {
            return View();
        }
    }

}
