using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace AutomationFramework
{
    public partial class BookHotelPage : CoreFrame
    {


    }

    public partial class AdactinHotelWebApp
    {
        public static BookHotelPage BookHotelPage
        {
            get
            {
                if(bookHotelPage == null)
                {
                    bookHotelPage = new BookHotelPage();
                }
                return bookHotelPage;
            }
            set
            {
                bookHotelPage = value;
            }
        }
        private static BookHotelPage bookHotelPage;
    }

}
