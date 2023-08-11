using DocumentFormat.OpenXml.Wordprocessing;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TOURDL.Models;

namespace TOURDL.Controllers
{
    public class TOURsController : Controller
    {
        private TourDLEntities db = new TourDLEntities();

        // GET: TOURs
        public ActionResult Index(string SearchString)
        {
            var tour = db.TOURs.ToList();
            if (!string.IsNullOrEmpty(SearchString))
            {
                tour = tour.Where(s => s.TenTour.Contains(SearchString) || s.ID_TOUR.Contains(SearchString)).ToList();
            }
            return View(tour);
        }

        // GET: TOURs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TOUR tOUR = db.TOURs.Find(id);
            if (tOUR == null)
            {
                return HttpNotFound();
            }
            return View(tOUR);
        }

        // GET: TOURs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TOURs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_TOUR,TenTour,GiaTour,MoTa,HinhTour,TinhThanh,LoaiTour")] TOUR tOUR)
        {
            if (ModelState.IsValid)
            {
                db.TOURs.Add(tOUR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tOUR);
        }

        // GET: TOURs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TOUR tOUR = db.TOURs.Find(id);
            if (tOUR == null)
            {
                return HttpNotFound();
            }
            return View(tOUR);
        }

        // POST: TOURs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_TOUR,TenTour,GiaTour,MoTa,HinhTour,TinhThanh,LoaiTour")] TOUR tOUR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tOUR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tOUR);
        }

        // GET: TOURs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TOUR tOUR = db.TOURs.Find(id);
            if (tOUR == null)
            {
                return HttpNotFound();
            }
            return View(tOUR);
        }

        // POST: TOURs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TOUR tOUR = db.TOURs.Find(id);
            db.TOURs.Remove(tOUR);
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
        [HttpGet]
        public ActionResult DanhMucSanPham(string id)
        {
            var data = db.SPTOURs.Where(s => s.ID_TOUR==id);
            return View(data.ToList());
        }
        [HttpGet]
        public ActionResult DanhMucTour(string name,int? to,int? from,int page=1)
        {
            page = page < 1 ? 1 : page;/////
            int pageSize = 3;/////////
            var tours = from t in db.SPTOURs select t;
            if (!string.IsNullOrEmpty(name))
            {
                if(to!=null && from!=null)
                {
                    tours=tours.Where(x=>x.TenSPTour.StartsWith(name) && x.GiaNguoiLon>=to && x.GiaNguoiLon<=from);
                }
                else
                {
                    tours = tours.Where(x => x.TenSPTour.StartsWith(name));
                }
            }
            else
            {
                if (to != null && from != null)
                {
                    tours = tours.Where(x => x.TenSPTour.StartsWith(name) && x.GiaNguoiLon >= to && x.GiaNguoiLon <= from);
                }
            }
            tours = tours.OrderBy(x => x.ID_SPTour);
            var toursPage = tours.ToPagedList(page, pageSize);//////
            return View(toursPage);
        }
        //[HttpGet]
        //public ActionResult TimKiem(string name)
        //{
        //    var tours = from t in db.SPTOURs select t;
        //    if (!string.IsNullOrEmpty(name))
        //    {
        //        tours=tours.Where(x=>x.TenSPTour.Contains(name));
        //    }
        //    return View(tours);
        //}
    }
}
