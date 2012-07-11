using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AwesomeEnterpriseApp.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to Awesome!";

            List<SelectListItem> movies = new List<SelectListItem>();

                movies.Add(new SelectListItem { Text = "Movie Name" });

            List<SelectListItem> locations = new List<SelectListItem>();

                locations.Add(new SelectListItem { Text = "Filming location" });


            List<SelectListItem> radius = new List<SelectListItem>();

                radius.Add(new SelectListItem { Text = "Radius" });


            ViewData["movieList"] = movies;

            ViewData["locationList"] = locations;

            ViewData["radiusList"] = radius;

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
