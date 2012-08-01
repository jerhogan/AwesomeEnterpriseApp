using AwesomeEnterpriseApp.BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using AwesomeEnterpriseApp.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AwesomeEnterpriseApp.Models.UI;

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
        ///A test for readAllFilms
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        public void readAllFilmsTest()
        {
            LocnXMLReader target = new LocnXMLReader();

            // Context db = new Context();
            // db.Database.Delete();
            // db.Database.Create();

            target.setSource("https://nycopendata.socrata.com/download/qb3k-n8mm/application/xml");
            List<FilmLocations> filmList = target.readAllFilms();

            LocationFinder locFinder = new LocationFinder();
            bool film25thHourFound = false;
            bool filmAThousandClownsFound = false;
            foreach (String film in locFinder.getAllFilmNames())
            {
                if (film == "25th Hour")
                    film25thHourFound = true;
                else if (film == "A Thousand Clowns")
                    filmAThousandClownsFound = true;
            }
            Assert.AreEqual(film25thHourFound, true);
            Assert.AreEqual(filmAThousandClownsFound, true);

            LocationListUI locList = locFinder.getLocationsForFilm("25th Hour");
            bool foundLoc1 = false;
            bool foundLoc2 = false;
            foreach (String locText in locList.locations)
            {
                if (locText == "World Trade Center, Lower Manhattan")
                    foundLoc1 = true;
                else if (locText == "Carl Schurz Park, Upper East Side, Manhattan")
                    foundLoc2 = true;
                else
                    Assert.Fail("Unexpected location in film 25th Hour " + locText);
            }
            Assert.AreEqual(foundLoc1, true);
            Assert.AreEqual(foundLoc2, true);

            locList = locFinder.getLocationsForFilm("A Thousand Clowns");
            foundLoc1 = false;
            foreach (String locText in locList.locations)
            {
                if (locText == "Statue of Liberty, Liberty Island, New York Harbor")
                    foundLoc1 = true;
                else
                    Assert.Fail("Unexpected location in film A Thousand Clowns " + locText);
            }
            Assert.AreEqual(foundLoc1, true);
        }
    }
}
