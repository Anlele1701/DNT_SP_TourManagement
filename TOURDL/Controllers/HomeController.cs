using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TOURDL.Models;

namespace TOURDL.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var entities = new TourDLEntities();
            return View(entities.TOURs.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}