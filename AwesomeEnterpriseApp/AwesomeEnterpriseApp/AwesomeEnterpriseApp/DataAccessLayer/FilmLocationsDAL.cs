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

        public List<FilmLocations> findAllFilms()
        {
            List<FilmLocations> films = new List<FilmLocations>();

            films = db.filmLocations.ToList();

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

            //Location location = new Location("L", new Point(1, 2));
            //locations.Add(location);
            
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
                Location location = new Location(locationName, new Point(xCoord, yCoord));

                if (filmToModify.locations != null)
                    locsInFilm = filmToModify.locations.ToList();
                else
                    locsInFilm = new List<Location>();

                locsInFilm.Add(location);

                filmToModify.locations = locsInFilm;
            }
            //locsInFilm = new List<Location>();
            //filmToModify.locations = locsInFilm;

            db.Entry(filmToModify).State = EntityState.Modified;
            db.SaveChanges();

            FilmLocations x = findFilmLocationByName(filmName);

            return filmToModify;
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