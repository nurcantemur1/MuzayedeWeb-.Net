using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.DB;

namespace WebService.Dto
{
    public class MuzayedeDto 
    {
        public int MuzayedeID { get; set; }
        public string MuzayedeAdi { get; set; }
 
        public TimeSpan Sure { get; set; }
        public DateTime MTarih { get; set; }
        public int KullaniciID { get; set; }



        public static MezatDBEntities db = new MezatDBEntities();
        public static MuzayedeDto ToDto(Muzayede muzayede)
        {
            MuzayedeDto dto = new MuzayedeDto();
            dto.MuzayedeID = muzayede.MuzayedeID;
            dto.MuzayedeAdi = muzayede.MuzayedeAdi;
            dto.Sure = muzayede.Sure;
            dto.MTarih = muzayede.MTarih;
            dto.KullaniciID = muzayede.KullaniciID;
          

            return dto;
        }


        public static Muzayede Tomuzayede(MuzayedeDto dto)
        {
            Muzayede muzayede = new Muzayede();
            muzayede.MuzayedeAdi = dto.MuzayedeAdi;
            muzayede.MTarih = dto.MTarih;
            muzayede.Sure = dto.Sure;
            muzayede.KullaniciID = dto.KullaniciID;
           
            return muzayede;
        }

      
    }
}