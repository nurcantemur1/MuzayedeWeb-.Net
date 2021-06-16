using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.DB;

namespace WebService.Dto
{
    public class MUrunleriDto
    {
        public int ID { get; set; }
        public Muzayede muzayede { get; set; }
        public UrunDto Urundto { get; set; }



        public static MezatDBEntities db = new MezatDBEntities();
        public static MUrunleriDto ToDto(MuzayedeUrunleri muzayedeUrunleri)
        {
            MUrunleriDto dto = new MUrunleriDto();
            dto.ID = muzayedeUrunleri.ID;
            dto.muzayede = db.Muzayede.Find(muzayedeUrunleri.MuzayedeID);
            dto.Urundto = UrunDto.ToDto(db.Urun.Find(muzayedeUrunleri.UrunID));
            return dto;
        }


        public static MuzayedeUrunleri ToMUrunleri(MUrunleriDto dto)
        {
            MuzayedeUrunleri muzayedeUrunleri = new MuzayedeUrunleri();
            muzayedeUrunleri.ID = dto.ID;
            muzayedeUrunleri.MuzayedeID = dto.muzayede.MuzayedeID;
            muzayedeUrunleri.UrunID = dto.Urundto.UrunID;

            return muzayedeUrunleri;
        }
    }
}