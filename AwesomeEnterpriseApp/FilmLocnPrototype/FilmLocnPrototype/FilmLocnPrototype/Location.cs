using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FilmLocnPrototype
{
    public class Location
    {
        public int index { get; set; }
        public string locnText { get; set; }
        public double latCoord { get; set; }
        public double lngCoord { get; set; }
        public double radius { get; set; }
    }
}
