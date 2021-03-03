using InterviewPractice.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        Actions moveToWebSiteElement = null;
        #endregion

        #region Locator Strings
        private string AccountIconXPath
        {
            get
            {
                string xpath = "//ul[@id='nav-user-list']/li/a[@href='/account']";

                return xpath;
            }
        }

        private string WomenMenuXPath
        {
            get
            {
                string xpath = "//li[contains(@class,'women dropdown has_sub_menu')]";

                return xpath;
            }
        }

        private string MenMenuXPath
        {
            get
            {
                string xpath = "//li[contains(@class,'men dropdown has_sub_menu')][2]";

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
        private IWebElement AccountIcon
        {
            get
            {
                IWebElement element = webDriver.FindElement(By.XPath(AccountIconXPath));

                return element;
            }
        }

        private IWebElement WomenMenu
        {
            get
            {
                IWebElement element = webDriver.FindElement(By.XPath(WomenMenuXPath));

                return element;
            }
        }

        private IWebElement MenMenu
        {
            get
            {
                IWebElement element = webDriver.FindElement(By.XPath(MenMenuXPath));

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
        public void NavigateToMenAccessories()
        {
            waitMechanism.ExplicitWaitByXPath(webDriver, 30, NavBarXPath);

            moveToWebSiteElement = new Actions(webDriver);

            // Mover mouse al menu de Mens
            moveToWebSiteElement
                .MoveToElement(MenMenu)
                .Build()
                .Perform();
            Thread.Sleep((int)ScriptWaits.SmallerWait);

            MenWalletLink.Click();
            Thread.Sleep((int)ScriptWaits.SmallerWait);
        }

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
        #endregion
    }
}
