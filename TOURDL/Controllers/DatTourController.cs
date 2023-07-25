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
        public ActionResult DatTour(string id)
        {
            var data = db.SPTOURs.Where(s => s.ID_SPTour == id);
            return View(data);
        }
    }
}