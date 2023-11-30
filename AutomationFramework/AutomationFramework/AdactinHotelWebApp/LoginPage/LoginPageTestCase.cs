using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Configuration;

namespace AutomationFramework
{
    [TestClass]
    public partial class LoginPage : CoreFrame
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
        public void LoginCorrect()
        {
            AdactinHotelWebApp.LoginPage.Login(LoginPage.Url, "NoorTester", "NoorTester");
            string message = Initialization.driver.FindElement(By.ClassName("welcome_menu")).Text;
            Assert.AreEqual("Welcome to Adactin Group of Hotels", message);

        }

        [TestMethod]
        [TestCategory("Test Within LoginPageTestCase Class-Open site")]
        public void OpenSite()
        {
            OpenUrl(Url);
            Write(usernameTxt, "Noor");
        }

        [TestMethod]
        [TestCategory("Test Within LoginPageTestCase Class-Login Negative")]
        public void LoginWrong()
        {
            AdactinHotelWebApp.LoginPage.Login(LoginPage.Url, "NoorTester", "Noor");
            string message = GetElementText(invaliduserpswresetLink);
            Assert.AreEqual("Click here", message);

        }
        [TestMethod]
        [TestCategory("Reset Password")]
        public void ResetPassword()
        {
            OpenUrl(Url);
            // click on forgot password link
            Click(forgotpasswordLink);

            // enter email
            Write(emailaddrecoveryTxt,"noori_dar@yahoo.com");
            // press reset btn
            Click(emailpswBtn);

            // validate with login correct credentials
            //AdactinHotelWebApp.LoginPage.Login(LoginPage.Url, "NoorTester", "NoorTester");
            AdactinHotelWebApp.LoginPage.Login(LoginPage.Url, "NoorTester", "NoorTester");
            string message = GetElementText(invaliduserpswresetLink);
            Assert.AreEqual("Click here", message);
        }
    }
}
