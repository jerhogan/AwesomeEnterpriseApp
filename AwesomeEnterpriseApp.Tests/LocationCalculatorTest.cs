using AwesomeEnterpriseApp.BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using AwesomeEnterpriseApp.Models;

namespace AwesomeEnterpriseApp.Tests
{
    
    
    /// <summary>
    ///This is a test class for LocationCalculatorTest and is intended
    ///to contain all LocationCalculatorTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LocationCalculatorTest
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
        ///A test for LocationCalculator Constructor
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
       // [AspNetDevelopmentServerHost("C:\\Users\\Jack\\Git\\AwesomeEnterpriseApp\\AwesomeEnterpriseApp\\AwesomeEnterpriseApp", "/")]
       // [UrlToTest("http://localhost:54116/")]
        public void LocationCalculatorConstructorTest()
        {
            LocationCalculator target = new LocationCalculator();
            LocationCalculator target2 = new LocationCalculator();
            Assert.AreEqual(target.radius, target2.radius);
            Assert.AreEqual(target.xCentre, target2.xCentre);
            Assert.AreEqual(target.yCentre, target2.yCentre);
            Assert.AreEqual(target.xLocation, target2.xLocation);
            Assert.AreEqual(target.yLocation, target2.yLocation);
        }

        /// <summary>
        ///A test for isInsideRadius
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
       // [HostType("ASP.NET")]
       // [AspNetDevelopmentServerHost("C:\\Users\\Jack\\Git\\AwesomeEnterpriseApp\\AwesomeEnterpriseApp\\AwesomeEnterpriseApp", "/")]
       // [UrlToTest("http://localhost:54116/")]
        public void isInsideRadiusTest()
        {
            LocationCalculator target = new LocationCalculator(); // TODO: Initialize to an appropriate value
            
            // Actual distance between locations = 0.94km;

            // 49-51 W 46th St
            target.xCentre = 40.756912;
            target.yCentre = -73.980989;

            // 4-42 W 58th St
            target.xLocation = 40.764259;
            target.yLocation = -73.975325;

            target.radius = 1; //km

            bool actual = target.isInsideRadius();
            bool expected = true; 
            actual = target.isInsideRadius();
            Assert.AreEqual(expected, actual);
        }

         [TestMethod()]
        public void isInsideRadiusTestFALSE()
        {
            LocationCalculator target = new LocationCalculator(); // TODO: Initialize to an appropriate value

            // Actual distance between locations = 1.3km;

            // 49-51 W 46th St
            target.xCentre = 40.756912;
            target.yCentre = -73.980989;

            // 37-39 W 77th St
            target.xLocation = 40.774361;
            target.yLocation = -73.975244;

            target.radius = 1; //km

            bool actual = target.isInsideRadius();
            bool expected = false;
            actual = target.isInsideRadius();
            Assert.AreEqual(expected, actual);
        }

        
    }
}
