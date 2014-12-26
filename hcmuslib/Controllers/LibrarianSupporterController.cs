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
    [Authorize(Roles = "ReaderSupporter")]
    public class LibrarianSupporterController : Controller
    {
        //
        // GET: /LibrarianSupporter/
        QLTHUVIENEntities data = new QLTHUVIENEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SendMail(string id_dg, string ngay_tra)
        {
            var viewResult = ViewMS() as ActionResult;
            //if (viewResult != null)
            //{
            //    viewResult.ViewName = "~/Views/Home/Contact.cshtml";
            //}
            var dg = (from d in data.DOCGIA where d.MS_THE == id_dg select d).First();
            EMail oMail = new EMail();
            oMail.SendMail("Email", dg.EMAIL, new String[] { "Nhắc Nhở Trả Sách Thư Viện ĐH Khoa Học Tự Nhiên", "Chào bạn, hệ thống thư viện nhắc nhở bạn ngày " + ngay_tra + " là đến hạn trả sách mà bạn đang mượn vui lòng thực hiện đúng như yêu cầu. Cám ơn"});
            
            return viewResult;
        }

        public ActionResult ViewMS()
        {                      
            return View();
        }
        public PartialViewResult AjaxApi_ViewMS(string MSType,string keySearch, string CurrentFilter, string CurrentType , int? page)
        {
            var ms = from d in data.LUUHANHSACH.AsNoTracking() select d;
            ViewBag.MsType0 = "selected";  
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

                    ms = from d in data.LUUHANHSACH.AsNoTracking()
                         where d.ID_LUU_HANH.Contains(keySearch) || d.DOC_GIA.Contains(keySearch)
                             || d.ID_SACH.Contains(keySearch)
                         select d;
                    break;
                case "1":
                    ViewBag.MsType1 = "selected";
                    ViewBag.MsType0 = "";
                    
                    ms = from d in data.LUUHANHSACH.AsNoTracking()
                         where d.TINH_TRANG == "1" && (d.ID_LUU_HANH.Contains(keySearch) || d.DOC_GIA.Contains(keySearch)
                             || d.ID_SACH.Contains(keySearch))
                         select d;
                    break;
                case "2":
                    ViewBag.MsType2 = "selected";
                    ViewBag.MsType0 = "";
                    ms = from d in data.LUUHANHSACH.AsNoTracking()
                         where (d.TINH_TRANG == "0" && d.THOI_HAN_MUON <= DateTime.Today) && (d.ID_LUU_HANH.Contains(keySearch) || d.DOC_GIA.Contains(keySearch)
                             || d.ID_SACH.Contains(keySearch))
                         select d;
                    break;
                case "3":
                    ViewBag.MsType3 = "selected";
                    ViewBag.MsType0 = "";
                    ms = from d in data.LUUHANHSACH.AsNoTracking()
                         where (d.TINH_TRANG == "0" && d.THOI_HAN_MUON >= DateTime.Today
                             && DateTime.Today >= DbFunctions.AddDays(d.THOI_HAN_MUON, -2)) && (d.ID_LUU_HANH.Contains(keySearch) || d.DOC_GIA.Contains(keySearch)
                         || d.ID_SACH.Contains(keySearch))
                         select d;
                    break;
                default:
                    ms = (from d in data.LUUHANHSACH.AsNoTracking() select d);
                    break;
            }
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            
            var list_ms = ms.ToList();
            @ViewBag.Count = list_ms.Count;
            return PartialView("AjaxApi_ViewMS", list_ms.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult TrainingManagement() 
        {
            if (Request.IsAjaxRequest()) 
            {
                string action = Request["action"];
                string tmtype = Request["tmtype"];
                string tt = "0";
                switch (tmtype)
                {
                    case "requested":
                        tt = "0";
                        break;
                    case "pending":
                        tt = "1";
                        break;
                    case "trained":
                        tt = "2";
                        break;
                }               
                if (action == "tmview")
                {
                    var tha = from t in data.TAPHUAN
                              where t.TINH_TRANG == tt
                              select t;
                    if (tha.Any())
                    {
                        ViewBag.type = tt;
                        return PartialView("_TrainingTableView", tha.ToList());
                    }
                    else
                    {
                        return PartialView("_TrainingNotFound");
                    }
                }
                if (action == "adddate") {
                    int day = Convert.ToInt16(Request["day"]);
                    int month = Convert.ToInt16(Request["month"]);
                    int year = Convert.ToInt16(Request["year"]);
                    int number = Convert.ToInt16(Request["number"]);
                    DateTime dt = new DateTime(year, month, day);
                    var tha = (from t in data.TAPHUAN
                              where t.TINH_TRANG == "0"
                              select t);
                    var thal = tha.Take(number);
                    if (thal.Any())
                    {
                        foreach (var item in thal) 
                        {
                            item.NGAY_DANG_KY = dt;
                            item.TINH_TRANG = "1";
                        }
                        data.SaveChanges();
                        ViewBag.type = "0";
                        return PartialView("_TrainingTableView", tha.ToList());
                    }
                    
                }
               
            }
            var th = from t in data.TAPHUAN
                     where t.TINH_TRANG == "0"
                     select t;           
            return View(th.ToList());            
        }
    }
}
