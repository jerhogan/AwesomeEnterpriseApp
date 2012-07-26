﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AwesomeEnterpriseApp.DataAccessLayer;
using AwesomeEnterpriseApp.Models.UI;
using AwesomeEnterpriseApp.Models;


namespace AwesomeEnterpriseApp.BusinessLogic
{

    public class LocationFinder
    {

        private FilmLocationsDAL fdal = new FilmLocationsDAL();

        public List<String> getAllFilmNames()
        {

            List<String> filmNames = new List<string>();

            List<FilmLocations> allFilms = fdal.findAllFilms();

            if (allFilms != null && allFilms.Count > 0)
            {
                for (int i = 0; i < allFilms.Count; i++)
                {
                    filmNames.Add(allFilms[i].filmTitle);
                }
            }

            return filmNames;
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

            locations.filmName = filmName;
            locations.locations = locationNames;

            return locations;
        }

    }
}