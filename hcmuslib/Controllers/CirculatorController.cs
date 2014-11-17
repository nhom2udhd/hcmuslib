using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hcmuslib.Models;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;

namespace hcmuslib.Controllers
{
    public class CirculatorController : Controller
    {
        //
        // GET: /Circulator/
        QLTHUVIENEntities data = new QLTHUVIENEntities();
        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult InputLibrarian()
        {
            //DOCGIA dg = new DOCGIA();
            //if (DGSearch != null)
            //{
            //    dg = (from d in data.DOCGIA where d.MS_THE == DGSearch select d).FirstOrDefault();
            //    if (dg == null)
            //        dg = new DOCGIA();
            //    @ViewBag.DGSearch = DGSearch;
            //}
                
            return View();
        }
        [HttpPost]
        public PartialViewResult GetDG(string DG_ID = "")
        {
            DOCGIA dg = new DOCGIA();
            if (DG_ID != null)
            {
                dg = (from d in data.DOCGIA where d.MS_THE == DG_ID select d).FirstOrDefault();
                if (dg == null)
                    dg = new DOCGIA();
                @ViewBag.DGSearch = DG_ID;
            }
            return PartialView("GetDG",dg);
        }
    }
}
