using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebService.DB;
using WebService.Dto;
using WebService.Model;
using WebService;
using WebSite.Models;
using PagedList.Mvc;
using PagedList;

namespace WebSite.Controllers
{
    public class MezatController : Controller
    {
        private PageService pageService = new PageService();
        private MuzayedeService muzayedeService = new MuzayedeService();
        private MUrunleriService mUrunleriService = new MUrunleriService();
        private KategoriService kategoriService = new KategoriService();
        private UrunlerServis urunlerServis = new UrunlerServis();
        private SecurityController security = new SecurityController();
        public ActionResult Kontrol(int muzayedeId)
        {
            return RedirectToAction("CanliMuzayede", new { muzayedeId });
            /*
            var muzayede = muzayedeService.Get(muzayedeId);
            if (muzayede != null)
            {
                if (muzayede.MTarih.CompareTo(DateTime.Now) > 0) 
                    return RedirectToAction("CanliMuzayede", new { muzayedeId });
            }
            return RedirectToAction("MuzayedeDetay", new { muzayedeId });
            */
        }

        public ActionResult Muzayede(int muzayedeId)
        {
            ViewBag.Kategoriler = kategoriService.GetAll();
            var model = pageService.MuzayedeDetayData(muzayedeId);
            return View(model);
        }
        public ActionResult CanliMuzayede(int muzayedeId, int? murunId)
        {
            //  var model = pageService.MuzayedeDetayData(muzayedeId);
         
            var model = new CanliMuzaedeModel();
            model.muzayede = muzayedeService.Get(muzayedeId);
            var list = mUrunleriService.MUList(muzayedeId);
            {
            if (murunId != null)  
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].ID == murunId)
                    {
                        if (i == list.Count - 1) break;
                        var siradaki = list[i + 1];
                        var siradakimurun = new MurunleriModel();
                        siradakimurun.urun = urunlerServis.Get(siradaki.UrunID);
                        siradakimurun.ID = siradaki.ID;
                        model.murun = siradakimurun;
                        return View(model);
                    }
                }
            }
            var ilk = list[0];
            var ilkmurun = new MurunleriModel();
            ilkmurun.urun = urunlerServis.Get(ilk.UrunID);
            ilkmurun.ID = ilk.ID;
            model.murun = ilkmurun;
            return View(model);
        }
        

        public ActionResult MuzayedeEkle(string MuzayedeAdi)
        {
            if (!string.IsNullOrEmpty(MuzayedeAdi))
            {
                var muzayede = new Muzayede();
                muzayede.MuzayedeAdi = MuzayedeAdi;
                muzayede.KullaniciID = security.KullaniciId();
                muzayede.MTarih = DateTime.Now;
                muzayede.Sure = TimeSpan.FromHours(10);
                muzayede = muzayedeService.Add(muzayede);
                security.CookieCreate("muzayedeId", muzayede.MuzayedeID.ToString());
                return Redirect("YeniMuzayede");
            }
            return RedirectToAction("Muzayedelerim", "Kullanici");
        }

     
        public ActionResult YeniMuzayede()
        {
            MuzayedeModel model = new MuzayedeModel();
            model.muzayede = muzayedeService.Get(int.Parse(security.CookieGet("muzayedeId")));
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

        public ActionResult MuzayedeKaydet()
        {
            security.CookieDelete("muzayedeId");
            return RedirectToAction("Muzayedelerim", "Kullanici");
        }

        public ActionResult YeniUrun()    
        {
            return View(new Urun());
        }
        
        [HttpPost]
        public ActionResult YeniUrun(Urun urun)
        {
            urun.KullaniciID = security.KullaniciId();
            urunlerServis.Add(urun);
            string id = security.CookieGet("muzayedeId");
            if (string.IsNullOrEmpty(id)) return RedirectToAction("Urunlerim","Kullanici");
            var murun = new MuzayedeUrunleri();
            murun.UrunID = urun.UrunID;
            murun.MuzayedeID = int.Parse(id);
            mUrunleriService.Add(murun);
            return RedirectToAction("YeniMuzayede", new { muzayedeId = murun.MuzayedeID });

        }

        [HttpPost]
        public ActionResult Resim(HttpPostedFileBase dosya)
        {
            if (dosya.ContentLength > 0)
            {
                string filePath = Path.Combine(Server.MapPath("~/Content/images"), Guid.NewGuid().ToString() + "_" + Path.GetFileName(dosya.FileName));
                dosya.SaveAs(filePath);
            }
            return View(dosya.FileName);
        }

        public ActionResult UrunListesi()
        {
            var list = urunlerServis.GetList(security.KullaniciId());
            var modellist = new List<ListUrunModel>();
            foreach (var urun in list)
            {
                if (!mUrunleriService.VarMi(urun.UrunID))
                {
                    var model = new ListUrunModel();
                    model.urun = urun;
                    model.check = false;
                    modellist.Add(model);
                }
            }

            ViewBag.muzayedeId = security.CookieGet("muzayedeId");
            return View(modellist);
        }
        
        [HttpPost]
        public ActionResult UrunListesi(List<ListUrunModel> modellist)
        {
            var muzayedeId = int.Parse(security.CookieGet("muzayedeId"));
            if (modellist != null)
            {
                foreach (var model in modellist)
                {
                    if (model.check)
                    {
                        var murun = new MuzayedeUrunleri();
                        murun.UrunID = model.urun.UrunID;
                        
                        murun.MuzayedeID = muzayedeId ;
                        mUrunleriService.Add(murun);
                    }
                }
            }

            return Redirect("YeniMuzayede");
        }

        public ActionResult UrunDelete(int urunid)
        {
            var murunId = mUrunleriService.GetMurunId(urunid);
            if(murunId > 0)  mUrunleriService.Delete(murunId);
            urunlerServis.Delete(urunid);
            return RedirectToAction("Urunlerim", "Kullanici");
        }
        
     
        public ActionResult UrunDetay(int id)
        {
            var model = urunlerServis.Get(id);
            return View(model);  
        }
        
        [HttpPost]
        public ActionResult UrunDetay(Urun urun)
        {
            
            ViewBag.id = urun.UrunID;
            urunlerServis.Update(urun);
            var model = urunlerServis.Get(urun.UrunID);
            return RedirectToAction("Urunlerim", "Kullanici");
        }

        public ActionResult MuzayedeDelete(int mid)
        {
            ViewBag.id = mid;
            muzayedeService.Delete(mid);
            var list = mUrunleriService.GetAll();
            foreach (var item in list)
            {
                if (item.muzayede.MuzayedeID == mid)
                {
                    mUrunleriService.Delete(item.ID);
                }
            }
            return RedirectToAction("Muzayedelerim", "Kullanici");
        }
    }
}