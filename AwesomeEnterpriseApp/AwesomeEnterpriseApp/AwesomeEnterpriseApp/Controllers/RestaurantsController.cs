using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AwesomeEnterpriseApp.Models;
using AwesomeEnterpriseApp;
using AwesomeEnterpriseApp.Models.UI;
using AwesomeEnterpriseApp.BusinessLogic;
using AwesomeEnterpriseApp.DataAccessLayer;



namespace AwesomeEnterpriseApp.Controllers
{
    public class RestaurantsController : ApiController
    {
        
        static List<Restaurant> _restaurantsWithinRadius = InitRestaurants();

        private static List<Restaurant>  InitRestaurants()
        {
            // throw new NotImplementedException();
            var ret = new List<Restaurant>();        
            ret.Add(new Restaurant());


            // AwesomeEnterpriseApp.BusinessLogic.RestaurantFinder().getAllRestaurants();
            

            return ret;
        }
        public IEnumerable<Restaurant> Get()
        {
            //InitRestaurants();
            return _restaurantsWithinRadius;
        }
        //// GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<controller>
        //public void Post(string value)
        //{
        //}

        //// PUT api/<controller>/5
        //public void Put(int id, string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}


    }
}










