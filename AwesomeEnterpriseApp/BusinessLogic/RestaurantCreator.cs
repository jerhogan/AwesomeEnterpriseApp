using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AwesomeEnterpriseApp.DataAccessLayer;

namespace AwesomeEnterpriseApp.BusinessLogic
{
    public class RestaurantCreator
    {

        private RestaurantDAL rdal = new RestaurantDAL();
        String x = "";
        String y = "";

        // Add a new Restaurant record to the DB
        public Boolean createNewRestaurant(String name, String cuisine, int fanciness, String websiteUrl, String houseNumber, String streetAddress1, String streetAddress2, String zipCode, String city)
        {

            try
            {
                Geocoder gc = new Geocoder();
                gc.Line1 = ((houseNumber != null) ? houseNumber : "") + " " + streetAddress1;
                gc.Line2 = streetAddress2;
                gc.Zip = zipCode;
                gc.City = city;
                gc.State = "New York";
                gc.Country = "US";

                gc.GeoCode();

                x = gc.Latitude;
                y = gc.Longitude;

            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }

            try
            {
                rdal.addRestaurant(name, cuisine, fanciness, websiteUrl, houseNumber, streetAddress1, streetAddress2, zipCode, city, x, y);
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                return false;
            }
            return true;
        }

    }
}