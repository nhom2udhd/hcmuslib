using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hcmuslib.Models;

namespace hcmuslib.Controllers
{
    public class LibrarianController : Controller
    {
        //
        // GET: /Librarian/
        QLTHUVIENEntities data = new QLTHUVIENEntities();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult BarcodeReader()
        {
            return View();
        }
        public ActionResult Analytics()
        {
            return View();
        }

        public ActionResult ManageReaderImage()
        {
            var result = from p in data.DOCGIA select p;
            var reader = result.ToList();           
            return View(reader);
        }

        [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
        public class MultipleButtonAttribute : ActionNameSelectorAttribute
        {
            public string Name { get; set; }
            public string Argument { get; set; }

            public override bool IsValidName(ControllerContext controllerContext, string actionName, System.Reflection.MethodInfo methodInfo)
            {
                var isValidName = false;
                var keyValue = string.Format("{0}:{1}", Name, Argument);
                var value = controllerContext.Controller.ValueProvider.GetValue(keyValue);

                if (value != null)
                {
                    controllerContext.Controller.ControllerContext.RouteData.Values[Name] = Argument;
                    isValidName = true;
                }

                return isValidName;
            }
        }

        [HttpPost]
        [MultipleButton(Name = "action", Argument = "Search")]
        public ActionResult Search(FormCollection f)
        { 
            string id = f["id-reader"];
            var result = from p in data.DOCGIA where p.MS_THE == id || p.HO_TEN.Contains(id) select p;

            return View(result);
        }

        [HttpPost]
        [MultipleButton(Name = "action", Argument = "BackToAll")]
        public ActionResult BackToAll()
        {
            return RedirectToAction("ManageReaderImage");
        }

        [HttpPost]
        [MultipleButton(Name = "action", Argument = "Upload")]
        public ActionResult Upload(FormCollection f, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                var MST = f["mathe"];
                DOCGIA result = (from p in data.DOCGIA where p.MS_THE == MST select p).First();

                var fileName = string.Format("avatar-{0}.png", result.MS_THE);
                var path = Path.Combine(Server.MapPath("~/Images/profilePic"), fileName);
                file.SaveAs(path);

                result.IMAGE_URL = fileName;
                data.SaveChanges();
            }
            return RedirectToAction("ManageReaderImage");
        }

        [HttpPost]
        [MultipleButton(Name = "action", Argument = "Remove")]
        public ActionResult Remove(FormCollection f)
        {
            var MST = f["mathe"];
            DOCGIA result = (from p in data.DOCGIA where p.MS_THE == MST select p).First();

            string current = Request.MapPath("~/Images/profilePic/" + result.IMAGE_URL);
            if (System.IO.File.Exists(current))
            {
                System.IO.File.Delete(current);
            }

            result.IMAGE_URL = null;
            data.SaveChanges();
            
            return RedirectToAction("ManageReaderImage");
        }

        public ActionResult BookReturningHome() 
        {
            string maDG = Request["madg"];
            string action = Request["action"];
            if (Request.IsAjaxRequest())
            {
                switch (action) {
                    case "show":
                         var lh = from l in data.LUUHANHSACH
                             where l.DOC_GIA == maDG && l.TINH_TRANG == "0"
                             select l;
                        if (lh.Any())
                        {
                            return PartialView("_BookReturningDetail", lh.ToList());
                        }
                        else {
                            return PartialView("_BookReturningNotFound");
                        }
                        break;
                    case "confirm": 
                        string lhid = Request["lhid"];
                        var lh1 = (from l in data.LUUHANHSACH
                                where l.ID_LUU_HANH == lhid
                                select l).First();
                        lh1.TINH_TRANG = "1";
                        data.SaveChanges();
                        return PartialView("_ReturnConfirmMessage");
                        break;
                    case "punishment":
                        string bid = Request["bid"];
                        string status = Request["status"];
                        Random ran = new Random(12);
                        string str = ran.Next(0, 99999999).ToString();
                        string id = "BT"+str.PadLeft(8, '0');
                        var findid = (from b in data.BOITHUONGTHIETHAI
                                     where b.ID_BOI_THUONG == id
                                     select b).ToList();
                        
                        while (findid.Count != 0) {
                           
                            str = ran.Next(0, 99999999).ToString();
                            id = "BT" + str.PadLeft(8, '0');
                            findid = (from b in data.BOITHUONGTHIETHAI
                                    where b.ID_BOI_THUONG == id
                                    select b).ToList();
                        }
                        
                        BOITHUONGTHIETHAI bt = new BOITHUONGTHIETHAI 
                        {   
                            ID_BOI_THUONG = id,
                            ID_VAT_BOI_THUONG = bid,
                            DOC_GIA = maDG,
                            LY_DO = status,
                            NGAY_BOI_THUONG=DateTime.Now,
                            TINH_TRANG = "1"
                        };
                        data.BOITHUONGTHIETHAI.Add(bt);
                        data.SaveChanges();
                        return PartialView("_PunishmentConfirm");
                        break;

                }   
            }
            return View();
        }

    }
}
