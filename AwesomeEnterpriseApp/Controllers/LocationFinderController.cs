using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AwesomeEnterpriseApp.DataAccessLayer;
using AwesomeEnterpriseApp.Models.UI;
using AwesomeEnterpriseApp.Models;
using System.Web.Mvc;


namespace AwesomeEnterpriseApp.Controllers
{
    
    public class LocationFinderController : Controller
    {

        private FilmLocationsDAL fdal = new FilmLocationsDAL();

        public String getStubData(String filmName)
        {
            return filmName + " shot on 5th Avenue, Queens";
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