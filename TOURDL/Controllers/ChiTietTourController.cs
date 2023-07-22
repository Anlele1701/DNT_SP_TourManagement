using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TOURDL.Models;

namespace MVC_Dulich.Controllers
{
    public class ChiTietTourController : Controller
    {
        // GET: ChiTietTour
        private TourDLEntities db = new TourDLEntities();

        public ActionResult Index(string id)
        {
            var category = db.SPTOURs.Find(id);
            var tours = db.TOURs.Where(t => t.ID_TOUR == id).ToList();
            return View(tours);
        }
    }
}