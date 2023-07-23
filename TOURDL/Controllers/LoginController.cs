using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TOURDL.Models;
namespace TOURDL.Controllers
{
    public class LoginController : Controller
    {
        TourDLEntities db = new TourDLEntities();   
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Authen()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Authen(NHANVIEN nhanvien)
        {
            var check = db.NHANVIENs.Where(s=>s.Mail_NV.Equals(nhanvien.Mail_NV)
            &&s.MatKhau.Equals(nhanvien.MatKhau)).FirstOrDefault();
            if (check == null)
            {
                return View("Index", nhanvien);
            }
            else
            {
                db.Configuration.ValidateOnSaveEnabled = false;
                Session["IDUser"] = nhanvien.ID_NV;
                Session["HoTen"] = nhanvien.HoTen_NV;
                Session["Email"] = nhanvien.Mail_NV;
                return RedirectToAction
                    ("Index", "NHANVIENs",new { id = check.ID_NV });
            }
             
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
        //public ActionResult Register(NHANVIEN nhanvien)
        //{
        //  if(ModelState.IsValid)
        //    {
        //        var check = tourDL.NHANVIENs.FirstOrDefault(s=>s.Mail_NV == nhanvien.Mail_NV);
        //        if(check == null)
        //        {
        //            tourDL.Configuration.ValidateOnSaveEnabled = false;
        //            tourDL.NHANVIENs.Add(nhanvien); 
        //            tourDL.SaveChanges();   
        //            return RedirectToAction("Index");   
        //        }
        //        else
        //        {
        //            ViewBag.error = "Email already exists! use another email please";
        //            return View();
        //        }
        //    }    
        //    return View();
        //}
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(KHACHHANG khachhang)
        {
            if (db.KHACHHANGs.Any(x => x.Mail_KH == khachhang.Mail_KH))
            {
                ViewBag.Notification = "Tài khoản đã tồn tại";
                return View();
            }
            else
            {
                db.KHACHHANGs.Add(khachhang);
                db.SaveChanges();
                Session["IdUserSS"]=khachhang.ID_KH.ToString();
                Session["UsernameSS"]=khachhang.HoTen_KH.ToString();
                return RedirectToAction("Index", "Home");
            }
        }
    }
}