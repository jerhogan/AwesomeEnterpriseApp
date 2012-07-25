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
            ViewData["Message"] = "Welcome to Awesome!";

            Context db = new Context();
            db.Database.Delete();
            db.Database.Create();

            new APIReader().readAPI();

            FilmLocationsDAL dal = new FilmLocationsDAL();

            List<FilmLocations> filmLocations = dal.findAllFilms();

            List<String> films = new List<string>();

            List<Location> locs = new List<Location>();

            for (int i = 0; i < filmLocations.Count(); i++)
            {
                films.Add(filmLocations[i].filmTitle);
                locs = filmLocations[i].locations;
                int x = 1;
            }

            List<SelectListItem> movies = new List<SelectListItem>();
            
           
              foreach (String title in films)
              {
              
               movies.Add(new SelectListItem { Text = title });

               }


              /* selectedFilmLocations selected = new selectedFilmLocations(); 
                       
                       
                   foreach(Select in selected)
                       {
                      
                       movies.Add(new SelectListItem { Text = film });

                        }
                   

            public int getSelectedItemId()
            {
                int index = ;
                return index = null;
            }

             int index = movies.;
            */
             // List<Location> locations;
         /*   List<SelectListItem> locations2 = new List<SelectListItem>();

                locations2.Add(new SelectListItem { Text = "Filming location" });
            */

            List<SelectListItem> radius = new List<SelectListItem>();


            String [] radiusVals = { "1km", "2kms", "3kms", "4kms", "5kms" };

                
                
                foreach(String radiusVal in radiusVals)
                {
                    radius.Add(new SelectListItem { Text = radiusVal });
                }
                
                


            ViewData["movieList"] = movies;

            //ViewData["locationList"] = locations2;

            ViewData["radiusList"] = radius;

            return View();
        }

       
        public ActionResult About()
        {
            return View();
        }
    }
}
