using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.DB;

namespace WebService.Dto
{
    public class SDetayDto
    {
        public int SiparisDetayID { get; set; }
        public string UrunAcıklamasi { get; set; }
        public int UrunID { get; set; }
        public int SiparisID { get; set; }
        public decimal SiparisTutari { get; set; }
        public int Adet { get; set; }
        public DateTime  SiparisTarih { get; set; }

        public static MezatDBEntities db = new MezatDBEntities();

        public static SDetayDto ToDto(SiparisDetay siparisdetay)
        {
            SDetayDto dto = new SDetayDto();
            dto.SiparisDetayID = siparisdetay.SiparisDetayID;
            dto.SiparisTutari = db.Siparis.Find(siparisdetay.SiparisID).SiparisTutari; 
            dto.Adet = siparisdetay.Adet;
            dto.SiparisTarih = db.Siparis.Find(siparisdetay.SiparisID).SiparisTarih;
            dto.UrunAcıklamasi = db.Urun.Find(siparisdetay.UrunID).UrunAciklamasi;

            return dto;
        }


        public static SiparisDetay ToDetay(SDetayDto dto)
        {
            SiparisDetay siparisDetay = new SiparisDetay();
            siparisDetay.SiparisDetayID = dto.SiparisDetayID;
            siparisDetay.SiparisID = db.Siparis.Find(dto.SiparisTutari).SiparisID;
            siparisDetay.Adet = dto.Adet;
            siparisDetay.UrunID = db.Urun.Find(dto.UrunAcıklamasi).UrunID;
            siparisDetay.SiparisID = db.Siparis.Find(dto.SiparisTarih).SiparisID;

            return siparisDetay;
        }
    }
}