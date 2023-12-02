using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace AutomationFramework
{
    public partial class BookedItineraryPage : CoreFrame
    {

        public void SearchByOrderId(string orderId)
        {


        }

        public void CancelBooking()
        {
            Click(cancelBtn);
        }

        internal void SelectAllBookings()
        {
            Click(selectAllBookedCheckbox);
        }
    }

    public partial class AdactinHotelWebApp
    {
        public static BookedItineraryPage BookedItineraryPage
        {
            get
            {
                if(bookedItineraryPage == null)
                {
                    bookedItineraryPage = new BookedItineraryPage();
                }
                return bookedItineraryPage;
            }
            set
            {
                bookedItineraryPage = value;
            }
        }
        private static BookedItineraryPage bookedItineraryPage;
    }

}
