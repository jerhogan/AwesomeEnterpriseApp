using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AwesomeEnterpriseApp.Models
{
    public class MovieSpots
    {
        public IEnumerable<SelectListItem> Spots { get; set; }
    }
}