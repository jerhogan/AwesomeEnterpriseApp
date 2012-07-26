using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AwesomeEnterpriseApp.Models;

namespace AwesomeEnterpriseApp.DataAccessLayer
{
    public class PointDAL
    {
        Context db = new Context();

        public Point findPoint(int idPoint)
        {
            return null;
        }
        public Point addPoint(string xCoord, string yCoord)
        {
            Point point = null;

            if (xCoord != null && !xCoord.Equals("") && yCoord != null && !yCoord.Equals(""))
            {
                point = new Point(xCoord, yCoord);
            }

            db.points.Add(point);

            db.SaveChanges();

            return point; 
        }

        public Boolean deletePoint(int idPoint)
        {
            return false;
        }
    }
}