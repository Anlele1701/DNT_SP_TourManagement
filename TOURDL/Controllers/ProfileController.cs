using DocumentFormat.OpenXml.Office2010.Excel;
using System;
using System.Collections.Generic;
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
    }
}