using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace AutomationFramework
{
    public partial class ForgotPasswordPage
    {
        public By emailaddrecoveryTxt = By.Id("emailadd_recovery");
        public By emailpswBtn = By.Id("Submit");
    }
}
