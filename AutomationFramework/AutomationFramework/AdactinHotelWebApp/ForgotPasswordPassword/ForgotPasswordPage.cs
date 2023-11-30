using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace AutomationFramework
{
    public partial class ForgotPasswordPage : CoreFrame
    {
        public void ResetPassword(string email)
        {
            OpenUrl(Url);
            Click(AdactinHotelWebApp.LoginPage.forgotpasswordLink);
            Write(emailaddrecoveryTxt, email);
            // press reset btn
            Click(emailpswBtn);
        }

    }

    public partial class AdactinHotelWebApp
    {
        public static ForgotPasswordPage ForgotPasswordPage
        {
            get
            {
                if(ForgotPasswordPage == null)
                {
                    ForgotPasswordPage = new ForgotPasswordPage();
                }
                return ForgotPasswordPage;
            }
            set
            {
                ForgotPasswordPage = value;
            }
        }
        private static ForgotPasswordPage forgotPasswordPage;
    }

}
