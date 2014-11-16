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
        public ActionResult InputLibrarian(string DGSearch)
        {
            DOCGIA dg = new DOCGIA();
            if (DGSearch != null)
            {
                dg = (from d in data.DOCGIA where d.MS_THE == DGSearch select d).First();
                @ViewBag.DGSearch = DGSearch;
            }
                
            return View(dg);
        }
    }
}
