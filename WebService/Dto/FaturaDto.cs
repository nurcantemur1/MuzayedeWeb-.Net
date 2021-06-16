using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.DB;

namespace WebService.Dto
{
    public class FaturaDto
    {
        public int FaturaID { get; set; }
        public int kargoID { get; set; }
        public string KargoAdi { get; set; }
        public decimal KargoUcreti { get; set; }
        public DateTime KargoTarihi { get; set; }
        public bool KargoDurum { get; set; }
        public int SiparisID { get; set; }
        public decimal SiparisTutari { get; set; }
        public int KullaniciID { get; set; }
        public string KullaniciAdi { get; set; }
        public string KullaniciSoyadi { get; set; }
        public string KullaniciAdres { get; set; }

        public static MezatDBEntities db = new MezatDBEntities();
        public static FaturaDto ToDto(Fatura fatura)
        {
            FaturaDto dto = new FaturaDto();
            dto.FaturaID = fatura.FaturaID;
            dto.KargoAdi = db.Kargo.Find(fatura.KargoID).KargoAdi;
            dto.KargoUcreti = db.Kargo.Find(fatura.KargoID).KargoUcreti;
            dto.KargoTarihi = db.Kargo.Find(fatura.KargoID).KargoTarihi;
            dto.KargoDurum = db.Kargo.Find(fatura.KargoID).KargoDurum;
            dto.KullaniciAdi = db.Kullanici.Find(fatura.KullaniciID).KullaniciAdi;
            dto.KullaniciSoyadi = db.Kullanici.Find(fatura.KullaniciID).KullaniciSoyadi;
            dto.KullaniciAdres = db.Kullanici.Find(fatura.KullaniciID).KullaniciAdres;
            dto.SiparisTutari = db.Siparis.Find(fatura.KargoID).SiparisTutari;
            return dto;
        }


        public static Fatura Tofatura(FaturaDto dto)
        {
            Fatura fatura = new Fatura();
            fatura.FaturaID = dto.FaturaID;
            fatura.KargoID = db.Kargo.Find(dto.KargoAdi).KargoID;
            fatura.KargoID = db.Kargo.Find(dto.KargoUcreti).KargoID;
            fatura.KargoID = db.Kargo.Find(dto.KargoTarihi).KargoID;
            fatura.KargoID = db.Kargo.Find(dto.KargoDurum).KargoID;
            fatura.KargoID = db.Siparis.Find(dto.SiparisTutari).SiparisID;
            fatura.KullaniciID = db.Kullanici.Find(dto.KullaniciAdi).KullaniciID;
            fatura.KullaniciID = db.Kullanici.Find(dto.KullaniciAdi).KullaniciID;
            fatura.KullaniciID = db.Kullanici.Find(dto.KullaniciSoyadi).KullaniciID;
            fatura.KullaniciID = db.Kullanici.Find(dto.KullaniciAdres).KullaniciID;


            return fatura;
        }
    }
}