using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AwesomeEnterpriseApp.Models;

namespace AwesomeEnterpriseApp.DataAccessLayer
{
    public class FilmLocationsDAL
    {
        public FilmLocations findFilmLocation(int idFilmLocation)
        {
            return null;
        }

        // Create a base film object, add locations after:
        // Sample Code:
        /*
         * FilmLocationsDAL filmDAL = new FilmLocationsDAL();
         * FilmLocations film = filmDAL.addBaseFilmLocation("Title");
         * filmDAL.addLocationToFilm(film, "Brooklyn", "10.123332", "-31.234432");
         */
        public FilmLocations addBaseFilmLocation(string filmTitle)
        {
            List<Location> locations = new List<Location>();

            FilmLocations film = new FilmLocations(filmTitle, locations);

            return film;
        }

        public FilmLocations addLocationToFilm(FilmLocations film, string locationName, string xCoord, string yCoord)
        {
            LocationDAL locationDAL = new LocationDAL();
            Location location = locationDAL.addLocation(locationName, xCoord, yCoord);

            film.locations.Add(location);

            return film;
        }

        public Boolean deleteFilmLocation(int idFilmLocation)
        {
            return false;
        }

    }
}