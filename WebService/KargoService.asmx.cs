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
    /// Summary description for KargoService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class KargoService : System.Web.Services.WebService
    {

        MezatDBEntities db = new MezatDBEntities();

        [WebMethod]
        public List<KargoDto> GetAll()
        {
            var list = db.Kargo.ToList();
            var dto_list = new List<KargoDto>();
            foreach (var kargo in list)
            {
                dto_list.Add(KargoDto.ToDto(kargo));
            }
            return dto_list;
        }
        [WebMethod]
        public KargoDto Get(int id)
        {
            return KargoDto.ToDto(db.Kargo.Find(id));
        }
        [WebMethod]
        public void Add(KargoDto dto)
        {
            db.Kargo.Add(KargoDto.ToKargo(dto));
            db.SaveChanges();
        }
    }
}
