using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hcmuslib.Models;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Net;

namespace hcmuslib.Controllers
{
    //[Authorize(Roles = "Circulator")]
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

            return View();
        }
        [HttpPost]
        public PartialViewResult GetDG(string DG_ID = "")
        {
            DOCGIA dg = new DOCGIA();
            if (DG_ID != null)
            {
                dg = (from d in data.DOCGIA.AsNoTracking() where d.MS_THE == DG_ID select d).FirstOrDefault();
                if (dg == null)
                    dg = new DOCGIA();
                @ViewBag.DGSearch = DG_ID;
                
            }
            return PartialView("GetDG",dg);
        }

        public ActionResult QRCodeGenerate(HttpPostedFileBase img)
        {
            if(img != null)
            {
                //dosomething
                var fileName = img.FileName;
                var fileContentStream = img.InputStream;

                //Store the file on your webserver
                img.SaveAs(string.Format(@"D:\Study\hcmuslib\hcmuslib\Images\QRCode\{0}", img.FileName));
            }             
            return View();
        }

        public ActionResult LentBook()
        {
            return View();
        }

        public JsonResult GetInfo(string dg, string sach)
        {
            string[] rs = new string[2];
            try
            {
                var docgia = (from d in data.DOCGIA where d.MS_THE == dg select d).First();
                var sh = (from s in data.SACH where s.ID_SACH == sach select s).First();
                rs[0] = docgia.HO_TEN;


                string ttsach = sh.BMNHANDECHINH.NHAN_DE_CHINH + "; " + sh.BMTACGIA.BUT_DANH + "; " + sh.BMNXB.TEN_NXB;
                rs[1] = ttsach;
                return Json(new { docgia = rs[0], sach = rs[1] });
            }
            catch
            {
                return null;
            }
           
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
