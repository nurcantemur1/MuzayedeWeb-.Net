//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebService.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Kargo
    {
        public int KargoID { get; set; }
        public string KargoAdi { get; set; }
        public decimal KargoUcreti { get; set; }
        public System.DateTime KargoTarihi { get; set; }
        public bool KargoDurum { get; set; }
        public int SiparisID { get; set; }
    }
}