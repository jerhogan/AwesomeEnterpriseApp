using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AwesomeEnterpriseApp.Models;

namespace AwesomeEnterpriseApp.DataAccessLayer
{
    public class PointDAL
    {
        public Point findPoint(int idPoint)
        {
            return null;
        }
        public Point addPoint(string xCoord, string yCoord)
        {
            Point point = null;

            if (xCoord != null && !xCoord.Equals("") && yCoord != null && !yCoord.Equals(""))
            {
                double x = Convert.ToDouble(xCoord);
                double y = Convert.ToDouble(yCoord);
                point = new Point(x, y);
            }
            return point; 
        }

        public Boolean deletePoint(int idPoint)
        {
            return false;
        }
    }
}