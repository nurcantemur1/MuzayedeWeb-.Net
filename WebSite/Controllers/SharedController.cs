using System;
using System.Web.Mvc;
using WebService.DB;
using WebService.Dto;
using WebService;

namespace WebSite.Controllers
{
    public class SharedController : Controller
    {
        KullaniciService kulaniciService = new KullaniciService();
        KullaniciPeyService kullaniciPeyService = new KullaniciPeyService();
        private SecurityController security = new SecurityController();
        private MUrunleriService murunleriService = new MUrunleriService();
        // GET: Shared
        public PartialViewResult _Header()
        {
            var id = HttpContext.User.Identity.Name;
            if (!string.IsNullOrEmpty(id))
            {
                return PartialView(kulaniciService.Get(int.Parse(id)));
            }
            return PartialView();

        }

        public PartialViewResult _Footer()
        {
            return PartialView();
        }



        public PartialViewResult MUrunCard(int MurunId)
        {
            var murun = murunleriService.Get(MurunId);
            return PartialView(murun);
            
        }

        [Authorize]
        public PartialViewResult _SonPey(int murunId)
        {
            int id = security.KullaniciId();
            if (id > 0)
            {
                var sonpey = kullaniciPeyService.GetSonpey(murunId);
                var murun = murunleriService.Get(murunId);
                decimal fiyat;
                if (sonpey == null)
                {
                    fiyat = murun.Urundto.UrunFiyat;
                }
                else
                {
                    if (sonpey.KullaniciID == id)
                    {
                        return PartialView();
                    }
                   fiyat = sonpey.Pey + 1;
                }

                var kpey = new KullaniciPeyDto();
                kpey.MUrunDto = murun;
                kpey.Pey = fiyat;
                kpey.PeyZaman = DateTime.Now;
                kpey.KullaniciID = id;
                kullaniciPeyService.Add(kpey);
            }

            ViewBag.Fiyat = kullaniciPeyService.GetSonpey(murunId).Pey;

            return PartialView();
        }


    }
}