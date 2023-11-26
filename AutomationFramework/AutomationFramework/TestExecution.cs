using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace AutomationFramework
{
    [TestClass]
    public class TestExecution
    {
        [TestMethod]
        public void Login()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "http://adactinhotelapp.com/";
            driver.FindElement(By.Id("username")).SendKeys("AmirTester");
            driver.FindElement(By.Id("password")).SendKeys("AmirTester");
            driver.FindElement(By.Id("login")).Click();
            driver.Close();
        }
    }
}
