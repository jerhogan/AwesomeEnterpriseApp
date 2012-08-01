using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AwesomeEnterpriseApp.Models;
using AwesomeEnterpriseApp.BusinessLogic;
using AwesomeEnterpriseApp.Models.UI;
using AwesomeEnterpriseApp.DataAccessLayer;
using System.Web.Mvc;

namespace AwesomeEnterpriseApp.Controllers
{
    public class RestaurantDetailsController : Controller
    {
        //
        // GET: /RestaurantDetails/

        public Boolean callRestaurantDetails(String name, String cuisine, int fanciness, String websiteUrl, String houseNumber, String streetAddress1, String streetAddress2, String zipCode, String city, String x, String y)
        {

            Boolean success = new RestaurantCreator().createNewRestaurant(name, cuisine, fanciness, websiteUrl, houseNumber, streetAddress1, streetAddress2, zipCode, city, x, y);

            return success;

        }

    }
}
