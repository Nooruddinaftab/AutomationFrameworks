using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace AutomationFramework
{
    public partial class BookHotelPage
    {
        public By fnameTxt = By.Id("first_name");
        public By lnameTxt = By.Id("last_name");
        public By addressTxt = By.Id("address");
        public By cCNoTxt = By.Id("cc_num");
        public By cCTypeDropDown = By.Id("cc_type");
        public By expiryDateDropDown = By.Id("cc_exp_month");
        public By expiryYearDropDown = By.Id("cc_exp_year");
        public By cVVNoTxt = By.Id("cc_cvv");
        public By bookNowBtn = By.Id("book_now");
        public By cancelBtn = By.Id("cancel");

        public By orderNoTxt = By.Id("order_no");
    }
}
