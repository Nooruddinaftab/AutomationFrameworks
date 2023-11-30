using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace AutomationFramework
{
    public partial class ChangePasswordPage : CoreFrame
    {


    }

    public partial class AdactinHotelWebApp
    {
        public static ChangePasswordPage ChangePasswordPage
        {
            get
            {
                if(changePasswordPage == null)
                {
                    changePasswordPage = new ChangePasswordPage();
                }
                return changePasswordPage;
            }
            set
            {
                changePasswordPage = value;
            }
        }
        private static ChangePasswordPage changePasswordPage;
    }

}
