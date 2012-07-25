using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq.Mapping;

namespace AwesomeEnterpriseApp.Models
{
    [Table(Name = "point")]
    public class Point
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }
        [Column(Name = "x")]
        public double x { get; set; }
        [Column(Name = "y")]
        public double y { get; set; }

        public Point(string x, string y)
        {
            this.x = Convert.ToDouble(x);
            this.y = Convert.ToDouble(y);
        }


    }



}