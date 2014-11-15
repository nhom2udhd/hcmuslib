using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hcmuslib.Models;

namespace hcmuslib.Controllers
{
    public class ReaderController : Controller
    {
        //
        // GET: /Reader/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RegisterTraining() 
        {
            return View();
        }
    }
}
