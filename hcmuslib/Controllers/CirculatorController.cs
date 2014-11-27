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
                dg = (from d in data.DOCGIA.AsNoTracking() where d.MS_THE == DG_ID select d).FirstOrDefault();
                if (dg == null)
                    dg = new DOCGIA();
                @ViewBag.DGSearch = DG_ID;
                
            }
            return PartialView("GetDG",dg);
        }
        
        public ActionResult QRCodeGenerate(string data)
        {
                
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

        public ActionResult BookReturningHome()
        {
            string maDG = Request["madg"];
            string action = Request["action"];
            if (Request.IsAjaxRequest())
            {
                switch (action)
                {
                    case "show":
                        var lh = from l in data.LUUHANHSACH
                                 where l.DOC_GIA == maDG && l.TINH_TRANG.Equals("0")
                                 select l;
                        if (lh.Any())
                        {
                            return PartialView("_BookReturningDetail", lh.ToList());
                        }
                        else
                        {
                            return PartialView("_BookReturningNotFound");
                        }
                    case "confirm":
                        string lhid = Request["lhid"];
                        var lh1 = (from l in data.LUUHANHSACH
                                   where l.ID_LUU_HANH == lhid
                                   select l).First();
                        lh1.TINH_TRANG = "1";
                        data.SaveChanges();
                        return PartialView("_ReturnConfirmMessage");
                    case "punishment":
                        string bid = Request["bid"];
                        string status = Request["status"];
                        Random ran = new Random(12);
                        string str = ran.Next(0, 99999999).ToString();
                        string id = "BT" + str.PadLeft(8, '0');
                        var findid = (from b in data.BOITHUONGTHIETHAI
                                      where b.ID_BOI_THUONG == id
                                      select b).ToList();

                        while (findid.Count != 0)
                        {

                            str = ran.Next(0, 99999999).ToString();
                            id = "BT" + str.PadLeft(8, '0');
                            findid = (from b in data.BOITHUONGTHIETHAI
                                      where b.ID_BOI_THUONG == id
                                      select b).ToList();
                        }

                        BOITHUONGTHIETHAI bt = new BOITHUONGTHIETHAI
                        {
                            ID_BOI_THUONG = id,
                            ID_VAT_BOI_THUONG = bid,
                            DOC_GIA = maDG,
                            LY_DO = status,
                            NGAY_BOI_THUONG = DateTime.Now,
                            TINH_TRANG = "1"
                        };
                        data.BOITHUONGTHIETHAI.Add(bt);
                        data.SaveChanges();
                        return PartialView("_PunishmentConfirm");

                }
            }
            return View();
        }
    }
}
