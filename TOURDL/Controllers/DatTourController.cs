using DocumentFormat.OpenXml.Drawing.Diagrams;
using DocumentFormat.OpenXml.Office.CustomUI;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Threading.Tasks;
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
            return View(db.SPTOURs.ToList());
        }
        //public ActionResult Create()
        //{
        //    SPTOUR sptour = new SPTOUR();
        //    string thoiGianDi = sptour.ThoiGianDi;
        //    List<SelectListItem> tour = new List<SelectListItem>();
        //    tour.Add(new SelectListItem() {Text= "Room", Value= "Room" });
        //    tour.Add(new SelectListItem() {Text= "Standard Double Room", Value= "Standard Double Room" });
        //    tour.Add(new SelectListItem() {Text= "Standard Family Room", Value= "Standard Family Room" });
        //    tour.Add(new SelectListItem() {Text= "Garden Family Room", Value= "Garden Family Room" });
        //    tour.Add(new SelectListItem() {Text= "Deluxe Double Room", Value= "Deluxe Double Room" });
        //    tour.Add(new SelectListItem() {Text= "Executive Junior Suite", Value= "Executive Junior Suite" });
        //    tour.Add(new SelectListItem() {Text= "Maisonette", Value= "Maisonette" });
        //    ViewBag.Tour = tour;
        //    List<SelectListItem> peoples = new List<SelectListItem>();
        //    peoples.Add(new SelectListItem() { Text = "Persons", Value = "Persons" });
        //    peoples.Add(new SelectListItem() { Text = "1 Person", Value = "1" });
        //    peoples.Add(new SelectListItem() { Text = "2 People", Value = "2" });
        //    peoples.Add(new SelectListItem() { Text = "3 People", Value = "3" });
        //    peoples.Add(new SelectListItem() { Text = "4 People", Value = "4" });
        //    peoples.Add(new SelectListItem() { Text = "5 People", Value = "5" });
        //    peoples.Add(new SelectListItem() { Text = "More", Value = "More" });
        //    ViewBag.Peoples = peoples;
        //    return View(new SPTOUR());
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create(SPTOUR sptour)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        SPTOUR obj = new SPTOUR() { SoNguoi=sptour.SoNguoi,DiemDen = sptour.DiemDen,NgayKetThuc=sptour.NgayKetThuc,NgayKhoiHanh=sptour.NgayKhoiHanh, DiemTapTrung = sptour.DiemTapTrung, GiaNguoiLon = sptour.GiaNguoiLon, GiaTreEm = sptour.GiaTreEm, HinhAnh = sptour.HinhAnh, MoTa = sptour.MoTa, };
        //        db.SPTOURs.Add(obj);
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");

        //    }
        //    List<SelectListItem> tour = new List<SelectListItem>();
        //    tour.Add(new SelectListItem() { Text = "Room", Value = "Room" });
        //    tour.Add(new SelectListItem() { Text = "Standard Double Room", Value = "Standard Double Room" });
        //    tour.Add(new SelectListItem() { Text = "Standard Family Room", Value = "Standard Family Room" });
        //    tour.Add(new SelectListItem() { Text = "Garden Family Room", Value = "Garden Family Room" });
        //    tour.Add(new SelectListItem() { Text = "Deluxe Double Room", Value = "Deluxe Double Room" });
        //    tour.Add(new SelectListItem() { Text = "Executive Junior Suite", Value = "Executive Junior Suite" });
        //    tour.Add(new SelectListItem() { Text = "Maisonette", Value = "Maisonette" });
        //    ViewBag.Tour = tour;
        //    List<SelectListItem> peoples = new List<SelectListItem>();
        //    peoples.Add(new SelectListItem() { Text = "Persons", Value = "Persons" });
        //    peoples.Add(new SelectListItem() { Text = "1 Person", Value = "1" });
        //    peoples.Add(new SelectListItem() { Text = "2 People", Value = "2" });
        //    peoples.Add(new SelectListItem() { Text = "3 People", Value = "3" });
        //    peoples.Add(new SelectListItem() { Text = "4 People", Value = "4" });
        //    peoples.Add(new SelectListItem() { Text = "5 People", Value = "5" });
        //    peoples.Add(new SelectListItem() { Text = "More", Value = "More" });
        //    ViewBag.Peoples = peoples;
        //    return View(sptour);
        //}
        public ActionResult DatTour(string id)
        {
            var data = db.SPTOURs.Find(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult DatTour(FormCollection form)
        {
            if (form["idkh"] == "")
            {
                return RedirectToAction("DangNhap", "Login");
            }
            else
            {
                HOADON hOADON = new HOADON();
                hOADON.ID_SPTour = form["idsptour"];
                hOADON.NgayDat = DateTime.Now;
                hOADON.TinhTrang = "Chưa TT";
                hOADON.ID_KH = int.Parse(form["idkh"]);
                hOADON.SLNguoiLon = int.Parse(form["songuoilon"]);
                hOADON.SLTreEm = int.Parse(form["sotreem"]);
                int slnguoilon = int.Parse(form["songuoilon"]);
                int sltreem = int.Parse(form["sotreem"]);
                int giaguoilon = int.Parse(form["gianguoilon"]);
                int giatreem = int.Parse(form["giatreem"]);
                int tongtien =(slnguoilon * giaguoilon)+(sltreem * giatreem);
                int soluong=slnguoilon+sltreem;
                Session["SoLuong"] = soluong;
                hOADON.TongTienTour = tongtien;
                db.HOADONs.Add(hOADON);
                db.SaveChanges();
                return RedirectToAction("HoaDon","HOADONs",new {id=hOADON.ID_HoaDon});
            }
        }
        public ActionResult Checkout(int id)
        {
            var data = db.HOADONs.Find(id);
            return View(data);
        }
        //public ActionResult Booking()
        //{

        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Booking(HOADON hoadon)
        //{
        //    if (db.HOADONs.Any(x=>x.ID_HoaDon==hoadon.ID_HoaDon))
        //    {
        //        ViewBag.Notification = "Hoá đơn đã có";
        //    }
        //    elses
        //    {
        //        db.HOADONs.Add(hoadon);
        //        db.SaveChanges();
        //        Session["IDUserSS"] = hoadon.ID_KH.ToString();
        //        Session["IDSPTour"] = hoadon.ID_SPTour.ToString();
        //        Session["IDHoaDon"] = hoadon.ID_HoaDon.ToString();
        //        return RedirectToAction("Index", "Home",new {id=hoadon.ID_HoaDon});
        //    }
        //    return View();
        //}
    }
}