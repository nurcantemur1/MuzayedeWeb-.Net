using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Protocols;
using WebService.DB;

namespace WebService.Dto
{
    public class UrunDto 
    {
        public int UrunID { get; set; }
        public string KategoriAdi { get; set; }
        public string UrunAdi { get; set; }
        public int UrunAdet { get; set; }
        public decimal UrunFiyat { get; set; }
        public bool UrunDurum { get; set; }
        public string UrunAciklamasi { get; set; }
        public DateTime UrunTarihi { get; set; }
        public string Resim { get; set; }

        public static MezatDBEntities db = new MezatDBEntities();
        public static UrunDto ToDto(Urun urun)
        {
            UrunDto dto = new UrunDto();
            dto.UrunID = urun.UrunID;
            dto.UrunAdi = urun.UrunAdi;
            //dto.KategoriAdi = db.Kategori.Find(urun.KategoriID).KategoriAdi;
            dto.UrunAdet = urun.UrunAdet;
            dto.UrunFiyat = urun.UrunFiyat;
            dto.UrunDurum = urun.UrunDurum;
            dto.UrunAciklamasi = urun.UrunAciklamasi;
            var UresimID = db.UrunResim.FirstOrDefault(x => x.UrunID == urun.UrunID);
            //dto.Resim = db.Resim.Find(UresimID).Resim1;

            return dto;
        } 


        public static Urun ToUrun(UrunDto dto)
        {
            Urun urun = new Urun();
            urun.UrunID = dto.UrunID;
            urun.UrunAdi = dto.UrunAdi;
            //urun.KategoriID = db.Kategori.Find(dto.KategoriAdi).KategoriID;
            urun.UrunAdet = dto.UrunAdet;
            urun.UrunFiyat = dto.UrunFiyat;
            urun.UrunDurum = dto.UrunDurum;
            urun.UrunAciklamasi = dto.UrunAciklamasi;
            return urun;
        }
    }
}