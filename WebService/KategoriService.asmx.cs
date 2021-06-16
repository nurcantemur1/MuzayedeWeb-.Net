using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using Microsoft.AspNetCore.Mvc;
using WebService.DB;
using WebService.Dto;


namespace WebService
{
    /// <summary>
    /// Summary description for KategoriService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class KategoriService : System.Web.Services.WebService
    {
        MezatDBEntities db = new MezatDBEntities();

        [WebMethod]
        public List<KategoriDto> GetAll()
        {
            var list = db.Kategori.ToList();
            var dto_list = new List<KategoriDto>();
            foreach (var kategori in list)
            {
                dto_list.Add(KategoriDto.ToDto(kategori));
            }
            return dto_list;
        }

        [WebMethod]
        public KategoriDto Get(int id)
        {
            return KategoriDto.ToDto(db.Kategori.Find(id));
        }

        [WebMethod]
        public void Add(KategoriDto dto)
        {
            db.Kategori.Add(KategoriDto.ToKategori(dto));
            db.SaveChanges();
        }
        [WebMethod]
        public void Update(KategoriDto dto)
        {
            var kategori = db.Kategori.Find(dto.KategoriID);
            kategori.KategoriAdi = dto.KategoriAdi;
            kategori.KategoriDurum = dto.KategoriDurum;
            db.SaveChanges();
        }
        [WebMethod]
        public void Delete(int id)
        {
            var kategori = db.Kategori.Find(id);
            db.Kategori.Remove(kategori);
            db.SaveChanges();
        }
    }
}
