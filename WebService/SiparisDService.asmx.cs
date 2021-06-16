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
    /// Summary description for SiparisDService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SiparisDService : System.Web.Services.WebService
    {
        MezatDBEntities db = new MezatDBEntities();

        [WebMethod]
        public List<SDetayDto> GetAll()
        {
            var list = db.SiparisDetay.ToList();
            var dto_list = new List<SDetayDto>();
            foreach (var siparisDetay in list)
            {
                dto_list.Add(SDetayDto.ToDto(siparisDetay));
            }
            return dto_list;
        }
        [WebMethod]
        public SDetayDto Get(int id)
        {
            return SDetayDto.ToDto(db.SiparisDetay.Find(id));
        }
        [WebMethod]
        public void Add(SDetayDto dto)
        {
            db.SiparisDetay.Add(SDetayDto.ToDetay(dto));
            db.SaveChanges();
        }
    }
}
