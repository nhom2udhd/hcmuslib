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
        QLTHUVIENEntities data = new QLTHUVIENEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RegisterTraining(string type, string number) 
        {
            if (Request.IsAjaxRequest())
            {
                string rname = Request["rname"];
                string rphone = Request["rphone"];
                string rtype = Request["rtype"];
                string rmail = Request["rmail"];
                switch (rtype) 
                {
                    case "sv":
                        rtype = "Sinh vien";
                        break;
                    case "sdh":
                        rtype = "Sau DH";
                        break;
                    case "cb":
                        rtype = "Can bo";
                        break;
                    default:
                        rtype = null;
                        break;
                }
                Random ran = new Random(12);
                string str = ran.Next(0, 99999999).ToString();
                string id = "TH" + str.PadLeft(8, '0');
                var findid = (from b in data.TAPHUAN
                              where b.ID == id
                              select b).ToList();

                while (findid.Count != 0)
                {

                    str = ran.Next(0, 99999999).ToString();
                    id = "TH" + str.PadLeft(8, '0');
                    findid = (from b in data.TAPHUAN
                              where b.ID == id
                              select b).ToList();
                }
                TAPHUAN th = new TAPHUAN 
                {
                    ID = id,
                    HO_TEN = rname,
                    SDT = rphone,
                    LOAI_DOC_GIA = rtype,
                    TINH_TRANG = "0",
                    EMAIL = rmail
                };
                data.TAPHUAN.Add(th);
                data.SaveChanges();
                return PartialView("_RegisterTrainingMessage");
            }
            return View();
        }
    }
}
