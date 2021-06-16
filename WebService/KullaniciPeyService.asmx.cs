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
    /// Summary description for KullaniciPeyService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class KullaniciPeyService : System.Web.Services.WebService
    {
        MezatDBEntities db = new MezatDBEntities();

        [WebMethod]
        public List<KullaniciPeyDto> GetAll()
        {
            var list = db.KullaniciPey.ToList();
            var dto_list = new List<KullaniciPeyDto>();
            foreach (var kullanicipey in list)
            {
                dto_list.Add(KullaniciPeyDto.ToDto(kullanicipey));
            }
            return dto_list;
        }
        [WebMethod]
        public KullaniciPeyDto Get(int id)
        {
            return KullaniciPeyDto.ToDto(db.KullaniciPey.Find(id));
        }
        [WebMethod]
        public void Add(KullaniciPeyDto dto)
        {
            db.KullaniciPey.Add(KullaniciPeyDto.ToPey(dto));
            db.SaveChanges();
        }

        [WebMethod]
        public KullaniciPeyDto GetSonpey(int murunid)
        {
            var list = db.KullaniciPey.Where(x => x.MurunID == murunid).ToList();
            if (list.Count == 0) return null;
            return KullaniciPeyDto.ToDto(list[list.Count()-1]);
        }

        [WebMethod]
        public List<KullaniciPeyDto> GetPeyList(int kullaniciId)
        {
            var list = db.KullaniciPey.Where(x=> x.KullaniciID == kullaniciId).ToList();
            var peyverilenler = new List<KullaniciPeyDto>();
            foreach (var item in list)
            {
                var dto = new KullaniciPeyDto();
                dto.PeyID = item.PeyID;
                dto.MUrunDto = MUrunleriDto.ToDto(db.MuzayedeUrunleri.Find(item.MurunID));
                dto.Pey = item.Pey;
                dto.PeyZaman = item.PeyZaman;
                peyverilenler.Add(dto);
            }

            return peyverilenler;
        }

        [WebMethod]
        public List<KullaniciPeyDto> SiparisList(int kullaniciId)
        {
            var alinanlar = new List<KullaniciPeyDto>();
            var list = db.KullaniciPey.Where(x=> x.KullaniciID == kullaniciId).ToList();
            var murunIdlist = list.Select(x=>x.MurunID).Distinct().ToList();
            foreach (var murunId in murunIdlist)
            {
                var dto = GetSonpey(murunId);
                if (dto.KullaniciID == kullaniciId)
                {
                    alinanlar.Add(dto);
                }
            }
            return alinanlar;
        }
    }
}
