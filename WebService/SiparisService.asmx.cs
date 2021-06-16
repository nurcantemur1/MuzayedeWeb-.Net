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
    /// Summary description for SiparisService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SiparisService : System.Web.Services.WebService
    {
        MezatDBEntities db = new MezatDBEntities();
        [WebMethod]
        public List<SiparisDto> GetAll()
        {
            var list = db.Siparis.ToList();
            var dto_list = new List<SiparisDto>();
            foreach (var siparis in list)
            {
                dto_list.Add(SiparisDto.ToDto(siparis));
            }
            return dto_list;
        }
        [WebMethod]
        public SiparisDto Get(int id)
        {
            return SiparisDto.ToDto(db.Siparis.Find(id));
        }
        [WebMethod]
        public void Add(SiparisDto dto)
        {
            db.Siparis.Add(SiparisDto.ToSiparis(dto));
            db.SaveChanges();
        }
        [WebMethod]
        public void Update(SiparisDto dto)
        {
            var siparis = db.Siparis.Find(dto.SiparisID);
            siparis.SiparisDurum = dto.SiparisDurum;
            siparis.SiparisTarih = dto.SiparisTarih;
            siparis.SiparisTutari = dto.SiparisTutari;
           
            db.SaveChanges();
        }
        [WebMethod]
        public void Delete(int id)
        {
            var siparis = db.Siparis.Find(id);
            db.Siparis.Remove(siparis);
            db.SaveChanges();
        }
    }
}
