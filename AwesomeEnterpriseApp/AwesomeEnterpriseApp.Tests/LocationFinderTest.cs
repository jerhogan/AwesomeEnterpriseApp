﻿using AwesomeEnterpriseApp.BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using AwesomeEnterpriseApp.Models.UI;
using System.Collections.Generic;

namespace AwesomeEnterpriseApp.Tests
{
    
    
    /// <summary>
    ///This is a test class for LocationFinderTest and is intended
    ///to contain all LocationFinderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LocationFinderTest
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
        ///A test for getLocationsForFilm
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        public void getLocationsForFilmTest()
        {
            LocationFinder target = new LocationFinder();
            String filmName;
            LocationListUI expected, actual;
            
            filmName = "12 Angry Men";
            expected = new LocationListUI();
            expected.filmName = filmName;
            expected.locations = new List<String>();
            expected.locations.Add ("New York County Courthouse<br>40 Foley Square<br>Lower Manhattan");
            actual = target.getLocationsForFilm(filmName);
            Assert.AreEqual(expected, actual);

            filmName = "15 Minutes";
            expected = new LocationListUI();
            expected.filmName = filmName;
            expected.locations = new List<String>();
            expected.locations.Add("E. 60-66th St.and Madison Ave.<br>Upper East Side<br>Manhattan");
            expected.locations.Add("Carl Schurz Park<br>Upper East Side<br>Manhattan");
            actual = target.getLocationsForFilm(filmName);
            Assert.AreEqual(expected, actual);
        }
    }
}
