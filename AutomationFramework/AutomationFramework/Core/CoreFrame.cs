using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace AutomationFramework
{
    public class CoreFrame
    {
        public static IWebDriver driver;

        public void SeleniumIntialization()
        {
            driver = new ChromeDriver();
        }
    }
}
