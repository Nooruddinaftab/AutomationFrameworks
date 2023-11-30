using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Configuration;

namespace AutomationFramework
{
    [TestClass]
    public partial class ForgotPasswordPage
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
        [TestCategory("Reset Password and verify loggin with old creds")]
        public void ResetPasswordCase()
        {
            ResetPassword("noori_dar@yahoo.com");
            // validate with login correct credentials
            AdactinHotelWebApp.LoginPage.LoginAfterResetPassword(LoginPage.Url, "NoorTester", "NoorTester");
        }
    }
}
