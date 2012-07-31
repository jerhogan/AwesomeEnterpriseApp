using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AwesomeEnterpriseApp;
using AwesomeEnterpriseApp.Controllers;
using AwesomeEnterpriseApp.Models;

namespace AwesomeEnterpriseApp.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            Context db = new Context();
            db.Database.Delete();
            db.Database.Create();

            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            ViewDataDictionary viewData = result.ViewData;
            Assert.AreEqual("Welcome to an Awesome Enterprise App!", viewData["Message"]);

            List<SelectListItem> flicks = (List <SelectListItem> )viewData["movieList"];
            Assert.AreEqual(178, flicks.Count);
            Assert.AreEqual("*batteries not included", flicks[0].Text);
            Assert.AreEqual("12 Angry Men", flicks[1].Text);
            Assert.AreEqual("15 Minutes", flicks[3].Text);
            Assert.AreEqual("Die Hard: With a Vengeance", flicks[37].Text);
            Assert.AreEqual("You've Got Mail", flicks[177].Text);

//            List<SelectListItem> locs = (List<SelectListItem>)viewData["locationList"];
//            Assert.AreEqual(1, locs.Count);
//            if (locs.Count > 0) 
//                Assert.AreEqual("E. 5th St.<br>East Village<br>Manhattan", locs[0].Text);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
