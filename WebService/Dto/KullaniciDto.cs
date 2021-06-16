using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using WebService.DB;

namespace WebService.Dto
{
    public class KullaniciDto
    {
        [HiddenInput(DisplayValue =false)]
        public int KullaniciID { get; set; }
        [Required]
        public string KullaniciAdi { get; set; }
        [Required]
        public string KullaniciSoyadi { get; set; }
        [Required]
        public string KullaniciAdres { get; set; }
        [Required]
        public string Kullanicimail { get; set; }
        [Required]
        public string KullaniciTelefon { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Sifre { get; set; }

        public static MezatDBEntities db = new MezatDBEntities();

        public static Kullanici ToKullanici(string email, string sifre)
        {
            throw new NotImplementedException();
        }

        public static KullaniciDto ToDto(int kullaniciID)
        {
            throw new NotImplementedException();
        }

        public static KullaniciDto ToDto(Kullanici kullanici)
        {
            KullaniciDto dto = new KullaniciDto();
            dto.KullaniciID = kullanici.KullaniciID;
            dto.KullaniciAdi = kullanici.KullaniciAdi;
            dto.KullaniciSoyadi = kullanici.KullaniciSoyadi;
            dto.KullaniciAdres = kullanici.KullaniciAdres;
            dto.Kullanicimail = kullanici.Kullanicimail;
            dto.KullaniciTelefon = kullanici.KullaniciTelefon;
            dto.Sifre = kullanici.Sifre;

            return dto;
        }

        public static Kullanici ToKullanici(KullaniciDto dto)
        {
            Kullanici kullanici = new Kullanici();
            kullanici.KullaniciID = dto.KullaniciID;
            kullanici.KullaniciAdi = dto.KullaniciAdi;
            kullanici.KullaniciSoyadi = dto.KullaniciSoyadi;
            kullanici.KullaniciAdres = dto.KullaniciAdres;
            kullanici.Kullanicimail = dto.Kullanicimail;
            kullanici.KullaniciTelefon = dto.KullaniciTelefon;
            kullanici.Sifre = dto.Sifre;

            return kullanici;
        }
        internal static string ToKullanici(object kullanicimail)
        {
            throw new NotImplementedException();
        }
    }
}