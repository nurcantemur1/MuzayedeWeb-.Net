

using System;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using WebService;

namespace WebSite.Controllers
{
    public class SecurityController : Controller
    {
        private KullaniciService kullaniciService = new KullaniciService();

        private UrunlerServis urunlerServis = new UrunlerServis();
        // GET: Security
        public bool MailFormat(string mail)
        {
            string mailformat = "\\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\\Z";
            if (!Regex.IsMatch(mail, mailformat, RegexOptions.IgnoreCase))
            {
                return true;
            }
            return false;
        }

        public bool MailVarMi(string mail)
        {
            if (MailFormat(mail) && kullaniciService.MailKontrol(mail))
            {
                return false;
            }

            return true;
        }


        public bool OturumKontrol()
        {
            return string.IsNullOrEmpty(System.Web.HttpContext.Current.User.Identity.Name);
        }

        public int KullaniciId()
        {
            if (string.IsNullOrEmpty(System.Web.HttpContext.Current.User.Identity.Name)) return 0;
            return int.Parse(System.Web.HttpContext.Current.User.Identity.Name);
        }


        public void CookieCreate(string cookiename, string value)
        {
            HttpCookie Cookie = null;
            if (System.Web.HttpContext.Current.Response.Cookies[cookiename] != null)
            {
                System.Web.HttpContext.Current.Request.Cookies.Remove(cookiename);
                System.Web.HttpContext.Current.Response.Cookies[cookiename].Value = value;
                Cookie = System.Web.HttpContext.Current.Response.Cookies[cookiename];
            }
            else
            {
                //Yoksa oluştur.
                Cookie = new HttpCookie(cookiename);
                Cookie.Expires = DateTime.Now.AddDays(10);
                Cookie[cookiename] = value;

            }
            System.Web.HttpContext.Current.Response.Cookies.Add(Cookie);
        }

        public string CookieGet(string cookiename)
        {
            if (System.Web.HttpContext.Current.Request.Cookies[cookiename] != null)
                return System.Web.HttpContext.Current.Request.Cookies[cookiename].Value;
            else
                return null;
        }

        public void CookieDelete(string cookiename)
        {
            System.Web.HttpContext.Current.Response.Cookies[cookiename].Expires = DateTime.Now.AddYears(-1);
            System.Web.HttpContext.Current.Request.Cookies.Remove(cookiename);
        }


    }
}