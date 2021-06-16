using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using WebService.DB;
using WebService.Model;
using Newtonsoft.Json;

namespace WebService
{
    /// <summary>
    /// Summary description for PageService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class PageService : System.Web.Services.WebService
    {
        private MezatDBEntities db = new MezatDBEntities();
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public AnasayfaModel AnasayfaData()
        {
            var model = new AnasayfaModel();
            model.MuzayedeList = db.Muzayede.ToList();
            return model;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public MuzayedeModel MuzayedeDetayData(int muzayedeid)
        {
            var model = new MuzayedeModel();
            model.muzayede = db.Muzayede.Find(muzayedeid);
           // var sorgu = db.Muzayede.ThenBy(x => x.MuzayedeID).First();
            var list = db.MuzayedeUrunleri.Where(x => x.MuzayedeID == muzayedeid).ToList();
            var model2list = new List<MurunleriModel>();
            foreach (var item in list)
            {
                var model2 = new MurunleriModel();
                model2.urun = db.Urun.Find(item.UrunID);
                model2.ID = item.ID;
                model2list.Add(model2);
            }

            model.muzayedeUrunleri = model2list;
            return model;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<UrunModel> UrunlerData()
        {
            var modellist = new List<UrunModel>();
            var urunlerlist= db.Urun.ToList();
            foreach (var urun in urunlerlist)
            {
                var model = new UrunModel();
                model.urun = urun;
                model.kategori = db.Kategori.Find(urun.KategoriID);
                model.kullanici = db.Kullanici.Find(urun.KullaniciID);
                modellist.Add(model);
            }

            return modellist;
        }

    }
}
