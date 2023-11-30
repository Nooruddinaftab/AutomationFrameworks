using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Configuration;

namespace AutomationFramework
{
    [TestClass]
    public partial class LoginPage
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
            Initialization.SeleniumInit();
        }

        [TestCleanup()]
        public void TestCleanUp()
        {
            Initialization.TestCleanup();
        }

        #endregion

        [TestMethod]
        [TestCategory("Login with Valid Creds")]
        [DataSource(DataSourceXML, "Data.xml", "LoginCorrect", DataAccessMethod.Sequential)]
        public void LoginCorrect()
        {
            string user = TestContext.DataRow["username"].ToString();
            string pass = TestContext.DataRow["password"].ToString();
            string msg = TestContext.DataRow["message"].ToString();
            Login(LoginPage.Url, user, pass);
            string messageLabelTxt = Initialization.driver.FindElement(AdactinHotelWebApp.SearchHotelPage.welcomeMessageLabel).Text;
            Assert.AreEqual(msg, messageLabelTxt);
        }

        [TestMethod]
        [TestCategory("Login with InValid Creds")]
        [DataSource(DataSourceXML, "Data.xml", "LoginWrong", DataAccessMethod.Sequential)]
        public void LoginWrong()
        {
            string user = TestContext.DataRow["username"].ToString();
            string pass = TestContext.DataRow["password"].ToString();

            Login(LoginPage.Url, user, pass);
            string message = GetElementText(invaliduserpswresetLink);
            Assert.AreEqual("Click here", message);

        }
        [TestMethod]
        [TestCategory("Reset Password")]
        [DataSource(DataSourceXML, "Data.xml", "ResetPassword", DataAccessMethod.Sequential)]
        public void ResetPassword()
        {
            string emailId = TestContext.DataRow["emailid"].ToString();
            string user = TestContext.DataRow["username"].ToString();
            string pass = TestContext.DataRow["password"].ToString();

            OpenUrl(Url);
            // click on forgot password link
            Click(forgotpasswordLink);

            AdactinHotelWebApp.ForgotPasswordPage.ResetPassword(emailId);

            // validate with login correct credentials
            LoginAfterResetPassword(LoginPage.Url, user, pass);

        }

    }
}
