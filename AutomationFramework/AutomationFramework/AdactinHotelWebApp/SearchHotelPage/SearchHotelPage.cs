using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace AutomationFramework
{
    public partial class SearchHotelPage : CoreFrame
    {


    }

    public partial class AdactinHotelWebApp
    {
        public static SearchHotelPage SearchHotelPage
        {
            get
            {
                if(searchHotelPage == null)
                {
                    searchHotelPage = new SearchHotelPage();
                }
                return searchHotelPage;
            }
            set
            {
                searchHotelPage = value;
            }
        }
        private static SearchHotelPage searchHotelPage;
    }

}
