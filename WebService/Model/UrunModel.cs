using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.DB;

namespace WebService.Model
{
    public class UrunModel
    {
        public  Urun urun { get; set; }
        public Kullanici kullanici { get; set; }
        public Kategori kategori { get; set; }
    }
}