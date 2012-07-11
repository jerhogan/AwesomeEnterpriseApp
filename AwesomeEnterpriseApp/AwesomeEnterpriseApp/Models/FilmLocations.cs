using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace AwesomeEnterpriseApp.Models
{
    [Table(Name = "filmlocations")]
    public class FilmLocations
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }
        [Column(Name = "filmTitle")]
        public string filmTitle { get; set; }
        [Column(Name = "locations")]
        public List<Location> locations { get; set; }

        public FilmLocations(string filmTitle, List<Location> locn)
        {
            this.filmTitle = filmTitle;
            this.locations = locn;
        }
    }
}
