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

           // FilmLocations film ;
              
            List<FilmLocations> films;
            //FilmLocations filmLoc = new filmTitle;
            LocnXMLReader xmlObject = new LocnXMLReader();
            xmlObject.setSource("https://nycopendata.socrata.com/download/qb3k-n8mm/application/xml");
            films = xmlObject.readAllFilms();
           // FilmLocations locations = xmlObject.readAllFilms();

            

            List<SelectListItem> movies = new List<SelectListItem>();
            
           
              foreach (FilmLocations movie in films)
              {
              
               movies.Add(new SelectListItem { Text = movie.filmTitle });

               }

                   
                   /*    
                       FilmLocations films = filmDAL.addBaseFilmLocation();
                   foreach(film in films)
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
            List<SelectListItem> locations2 = new List<SelectListItem>();

                locations2.Add(new SelectListItem { Text = "Filming location" });


            List<SelectListItem> radius = new List<SelectListItem>();


            String [] radiusVals = { "100 meters", "200 meters", "300 meters", "400 meters", "500 meters" };

                
                
                foreach(String radiusVal in radiusVals)
                {
                    radius.Add(new SelectListItem { Text = radiusVal });
                }
                
                


            ViewData["movieList"] = movies;

            ViewData["locationList"] = locations2;

            ViewData["radiusList"] = radius;

            return View();
        }

      /*  public ActionResult GetItems() 
        {
              var list = new List<SelectListItem> 
              {new SelectListItem 
                { Text = "not selected", Value = "" }
              };            
            
            list.AddRange(filmLocations.GetAll().Select(o => new SelectListItem
            {
                Text = o.Name,
                Value = o.Id.ToString(),
                Selected = o.Id == key
            }));
            return Json(list);
        
        } */

        public ActionResult About()
        {
            return View();
        }
    }
}
