using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace AutomationFramework
{
    public partial class SearchHotelPage : CoreFrame
    {
        public void ResetCriteria()
        {
            Click(resetBtn);
        }
        public void Search(string location, string Hotels, string RoomType, string NoOfRooms, string CheckinDate, string CheckoutDate, string AdultsPerRoom, string ChildrenPerRoom)
        {
            try
            {
                Write(locationDropdown, location);
                Write(hotelsDropdown, Hotels);
                Write(roomTypeDropdown, RoomType);
                Write(numOfRoomsDropdown, NoOfRooms);
                Write(checkinDateTxt, CheckinDate);
                Write(checkoutDateTxt, CheckoutDate);
                Write(adultPerRmDropdown, AdultsPerRoom);
                Write(childrenPerRmDropdown, ChildrenPerRoom);
                Click(searchBtn);
            }
            catch
            {
                throw new InvalidOperationException("failed");
            }
        }
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
