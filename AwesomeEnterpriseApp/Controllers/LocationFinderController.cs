using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AwesomeEnterpriseApp.DataAccessLayer;
using AwesomeEnterpriseApp.Models.UI;
using AwesomeEnterpriseApp.Models;
using System.Web.Mvc;
using AwesomeEnterpriseApp.BusinessLogic;


namespace AwesomeEnterpriseApp.Controllers
{
    
    public class LocationFinderController : Controller
    {

        private FilmLocationsDAL fdal = new FilmLocationsDAL();

        public String  getSecondList(String filmName)
        {
            String htmlList;

            LocationListUI loc = new LocationFinder().getLocationsForFilm(filmName);

            htmlList = "";
            foreach (String location in loc.locations)
            {
                htmlList = htmlList + "<option>" + location + "</option>";
            }

            return htmlList;
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