using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace AutomationFramework
{
    public class CoreFrame
    {
        #region Properties
        public static dynamic driver;
        public static int MaxTimeToFindElement = Convert.ToInt32(ConfigurationManager.AppSettings["MaxTimeToFindElement"]);
        public static string ExecutionBrowser = ConfigurationManager.AppSettings["ExecutionBrowser"].ToString();
        public static bool HeadlessExecution = Convert.ToBoolean(ConfigurationManager.AppSettings["HeadlessExecution"]);
        #endregion

        #region Javascript Core
        public void Write(string locator, string setValue, int timeToReadyElement = 0)
        {
            try // Locate Element
            {
                ExecuteJavaScriptCode("$('" + locator + "').val('" + setValue + "').trigger('change')");
            }
            catch (Exception ex)
            {

            }
        }
        public void Click(string locator, int timeToReadyElement = 0)
        {
            try // Locate Element
            {
                ExecuteJavaScriptCode("$('" + locator + "').click()");
            }
            catch (Exception ex) // Element Not found
            {



            }
        }
        public string GetElementText(string locator)
        {
            string text = ExecuteJavaScriptCode("$('" + locator + "').click()");
            return text;
        }


        public static void SelectFromKendoMultiColumnComboBox(string locator, string filterText)
        {
            try
            {
                ExecuteJavaScriptCode("$('" + locator + "').data('kendoMultiColumnComboBox').value('" + filterText + "')");
                ExecuteJavaScriptCode("$('" + locator + "').data('kendoMultiColumnComboBox').trigger('change')");
            }
            catch (Exception ex)
            {
            }
        }
        #endregion

        #region Core Methods
        public void Write(By by, string setValue, int timeToReadyElement = 0)
        {
            try // Locate Element
            {
                var element = WaitforElement(by, timeToReadyElement);
                element.SendKeys(setValue);
            }
            catch (Exception ex)
            {

            }
        }
        public void Click(By by, int timeToReadyElement = 0)
        {
            try // Locate Element
            {
                var element = WaitforElement(by, timeToReadyElement);
                element.Click();

            }
            catch (Exception ex) // Element Not found
            {

            }
        }
        public void OpenUrl(string url)
        {
            driver.Url = url;
        }
        public string GetElementText(By by)
        {
            string text;
            try
            {
                text = driver.FindElement(by).Text;
            }
            catch
            {
                try
                {
                    text = driver.FindElement(by).GetAttribute("value");
                }
                catch
                {
                    text = driver.FindElement(by).GetAttribute("innerHTML");
                }
            }
            return text;
        }
        public bool GetElementState()
        {
            return true;
        }
        public string GetElementText(By by, int timeToReadyElement = 1)
        {
            string actualValue = string.Empty;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            try
            {
                if (IsElementPresent(by))
                {
                    if (IsElementTextField(by) == true)
                    {
                        actualValue = WaitforElement(by, timeToReadyElement).GetAttribute("value");
                    }
                    else
                    {
                        actualValue = WaitforElement(by, timeToReadyElement).GetAttribute("text");
                        if (actualValue == null || actualValue == String.Empty)
                        {
                            actualValue = WaitforElement(by, timeToReadyElement).GetAttribute("innerHTML");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return actualValue;
        }

        #endregion

        #region Utility Methods
        public int PDFCompare(string pdfPath, string regex)
        {
            try
            {
                string data = PDFExtractor.ExtractTextFromPDF(pdfPath);
                Regex expression = new Regex(regex);
                var results = expression.Matches(data);
                return results.Count;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static void PlaybackWait(int miliSeconds)
        {
            Thread.Sleep(miliSeconds);
        }

        public static string ExecuteJavaScriptCode(string javascriptCode)
        {
            string value = null;
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                value = (string)js.ExecuteScript(javascriptCode);
            }
            catch (Exception)
            {

            }
            return value;
        }
        #endregion

        #region Private Methods       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="by"></param>
        /// <returns></returns>
        private bool IsElementTextField(By by)
        {
            try
            {
                bool resultText = Convert.ToBoolean(driver.FindElement(by).GetAttribute("type").Equals("text"));
                bool resultPass = Convert.ToBoolean(driver.FindElement(by).GetAttribute("type").Equals("password"));
                if (resultText == true || resultPass == true)
                { return true; }
                else
                { return false; }
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="by"></param>
        /// <param name="timeToReadyElement"></param>
        /// <returns></returns>
        private IWebElement WaitforElement(By by, int timeToReadyElement = 0)
        {
            IWebElement element = null;
            try
            {
                if (timeToReadyElement != 0 && timeToReadyElement.ToString() != null)
                {
                    PlaybackWait(timeToReadyElement * 1000);
                }

                element = driver.FindElement(by);

            }
            catch
            {

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(MaxTimeToFindElement));
                wait.Until(driver => IsPageReady(driver) == true && IsElementVisible(by) == true && IsClickable(by) == true);
                element = driver.FindElement(by);
            }
            return element;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="driver"></param>
        /// <returns></returns>
        private bool IsPageReady(IWebDriver driver)
        {
            return ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="by"></param>
        /// <returns></returns>
        private bool IsElementVisible(By by)
        {
            if (driver.FindElement(by).Displayed || driver.FindElement(by).Enabled)
            {
                return true;
            }
            else
            { return false; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="by"></param>
        /// <returns></returns>
        private bool IsClickable(By by)
        {
            try
            {
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="by"></param>
        /// <returns></returns>
        private bool IsElementPresent(By by)
        {
            try
            {
                CoreFrame.driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        #endregion

    }

    #region PDF Extractor
    public class PDFExtractor
    {
        public static string ExtractTextFromPDF(string pdfFileName)
        {
            //iTextSharp
            PdfReader reader = null;
            StringBuilder result = new StringBuilder();
            using (reader = new PdfReader(pdfFileName))
            {
                for (int page = 1; page <= reader.NumberOfPages; page++)
                {
                    SimpleTextExtractionStrategy strategy =
                    new SimpleTextExtractionStrategy();
                    string pageText =
                    PdfTextExtractor.GetTextFromPage(reader, page, strategy);
                    result.Append(pageText);
                }
            }
            return result.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pdfPath"></param>
        /// <param name="regex"></param>
        /// <returns></returns>
        public static MatchCollection PDFCompareValueUsingRegrex(string pdfPath, string regex)
        {
            try
            {
                string testData = $"PDF Path: {pdfPath} <br> Report: Electronic Batch Record";
                string data = PDFExtractor.ExtractTextFromPDF(pdfPath);
                Regex expression = new Regex(regex);
                var results = expression.Matches(data);
                return results;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

    #endregion
}
