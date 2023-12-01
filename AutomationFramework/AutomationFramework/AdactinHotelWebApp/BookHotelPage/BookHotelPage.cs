using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace AutomationFramework
{
    public partial class BookHotelPage : CoreFrame
    {
        public void BookHotel(string fname, string lname, string address, string cCNo, string cCType, string expiryDate, string expiryYear, string cVVNo)
        {
            Write(fnameTxt, fname);
            Write(lnameTxt, lname);
            Write(addressTxt, address);
            Write(cCNoTxt, cCNo);
            Write(cCTypeDropDown, cCType);
            Write(expiryDateDropDown, expiryDate);
            Write(expiryYearDropDown, expiryYear);
            Write(cVVNoTxt, cVVNo);
            Click(bookNowBtn);
        }
        public string GetOrderNo()
        {
            //driver.FindElement(orderNoTxt).GetAttribute("value");
            string GeneratedorderNo = GetElementText(orderNoTxt);
            return GeneratedorderNo;
        }
        public void BookNowBtn()
        {
            Click(bookNowBtn);
        }

        public void CancelBtn()
        {
            Click(cancelBtn);
        }

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
