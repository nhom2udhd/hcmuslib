using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hcmuslib.Models;
namespace hcmuslib.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SendMail(FormCollection f)
        {
            string first_name = f["first_name"];
            string last_name = f["last_name"];
            string message = f["message"];
            string email = f["email"];
            EMail oMail = new EMail();
            oMail.SendMail("Email", "1112201@student.hcmus.edu.vn", new String[] { String.Concat("Ngu", " ", "nguyen", " - Góp ý"), "hello" });
            return RedirectToAction("index", "home");
        }
    }
}
