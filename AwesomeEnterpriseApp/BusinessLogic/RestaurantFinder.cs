using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AwesomeEnterpriseApp.Models;
using AwesomeEnterpriseApp.Models.UI;
using AwesomeEnterpriseApp.DataAccessLayer;

namespace AwesomeEnterpriseApp.BusinessLogic
{
    public class RestaurantFinder
    {
        // Instantiate DALs 
        private RestaurantDAL rdal = new RestaurantDAL();
        private FilmLocationsDAL fdal = new FilmLocationsDAL();
        private List<Restaurant> restaurantsWithinRadius = null;

        // This is the actual method you call, it will calculate what's within the radius and return ViewModels
        public List<PresentedRestaurantUI> getRestaurantsWithinRadius(IncomingRequestUI request)
        {
            List<Restaurant> restaurantsWithinRadius = queryForRestaurantsAndCalculate(request);

            List<PresentedRestaurantUI> returnableModels = convertToViewModel(restaurantsWithinRadius);

            return returnableModels;

        }

        private static List<PresentedRestaurantUI> convertToViewModel(List<Restaurant> restaurantsWithinRadius)
        {
            List<PresentedRestaurantUI> returnableModels = new List<PresentedRestaurantUI>();

            if (restaurantsWithinRadius != null)
            {
                foreach (Restaurant rest in restaurantsWithinRadius)
                {
                    // Convert restaurant to viewmodel
                    PresentedRestaurantUI NewRest = new PresentedRestaurantUI();
                    if (rest.name != null)
                        NewRest.name = rest.name;
                    if (rest.cuisine != null)
                        NewRest.cuisine = rest.cuisine;

                    String address = "";
                    if (rest.address.houseNumber != null)
                        address += rest.address.houseNumber + ", ";
                    if (rest.address.streetAddress1 != null)
                        address += rest.address.streetAddress1 + ", ";
                    if (rest.address.streetAddress2 != null)
                        address += rest.address.streetAddress2 + ", ";
                    if (rest.address.zipCode != null)
                        address += rest.address.zipCode + ", ";
                    if (rest.address.city != null)
                        address += rest.address.city;


                    NewRest.address = address;

                    switch (rest.fanciness)
                    {
                        case 1:
                            NewRest.fanciness = "Takeaway";
                            break;
                        case 2:
                            NewRest.fanciness = "Diner";
                            break;
                        case 3:
                            NewRest.fanciness = "Restaurant";
                            break;
                        case 4:
                            NewRest.fanciness = "Fine Dining";
                            break;
                        case 5:
                            NewRest.fanciness = "Awesome";
                            break;
                        default:
                            NewRest.fanciness = "Nobody knows..";
                            break;
                    }

                    if (rest.websiteUrl != null)
                        NewRest.websiteURL = rest.websiteUrl;

                    //NewRest.distance = 

                    returnableModels.Add(NewRest);
                }
            }

            return returnableModels;
        }

        // The returned list is ready to be put out over API and View
        public List<Restaurant> queryForRestaurantsAndCalculate(IncomingRequestUI request)
        {
            if (request == null)
                return null;

            restaurantsWithinRadius = new List<Restaurant>();

            // Find the lat/long (Point) of the IncomingRequestUI using FilmLocationsDAL
            Point requestPoint = null;
            List<Location> locationsForRequestedFilm = fdal.findLocationsByFilm(request.filmName);
            foreach (Location loc in locationsForRequestedFilm)
            {
                if (loc.locnText.Equals(request.location))
                {
                    requestPoint = loc.point;
                }
            }

            if (requestPoint == null)
                return null;

            // Find all restaurants
            List<Restaurant> allRestaurants = rdal.findAllRestaurants();

            // Create a Calculator obj
            LocationCalculator calc = new LocationCalculator();

            // Iterate through all restaurants in the DB
            for (int i = 0; i < allRestaurants.Count; i++)
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
        // public static void getFilmDetails();


        public void demoMethod()
        {

            IncomingRequestUI request = new IncomingRequestUI();
            //fill request with user values

            //create finder object
            RestaurantFinder finder = new RestaurantFinder();
            //use finder to return list of viewmodels
            List<PresentedRestaurantUI> restaurantsInRadius = finder.getRestaurantsWithinRadius(request);
        }

    }
}