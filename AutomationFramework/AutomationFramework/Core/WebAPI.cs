#region Assembly System.Net.Http.Formatting, Version=5.2.7.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
#endregion
using OpenQA.Selenium;

using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System.Reflection;
using System;
using System.IO;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Android;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Data;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.Linq.Expressions;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Service;
using System.Configuration;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

namespace AutomationFramework
{
    public class WebAPI
    {
        public static string GET(string url, string urlParameter)
        {
            string URL = url;
            string urlParameters = urlParameter;

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);
            string customerJsonString = "";

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync(urlParameters).Result;

            string rss = response.ToString();

            Console.WriteLine(response.ReasonPhrase + response.RequestMessage);
            if (response.IsSuccessStatusCode)
            {
                return customerJsonString = response.Content.ReadAsStringAsync().Result;
            }

            client.Dispose();
            return customerJsonString;
        }


        public static string SearchValueFromJSON(string data, string value1, string value2)
        {
            JObject json = JObject.Parse(data);
            string rssTitle = (string)json[value1][value2];
            return rssTitle;
        }

    }
}
