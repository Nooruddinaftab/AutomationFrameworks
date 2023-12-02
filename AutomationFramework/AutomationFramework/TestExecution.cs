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
        [TestCategory("CancelAllBookings")]
        [DataSource(DataSourceXML, "Data.xml", "CancelAllBookings", DataAccessMethod.Sequential)]
        public void CancelAllBookings()
        {
            string user = TestContext.DataRow["username"].ToString();
            string pass = TestContext.DataRow["password"].ToString();
            string msg = TestContext.DataRow["message"].ToString();
            AdactinHotelWebApp.LoginPage.Login(LoginPage.Url, user, pass);
            string messageLabelTxt = Initialization.driver.FindElement(AdactinHotelWebApp.SearchHotelPage.welcomeMessageLabel).Text;
            Assert.AreEqual(msg, messageLabelTxt);

            AdactinHotelWebApp.BookedItineraryPage.Click(AdactinHotelWebApp.BookedItineraryPage.bookedItineraryTab);
            AdactinHotelWebApp.BookedItineraryPage.SelectAllBookings();
            AdactinHotelWebApp.BookedItineraryPage.CancelBooking();
            AdactinHotelWebApp.BookedItineraryPage.AlertAccept();
        }


        [TestMethod]
        [TestCategory("LoginAndVerify")]
        [DataSource(DataSourceXML, "Data.xml", "LoginAndVerify", DataAccessMethod.Sequential)]
        public void LoginAndVerify()
        {
            string user = TestContext.DataRow["username"].ToString();
            string pass = TestContext.DataRow["password"].ToString();
            string msg = TestContext.DataRow["message"].ToString();
            AdactinHotelWebApp.LoginPage.Login(LoginPage.Url, user, pass);
            string messageLabelTxt = Initialization.driver.FindElement(AdactinHotelWebApp.SearchHotelPage.welcomeMessageLabel).Text;
            Assert.AreEqual(msg, messageLabelTxt);
        }

        [TestMethod]
        [TestCategory("Search Hotels")]
        [DataSource(DataSourceXML, "Data.xml", "SearchHotel", DataAccessMethod.Sequential)]
        public void SearchHotel()
        {
            string user = TestContext.DataRow["username"].ToString();
            string pass = TestContext.DataRow["password"].ToString();
            string msg = TestContext.DataRow["message"].ToString();
            AdactinHotelWebApp.LoginPage.Login(LoginPage.Url, user, pass);
            string messageLabelTxt = Initialization.driver.FindElement(AdactinHotelWebApp.SearchHotelPage.welcomeMessageLabel).Text;
            Assert.AreEqual(msg, messageLabelTxt);

            string Location = TestContext.DataRow["Location"].ToString();
            string Hotels = TestContext.DataRow["Hotels"].ToString();
            string RoomType = TestContext.DataRow["RoomType"].ToString();
            string NoOfRooms = TestContext.DataRow["NoOfRooms"].ToString();
            string CheckinDate = TestContext.DataRow["CheckinDate"].ToString();
            string CheckoutDate = TestContext.DataRow["CheckoutDate"].ToString();
            string AdultsPerRoom = TestContext.DataRow["AdultsPerRoom"].ToString();
            string ChildrenPerRoom = TestContext.DataRow["ChildrenPerRoom"].ToString();

            AdactinHotelWebApp.SearchHotelPage.Search(Location, Hotels, RoomType, NoOfRooms, CheckinDate, CheckoutDate, AdultsPerRoom, ChildrenPerRoom);
        }
        [TestMethod]
        [TestCategory("Select Hotel")]
        [DataSource(DataSourceXML, "Data.xml", "SelectHotel", DataAccessMethod.Sequential)]
        public void SelectHotel()
        {
            string user = TestContext.DataRow["username"].ToString();
            string pass = TestContext.DataRow["password"].ToString();
            string msg = TestContext.DataRow["message"].ToString();
            AdactinHotelWebApp.LoginPage.Login(LoginPage.Url, user, pass);
            string messageLabelTxt = Initialization.driver.FindElement(AdactinHotelWebApp.SearchHotelPage.welcomeMessageLabel).Text;
            Assert.AreEqual(msg, messageLabelTxt);

            string Location = TestContext.DataRow["Location"].ToString();
            string Hotels = TestContext.DataRow["Hotels"].ToString();
            string RoomType = TestContext.DataRow["RoomType"].ToString();
            string NoOfRooms = TestContext.DataRow["NoOfRooms"].ToString();
            string CheckinDate = TestContext.DataRow["CheckinDate"].ToString();
            string CheckoutDate = TestContext.DataRow["CheckoutDate"].ToString();
            string AdultsPerRoom = TestContext.DataRow["AdultsPerRoom"].ToString();
            string ChildrenPerRoom = TestContext.DataRow["ChildrenPerRoom"].ToString();

            AdactinHotelWebApp.SearchHotelPage.Search(Location, Hotels, RoomType, NoOfRooms, CheckinDate, CheckoutDate, AdultsPerRoom, ChildrenPerRoom);

            int ResultIndex = Convert.ToInt32(TestContext.DataRow["ResultIndex"].ToString());
            AdactinHotelWebApp.SelectHotelPage.SelectHotel(ResultIndex);
        }
        [TestMethod]
        [TestCategory("Book Hotel")]
        [DataSource(DataSourceXML, "Data.xml", "BookHotel", DataAccessMethod.Sequential)]
        public void BookHotel()
        {
            string user = TestContext.DataRow["username"].ToString();
            string pass = TestContext.DataRow["password"].ToString();
            string msg = TestContext.DataRow["message"].ToString();
            AdactinHotelWebApp.LoginPage.Login(LoginPage.Url, user, pass);
            string messageLabelTxt = Initialization.driver.FindElement(AdactinHotelWebApp.SearchHotelPage.welcomeMessageLabel).Text;
            Assert.AreEqual(msg, messageLabelTxt);

            string Location = TestContext.DataRow["Location"].ToString();
            string Hotels = TestContext.DataRow["Hotels"].ToString();
            string RoomType = TestContext.DataRow["RoomType"].ToString();
            string NoOfRooms = TestContext.DataRow["NoOfRooms"].ToString();
            string CheckinDate = TestContext.DataRow["CheckinDate"].ToString();
            string CheckoutDate = TestContext.DataRow["CheckoutDate"].ToString();
            string AdultsPerRoom = TestContext.DataRow["AdultsPerRoom"].ToString();
            string ChildrenPerRoom = TestContext.DataRow["ChildrenPerRoom"].ToString();

            AdactinHotelWebApp.SearchHotelPage.Search(Location, Hotels, RoomType, NoOfRooms, CheckinDate, CheckoutDate, AdultsPerRoom, ChildrenPerRoom);

            int ResultIndex = Convert.ToInt32(TestContext.DataRow["ResultIndex"].ToString());
            AdactinHotelWebApp.SelectHotelPage.SelectHotel(ResultIndex);

            string fname = TestContext.DataRow["fname"].ToString();
            string lname = TestContext.DataRow["lname"].ToString();
            string address = TestContext.DataRow["address"].ToString();
            string cCNo = TestContext.DataRow["cCNo"].ToString();
            string cCType = TestContext.DataRow["cCType"].ToString();
            string expiryDate = TestContext.DataRow["expiryDate"].ToString();
            string expiryYear = TestContext.DataRow["expiryYear"].ToString();
            string cVVNo = TestContext.DataRow["cVVNo"].ToString();
            AdactinHotelWebApp.BookHotelPage.BookHotel(fname, lname, address, cCNo, cCType, expiryDate, expiryYear, cVVNo);
            Thread.Sleep(10000);
            Console.WriteLine("Order Number: " + AdactinHotelWebApp.BookHotelPage.GetOrderNo());
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
