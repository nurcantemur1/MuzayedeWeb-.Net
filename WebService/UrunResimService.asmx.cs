using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebService.DB;

namespace WebService
{
    /// <summary>
    /// Summary description for UrunResimService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class UrunResimService : System.Web.Services.WebService
    {
        private MezatDBEntities db = new MezatDBEntities();

        [WebMethod]
        public void Add(UrunResim urunresim)
        {
            db.UrunResim.Add(urunresim);
            db.SaveChanges();

        }
    }
}
