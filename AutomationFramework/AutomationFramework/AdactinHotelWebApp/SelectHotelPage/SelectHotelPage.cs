using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace AutomationFramework
{
    public partial class SelectHotelPage : CoreFrame
    {


    }

    public partial class AdactinHotelWebApp
    {
        public static SelectHotelPage SelectHotelPage
        {
            get
            {
                if(selectHotelPage == null)
                {
                    selectHotelPage = new SelectHotelPage();
                }
                return selectHotelPage;
            }
            set
            {
                selectHotelPage = value;
            }
        }
        private static SelectHotelPage selectHotelPage;
    }

}
