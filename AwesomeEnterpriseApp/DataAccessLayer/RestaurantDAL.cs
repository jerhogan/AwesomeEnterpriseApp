using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AwesomeEnterpriseApp.Models;

namespace AwesomeEnterpriseApp.DataAccessLayer
{
    public class RestaurantDAL
    {

        public Context db = new Context();

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
            Point point = pointDAL.addPoint(xCoord, yCoord);

            Restaurant restaurant = new Restaurant(name, cuisine, fanciness, websiteUrl, restaurantAddress, point);

            db.restaurants.Add(restaurant);
            db.SaveChanges();

            return restaurant;
        }


        public Restaurant updateRestaurant(String name, int cuisine, int fanciness, String websiteUrl, String houseNumber, String street1,
            String street2, String zipCode, String city, String xCoord, String yCoord)
        {
            Restaurant existingRest = findRestaurant(xCoord, yCoord);
            if (existingRest == null)
            {
                return addRestaurant(name, cuisine, fanciness, websiteUrl, houseNumber, street1, street2, zipCode, city, xCoord, yCoord);
            }

            Address a = existingRest.address;
            a.city = city;
            a.houseNumber = houseNumber;
            a.streetAddress1 = street1;
            a.streetAddress2 = street2;
            existingRest.address = a;

            Point point = existingRest.point;
            point.x = Convert.ToDouble(xCoord);
            point.y = Convert.ToDouble(yCoord);
            existingRest.point = point;

            existingRest.name = name;
            existingRest.cuisine = cuisine;
            existingRest.fanciness = fanciness;
            existingRest.websiteUrl = websiteUrl;

            db.Entry(existingRest).State = System.Data.EntityState.Modified;
            db.SaveChanges();

            return existingRest;
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