﻿using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using TOURDL.Models;

namespace TOURDL.Controllers
{
    public class NHANVIENsController : Controller
    {
        private TourDLEntities db = new TourDLEntities();
        // GET: NHANVIENs
        public ActionResult CountBookedTours()
        {
            using (TourDLEntities context = new TourDLEntities())
            {
                int bookedToursCount = context.HOADONs.Count(); // Đếm số lượng bản ghi trong bảng HOADON
                return Json(new { count = bookedToursCount }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult CountEmploy()
        {
            using (TourDLEntities context = new TourDLEntities())
            {
                int employCount = context.NHANVIENs.Count(); // Đếm số lượng bản ghi trong bảng HOADON
                return Json(new { count = employCount }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult TotalBookingAmount()
        {
            using (TourDLEntities context = new TourDLEntities())
            {
                // Truy vấn dữ liệu từ bảng HOADON
                var totalAmount = context.HOADONs.Sum(h => h.TongTienTour);

                // Trả về tổng tiền dạng JSON hoặc View
                return Json(new { TotalAmount = totalAmount }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Index(string SearchString)
        {
            var nv=db.NHANVIENs.ToList();
            if (!string.IsNullOrEmpty(SearchString))
            {
                nv=nv.Where(s=>s.HoTen_NV.Contains(SearchString)||s.Mail_NV.Contains(SearchString)).ToList();
            }
            return View(nv);
        }

        // GET: NHANVIENs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            return View(nHANVIEN);
        }

        // GET: NHANVIENs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NHANVIENs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_NV,HoTen_NV,GioiTinh_NV,NgaySinh_NV,MatKhau,Mail_NV,ChucVu,SDT_NV")] NHANVIEN nHANVIEN)
        {
            if (ModelState.IsValid)
            {
                db.NHANVIENs.Add(nHANVIEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nHANVIEN);
        }

        // GET: NHANVIENs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            return View(nHANVIEN);
        }

        // POST: NHANVIENs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_NV,HoTen_NV,GioiTinh_NV,NgaySinh_NV,MatKhau,Mail_NV,ChucVu,SDT_NV")] NHANVIEN nHANVIEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nHANVIEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nHANVIEN);
        }

        // GET: NHANVIENs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            return View(nHANVIEN);
        }

        // POST: NHANVIENs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            db.NHANVIENs.Remove(nHANVIEN);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult GetData()
        {
            TourDLEntities context = new TourDLEntities();

            var query = context.HOADONs.Include("SPTOUR")
                .GroupBy(p => p.SPTOUR.TenSPTour)
                .Select(g => new { name = g.Key, count = g.Sum(w => w.TongTienTour) }).ToList();

            ViewBag.ChartData = query;
            var query2 = context.HOADONs.Include("SPTOUR")
                .GroupBy(p => p.SPTOUR.TenSPTour)
                .Select(g => new { name = g.Key, count = g.Sum(w => w.SLNguoiLon + w.SLTreEm) }).ToList();

            ViewBag.KhachData = query2;


            var query3 = context.TOURs.Include("SPTOUR")
            .GroupBy(p => p.TenTour)
            .Select(g => new { name = g.Key, count = g.Sum(w => w.SPTOURs.Count()) }).ToList();
            ViewBag.TourData = query3;
            return View();
        }
        public ActionResult ShowData()
        {
            return View();
        }
        [HttpPost]
        public List<object> GetShowData()
        {
            TourDLEntities context = new TourDLEntities();

            List<object> data=new List<object>();

            List<string> labels = context.HOADONs.Select(s => s.SPTOUR.TenSPTour).ToList();
            data.Add(labels);

            List<int?> price = context.HOADONs.Select(s =>s.TongTienTour).ToList();
            int? totalPrice = price.Sum();
            data.Add(totalPrice);

            return data;  
        }
        public ActionResult DashBoard()
        {
            var hoadons = db.HOADONs.ToList();
            int total = 0;

            foreach (var hoadon in hoadons)
            {
                total+=(int)hoadon.TongTienTour;
                string idsptour = hoadon.ID_SPTour;
                var spTour = hoadon.SPTOUR;

                if (spTour!=null)
                {
                    string spTourName = spTour.TenSPTour;
                    int spTourTien = total;
                }
            }

            

            return View();
        }
    }
}
