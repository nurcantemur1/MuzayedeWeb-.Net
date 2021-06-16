using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading;
using System.Web.Services;
using WebService.DB;
using WebService.Dto;

namespace WebService
{
    /// <summary>
    /// Summary description for UrunlerServis
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class UrunlerServis : System.Web.Services.WebService
    {
        MezatDBEntities db = new MezatDBEntities();

        [WebMethod]
        public List<UrunDto> GetAll()
        {
            var list = db.Urun.ToList();
            var dto_list = new List<UrunDto>();
            foreach( var urun in list)
            {
                dto_list.Add(UrunDto.ToDto(urun));  
            }
            return dto_list;
        }
        [WebMethod]
        public Urun Get(int id)
        {
            return db.Urun.Find(id);
        }
        [WebMethod]
        public void Add(Urun urun)
        {
            db.Urun.Add(urun);
            db.SaveChanges();
        }
        [WebMethod]
        public void Update(Urun urun)
        {
            db.Urun.AddOrUpdate(urun);
            db.SaveChanges();
        }
        [WebMethod]
        public void Delete(int id)
        {
            var urun = db.Urun.Find(id);
            db.Urun.Remove(urun);
            db.SaveChanges();
        }
        [WebMethod]
        public List<Urun> GetList(int kid)
        {
            return db.Urun.Where(x=> x.KullaniciID == kid && !x.UrunDurum).ToList();
        }
    }
}
