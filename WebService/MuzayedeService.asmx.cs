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
    /// Summary description for MuzayedeService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MuzayedeService : System.Web.Services.WebService
    {
        MezatDBEntities db = new MezatDBEntities();

       [WebMethod]
       [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<MuzayedeDto> GetAll()
        {
            var list = db.Muzayede.ToList();
            var dto_list = new List<MuzayedeDto>();
            foreach (var muzayede in list)
            {
                dto_list.Add(MuzayedeDto.ToDto(muzayede));
            }
            return dto_list;
        }
       [WebMethod]
       [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
       public List<MuzayedeDto> GetAll2(bool state = true)
        {


            var list = new List<Muzayede>();
            if (state) list = db.Muzayede.OrderBy(x => x.Izlenme).Take(10).ToList();
            else list = db.Muzayede.OrderByDescending(x => x.Izlenme).Take(10).ToList();

            var dto_list = new List<MuzayedeDto>();
            foreach (var muzayede in list)
            {
                dto_list.Add(MuzayedeDto.ToDto(muzayede));
            }
            return dto_list;
        }
      

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<MuzayedeDto> KMGetAll(int kId)
        {
            var  list = db.Muzayede.Where(x=>x.KullaniciID == kId).ToList();
            var dto_list = new List<MuzayedeDto>();
            foreach (var muzayede in list)
            {
                dto_list.Add(MuzayedeDto.ToDto(muzayede));
            }
            return dto_list;
        }
        
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Muzayede Get(int id)
        {
            return db.Muzayede.Find(id);
        }

      [WebMethod]
        public Muzayede Add(Muzayede muzayede)
        {
            db.Muzayede.Add(muzayede);
            db.SaveChanges();
            return Get(muzayede.MuzayedeID);
        }

        [WebMethod]
        public void Update(MuzayedeDto dto)
        {
            var muzayede = db.Muzayede.Find(dto.MuzayedeID);
            muzayede.MuzayedeAdi = dto.MuzayedeAdi;
            muzayede.MTarih = dto.MTarih;
            muzayede.Sure = dto.Sure;
            db.SaveChanges();
        }
        [WebMethod]
        public void Delete(int id)
        {
            var muzayede = db.Muzayede.Find(id);
            db.Muzayede.Remove(muzayede);
            db.SaveChanges();
        }
    }
}
