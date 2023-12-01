using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace AutomationFramework
{
    public partial class SelectHotelPage : CoreFrame
    {

        public void SelectHotel(int resultIndex)
        {
            SetSelectRadioBtnArray();
            Click(selectRadioBtnArray[resultIndex]);
            Click(continueBtn);
        }
        public void ContinueBtn()
        {
            Click(continueBtn);
        }

        public void CancelBtn()
        {
            Click(cancelBtn);
        }
        private void SetSelectRadioBtnArray(int maxElement=10)
        {
            selectRadioBtnArray = new By[maxElement];

            for (int i = 0; i < maxElement; i++)
            {
                string labelstr = "radiobutton_";
                labelstr += i.ToString();
                selectRadioBtnArray[i] = By.Id(labelstr);
            }

        }
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
