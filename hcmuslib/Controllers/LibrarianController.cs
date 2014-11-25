using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hcmuslib.Models;
using PagedList;

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

        public ActionResult ManageReaderImage(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var docgia = from p in data.DOCGIA select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                docgia = docgia.Where(p => p.MS_THE.Contains(searchString));
            }
            
            switch (sortOrder)
            { 
                case "name_desc":
                    docgia = docgia.OrderByDescending(p => p.HO_TEN);
                    break;
                default:
                    docgia = docgia.OrderBy(p => p.HO_TEN);
                    break;
            }

            int pageSize = 20;
            int pageNumber = (page ?? 1);
            return View(docgia.ToPagedList(pageNumber, pageSize));
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
    }
}
