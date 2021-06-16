using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.DB;

namespace WebSite.Models
{
    public class ListUrunModel
    {
        public Urun urun { get; set; }
        public bool check { get; set; } 
    }
}