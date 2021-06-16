using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.DB;

namespace WebService.Dto
{
    public class KategoriDto
    {
        public int KategoriID { get; set; }
        public string KategoriAdi { get; set; }
        public bool KategoriDurum { get; set; }


        public static MezatDBEntities db = new MezatDBEntities();
        public static KategoriDto ToDto(Kategori kategori)
        {
            KategoriDto dto = new KategoriDto();
            dto.KategoriID = kategori.KategoriID;
            dto.KategoriAdi = kategori.KategoriAdi;
           

            return dto;
        }


        public static Kategori ToKategori(KategoriDto dto)
        {
            Kategori kategori = new Kategori();
            kategori.KategoriID = dto.KategoriID;
            kategori.KategoriAdi = dto.KategoriAdi;

            return kategori;
        }
    }
}