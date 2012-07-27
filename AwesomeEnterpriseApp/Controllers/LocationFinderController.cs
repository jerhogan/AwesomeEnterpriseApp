using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AwesomeEnterpriseApp.DataAccessLayer;
using AwesomeEnterpriseApp.Models.UI;
using AwesomeEnterpriseApp.Models;
using System.Web.Mvc;
using AwesomeEnterpriseApp.BusinessLogic;
//using System.Web.Helpers;

namespace AwesomeEnterpriseApp.Controllers
{
    
    public class LocationFinderController : Controller
    {

        private FilmLocationsDAL fdal = new FilmLocationsDAL();

     /*   public String getStubData(String filmName)
        {
            return filmName + " shot on 5th Avenue, Queens";
        } */

         //public String[] getSecondList(String filmName)
        public ActionResult getSecondList(String filmName)
        {
            List<String> allLocs = new List<string>();
            LocationFinder finder = new LocationFinder();
            List<SelectListItem> Locs = new List<SelectListItem>();
            LocationListUI locationsViewModel = finder.getLocationsForFilm(filmName);

            foreach (String loc in locationsViewModel.locations)
            {
                Locs.Add(new SelectListItem { Text = loc });
            }

           /* foreach (String title in films)
            {

                movies.Add(new SelectListItem { Text = title });

            }*/

           // return allLocs.ToArray();



            ViewData["locationList"] = Locs;

            return View();

        }

        private void Add(SelectListItem selectListItem)
        {
            throw new NotImplementedException();
        }

       

        public LocationListUI getLocationsForFilm(String filmName)
        {
          
        
           LocationListUI locations = null;

            List<String> locationNames = new List<string>();

            List<Location> allLocations = fdal.findLocationsByFilm(filmName);

            if (allLocations != null && allLocations.Count > 0)
            {
                for (int i = 0; i < allLocations.Count; i++)
                {
                    locationNames.Add(allLocations[i].locnText);
                }
            }

            locations = new LocationListUI();

            locations.filmName = filmName;
            locations.locations = locationNames;
            
            return locations;
        } 

    }
}