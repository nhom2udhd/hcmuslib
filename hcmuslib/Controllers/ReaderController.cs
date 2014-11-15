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

        public ActionResult RegisterTraining(string type, string number) 
        {
            if (Request.IsAjaxRequest()) {
                ViewBag.type = type;
                ViewBag.number = number;
                return PartialView("_RegisterTrainingMessage");
            }
            return View();
        }
    }
}
