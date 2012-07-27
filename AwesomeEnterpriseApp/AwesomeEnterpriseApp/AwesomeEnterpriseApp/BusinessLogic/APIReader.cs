using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AwesomeEnterpriseApp.Models;

namespace AwesomeEnterpriseApp.BusinessLogic
{
    public class APIReader
    {
        public List<String> readAPI()
        {
            List<FilmLocations> films;
            List<String> filmNames = new List<string>();
            //FilmLocations filmLoc = new filmTitle;
            LocnXMLReader xmlObject = new LocnXMLReader();
            xmlObject.setSource("https://nycopendata.socrata.com/download/qb3k-n8mm/application/xml");
            films = xmlObject.readAllFilms();

            foreach (FilmLocations f in films)
            {
                filmNames.Add(f.filmTitle);
            }
                
            return filmNames;
        }
    }
}