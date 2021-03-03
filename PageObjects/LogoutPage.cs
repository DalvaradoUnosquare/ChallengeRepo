using System;
using OpenQA.Selenium;
using System.Threading;
using System.Configuration;
using InterviewPractice.Helpers;
using static InterviewPractice.Helpers.WaitMechanism;

namespace InterviewPractice.PageObjects
{
    public class LogoutPage
    {
        #region Constructors
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

        WaitMechanism waitMehanism = new WaitMechanism();
        #endregion

        #region GlobalVariables
        #endregion

        #region Locator Strings
        private string SignOutButtonXPath
        {
            get
            {
                string xpath = "//a[@id='sign_out']";

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
        private IWebElement SignOutButton
        {
            get
            {
                IWebElement element = webDriver.FindElement(By.XPath(SignOutButtonXPath));

                return element;
            }
        }
        #endregion

        #region Methods
        public void LogOutApp()
        {
            SignOutButton.Click();
            Thread.Sleep((int)ScriptWaits.SmallerWait);
        }

        public string GetMainPageTitle()
        {
            string pageTitle = string.Empty;

            pageTitle = webDriver.Title;

            return pageTitle;
        }
        #endregion

    }
}
