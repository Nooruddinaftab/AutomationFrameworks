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
        [TestCategory("Test Within LoginPageTestCase Class-Open site")]
        public void OpenSite()
        {
            OpenUrl("http://adactinhotelapp.com/");
            Write(usernameTxt, "Noor");
        }

        [TestMethod]
        [TestCategory("Test Within LoginPageTestCase Class-Login Negative")]
        public void Login()
        {
            OpenUrl("http://adactinhotelapp.com/");
            Write(usernameTxt, "Noor");
            Write(passwordTxt, "Noor");
            Click(loginBtn);

        }
    }
}
