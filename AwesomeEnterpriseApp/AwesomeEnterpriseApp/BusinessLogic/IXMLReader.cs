using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AwesomeEnterpriseApp.Models;
using AwesomeEnterpriseApp.DataAccessLayer;

namespace AwesomeEnterpriseApp.BusinessLogic
{
    interface IXMLReader
    {
        List<FilmLocations> readAllFilms();
        void setSource(String xmlSource);
    }
}
