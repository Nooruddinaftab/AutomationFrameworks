using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace AutomationFramework
{
    public partial class LoginPage 
    {
        public By usernameTxt = By.Id("username");
        public By passwordTxt = By.Id("password");
        public By loginBtn = By.Id("login");

        public By forgotpasswordLink = By.XPath("//*[@id=\"login_form\"]/table/tbody/tr[4]/td[2]/div/a");
        public By invaliduserpswresetLink = By.XPath("//*[@id=\"login_form\"]/table/tbody/tr[5]/td[2]/div/b/a");
    }
}
