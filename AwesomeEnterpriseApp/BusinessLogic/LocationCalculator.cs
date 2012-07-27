using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AwesomeEnterpriseApp.Models;

namespace AwesomeEnterpriseApp.BusinessLogic
{
    public class LocationCalculator
    {

        public double xCentre { get; set; }
        public double yCentre { get; set; }

        public double xLocation { get; set; }
        public double yLocation { get; set; }

        public double radius { get; set; }

        public LocationCalculator()
        {
        }
        
        public void setNewQuery(Point centre, Point location, double radius)
        {
            this.xCentre = centre.x;
            this.yCentre = centre.y;

            this.xLocation = location.x;
            this.yLocation = location.y;

            this.radius = radius;
        }

        public Boolean isInsideRadius()
        {
            
            double xDiff = (xCentre - xLocation) * 110.54;  //Lat
            // Longitude is calculated by latitude, not by specifying the lng of NY, leaving  app open to further cities
            double yDiff = (yCentre - yLocation) * (111.320 * Math.Cos(xLocation * 110.54));  //Long

            double distance = Math.Sqrt((xDiff * xDiff) + (yDiff * yDiff));

            Console.Out.WriteLine(distance);
            Console.In.ReadLine();

            if (distance <= radius)
            {
                return true;
            }
            return false;
        }


    }
}