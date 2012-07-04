using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AwesomeEnterpriseApp.Models;

namespace FilmLocnPrototype
{
    interface IXMLReader
    {
        List<FilmLocations> filmLocation();
        void setSource(String xmlSource);
    }
}
