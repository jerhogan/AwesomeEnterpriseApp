using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using AwesomeEnterpriseApp.Models;

namespace AwesomeEnterpriseApp.DataAccessLayer
{
    public class FilmLocationsDAL
    {
        private Context db = new Context();


        public FilmLocations findFilmLocationByID(int idFilmLocation)
        {

            List<FilmLocations> locs = null;
            // Prevent lazy loading by specifying the elements required
            locs = db.filmLocations.Include("locations.point").ToList();

            // Find the required item
            foreach (FilmLocations film in locs)
            {
                if (film.Id == idFilmLocation)
                {
                    return film;
                }
            }

            // Or return null.. :)
            return null;
        }

        // The same with name instead of ID
        public FilmLocations findFilmLocationByName(string filmName)
        {
            List<FilmLocations> locs = null;

            locs = db.filmLocations.Include("locations.point").ToList();

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

            filmLocs = db.filmLocations.Include("locations.point").ToList();

            foreach (FilmLocations film in filmLocs)
            {
                // This will specifically return a list of locations associated with a film object
                if (film.filmTitle.Equals(filmName))
                {
                    locs = film.locations.ToList();
                }
            }

            return locs;
        }

        public List<FilmLocations> findAllFilms()
        {

            List<FilmLocations> films = new List<FilmLocations>();
            // Get all film objects with their dependencies
            films = db.filmLocations.Include("locations.point").ToList();

            return films;
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
            FilmLocations film = new FilmLocations();

            List<Location> locations = new List<Location>();
            
            // Creates a base location object with an empty list. Recalled by the API reader to fill sublist with objects
            film = new FilmLocations(filmTitle, locations);

            db.filmLocations.Add(film);

            db.SaveChanges();

            return film;
        }

        public FilmLocations addLocationToFilm(string filmName, string locationName, string xCoord, string yCoord)
        {
            FilmLocations filmToModify = findFilmLocationByName(filmName);
            List<Location> locsInFilm = null;

            if (filmToModify != null)
            {
                // Create a location with dependent Point object. This will auto-persist the dependents
                Location location = new Location(locationName, new Point(xCoord, yCoord));

                // If there is no list, create one
                if (filmToModify.locations != null)
                    locsInFilm = filmToModify.locations.ToList();
                else
                    locsInFilm = new List<Location>();

                // Add the new location to the existing list..
                locsInFilm.Add(location);

                // ... and save it back into the object
                filmToModify.locations = locsInFilm;
            }

            // EF will only save the main object (and hence the dependents) if it is marked as modified
            db.Entry(filmToModify).State = EntityState.Modified;
            db.SaveChanges();

            // Check it comes back (legacy)
            FilmLocations x = findFilmLocationByName(filmName);

            return filmToModify;
        }

        public FilmLocations removeLocationFromFilm(string filmName, string locationName)
        {
            // Same as add dependency but reversed
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