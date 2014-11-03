using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hcmuslib.Controllers
{
    public class LibrarianController : Controller
    {
        //
        // GET: /Librarian/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ManageReaderImage()
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
    }
}
