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

        By forgotpasswordLink = By.XPath("//*[@id=\"login_form\"]/table/tbody/tr[4]/td[2]/div/a");
        By emailaddrecoveryTxt = By.Id("emailadd_recovery");
        By emailpswBtn = By.Id("Submit");
        By invaliduserpswresetLink = By.XPath("//*[@id=\"login_form\"]/table/tbody/tr[5]/td[2]/div/b/a");
    }
}
