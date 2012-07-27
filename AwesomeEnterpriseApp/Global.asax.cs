using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;

namespace AwesomeEnterpriseApp
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            //routing for the Api
            routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "api/{controller}/{id}",
              defaults: new { id = RouteParameter.Optional }
            );

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

            routes.MapRoute(
                "RegisterRestaurant", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "RestaurantDetails", action = "RestaurantDetails", id = UrlParameter.Optional } // Parameter defaults
            );

            routes.MapRoute(
                "LocationFinder", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "LocationFinder", action = "getSecondList", id = UrlParameter.Optional } // Parameter defaults
            );

            routes.MapRoute(
                "RestaurantFinder", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "RestaurantFinder", action = "GetMessage", id = UrlParameter.Optional } // Parameter defaults
            );
            
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
        }
    }
}