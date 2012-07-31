using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AwesomeEnterpriseApp.Models;
using AwesomeEnterpriseApp.BusinessLogic;
using AwesomeEnterpriseApp.Models.UI;
//using AwesomeEnterpriseApp.DataAccessLayer;
using System.Web.Mvc;

namespace AwesomeEnterpriseApp.Controllers
{
    public class RestaurantFinderController : Controller
    {

        RestaurantFinder newRestObject = new RestaurantFinder();
        
        public String getMessage(String radius, String filmName, String location)
        {
            String htmlList = "";

            IncomingRequestUI request = new IncomingRequestUI();
            request.radius = double.Parse ( radius.Substring(0, 1) );
            request.location = location;
            request.filmName = filmName;

            List<PresentedRestaurantUI> restList = newRestObject.getRestaurantsWithinRadius (request);

            foreach (PresentedRestaurantUI rest in restList)
            {
                String details = "<h5>Name: " + rest.name + "</h5>";
                if (rest.cuisine != null)
                    details += "<br>Cuisine: " + rest.cuisine;
                if (rest.fanciness != null)
                    details += "<br>Quality: " + rest.fanciness;
                if (rest.address != null)
                    details += "<br>Address: " + rest.address;
                if (rest.websiteURL != null)
                    details += "<br>Website: " + rest.websiteURL;

                htmlList += "<p>" + details + "</p>";
            }

            return (htmlList);
        }



        

    }
}