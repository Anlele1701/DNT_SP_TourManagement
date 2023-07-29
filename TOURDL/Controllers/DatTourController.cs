using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TOURDL.Models;

namespace TOURDL.Controllers
{
    public class DatTourController : Controller
    {
        // GET: DatTour
        private TourDLEntities db = new TourDLEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DatTour()
        {
            return View();
        }
        //public ActionResult Booking()
        //{

        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Booking(HOADON khachhang)
        //{
        //    if (db.HOADONs.Any(x => x.Mail_KH == khachhang.Mail_KH))
        //    {
        //        ViewBag.Notification = "Tài khoản đã tồn tại";
        //    }
        //    else
        //    {
        //        db.KHACHHANGs.Add(khachhang);
        //        db.SaveChanges();
        //        Session["IDUserSS"] = khachhang.ID_KH.ToString();
        //        Session["EmailUserSS"] = khachhang.Mail_KH.ToString();
        //        Session["UsernameSS"] = khachhang.HoTen_KH.ToString();
        //        return RedirectToAction("DangNhap", "Login");
        //    }
        //    return View();
        //}
    }
}