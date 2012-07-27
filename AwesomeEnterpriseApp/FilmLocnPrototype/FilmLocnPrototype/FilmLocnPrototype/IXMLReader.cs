using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FilmLocnPrototype
{
    interface IXMLReader
    {
        List<FilmLocations> filmLocation();
        void setSource(String xmlSource);
    }
}
