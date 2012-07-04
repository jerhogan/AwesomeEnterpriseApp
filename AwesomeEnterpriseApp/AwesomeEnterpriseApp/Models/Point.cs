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
        [Column(IsPrimaryKey = true, Storage = "idPoint")]
        public int idPoint { get; set; }
        [Column(Name = "x")]
        public double x { get; set; }
        [Column(Name = "y")]
        public double y { get; set; }

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }


    }



}