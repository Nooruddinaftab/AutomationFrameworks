using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace AutomationFramework
{
    public partial class BookedItineraryPage
    {
        public By bookedItineraryTab = By.XPath("/html/body/table[2]/tbody/tr[1]/td[2]/a[2]");
        public By selectAllBookedCheckbox = By.Id("check_all");
        public By cancelBtn = By.ClassName("reg_button");

    }
}
