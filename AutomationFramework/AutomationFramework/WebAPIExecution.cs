using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Configuration;
using System.Threading;

namespace AutomationFramework
{
    [TestClass]
    public class WebAPIExecution
    {
        #region Setups and Cleanups
        public TestContext instance;
        public TestContext TestContext
        {
            set { instance = value; }
            get { return instance; }
        }

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {

        }

        [ClassCleanup()]
        public static void ClassCleanup()
        {

        }

        [TestInitialize()]
        public void TestInit()
        {

        }

        [TestCleanup()]
        public void TestCleanUp()
        {

        }

        #endregion

        public const string DataSourceXML = "Microsoft.VisualStudio.TestTools.DataSource.XML";
        public const string DataSourceCSV = "Microsoft.VisualStudio.TestTools.DataSource.CSV";
        public const string AppUrl = "http://adactinhotelapp.com/";


        [TestMethod(), TestCategory("WebAPI")]
        public void WebAPI_ValidateDatafromGET_TC01()
        {
            string data = WebAPI.GET(@"http://api.weatherapi.com/", @"v1/current.json?key=7d1845e091e1458785c182851212110&q=Karachi&aqi=yes");
            string value = WebAPI.SearchValueFromJSON(data, "location", "name");

            Assert.AreEqual("Karachi", value);
        }


        [TestMethod(), TestCategory("WebAPI")]
        [DataSource(DataSourceXML, "Data.xml", "WebAPI", DataAccessMethod.Sequential)]
        public void WebAPI_ValidateDatafromGET_TC02()
        {
            string baseURL = TestContext.DataRow["baseURL"].ToString();
            string methodURL = @"v1/current.json?key=7d1845e091e1458785c182851212110&q=Karachi&aqi=yes";
            string expectedValue = TestContext.DataRow["ExpectedValue"].ToString();

            string data = WebAPI.GET(@baseURL, methodURL);
            string value = WebAPI.SearchValueFromJSON(data, "location", "region");

            Assert.AreEqual(expectedValue, value);
        }

    }
}