using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hcmuslib.Models;

namespace hcmuslib.Controllers
{
    public class ProvidedController : Controller
    {
        //
        // GET: /Provided/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult viewList()
        {
            DONHANG data = new DONHANG();
            
            return View();
        }
    }
}
