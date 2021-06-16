using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.DB;

namespace WebService.Dto
{
    public class KullaniciPeyDto
    {
        public int PeyID { get; set; }
        public MUrunleriDto MUrunDto { get; set; }
        public decimal Pey { get; set; }
        public DateTime PeyZaman { get; set; }
        public int KullaniciID { get; set; }


        public static MezatDBEntities db = new MezatDBEntities();
        public static KullaniciPeyDto ToDto(KullaniciPey kullaniciPey)
        {
            KullaniciPeyDto dto = new KullaniciPeyDto();
            dto.PeyID = kullaniciPey.PeyID;
            dto.Pey = kullaniciPey.Pey;
            dto.PeyZaman = kullaniciPey.PeyZaman;
            dto.KullaniciID = kullaniciPey.KullaniciID;
            dto.MUrunDto = MUrunleriDto.ToDto(db.MuzayedeUrunleri.Find(kullaniciPey.MurunID));
            return dto;
        }

        public static KullaniciPey ToPey(KullaniciPeyDto dto)
        {
            KullaniciPey kullaniciPey = new KullaniciPey();
            kullaniciPey.PeyID = dto.PeyID;
            kullaniciPey.Pey = dto.Pey;
            kullaniciPey.PeyZaman = dto.PeyZaman;
            kullaniciPey.KullaniciID = dto.KullaniciID;
            kullaniciPey.MurunID = dto.MUrunDto.ID;
            return kullaniciPey;
        }             
    
    }
 
}