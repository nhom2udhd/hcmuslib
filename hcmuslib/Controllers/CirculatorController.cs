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

        public JsonResult GetInfo(string dg, string sach)
        {
            string[] rs = new string[2];
            var docgia = (from d in data.DOCGIA where d.MS_THE == dg select d).First();
            rs[0] = docgia.HO_TEN;
            var sh=(from s in data.SACH where s.ID_SACH==sach select s).First();

            string ttsach = sh.BMNHANDECHINH.NHAN_DE_CHINH + "; " + sh.BMTACGIA.BUT_DANH + "; " + sh.BMNXB.TEN_NXB;
            rs[1] = ttsach;
            return Json(new {docgia= rs[0], sach=rs[1]});
        }

        [HttpPost]
        public ActionResult SaveLentBookInfo(FormCollection f)
        {

            int size = f.GetValues("docgia[]").Length ;
            Random ran = new Random(12);
            string str = ran.Next(0, 99999999).ToString();
            string id = "LH"+str.PadLeft(8, '0');
            var obj = (from p in data.LUUHANHSACH where p.ID_LUU_HANH == id select p).ToList();
            while (obj.Count != 0)
            {
                str = ran.Next(0, 99999999).ToString();
                id = "LH" + str.PadLeft(8, '0');
                obj = (from p in data.LUUHANHSACH where p.ID_LUU_HANH == id select p).ToList();
            }

            for (int i = 0; i < size; i++)
            {
                LUUHANHSACH luuhanh = new LUUHANHSACH();
                luuhanh.DOC_GIA = f.GetValues("docgia[]")[i];
                luuhanh.ID_SACH = f.GetValues("sach[]")[i];
                luuhanh.ID_LUU_HANH = id;
                luuhanh.NGAY_MUON = DateTime.Now;
                luuhanh.THOI_HAN_MUON = DateTime.Now.AddDays(14);
                data.LUUHANHSACH.Add(luuhanh);
            }
            data.SaveChanges();
            return RedirectToAction("LentBook");
        }
    }
}
