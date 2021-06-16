using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebService.DB;
using WebService.Dto;

namespace WebService
{
    /// <summary>
    /// Summary description for MUrunleriService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MUrunleriService : System.Web.Services.WebService
    {
        MezatDBEntities db = new MezatDBEntities();

        [WebMethod]
        public List<MUrunleriDto> GetAll()
        {
            var list = db.MuzayedeUrunleri.ToList();
            var dto_list = new List<MUrunleriDto>();
           
            foreach (var muzayedeUrunleri in list)
            {
                dto_list.Add(MUrunleriDto.ToDto(muzayedeUrunleri));
            } 
            return dto_list;
        }
        [WebMethod]
        public MUrunleriDto Get(int id)
        {
            return MUrunleriDto.ToDto(db.MuzayedeUrunleri.Find(id));
        }

        public int GetMurunId(int urunid)
        {
            var murun = db.MuzayedeUrunleri.FirstOrDefault(x => x.UrunID == urunid);
            if(murun != null) return murun.ID;
            return 0;
        }

        [WebMethod]
        public bool VarMi(int urunId)
        {
            return db.MuzayedeUrunleri.Any(x => x.UrunID == urunId);
        }

        [WebMethod]
        public void Add(MuzayedeUrunleri murun)
        {
            db.MuzayedeUrunleri.Add(murun);
            db.SaveChanges();
        }
        [WebMethod]
        public List<MuzayedeUrunleri> MUList(int muzayedeId)
        {
            return db.MuzayedeUrunleri.Where(x => x.MuzayedeID == muzayedeId).ToList();

        }
        
        [WebMethod]
        public void Delete(int id)
        {
            var murunleri = db.MuzayedeUrunleri.Find(id);
            db.MuzayedeUrunleri.Remove(murunleri);
            db.SaveChanges();
        }
    }
}
