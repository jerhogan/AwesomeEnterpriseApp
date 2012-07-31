using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AwesomeEnterpriseApp.Models;


namespace AwesomeEnterpriseApp.Controllers
{   //URI /api/restaurants
    public class RestaurantsController : ApiController
    {
        static List< Restaurant> _restaurantsWhitinRadius = InitRestaurants();
        private static List<Restaurant> InitRestaurants()
        {
           // throw new NotImplementedException();
            var ret = new List<Restaurant>();
            //restaurantsWithinRadius = new List<Restaurant>();
            ret.Add(new Restaurant());
            //return restaurantsWithinRadius;
            return ret;
        }
        public IEnumerable<Restaurant> Get()
        {
            InitRestaurants();
            return _restaurantsWhitinRadius;
        }


        //public static List<Restaurant> restaurantsWithinRadius { get; set; }
    }

    //public class Restaurant
    //{
       
      //  public int Id { get; set; }       
       // public String name { get; set; }
       // public int cuisine { get; set; }
        //public int fanciness { get; set; }
        //public String websiteUrl { get; set; }
       // public Address address { get; set; }
       // public Point point { get; set; }
    }



