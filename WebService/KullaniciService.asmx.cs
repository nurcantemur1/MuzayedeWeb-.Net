using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using WebService.DB;
using WebService.Dto;
using System.Web.UI.WebControls;

namespace WebService
{
    /// <summary>
    /// Summary description for KullaniciService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class KullaniciService : System.Web.Services.WebService
    {
        MezatDBEntities db = new MezatDBEntities();

        [WebMethod]
        public List<KullaniciDto> GetAll()
        {
            var list = db.Kullanici.ToList();
            var dto_list = new List<KullaniciDto>();
            foreach (var Kullanici in list)
            {
                dto_list.Add(KullaniciDto.ToDto(Kullanici));
            }
            return dto_list;
        }

        [WebMethod]
        public Kullanici Get(int id)
        {
            return db.Kullanici.Find(id);
        }
   

        [WebMethod]
        public bool Add(Kullanici kullanici)
        {
            db.Kullanici.Add(kullanici);
           return db.SaveChanges()>0;
        }

        [WebMethod]
        public void Update(Kullanici kullanici)
        {
            db.Kullanici.AddOrUpdate(kullanici);
            db.SaveChanges();
        }
        [WebMethod]
        public void Delete(int id)
        {
            var kullanici = db.Kullanici.Find(id);
            db.Kullanici.Remove(kullanici);
            db.SaveChanges();
        }


        [WebMethod]
        public bool MailKontrol(string mail)
        {
            return db.Kullanici.FirstOrDefault(x => x.Kullanicimail.Equals(mail)) == null;
        }

        [WebMethod]
        public Kullanici GirisKontrol(string mail,string sifre)
        {
            return db.Kullanici.FirstOrDefault(x => x.Kullanicimail.Equals(mail) && x.Sifre.Equals(sifre));
        }

    }
}
