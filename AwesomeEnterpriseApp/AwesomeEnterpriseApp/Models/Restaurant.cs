using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq.Mapping;

namespace AwesomeEnterpriseApp.Models
{
    [Table(Name = "restaurant")]
    public class Restaurant
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }
        [Column(Name = "name")]
        public String name { get; set; }
        [Column(Name = "cuisine")]
        public int cuisine { get; set; }
        [Column(Name = "fanciness")]
        public int fanciness { get; set; }
        [Column(Name = "websiteUrl")]
        public String websiteUrl { get; set; }
        [Column(Name = "address")]
        public Address address { get; set; }
        [Column(Name = "point")]
        public Point point { get; set; }


        public Restaurant(String name, int cuisine, int fanciness, String websiteUrl, Address address, Point point)
        {
            this.name = name;
            this.cuisine = cuisine;
            this.fanciness = fanciness;
            this.websiteUrl = websiteUrl;
            this.address = address;
            this.point = point;
        }

    }
    
}