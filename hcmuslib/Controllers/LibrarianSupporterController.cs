using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hcmuslib.Models;

namespace hcmuslib.Controllers
{
    public class LibrarianSupporterController : Controller
    {
        //
        // GET: /LibrarianSupporter/
        QLTHUVIENEntities data = new QLTHUVIENEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewMS(string MSType)
        {
                      
            var dh = from d in data.LUUHANHSACH select d;
            
            
            if (MSType == "1")
            {
                dh = from d in data.LUUHANHSACH where d.TINH_TRANG == "1" select d;
            }
            else if (MSType == "2")
            {
                dh = from d in data.LUUHANHSACH where d.TINH_TRANG == "0" select d;
            }
            else if (MSType == "3")
            {
                dh = from d in data.LUUHANHSACH where (d.TINH_TRANG == "0") select d;
            }
            var list_dh = dh.ToList();
            return View(list_dh,MSType);
        }

        private ActionResult View(List<LUUHANHSACH> list_dh, string MSType)
        {
            throw new NotImplementedException();
        }
        //public ActionResult selectMSType(string MSType)
        //{
        //    var dh = from d in data.LUUHANHSACH select d ;
        //    if(MSType == "1")
        //    {
        //        dh = from d in data.LUUHANHSACH where d.TINH_TRANG == "1" select d;
        //    }
        //    else if(MSType == "2")
        //    {
        //        dh = from d in data.LUUHANHSACH where d.TINH_TRANG == "0" select d; 
        //    }
        //    else if(MSType == "3")
        //    {
        //        dh = from d in data.LUUHANHSACH where (d.TINH_TRANG == "0") select d;
        //    }
               

        //    var list_dh = dh.ToList();
        //    return View(list_dh);
        //}

    }
}
