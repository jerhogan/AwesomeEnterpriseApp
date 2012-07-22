using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AwesomeEnterpriseApp.Models;

namespace AwesomeEnterpriseApp.DataAccessLayer
{
    public class FilmLocationsDAL
    {
        private AwesomeDB db = new AwesomeDB();
        private FilmLocations film; 
        

        public FilmLocations findFilmLocationByID(int idFilmLocation)
        {
            List<FilmLocations> locs = null;

            locs = db.filmLocations.ToList();

            foreach (FilmLocations film in locs)
            {
                if (film.Id == idFilmLocation)
                {
                    return film;
                }
            }

            return null;
        }

        public FilmLocations findFilmLocationByName(string filmName)
        {
            List<FilmLocations> locs = null;

            locs = db.filmLocations.ToList();

            foreach (FilmLocations film in locs)
            {
                if (film.filmTitle.Equals(filmName))
                {
                    return film;
                }
            }

            return null;
        }

        public List<Location> findLocationsByFilm(String filmName)
        {
            List<FilmLocations> filmLocs = null;
            List<Location> locs = null;

            filmLocs = db.filmLocations.ToList();

            foreach (FilmLocations film in filmLocs)
            {
                if (film.filmTitle.Equals(filmName))
                {
                    locs = film.locations.ToList();
                }
            }

            return locs;
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

            film = new FilmLocations(filmTitle, locations);

            db.filmLocations.Add(film);

            return film;
        }

        public FilmLocations addLocationToFilm(string filmName, string locationName, string xCoord, string yCoord)
        {
            FilmLocations filmToModify = findFilmLocationByName(filmName);

            if (filmToModify != null)
            {
                createAndAddLocation(locationName, xCoord, yCoord, filmToModify);

            }
            else
            {
                FilmLocations newFilm = addBaseFilmLocation(filmName);
                createAndAddLocation(locationName, xCoord, yCoord, newFilm);
            }
            return filmToModify; 
        }

        private void createAndAddLocation(string locationName, string xCoord, string yCoord, FilmLocations filmToModify)
        {
            LocationDAL locationDAL = new LocationDAL();
            Location location = locationDAL.addLocation(locationName, xCoord, yCoord);

            
                List<Location> locsInFilm = new List<Location>();

           // if(locsInFilm != null){
             //   locsInFilm = filmToModify.locations.ToList();

            
                locsInFilm.Add(location);
            
            //}

            db.SaveChanges();
        }

        public FilmLocations removeLocationFromFilm(string filmName, string locationName)
        {
            FilmLocations filmToModify = findFilmLocationByName(filmName);

            if (filmToModify != null)
            {
                Location locToRemove = null;
                List<Location> locsInFilm = filmToModify.locations.ToList();
                foreach (Location loc in locsInFilm)
                {
                    if (loc.locnText.Equals(locationName))
                    {
                        locToRemove = loc;
                    }
                }

                if (locToRemove != null)
                {
                    locsInFilm.Remove(locToRemove);
                }

                db.SaveChanges();

            }

            return filmToModify; 
        }

        public Boolean deleteFilmLocation(int idFilmLocation)
        {
            Boolean deleted = false;

            FilmLocations film = db.filmLocations.Find(idFilmLocation);

            if (film != null)
            {
                db.filmLocations.Remove(film);
                deleted = true;
            }

            return deleted;
        }

    }
}