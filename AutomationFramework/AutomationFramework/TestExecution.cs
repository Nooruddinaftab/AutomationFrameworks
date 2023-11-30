using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Threading;

namespace AutomationFramework
{
    [TestClass]
    public class TestExecution
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
            CoreFrame.ExecutionBrowser = ConfigurationManager.AppSettings["ExecutionBrowser"].ToString();
            Initialization.SeleniumInit();
        }

        [TestCleanup()]
        public void TestCleanUp()
        {
            Initialization.TestCleanup();
        }

        #endregion

        public const string DataSourceXML = "Microsoft.VisualStudio.TestTools.DataSource.XML";
        public const string DataSourceCSV = "Microsoft.VisualStudio.TestTools.DataSource.CSV";


        [TestMethod]
        [TestCategory("Login")]
        public void Login()
        {
            AdactinHotelWebApp.LoginPage.Login(LoginPage.Url, "NoorTester", "NoorTester");
            string message = Initialization.driver.FindElement(By.ClassName("welcome_menu")).Text;
            Assert.AreEqual("Welcome to Adactin Group of Hotels", message);
        }

        /*
        [TestMethod]
        [TestCategory("E2E")]
        public void TestCase_E2E_01()
        {
            LoginPage loginPage = new LoginPage();
            SearchPage searchPage = new SearchPage();
            SelectPage selectPage = new SelectPage();
            BookHotelPage bookHotelPage = new BookHotelPage();

            loginPage.Login(LoginPage.Url, "NoorTester", "NoorTester");
            searchPage.SearchHotel();
            selectPage.SelectHotel();
            bookHotelPage.BookHotel();
            Thread.Sleep(10000);
            Console.WriteLine("Order Number: " + bookHotelPage.GetOrderNo());
        }


        [TestMethod]
        [TestCategory("E2E")]
        public void TestCase_E2E_02()
        {
            AdactinHotelApp.LoginPage.Login(LoginPage.Url, "NoorTester", "NoorTester");
            AdactinHotelApp.SearchPage.SearchHotel();
            AdactinHotelApp.SelectPage.SelectHotel();
            AdactinHotelApp.BookHotelPage.BookHotel();
            Thread.Sleep(10000);
            Console.WriteLine("Order Number: " + AdactinHotelApp.BookHotelPage.GetOrderNo());
        }

        [TestMethod]
        [TestCategory(MyDemoAppTestCategory.Login)]
        public void TestCase_E2E_03()
        {
            AdactinHotelApp.LoginPage.Login(LoginPage.Url, "NoorTester", "NoorTester");
            AdactinHotelApp.SearchPage.SearchHotel();
            AdactinHotelApp.SelectPage.SelectHotel();
            AdactinHotelApp.BookHotelPage.BookHotel();
            Thread.Sleep(10000);
            Console.WriteLine("Order Number: " + AdactinHotelApp.BookHotelPage.GetOrderNo());
        }

        [TestMethod]
        [TestCategory("Login"), TestCategory("BAT"), TestCategory("P1")]
        [Owner("Noor"), WorkItem(3345)]
        [DataSource(DataSourceXML, "Data.xml", "Login", DataAccessMethod.Sequential)]
        public void ValidateLoginWithValidUserValidPass_XML()
        {
            string url = TestContext.DataRow["url"].ToString();
            string user = TestContext.DataRow["username"].ToString();
            string pass = TestContext.DataRow["password"].ToString();

            AdactinHotelApp.LoginPage.Login(url, user, pass);

            string message = Initialization.driver.FindElement(By.ClassName("welcome_menu")).Text;
            Assert.AreEqual("Welcome to Adactin Group of Hotels", message);
        }


        [TestMethod(), TestCategory("PDFReportAutomation")]
        public void GenerateAndValidatePDF_TC()
        {
            MatchCollection actual = PDFExtractor.PDFCompareValueUsingRegrex(@"Safety Audit.pdf", @"(SAFETY AUDIT REPORT|Fraud 23 13 24 21 16 -30.4%)");
            Assert.AreEqual("SAFETY AUDIT REPORT", actual[0].Value.ToString());
            Assert.AreEqual("Fraud 23 13 24 21 16 -30.4%", actual[1].Value.ToString());
        }


        [TestMethod(), TestCategory("Database")]
        public void MSSQLDatabaseTC_01()
        {
            SqlConnection sqlconnection = Initialization.MSSQLConnect();

            SqlCommand command = new SqlCommand("Select id from student where name = 'Noor'", sqlconnection);

            // int result = command.ExecuteNonQuery();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    string a = reader["id"].ToString();
                }
            }

            Initialization.CloseSQLDBConnection(sqlconnection);

        }
        */
    }
}
