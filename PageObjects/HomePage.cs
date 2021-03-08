using InterviewPractice.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static InterviewPractice.Helpers.WaitMechanism;

namespace InterviewPractice.PageObjects
{
    public class HomePage
    {
        // Declarando constructor con parametro desde clase WebDriverInstantiator utilizando Configuration Manager Config
        #region Constructors
        public static IWebDriver webDriver =
            WebDriverInstantiator
                .GetInstance(
                    (WebDriverInstantiator.WebDriverBrowsers)
                        Enum.Parse
                        (
                            typeof(WebDriverInstantiator.WebDriverBrowsers),
                            ConfigurationManager.AppSettings["BrowserDriver"]
                         )
                );

        WaitMechanism waitMechanism = new WaitMechanism();
        #endregion

        #region GlobalVariables
        private const string currentUserNameVariable = "@CurrenUserNameVariable";
        Actions moveToWebSiteElement = null;
        #endregion

        #region Locator Strings
        private string AmazonLogoXPath
        {
            get
            {
                string xpath = "//a[@id='nav-logo-sprites']";

                return xpath;
            }
        }

        private string AmazonSearchboxXPath
        {
            get
            {
                string xpath = "//input[@id='twotabsearchtextbox']";

                return xpath;
            }
        }

        private string MagnyfiyngGlassXPath
        {
            get
            {
                string xpath = "//input[@id='nav-search-submit-button']";

                return xpath;
            }
        }

        private string MenWalletLinkXPath
        {
            get
            {
                string xpath = "//ul[@id='nav-menu-desktop-list']//li[3]//li/a[text()='Wallets']";

                return xpath;
            }
        }

        private string BestSellersMenuXPath
        {
            get
            {
                string xpath = "//ul[@id='nav-menu-desktop-list']/li/a[text()='Bestsellers']";

                return xpath;
            }
        }

        private string SaleMenuXPath
        {
            get
            {
                string xpath = "//ul[@id='nav-menu-desktop-list']/li/a[text()='Sale']";

                return xpath;
            }
        }

        private string NavBarXPath
        {
            get
            {
                string xpath = "//header[@id='nav-bar-wrapper']";

                return xpath;
            }
        }
        #endregion

        #region Objects
        private IWebElement AmazonLogo
        {
            get
            {
                IWebElement element = webDriver.FindElement(By.XPath(AmazonLogoXPath));

                return element;
            }
        }

        private IWebElement AmazonSearchbox
        {
            get
            {
                IWebElement element = webDriver.FindElement(By.XPath(AmazonSearchboxXPath));

                return element;
            }
        }

        private IWebElement MagnyfiyngGlass
        {
            get
            {
                IWebElement element = webDriver.FindElement(By.XPath(MagnyfiyngGlassXPath));

                return element;
            }
        }

        private IWebElement MenWalletLink
        {
            get
            {
                IWebElement element = webDriver.FindElement(By.XPath(MenWalletLinkXPath));

                return element;
            }
        }

        private IWebElement BestSellersMenu
        {
            get
            {
                IWebElement element = webDriver.FindElement(By.XPath(BestSellersMenuXPath));

                return element;
            }
        }

        private IWebElement SaleMenu
        {
            get
            {
                IWebElement element = webDriver.FindElement(By.XPath(SaleMenuXPath));

                return element;
            }
        }
        #endregion

        #region Methods
        public void EnterSearchProduct(string productToSearch)
        {
            waitMechanism.ExplicitWaitByXPath(webDriver, 30, AmazonLogoXPath);

            AmazonSearchbox.SendKeys(productToSearch);
            Thread.Sleep((int)ScriptWaits.SmallWait);

            MagnyfiyngGlass.Click();
        }

        //public void NavigateToMenAccessories()
        //{
        //    waitMechanism.ExplicitWaitByXPath(webDriver, 30, NavBarXPath);

        //    moveToWebSiteElement = new Actions(webDriver);

        //    // Mover mouse al menu de Mens
        //    moveToWebSiteElement
        //        .MoveToElement(MenMenu)
        //        .Build()
        //        .Perform();
        //    Thread.Sleep((int)ScriptWaits.SmallerWait);

        //    MenWalletLink.Click();
        //    Thread.Sleep((int)ScriptWaits.SmallerWait);
        //}

        public void GetHomePageScreenShot()
        {
            // Tomando screenshot
            Screenshot image = ((ITakesScreenshot)webDriver).GetScreenshot();
            Thread.Sleep((int)ScriptWaits.MediumWait);

            // Salvando screenshot
            FileInfo file = new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"TestEvidence\HomePage_Screenshot.png"));
            Thread.Sleep((int)ScriptWaits.SmallWait);

            image.SaveAsFile(file.ToString(), ScreenshotImageFormat.Png);
            Thread.Sleep((int)ScriptWaits.LargerWait);
        }

        public Dictionary<string, string> GetCurrtenUserDBInfo(string currentUserName)
        {
            Dictionary<string, string> agencyGroupExcludedTestDBInfoList = new Dictionary<string, string>();

            //Create Connection String
            string sConn = "TestDataSetUp.Properties.Settings.constr";
            FileInfo file = new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Helpers\DBQueries\users.sql"));

            //Get the script text
            string script = file.OpenText().ReadToEnd();

            //Replace the donorId variable
            script = script.Replace(currentUserNameVariable, currentUserName);

            script = script.Replace("GO", "");
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[sConn];

            using (SqlConnection conn = new SqlConnection(settings.ConnectionString))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    //Opening Connection
                    conn.Open();
                    Thread.Sleep((int)ScriptWaits.LargerWait);

                    //Setting Command to execute
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    //Creating Commands
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = script;

                    //Executing Commands
                    DbDataReader dataReader = cmd.ExecuteReader();

                    //Getting Table Values
                    while (dataReader.Read())
                    {
                        agencyGroupExcludedTestDBInfoList.Add("UserID", Convert.ToString(dataReader.GetValue(dataReader.GetOrdinal("UserID"))));
                        agencyGroupExcludedTestDBInfoList.Add("Sid", Convert.ToString(dataReader.GetValue(dataReader.GetOrdinal("Sid"))));
                        agencyGroupExcludedTestDBInfoList.Add("UserType", Convert.ToBoolean(dataReader.GetValue(dataReader.GetOrdinal("UserType"))).ToString());
                        agencyGroupExcludedTestDBInfoList.Add("AuthType", Convert.ToBoolean(dataReader.GetValue(dataReader.GetOrdinal("AuthType"))).ToString());
                        agencyGroupExcludedTestDBInfoList.Add("UserName", Convert.ToString(dataReader.GetValue(dataReader.GetOrdinal("UserName"))));
                    }

                    //Closing Connection
                    conn.Dispose();
                }
            }

            return agencyGroupExcludedTestDBInfoList;
        }
        #endregion
    }
}
