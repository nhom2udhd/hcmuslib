using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hcmuslib.Models;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using PagedList;
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

        public ActionResult ViewMS(string MSType,string keySearch,string sortOrder, string CurrentFilter, string CurrentType, int? page)
        {           
            var ms = from d in data.LUUHANHSACH select d;
            ViewBag.MsType0 = "selected";
            //@ViewBag.keySearch = keySearch;   
            if(keySearch != null)
            {
                page = 1;
            }
            else
            {
                keySearch = CurrentFilter;
            }
            if (MSType != null)
            {
                page = 1;
            }
            else
            {
                MSType = CurrentType;
            }
            ViewBag.CurrentFilter = keySearch;
            ViewBag.CurrentType = MSType;
            if (keySearch == null)
                keySearch = "";
            switch (MSType)
            {
                case "0":

                    ms = from d in data.LUUHANHSACH
                         where d.ID_LUU_HANH.Contains(keySearch) || d.DOC_GIA.Contains(keySearch)
                             || d.ID_SACH.Contains(keySearch)
                         select d;
                    break;
                case "1":
                    ViewBag.MsType1 = "selected";
                    ViewBag.MsType0 = "";
                    
                    ms = from d in data.LUUHANHSACH
                         where d.TINH_TRANG == "1" && (d.ID_LUU_HANH.Contains(keySearch) || d.DOC_GIA.Contains(keySearch)
                             || d.ID_SACH.Contains(keySearch))
                         select d;
                    break;
                case "2":
                    ViewBag.MsType2 = "selected";
                    ViewBag.MsType0 = "";
                    ms = from d in data.LUUHANHSACH
                         where (d.TINH_TRANG == "0" && d.THOI_HAN_MUON <= DateTime.Today) && (d.ID_LUU_HANH.Contains(keySearch) || d.DOC_GIA.Contains(keySearch)
                             || d.ID_SACH.Contains(keySearch))
                         select d;
                    break;
                case "3":
                    ViewBag.MsType3 = "selected";
                    ViewBag.MsType0 = "";
                    ms = from d in data.LUUHANHSACH
                         where (d.TINH_TRANG == "0" && d.THOI_HAN_MUON >= DateTime.Today
                             && DateTime.Today >= DbFunctions.AddDays(d.THOI_HAN_MUON, -2)) && (d.ID_LUU_HANH.Contains(keySearch) || d.DOC_GIA.Contains(keySearch)
                         || d.ID_SACH.Contains(keySearch))
                         select d;
                    break;
                default:
                    ms = (from d in data.LUUHANHSACH select d);
                    break;
            }
<<<<<<< HEAD
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            
            var list_ms = ms.ToList();
            return View(list_ms.ToPagedList(pageNumber,pageSize));
=======
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

>>>>>>> 0fb5938b2b6fc7f3d905561f31d7934bf19a5016
        }
    }
}
