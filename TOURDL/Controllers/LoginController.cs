using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
            return View(db.KHACHHANGs.ToList());
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
                Session["IDUserAdmin"] = check.ID_NV;
                Session["HoTen"] = check.HoTen_NV;
                Session["Email"] = check.Mail_NV;
                return RedirectToAction
                    ("Index", "NHANVIENs");
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
            DateTime ngayHienTai=DateTime.Now;
            if (db.KHACHHANGs.Any(x => x.Mail_KH == khachhang.Mail_KH))
            {
                ViewBag.Notification = "Tài khoản đã tồn tại";
            }
            else if (string.IsNullOrEmpty(khachhang.Mail_KH) || khachhang.GioiTinh_KH == null || khachhang.NgaySinh_KH == null || string.IsNullOrEmpty(khachhang.MatKhau) || string.IsNullOrEmpty(khachhang.CCCD) || string.IsNullOrEmpty(khachhang.SDT_KH) || string.IsNullOrEmpty(khachhang.HoTen_KH))
            {
                ViewBag.Notification = "Vui lòng nhập đủ thông tin nhé ! Xin cảm ơn";
            }
            else if (!(khachhang.GioiTinh_KH == "Nam" || khachhang.GioiTinh_KH == "Nữ"))
            {
                ViewBag.Notification = "Giới tính chỉ có thể là 'Nam' hoặc 'Nữ'";
            }
            else if (khachhang.NgaySinh_KH>ngayHienTai)
            {
                ViewBag.Notification = "Ngày sinh phải nhỏ hơn ngày hiện tại";
            }
            else if (khachhang.CCCD.Length != 12 || !Regex.IsMatch(khachhang.CCCD, @"^[0-9]+$"))
            {
                ViewBag.Notification = "Căn Cước Công Dân vui lòng nhập đủ 12 số và không bao gồm chữ,kí tự";
            }
            else if (khachhang.SDT_KH.Length != 10 || !Regex.IsMatch(khachhang.SDT_KH, @"^[0-9]+$"))
            {
                ViewBag.Notification = "Số điện thoại phải có từ 10 hoặc 11 số và không bao gồm chữ,kí tự";
            }
            else
            {
                db.KHACHHANGs.Add(khachhang);
                db.SaveChanges();
                Session["IDUser"]=khachhang.ID_KH.ToString();
                Session["EmailUserSS"]=khachhang.Mail_KH.ToString();
                Session["UsernameSS"]=khachhang.HoTen_KH.ToString();
                Session["SDT"]=khachhang.SDT_KH.ToString();
                return RedirectToAction("DangNhap", "Login");
            }
            return View();
        }
        public ActionResult DangXuat()
        {
            Session.Clear();
            return RedirectToAction ("Index", "Home");
        }

        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangNhap(KHACHHANG khachhang)
        {
            var kiemTraDangNhap = db.KHACHHANGs.Where(x => x.Mail_KH.Equals(khachhang.Mail_KH) && x.MatKhau.Equals(khachhang.MatKhau)).FirstOrDefault();
            if (kiemTraDangNhap != null)
            {
                Session["IDUser"] = kiemTraDangNhap.ID_KH;
                Session["EmailUserSS"] = kiemTraDangNhap.Mail_KH.ToString();
                Session["UsernameSS"] = kiemTraDangNhap.HoTen_KH.ToString();
                Session["GioiTinh"] = kiemTraDangNhap.GioiTinh_KH;
                Session["SDT"] = kiemTraDangNhap.SDT_KH.ToString();
                return RedirectToAction
                    ("Index", "Home",new {id= Session["IDUser"] });
            }
            else
            {
                ViewBag.Notification = "Tài khoản và mật khẩu không đúng";
                //db.Configuration.ValidateOnSaveEnabled = false;
                //db.KHACHHANGs.Add(khachhang);
                //db.SaveChanges();

                //Session["IDUser"] = khachhang.ID_KH;
                //Session["HoTenSS"] = khachhang.HoTen_KH;
                //Session["Email"] = khachhang.Mail_KH;
                //return RedirectToAction
                //    ("Index", "Home", new { id = kiemTraDangNhap.ID_KH });
            }
            return View();
        }
        //public ActionResult KhachHang()
        //{
        //    return View();
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult KhachHang(KHACHHANG khachhang)
        //{
        //    var check = db.KHACHHANGs.Where(s => s.Mail_KH.Equals(khachhang.Mail_KH)
        //    && s.MatKhau.Equals(khachhang.MatKhau)).FirstOrDefault();
        //    if (check == null)
        //    {
        //        return View("Index","Home");
        //    }
        //    else
        //    {
        //        db.Configuration.ValidateOnSaveEnabled = false;
        //        Session["IDUser"] = khachhang.ID_KH;
        //        Session["HoTen"] = khachhang.HoTen_KH;
        //        Session["Email"] = khachhang.Mail_KH;
        //        return RedirectToAction
        //            ("Index", "Home", new { id = check.ID_KH });
        //    }

        //}
    }
}