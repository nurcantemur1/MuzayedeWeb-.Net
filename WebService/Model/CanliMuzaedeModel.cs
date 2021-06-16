using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.DB;

namespace WebService.Model
{
    public class CanliMuzaedeModel
    {
        public Muzayede muzayede { get; set; }

        public MurunleriModel murun { get; set; }
    }
}