using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using System.Web.Mvc.Ajax;
using AwesomeEnterpriseApp.BusinessLogic;
using AwesomeEnterpriseApp.DataAccessLayer;
using AwesomeEnterpriseApp.Models;


namespace AwesomeEnterpriseApp.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to an Awesome Enterprise App!";

            LocationCalculator target = new LocationCalculator(); // TODO: Initialize to an appropriate value
            double distance = 0.94;
            // 49-51 W 46th St
            target.xCentre = 40.756912;
            target.yCentre = -73.980989;

            // 4-42 W 58th St
            target.xLocation = 40.764259;
            target.yLocation = -73.975325;

            target.radius = 1; //km

            Boolean x = target.isInsideRadius();

            new APIReader().readAPI();

            List<String> films = new LocationFinder().getAllFilmNames();

            List<SelectListItem> movies = new List<SelectListItem>();
            
           
              foreach (String title in films)
              {
              
               movies.Add(new SelectListItem { Text = title });

               }

            //return allLocs.ToArray();

           

              ViewData["movieList"] = movies;
             
        

           // ViewData["locationList"] = locations;

           // ViewData["radiusList"] = radius;

            return View();
        }

       
        public ActionResult About()
        {
            return View();
        }
    }
}
