using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AwesomeEnterpriseApp.Models
{
    public class Context : DbContext
    {
        public DbSet<Restaurant> restaurants { get; set; }
        public DbSet<FilmLocations> filmLocations { get; set; }
        public DbSet<Address> addresses { get; set; }
        public DbSet<Location> locations { get; set; }
        public DbSet<Point> points { get; set; }

    }
}