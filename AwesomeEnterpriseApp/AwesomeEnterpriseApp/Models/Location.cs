using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace AwesomeEnterpriseApp.Models
{
    [Table(Name = "location")]
    public class Location
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }
        [Column(Name = "locnText")]
        public string locnText { get; set; }
        [Column(Name = "point")]
        public Point point { get; set; }

        public Location() { }

        public Location(string locnText, Point point)
        {
            this.locnText = locnText;
            this.point = point;
        }
    }
}
