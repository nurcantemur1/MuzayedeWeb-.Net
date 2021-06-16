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
    /// Summary description for FaturaService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class FaturaService : System.Web.Services.WebService
    {

        MezatDBEntities db = new MezatDBEntities();

        [WebMethod]
        public List<FaturaDto> GetAll()
        {
            var list = db.Fatura.ToList();
            var dto_list = new List<FaturaDto>();
            foreach (var fatura in list)
            {
                dto_list.Add(FaturaDto.ToDto(fatura));
            }
            return dto_list;
        }
        [WebMethod]
        public FaturaDto Get(int id)
        {
            return FaturaDto.ToDto(db.Fatura.Find(id));
        }
        [WebMethod]
        public void Add(FaturaDto dto)
        {
            db.Fatura.Add(FaturaDto.Tofatura(dto));
            db.SaveChanges();
        }
    }
}
