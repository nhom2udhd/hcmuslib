using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hcmuslib.Models;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;

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

        public ActionResult ViewMS(string MSType,string keySearch)
        {        
            
            var ms = from d in data.LUUHANHSACH select d;
            ViewBag.MsType0 = "selected";
            @ViewBag.keySearch = keySearch;
            
                
            if(MSType == "0")
            {
                ms = from d in data.LUUHANHSACH where d.ID_LUU_HANH.Contains(keySearch) || d.DOC_GIA.Contains(keySearch)
                        || d.ID_SACH.Contains(keySearch)
                    select d;
            }
            else if (MSType == "1")
            {
                    ViewBag.MsType1 = "selected";
                    ViewBag.MsType0 = "";
                    ms = from d in data.LUUHANHSACH
                         where d.TINH_TRANG == "1" && (d.ID_LUU_HANH.Contains(keySearch) || d.DOC_GIA.Contains(keySearch)
                             || d.ID_SACH.Contains(keySearch))
                         select d;
            }
            else if (MSType == "2")
            {
                    ViewBag.MsType2 = "selected";
                    ViewBag.MsType0 = "";
                    ms = from d in data.LUUHANHSACH
                         where (d.TINH_TRANG == "0" && d.THOI_HAN_MUON <= DateTime.Today) && (d.ID_LUU_HANH.Contains(keySearch) || d.DOC_GIA.Contains(keySearch)
                             || d.ID_SACH.Contains(keySearch))
                         select d;
            }
            else if (MSType == "3")
            {
                ViewBag.MsType3 = "selected";
                ViewBag.MsType0 = "";
                ms = from d in data.LUUHANHSACH
                        where (d.TINH_TRANG == "0" && d.THOI_HAN_MUON >= DateTime.Today
                            && DateTime.Today >= DbFunctions.AddDays(d.THOI_HAN_MUON, -2)) && (d.ID_LUU_HANH.Contains(keySearch) || d.DOC_GIA.Contains(keySearch)
                        || d.ID_SACH.Contains(keySearch))
                        select d;
            }
                          
            var list_ms = ms.ToList();
            return View(list_ms);
        }
    }
}
