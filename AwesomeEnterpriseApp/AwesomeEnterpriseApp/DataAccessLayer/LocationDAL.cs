﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AwesomeEnterpriseApp.Models;

namespace AwesomeEnterpriseApp.DataAccessLayer
{ 
    public class LocationDAL
    {
        Context db = new Context();

        public Location findLocation(int idLocation)
        {
            return null;
        }

        public Location addLocation(string locationName, string xCoord, string yCoord)
        {
            PointDAL pointDAL = new PointDAL();
            Point point = pointDAL.addPoint(xCoord, yCoord);

            Location location = new Location(locationName, point);

            db.locations.Add(location);

            return location;
        }

        public Boolean deleteLocation(int idLocation)
        {
            return false;
        }
    }
}