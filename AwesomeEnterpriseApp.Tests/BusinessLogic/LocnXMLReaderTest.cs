using AwesomeEnterpriseApp.BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using AwesomeEnterpriseApp.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AwesomeEnterpriseApp.Tests
{
    
    
    /// <summary>
    ///This is a test class for LocnXMLReaderTest and is intended
    ///to contain all LocnXMLReaderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LocnXMLReaderTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for addEntry
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        public void addEntryTest()
        {
            LocnXMLReader target = new LocnXMLReader();

            Context db = new Context();
            db.Database.Delete();
            db.Database.Create();

            string filmName = "Die Hard";
            double latCoord = 30.5;
            double lngCoord = -70.25;
            string locnDisplayText = "Manhattan";
            target.addEntry(filmName, latCoord, lngCoord, locnDisplayText);
            Assert.AreEqual(target.filmLocations.Count, 1);
            Assert.AreEqual(target.filmLocations[0].filmTitle, "Die Hard");
            Assert.AreEqual(target.filmLocations[0].locations.Count, 1);
            foreach (Location currentLoc in target.filmLocations[0].locations)
            {
                Assert.AreEqual(currentLoc.locnText, "Manhattan");
                Assert.AreEqual(currentLoc.point.x, 30.5);
                Assert.AreEqual(currentLoc.point.y, -70.25);
            }
            filmName = "Die Hard";
            latCoord = 25.5;
            lngCoord = -55.25;
            locnDisplayText = "Brooklyn";
            target.addEntry(filmName, latCoord, lngCoord, locnDisplayText);
            Assert.AreEqual(target.filmLocations.Count, 1);
            Assert.AreEqual(target.filmLocations[0].filmTitle, "Die Hard");
            Assert.AreEqual(target.filmLocations[0].locations.Count, 2);
            foreach (Location currentLoc in target.filmLocations[0].locations)
            {
                if (currentLoc.locnText == "Manhattan")
                {
                    Assert.AreEqual(currentLoc.locnText, "Manhattan");
                    Assert.AreEqual(currentLoc.point.x, 30.5);
                    Assert.AreEqual(currentLoc.point.y, -70.25);
                }
                else if (currentLoc.locnText == "Brooklyn")
                {
                    Assert.AreEqual(currentLoc.locnText, "Brooklyn");
                    Assert.AreEqual(currentLoc.point.x, 25.5);
                    Assert.AreEqual(currentLoc.point.y, -55.25);
                }
                else
                    Assert.Fail("Unexpected location in film " + currentLoc.locnText);
            }

            filmName = "Die Hard 2";
            latCoord = 22.75;
            lngCoord = -66.66666666667;
            locnDisplayText = "Queens";
            target.addEntry(filmName, latCoord, lngCoord, locnDisplayText);
            Assert.AreEqual(target.filmLocations.Count, 2);
            Assert.AreEqual(target.filmLocations[1].filmTitle, "Die Hard 2");
            Assert.AreEqual(target.filmLocations[1].locations.Count, 1);
            foreach (Location currentLoc in target.filmLocations[1].locations)
            {
                Assert.AreEqual(currentLoc.locnText, "Queens");
                Assert.AreEqual(currentLoc.point.x, 22.75);
                Assert.AreEqual(currentLoc.point.y, -66.66666666667);
            }
        }
    }
}
