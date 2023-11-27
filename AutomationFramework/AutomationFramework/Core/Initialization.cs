
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Configuration;
using System.Data.OracleClient;
using System.Data.SqlClient;
using OracleCommand = Oracle.ManagedDataAccess.Client.OracleCommand;
using OracleConnection = Oracle.ManagedDataAccess.Client.OracleConnection;
using OracleDataReader = Oracle.ManagedDataAccess.Client.OracleDataReader;

namespace AutomationFramework
{
    public class Initialization : CoreFrame
    {
        #region Properties
        public static string host = ConfigurationManager.AppSettings["Host"].ToString();
        public static string port = ConfigurationManager.AppSettings["Port"].ToString();
        public static string serviceName = ConfigurationManager.AppSettings["ServiceName"].ToString();
        public static string dbUser = ConfigurationManager.AppSettings["DBUserName"].ToString();
        public static string dbPass = ConfigurationManager.AppSettings["DBPassword"].ToString();

        public static string connectionString = ConfigurationManager.AppSettings["MSSqlConnectString"].ToString();

        public static SqlConnection MSSQLConnection { get; set; }
        public static OracleConnection orcl = null;

        #region Android Device Properties
        public static string DeviceName = ConfigurationManager.AppSettings["DeviceName"].ToString();
        public static string Platform = ConfigurationManager.AppSettings["Platform"].ToString();
        public static string Version = ConfigurationManager.AppSettings["Version"].ToString();
        public static string DeviceBrowser = ConfigurationManager.AppSettings["DeviceBrowser"].ToString();
        public static string UDID = ConfigurationManager.AppSettings["UDID"].ToString();
        public static string AppPackage = ConfigurationManager.AppSettings["AppPackage"].ToString();
        public static string AppActivity = ConfigurationManager.AppSettings["AppActivity"].ToString();
        #endregion

        #endregion

        #region SELENIUM CONNECTION
        public static void SeleniumInit()
        {

            #region Edge
            if (ExecutionBrowser == Browser.MicrosoftEdge)
            {
                try
                {
                    var options = new OpenQA.Selenium.Edge.EdgeOptions();
                    var service = EdgeDriverService.CreateDefaultService(@"C:\Users\imammami\source\repos\FrameworkDemo\bin\Debug\", @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe");
                    service.Start();


                    // For future reference - please check to see if there are options that should be set...

                    driver = new RemoteWebDriver(service.ServiceUrl, options);

                }
                catch (Exception ex)
                {
                }

            }
            #endregion

            #region IE
            else if (ExecutionBrowser == Browser.IE)
            {


            }
            #endregion

            #region Firefox
            else if (ExecutionBrowser == Browser.FireFox)
            {

                if (HeadlessExecution)
                {
                    FirefoxOptions options = new FirefoxOptions();
                    options.AddArguments("--headless");
                    driver = new FirefoxDriver(options);

                }
                else
                {
                    driver = new FirefoxDriver();
                }
            }
            #endregion

            #region Chrome
            else if (ExecutionBrowser == Browser.Chrome)
            {
                try
                {
                    if (HeadlessExecution == true)
                    {
                        var chromeOptions = new ChromeOptions();
                        chromeOptions.AddArguments("headless");
                        chromeOptions.AddArguments("--incognito");
                        chromeOptions.AddArgument("--start-maximized");
                        driver = new ChromeDriver(chromeOptions);
                    }
                    else
                    {
                        var chromeOptions = new ChromeOptions();
                        chromeOptions.AddArguments("--incognito");
                        chromeOptions.AddArgument("--start-maximized");
                        driver = new ChromeDriver(chromeOptions);
                    }
                }
                catch (Exception ex)
                {
                    // Logger.Fatal(ExecutionBrowser + " Driver is Initializing.", "Driver should be Initialized.", "Driver Initialization Failed: " + ex.ToString() + "");
                }
            }
            #endregion

            #region Android
            else if (ExecutionBrowser == Browser.Android)
            {
                AppiumOptions capabilities = new AppiumOptions();
                capabilities.AddAdditionalCapability(Keywords.DeviceName, DeviceName);
                capabilities.AddAdditionalCapability(Keywords.Udid, UDID);
                capabilities.AddAdditionalCapability(Keywords.PlatformVersion, Version);
                capabilities.AddAdditionalCapability(Keywords.PlatformName, Platform);
                if (DeviceBrowser != string.Empty)
                {
                    capabilities.AddAdditionalCapability(Keywords.BrowserName, DeviceBrowser);
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.UseSpecCompliantProtocol = false;
                    capabilities.GetMergeResult(chromeOptions);
                }
                else
                {
                    capabilities.AddAdditionalCapability(Keywords.AppPackage, AppPackage);
                    capabilities.AddAdditionalCapability(Keywords.AppActivity, AppActivity);
                }
                //driver = new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723/wd/hub"), capabilities);
            }
            #endregion

        }

        public static void CloseSelenium()
        {
            driver.Close();
            driver.Dispose();
            driver.Quit();
        }
        #endregion

        #region MSSQL CONNECTION
        public static SqlConnection MSSQLConnect()
        {
            //string connectionString = null;
            SqlConnection connection;
            // connectionString = @"Data Source="+host+";Initial Catalog="+dbName+"; Integrated Security=SSPI; User ID="+dbUser+"; Password="+dbPass;
            connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
            }
            catch (Exception)
            {
                // MessageBox.Show("Cannot open Database Connection(MSSQL)! " + ex);
            }

            return connection;
        }
        public static void CloseSQLDBConnection(SqlConnection conn)
        {
            if (conn != null)
            {
                conn.Close();
                conn.Dispose();
            }
        }
        #endregion

        #region ORACLE CONNECTION
        public static OracleConnection OracleDBConnect()
        {
            OracleConnection conn = null;
            try
            {
                string oradb = "Data Source=(DESCRIPTION="
                             + "(ADDRESS=(PROTOCOL=TCP)(HOST=" + host + ")(PORT=" + port + "))"
                             + "(CONNECT_DATA=(SERVICE_NAME=" + serviceName + ")));"
                             + "User Id=" + dbUser + ";Password=" + dbPass + ";";

                conn = new OracleConnection(oradb);
                conn.Open();
            }

            catch (Exception ex)
            {
                // string testData = $"Host: {host} <br> Port: {port} <br> ServiceName: {serviceName} <br> DB User ID: {dbUser} <br> DB Password: {dbPass} <br>";
                // Logger.Failed("Oracle Database is connecting.", "Oracle database should be connected", testData + ex.ToString());
            }
            return conn;
        }
        public static string ExecuteOracleQuery(OracleConnection conn, string dbQuery)
        {
            OracleDataReader odr = null;
            try
            {
                string sql = dbQuery;
                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.ExecuteNonQuery();
                //    odr = cmd.ExecuteReader();
                //    odr.Read();
                //}
            }
            catch (Exception ex)
            {
                string testData = $"SQL Query: {dbQuery}";
                // Logger.Info("Sql Query is executing.", "Sql Query should be executed", testData + ex.ToString());
            }

            return odr.ToString();
        }
        public static void CloseOracleDBConnection(OracleConnection conn)
        {
            if (conn != null)
            {
                conn.Close();
                conn.Dispose();
            }
        }
        #endregion

        /// <summary>
        /// 1. Install JDK 8 and set Environemnt Variables (JAVA_HOME>Path of JDK, Path>JDK bin Path; ANDROID_HOME> sdk path)
        /// 2. Install Android Studio
        /// 3. Install Appium
        /// 4. Create a virtual device using Andoird Device Manager(Android Sudio>Tool>AVD Manager)
        /// 5. power shell > adb devices
        /// </summary>
        public static void AndroidConnection()
        {

        }

        public static void TestCleanup()
        {
            driver.Quit();
        }

    }
}
