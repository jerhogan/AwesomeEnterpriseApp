using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AwesomeEnterpriseApp.Models;

namespace AwesomeEnterpriseApp.BusinessLogic.Interfaces
{
    interface IXMLReader
    {
        
            List<FilmLocations> readAllFilms();
            void setSource(String xmlSource);
        
    }
}
