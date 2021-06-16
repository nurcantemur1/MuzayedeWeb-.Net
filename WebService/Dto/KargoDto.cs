using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.DB;

namespace WebService.Dto
{
    public class KargoDto
    {
        public int KargoID { get; set; }
        public string KargoAdi { get; set; }
        public decimal KargoUcreti { get; set; }
        public DateTime KargoTarihi { get; set; }
        public bool KargoDurum { get; set; }
        public DateTime SiparisTarih { get; set; }
        public decimal SiparisTutari { get; set; }



        public static MezatDBEntities db = new MezatDBEntities();

        public static KargoDto ToDto(Kargo kargo)
        {
            KargoDto dto = new KargoDto();
            dto.KargoID = kargo.KargoID;
            dto.KargoAdi = kargo.KargoAdi;
            dto.KargoUcreti = kargo.KargoUcreti;
            dto.KargoTarihi = kargo.KargoTarihi;
            dto.KargoDurum = kargo.KargoDurum;
            dto.SiparisTarih = db.Siparis.Find(kargo.SiparisID).SiparisTarih;
            dto.SiparisTutari = db.Siparis.Find(kargo.SiparisID).SiparisTutari;

            return dto;
        }


        public static Kargo ToKargo(KargoDto dto)
        {
            Kargo kargo = new Kargo();
            kargo.KargoID = dto.KargoID;
            kargo.KargoAdi = dto.KargoAdi;
            kargo.KargoUcreti = dto.KargoUcreti;
            kargo.KargoTarihi = dto.KargoTarihi;
            kargo.KargoDurum = dto.KargoDurum;
            kargo.SiparisID = db.Siparis.Find(dto.SiparisTutari).SiparisID;
            kargo.SiparisID = db.Siparis.Find(dto.SiparisTarih).SiparisID;

            return kargo;
        }
    }
}