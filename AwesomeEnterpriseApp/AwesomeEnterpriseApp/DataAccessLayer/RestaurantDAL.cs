using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AwesomeEnterpriseApp.Models;
using AwesomeEnterpriseApp.Models.DB;

namespace AwesomeEnterpriseApp.DataAccessLayer
{
    public class RestaurantDAL
    {

        public RestaurantDB db = new RestaurantDB();

        public Restaurant findRestaurant(String xCoord, String yCoord)
        {
            List<Restaurant> rests = null;

            rests = db.restaurants.ToList();

            foreach (Restaurant restaurant in rests)
            {
                if (restaurant.point.x.Equals(xCoord) && restaurant.point.y.Equals(yCoord))
                {
                    return restaurant;
                }
            }

            return null;
        }

        public List<Restaurant> findAllRestaurants()
        {
            List<Restaurant> rests = null;

            rests = db.restaurants.ToList();

            foreach (Restaurant restaurant in rests)
            {
                rests.Add(restaurant);
            }

            return rests;
        }

        public Restaurant addRestaurant(String name, int cuisine, int fanciness, String websiteUrl, String houseNumber, String street1, 
            String street2, String zipCode, String city, String xCoord, String yCoord) 
        {
            AddressDAL addressDAL = new AddressDAL();
            Address restaurantAddress = addressDAL.addAddress(houseNumber, street1, street2, zipCode, city);

            PointDAL pointDAL = new PointDAL();
            Point point = pointDAL.addPoint(xCoord,yCoord);

            Restaurant restaurant = new Restaurant(name, cuisine, fanciness, websiteUrl, restaurantAddress, point);

            db.restaurants.Add(restaurant);

            return restaurant;
        }

        public Boolean deleteRestaurant(int idRestaurant)
        {
            Boolean deleted = false;

            Restaurant restaurant = db.restaurants.Find(idRestaurant);

            if (restaurant != null)
            {
                db.restaurants.Remove(restaurant);
                deleted = true;
            }

            return deleted;
        }
    }
}