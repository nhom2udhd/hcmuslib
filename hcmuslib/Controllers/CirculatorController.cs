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

        public ActionResult LentBook()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveLentBookInfo(FormCollection f)
        {
            
            int size = f.Count;
            Random ran = new Random();
            for (int i = 0; i < size; i++)
            {
                LUUHANHSACH luuhanh = new LUUHANHSACH();
                luuhanh.DOC_GIA = f.GetValues("docgia[]")[i];
                luuhanh.ID_SACH = f.GetValues("sach[]")[i];
                luuhanh.ID_LUU_HANH = "LH" + ran.Next().ToString();
                luuhanh.NGAY_MUON = DateTime.Now;
                luuhanh.THOI_HAN_MUON = DateTime.Now.AddDays(14);
                data.LUUHANHSACH.Add(luuhanh);
            }
            data.SaveChanges();
            return RedirectToAction("LentBook");
        }
    }
}
