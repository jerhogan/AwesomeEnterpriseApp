using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AwesomeEnterpriseApp.Models
{
    public class AwesomeDB : DbContext
    {
        public DbSet<Restaurant> restaurants { get; set; }
        public DbSet<FilmLocations> filmLocations { get; set; }

    }
}