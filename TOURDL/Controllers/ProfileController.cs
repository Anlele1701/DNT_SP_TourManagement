using DocumentFormat.OpenXml.Office2010.Excel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TOURDL.Models;

namespace TOURDL.Controllers
{
    public class ProfileController : Controller
    {
        private TourDLEntities db = new TourDLEntities();
        // GET: Profile
        public ActionResult profile(int id)
        {
            var data = db.KHACHHANGs.Find(id);
            return View(data);
        }
        public ActionResult editProfile(int id)
        {
            var data = db.KHACHHANGs.Find(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult editProfile([Bind(Include = "ID_KH,HoTen_KH,GioiTinh_KH,NgaySinh_KH,MatKhau,CCCD,SDT_KH,Mail_KH,Diem")]KHACHHANG khachhang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khachhang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index","Home", new { id = khachhang.ID_KH });
            }
            return View();
        }
    }
}