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
            string execBrowser = ConfigurationManager.AppSettings["ExecutionBrowser"].ToString();
            Initialization.SeleniumInit();
        }

        [TestCleanup()]
        public void TestCleanUp()
        {
            Initialization.TestCleanup();
        }

        #endregion


        [TestMethod]
        public void TestCase_001Demo()
        {
            OpenUrl("http://adactinhotelapp.com/");
            Write(usernameTxt, "Amir");
        }

        [TestMethod]
        public void TestCase_002Demo()
        {
            OpenUrl("http://adactinhotelapp.com/");
            Write(usernameTxt, "Amir");
            Write(passwordTxt, "Amir");
            Click(loginBtn);

        }
    }
}
