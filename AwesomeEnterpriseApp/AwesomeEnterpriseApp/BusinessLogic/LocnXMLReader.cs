using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using AwesomeEnterpriseApp.Models;
using AwesomeEnterpriseApp.DataAccessLayer;
using AwesomeEnterpriseApp.BusinessLogic;
using AwesomeEnterpriseApp.BusinessLogic.Interfaces;

namespace AwesomeEnterpriseApp.BusinessLogic
{
    public class LocnXMLReader : IXMLReader
    {
        private List<FilmLocations> filmLocations = new List<FilmLocations>();

        private FilmLocationsDAL filmDAL = new FilmLocationsDAL();

        private String xmlSourceName = "";

        static int numFilms = 0;

        private LocationFinder finder = new LocationFinder();

        public void setSource(String xmlSource)
        {
            this.xmlSourceName = xmlSource;
        }

        public List<FilmLocations> readAllFilms()
        {
            readXML();
            return (filmLocations);
        }
        
        public LocnXMLReader()
        {
       
        }

        private void readXML()
        {
            String addFilmTitle = "";
            double addLat = 0.0;
            double addLng = 0.0;
            String addDisplayText = "";
            int filmCellNo = 0;
            int latCellNo = 0;
            int lngCellNo = 0;
            int locationDisplayTextCellNo = 0;
            bool isFullMapList = false;
            XDocument doc = XDocument.Load(xmlSourceName);
            foreach (var w in doc.Descendants())
            {
                isFullMapList = false;
                if (w.Name.LocalName == "Worksheet")
                {
                    foreach (var x in w.Attributes())
                    {
                        if (x.Name.LocalName == "Name")
                        {
                            if (x.Value == "Full Map List")
                            {
                                isFullMapList = true;
                            }
                        }
                    }
                    if (isFullMapList)
                    {
                        int iRow = -1; // index into Row elements
                        int iCell = -1; // index into Cell elements
                        foreach (var i in w.Descendants())
                        {
                            if (i.Name.LocalName == "Row")
                            {
                                iRow++;
                                if (iRow > 0) // Row 0 contains configuration information which we don't need
                                {
                                    //                                    Console.WriteLine("Index " + (iRow - 1));
                                    iCell = -1;
                                    foreach (var j in i.Descendants())
                                    {
                                        if (j.Name.LocalName == "Cell")
                                        {
                                            iCell++;
                                            foreach (var k in j.Descendants())
                                            {
                                                if (k.Name.LocalName == "Data")
                                                {
                                                    if (iRow == 1) // This Row contains the Data Header
                                                    {
                                                        switch (k.Value)
                                                        {
                                                            case "Film":
                                                                filmCellNo = iCell;
                                                                break;
                                                            case "LATITUDE":
                                                                latCellNo = iCell;
                                                                break;
                                                            case "LONGITUDE":
                                                                lngCellNo = iCell;
                                                                break;
                                                            case "Location Display Text":
                                                                locationDisplayTextCellNo = iCell;
                                                                break;
                                                            default:
                                                                break;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (iCell == filmCellNo)
                                                        {
                                                            addFilmTitle = k.Value;
                                                            //                                                            Console.WriteLine("Film: " + k.Value);
                                                        }
                                                        else if (iCell == latCellNo)
                                                        {
                                                            addLat = double.Parse(k.Value);
                                                            //                                                            Console.WriteLine("LATITUDE: " + k.Value);
                                                        }
                                                        else if (iCell == lngCellNo)
                                                        {
                                                            addLng = double.Parse(k.Value);
                                                            //                                                            Console.WriteLine("LONGITUDE: " + k.Value);
                                                        }
                                                        else if (iCell == locationDisplayTextCellNo)
                                                        {
                                                            addDisplayText = k.Value;
                                                            //                                                            Console.WriteLine("Location Display Text: " + k.Value);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    if (iRow > 1)
                                        addEntry(addFilmTitle, addLat, addLng, addDisplayText);
                                }
                            }
                        }
                    }
                }
            }

            //            Console.ReadLine();
        }

        private void addEntry(string filmName,
                               double latCoord,
                               double lngCoord,
                               string locnDisplayText)
        {
            bool newFilm;
            FilmLocations filmLoc = null;

            numFilms = filmLocations.Count;
            newFilm = true;
            if (numFilms >= 1)
                if (filmLocations[filmLocations.Count - 1].filmTitle == filmName)
                {
                    newFilm = false;
                }
            if (newFilm && filmDoesNotExist(filmName))
            {
                numFilms++;
                filmLoc = filmDAL.addBaseFilmLocation(filmName);
                filmDAL.addLocationToFilm(filmLoc.filmTitle, locnDisplayText, latCoord.ToString(), lngCoord.ToString());
                filmLocations.Add(filmLoc);

                //filmLoc.filmTitle = filmName;
                //filmLoc.index = numFilms - 1;
               // filmLoc.locations = new List<Location>();
            }
            else
            {
                if (locationDoesNotExist(filmName, locnDisplayText))
                {
                    filmLoc = filmLocations[numFilms - 1];
                    filmDAL.addLocationToFilm(filmLoc.filmTitle, locnDisplayText, latCoord.ToString(), lngCoord.ToString());
                }
            }

            //int numLocns = filmLoc.locn.Count;
            //Location locn = new Location();
            //locn.index = numLocns;
            //locn.locnText = locnDisplayText;
            //locn.latCoord = latCoord;
            //locn.lngCoord = lngCoord;
            //filmLoc.locations.Add(locn);
        }

        private bool locationDoesNotExist(String filmName, String locationName)
        {
            return finder.locationDoesNotExist(filmName, locationName);
        }

        private bool filmDoesNotExist(String filmName)
        {
            return finder.filmDoesNotExist(filmName);
        }
    }
}