using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using WebService.DB;

namespace WebService.Model
{
    public class MuzayedeModel
    {
        public Muzayede muzayede { get; set; }
        public List<MurunleriModel> muzayedeUrunleri { get; set; }
    }
}