using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AwesomeEnterpriseApp.Models;
using AwesomeEnterpriseApp.Models.UI;

namespace AwesomeEnterpriseApp.BusinessLogic
{
    public class RestaurantFinder
    {
        
        // The returned list is ready to be put out over API and View
        public List<Restaurant> getRestaurantsWithinRadius(IncomingRequestUI request)
        {
            // Create collection of Restaurants that are within radius.. empty for now.
            List<Restaurant> restaurantsWithinRadius = new List<Restaurant>();

            // Find the lat/long (Point) of the IncomingRequestUI using FilmLocationsDAL, for now we pretend
            Point requestPoint = null;

            // Find all restaurants, for now we'll pretend
            List<Restaurant> allRestaurants = new List<Restaurant>();

            // Create a Calculator obj
            LocationCalculator calc = new LocationCalculator();

            // Iterate through all restaurants in the DB
            for (int i=0; i<allRestaurants.Count; i++)
            {
                // Passing the centre point, restaurant point and radius into the calculator
                calc.setNewQuery(requestPoint, allRestaurants[i].point, request.radius);
                // If the calculator decides the restarant is within the radius...
                if (calc.isInsideRadius())
                {
                    // ...add it to the outgoing list
                    restaurantsWithinRadius.Add(allRestaurants[i]);
                }
            }

            // Return the list of all Restaurants within radius
            return restaurantsWithinRadius;

        }
        public static void getFilmDetails()
 
    }
}