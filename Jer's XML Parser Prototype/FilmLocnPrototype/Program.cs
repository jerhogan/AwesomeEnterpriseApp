﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FilmLocnPrototype
{
    class Program
    {
        static void Main(string[] args)
        {
            FilmLocations[] locations;
            LocnXMLReader xmlObject = new LocnXMLReader();

            xmlObject.readXML();
            locations = xmlObject.getFilmLocations();
            foreach (var loc in locations)
            {
                Console.WriteLine("Film Index " + loc.index);
                Console.WriteLine("Film Title " + loc.filmTitle);
                foreach (var sLoc in loc.locn)
                {
                    Console.WriteLine("Locn Index " + sLoc.index);
                    Console.WriteLine("Locn Display Text " + sLoc.locnText);
                    Console.WriteLine("Locn lat " + sLoc.latCoord);
                    Console.WriteLine("Locn lng " + sLoc.lngCoord);
                    Console.WriteLine("Locn Radius " + sLoc.radius);
                }
                Console.ReadLine();
            }
            Console.ReadLine();
        }
    }
}
