using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace AutomationFramework
{
    public partial class LoginPage : CoreFrame
    {
        By usernameTxt = By.Id("username");
        By passwordTxt = By.Id("password");
        By loginBtn = By.Id("login");

    }
}
