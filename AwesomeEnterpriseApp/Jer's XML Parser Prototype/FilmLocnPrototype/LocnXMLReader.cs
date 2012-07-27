using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace FilmLocnPrototype
{
    public class LocnXMLReader
    {
        public LocnXMLReader()
        {
            filmLocations = new FilmLocations [0];
        }

        private FilmLocations[] filmLocations;

        public FilmLocations[] getFilmLocations ()
        {
            return (filmLocations);
        }

        static int numFilms = 0;

        public void readXML()
        {
            String addFilmTitle = "";
            double addLat= 0.0F;
            double addLng = 0.0F;
            String addDisplayText = "";
            int filmCellNo = 0;
            int latCellNo = 0;
            int lngCellNo = 0;
            int locationDisplayTextCellNo = 0;
            bool isFullMapList = false;
            XDocument doc = XDocument.Load("https://nycopendata.socrata.com/download/qb3k-n8mm/application/xml");

            foreach (var w in doc.Descendants())
            {
                isFullMapList = false;
                if (w.Name.LocalName == "Worksheet")
                {
                    foreach (var x in w.Attributes ())
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
                                                            addLat = double.Parse (k.Value);
//                                                            Console.WriteLine("LATITUDE: " + k.Value);
                                                        }
                                                        else if (iCell == lngCellNo)
                                                        {
                                                            addLng = double.Parse (k.Value);
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

            numFilms = filmLocations.Length;
            newFilm = true;
            if (numFilms >= 1) 
                if (filmLocations[numFilms - 1].filmTitle == filmName)
                {
                    newFilm = false;
                }
            if (newFilm)
            {
                numFilms++;
                Array.Resize<FilmLocations> (ref filmLocations, numFilms);
                filmLocations[numFilms - 1] = new FilmLocations();
                filmLocations[numFilms - 1].filmTitle = filmName;
                filmLocations[numFilms - 1].index  = numFilms - 1;
                filmLocations[numFilms - 1].locn = new Location[0];
            }

            int numLocns;
            numLocns = filmLocations[numFilms - 1].locn.Length + 1;
            Location[] location = filmLocations[numFilms - 1].locn;
            Array.Resize<Location>(ref location, numLocns);
            filmLocations[numFilms - 1].locn = location;
            filmLocations[numFilms - 1].locn[numLocns - 1] = new Location();
            filmLocations[numFilms - 1].locn[numLocns - 1].index = numLocns - 1;
            filmLocations[numFilms - 1].locn[numLocns - 1].locnText  = locnDisplayText;
            filmLocations[numFilms - 1].locn[numLocns - 1].latCoord = latCoord;
            filmLocations[numFilms - 1].locn[numLocns - 1].lngCoord  = lngCoord;
            filmLocations[numFilms - 1].locn[numLocns - 1].radius = 0.0F;
        }
    }
}