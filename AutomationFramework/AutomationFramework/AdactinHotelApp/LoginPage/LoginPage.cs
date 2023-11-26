using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace AutomationFramework
{
    public partial class LoginPage : CoreFrame
    {
        public void Login(string url, string username, string password)
        {
            driver.Url = url;
            driver.FindElement(usernameTxt).SendKeys(username);
            driver.FindElement(passwordTxt).SendKeys(password);
            driver.FindElement(loginBtn).Click();
        }
    }
}
