using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSite.Models
{
    public class KullaniciViewModel
    {
        public int id { get; set; }
        public string isim { get; set; }
        public string soyisim { get; set; }
        public string email { get; set; }
        public string sifre { get; set; }
        public string sifreTekrar { get; set; }
        public string adres { get; set; }
        public string telefon { get; set; }
    }
}