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
        [HostType("ASP.NET")]
       // [AspNetDevelopmentServerHost("C:\\Users\\Jack\\Git\\AwesomeEnterpriseApp\\AwesomeEnterpriseApp\\AwesomeEnterpriseApp", "/")]
       // [UrlToTest("http://localhost:54116/")]
        public void LocationCalculatorConstructorTest()
        {
            LocationCalculator target = new LocationCalculator();
            LocationCalculator target2 = new LocationCalculator();
            Assert.AreEqual(target, target2);
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
            double distance = 0.94;
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

        /// <summary>
        ///A test for setNewQuery
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Jack\\Git\\AwesomeEnterpriseApp\\AwesomeEnterpriseApp\\AwesomeEnterpriseApp", "/")]
        [UrlToTest("http://localhost:54116/")]
        public void setNewQueryTest()
        {
            LocationCalculator target = new LocationCalculator(); // TODO: Initialize to an appropriate value
            Point centre = null; // TODO: Initialize to an appropriate value
            Point location = null; // TODO: Initialize to an appropriate value
            double radius = 0F; // TODO: Initialize to an appropriate value
            target.setNewQuery(centre, location, radius);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for radius
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Jack\\Git\\AwesomeEnterpriseApp\\AwesomeEnterpriseApp\\AwesomeEnterpriseApp", "/")]
        [UrlToTest("http://localhost:54116/")]
        public void radiusTest()
        {
            LocationCalculator target = new LocationCalculator(); // TODO: Initialize to an appropriate value
            double expected = 0F; // TODO: Initialize to an appropriate value
            double actual;
            target.radius = expected;
            actual = target.radius;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for xCentre
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
       // [HostType("ASP.NET")]
       // [AspNetDevelopmentServerHost("C:\\Users\\Jack\\Git\\AwesomeEnterpriseApp\\AwesomeEnterpriseApp\\AwesomeEnterpriseApp", "/")]
       // [UrlToTest("http://localhost:54116/")]
        public void xCentreTest()
        {
            LocationCalculator target = new LocationCalculator(); // TODO: Initialize to an appropriate value
            double expected = 0F; // TODO: Initialize to an appropriate value
            double actual;
            target.xCentre = expected;
            actual = target.xCentre;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for xLocation
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[AspNetDevelopmentServerHost("C:\\Users\\Jack\\Git\\AwesomeEnterpriseApp\\AwesomeEnterpriseApp\\AwesomeEnterpriseApp", "/")]
        //[UrlToTest("http://localhost:54116/")]
        public void xLocationTest()
        {
            LocationCalculator target = new LocationCalculator(); // TODO: Initialize to an appropriate value
            Point expected = new Point("01", "02");
            //target.
        }

        /// <summary>
        ///A test for yCentre
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Jack\\Git\\AwesomeEnterpriseApp\\AwesomeEnterpriseApp\\AwesomeEnterpriseApp", "/")]
        [UrlToTest("http://localhost:54116/")]
        public void yCentreTest()
        {
            LocationCalculator target = new LocationCalculator(); // TODO: Initialize to an appropriate value
            double expected = 0F; // TODO: Initialize to an appropriate value
            double actual;
            target.yCentre = expected;
            actual = target.yCentre;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for yLocation
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Jack\\Git\\AwesomeEnterpriseApp\\AwesomeEnterpriseApp\\AwesomeEnterpriseApp", "/")]
        [UrlToTest("http://localhost:54116/")]
        public void yLocationTest()
        {
            LocationCalculator target = new LocationCalculator(); // TODO: Initialize to an appropriate value
            double expected = 0F; // TODO: Initialize to an appropriate value
            double actual;
            target.yLocation = expected;
            actual = target.yLocation;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
