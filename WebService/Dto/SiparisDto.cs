using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.DB;

namespace WebService.Dto
{
    public class SiparisDto
    {
        public int SiparisID { get; set; }
        public bool SiparisDurum { get; set; }
        public decimal SiparisTutari { get; set; }
        public DateTime SiparisTarih { get; set;}
        public int UrunID { get; set; }
        public int KullaniciID { get; set; }
        public int SiparisDetayID { get; set; }


        public static MezatDBEntities db = new MezatDBEntities();
        public static SiparisDto ToDto(Siparis siparis)
        {
            SiparisDto dto = new SiparisDto();
            dto.SiparisID = siparis.SiparisID;
            dto.SiparisTarih = siparis.SiparisTarih;
            dto.SiparisDurum = siparis.SiparisDurum;
            dto.KullaniciID = siparis.KullaniciID;
            siparis.SiparisDetayID = siparis.SiparisDetayID;

            return dto;
        }


        public static Siparis ToSiparis(SiparisDto dto)
        {
            Siparis siparis = new Siparis();
            siparis.SiparisID = dto.SiparisID;
            siparis.SiparisTarih = dto.SiparisTarih;
            siparis.SiparisDurum = dto.SiparisDurum;
            siparis.KullaniciID = dto.KullaniciID;
            siparis.SiparisDetayID = dto.SiparisDetayID;
         

            return siparis;
        }

    }
}