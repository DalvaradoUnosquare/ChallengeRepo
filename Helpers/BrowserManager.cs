using System;
using System.IO;
using System.Linq;
using OpenQA.Selenium;
using NUnit.Framework;
using TechTalk.SpecFlow;
using System.Configuration;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace InterviewPractice.Helpers
{
    [Binding]
    public class BrowserManager
    {
        // Declarando constructor con parametro desde clase WebDriverInstantiator utilizando Configuration Manager Config
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

        ExtentTest test = null;

        #region Methods
        public string InitializeBrowser(string siteUrl, string testCaseName)
        {
            string baseURL = siteUrl;
            string landingPageTitle = string.Empty;

            ExtentReports extent = new ExtentReports();
            test = extent.CreateTest(testCaseName).Info("Test Started");
            webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            webDriver.Manage().Window.Maximize();
            webDriver.Manage().Cookies.DeleteAllCookies();
            webDriver.Navigate().GoToUrl(baseURL);
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            landingPageTitle = webDriver.Title;
            test.Log(Status.Info, "Chrome Browser Launched");
            test.Log(Status.Pass);

            return landingPageTitle;
        }

        public string InitializeBrowser(string siteUrl)
        {
            string baseURL = siteUrl;
            string landingPageTitle = string.Empty;

            webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            webDriver.Manage().Window.Maximize();
            webDriver.Manage().Cookies.DeleteAllCookies();
            webDriver.Navigate().GoToUrl(baseURL);
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            landingPageTitle = webDriver.Title;

            return landingPageTitle;
        }

        public static void SwitchToOriginalTab()
        {
            webDriver.SwitchTo().Window(webDriver.WindowHandles.First());
            webDriver.SwitchTo().Window(webDriver.CurrentWindowHandle);
        }

        public static void SwitchToOriginalWindow()
        {
            webDriver.SwitchTo().Window(webDriver.WindowHandles.First());
            webDriver.SwitchTo().Window(webDriver.CurrentWindowHandle);
        }

        public static void FinalizeBrowser()
        {
            WebDriverInstantiator.DisposeWebDriver();
            webDriver = null;
        }

        #endregion
    }
}
