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
            OpenUrl(url);
            Write(usernameTxt, username);
            Write(passwordTxt, password);
            Click(loginBtn);
        }
        public void LoginAfterResetPassword(string url, string username, string password)
        {
            OpenUrl(url);
            Write(usernameTxt, username);
            Write(passwordTxt, password);
            Click(loginBtn);
            string message = GetElementText(invaliduserpswresetLink);
            Assert.AreEqual("Click here", message);
            //Assert.AreEqual("dasdasd here", message); call this to fail
        }
    }

    public partial class AdactinHotelWebApp
    {
        public static LoginPage LoginPage
        {
            get
            {
                if(loginPage == null)
                {
                    loginPage = new LoginPage();
                }
                return loginPage;
            }
            set
            {
                loginPage = value;
            }
        }
        private static LoginPage loginPage;
    }

}
