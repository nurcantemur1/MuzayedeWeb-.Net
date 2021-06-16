
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using WebService.Dto;
using WebService;
using WebService.DB;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class HomeController : Controller
    {
        private SecurityController security = new SecurityController();
        private KullaniciService kullaniciService = new KullaniciService();
        private PageService pageService = new PageService();
        private KategoriService kategoriService = new KategoriService();


        public ActionResult Index()
        {
            var model = pageService.AnasayfaData();
            return View(model);

        }

        

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "İletişim";

            return View();
        }
        public ActionResult EkspertizFormu()
        {
            return View();
        }
        public ActionResult Urunler()
        {
            ViewBag.Kategoriler = kategoriService.GetAll();
            var model = pageService.UrunlerData();
            return View(model);
        }

        public ActionResult KayitOl()
        {
            return View(new KullaniciViewModel());
        }


        [HttpPost]
        public ActionResult KayitOl(KullaniciViewModel model)
        {
            if (!security.MailVarMi(model.email) && model.sifre.Equals(model.sifreTekrar))
            {
                kullaniciService.Add(
                    new WebService.DB.Kullanici
                    {
                        Kullanicimail = model.email,
                        Sifre = model.sifre,
                        KullaniciAdi = model.isim,
                        KullaniciAdres = "-",
                        KullaniciSoyadi = model.soyisim,
                        KullaniciTelefon = "-"
                    });
                return RedirectToAction("Login", "Home");
            }
            return View(model);

        }

        public ActionResult Login()
        {
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.User.Identity.Name))
            {
                return RedirectToAction("index", "Home");
            }
            return View(new KullaniciViewModel());
        }



        [HttpPost]
        public ActionResult Login(KullaniciViewModel model)
        {
            var kullanici = kullaniciService.GirisKontrol(model.email, model.sifre);

            if (kullanici != null)
            {
                FormsAuthentication.SetAuthCookie(kullanici.KullaniciID.ToString(), false);

                return RedirectToAction("Index", "Home");

            }
            return Redirect("Login");
        }
    }
}