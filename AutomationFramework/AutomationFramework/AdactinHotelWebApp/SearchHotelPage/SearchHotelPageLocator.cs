using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace AutomationFramework
{
    public partial class SearchHotelPage
    {
        public By welcomeMessageLabel = By.ClassName("welcome_menu");
        public By locationDropdown = By.Id("location");
        public By hotelsDropdown = By.Id("hotels");
        public By roomTypeDropdown = By.Id("room_type");
        public By numOfRoomsDropdown = By.Id("room_nos");
        public By checkinDateTxt = By.Id("datepick_in");
        public By checkoutDateTxt = By.Id("datepick_out");
        public By adultPerRmDropdown = By.Id("adult_room");
        public By childrenPerRmDropdown = By.Id("child_room");
        public By searchBtn = By.Id("Submit");
        public By resetBtn = By.Id("Reset");
    }
}
