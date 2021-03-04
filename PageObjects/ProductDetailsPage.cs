using InterviewPractice.Helpers;
using OpenQA.Selenium;
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
    public class ProductDetailsPage
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

        #region Locator Strings
        private string ProductPriceXPath
        {
            get
            {
                string xpath = "//span[@id='priceblock_ourprice']";

                return xpath;
            }
        }

        private string AddToCartButtonXPath
        {
            get
            {
                string xpath = "//input[@id='add-to-cart-button']";

                return xpath;
            }
        }

        private string AddToCartIconXPath
        {
            get
            {
                string xpath = "//span[@id='nav-cart-count']";

                return xpath;
            }
        }

        private string ClosetIconXPath
        {
            get
            {
                string xpath = "//a[@id='attach-close_sideSheet-link']";

                return xpath;
            }
        }
        #endregion

        #region Objects
        private IWebElement ProductPrice
        {
            get
            {
                IWebElement element = webDriver.FindElement(By.XPath(ProductPriceXPath));

                return element;
            }
        }

        private IWebElement AddToCartButton
        {
            get
            {
                IWebElement element = webDriver.FindElement(By.XPath(AddToCartButtonXPath));

                return element;
            }
        }

        private IWebElement AddToCartIcon
        {
            get
            {
                IWebElement element = webDriver.FindElement(By.XPath(AddToCartIconXPath));

                return element;
            }
        }

        private IWebElement ClosetIcon
        {
            get
            {
                IWebElement element = null;

                if (webDriver.FindElements(By.XPath(ClosetIconXPath)).Count > 0)
                {
                    element = webDriver.FindElement(By.XPath(ClosetIconXPath));
                }

                return element;
            }
        }
        #endregion

        #region Methods
        public string GetProductDetailsPrice()
        {
            string productPrice = string.Empty;

            productPrice = ProductPrice.Text.Length > 0 ? ProductPrice.Text : string.Empty;

            return productPrice;
        }

        public void ClickAddToCartButton()
        {
            AddToCartButton.Click();
            Thread.Sleep((int)ScriptWaits.SmallWait);
        }

        public void ClickAddToCartIcon()
        {
            if (ClosetIcon != null)
            {
                ClosetIcon.Click();
            }

            AddToCartIcon.Click();
            Thread.Sleep((int)ScriptWaits.SmallWait);
        }

        public void GetProductDetailsScreenShot()
        {
            // Tomando screenshot
            Screenshot image = ((ITakesScreenshot)webDriver).GetScreenshot();
            Thread.Sleep((int)ScriptWaits.MediumWait);

            // Salvando screenshot
            FileInfo file = new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"TestEvidence\ProductDetailsPage_Screenshot.png"));
            Thread.Sleep((int)ScriptWaits.SmallWait);

            image.SaveAsFile(file.ToString(), ScreenshotImageFormat.Png);
            Thread.Sleep((int)ScriptWaits.LargerWait);
        }
        #endregion
    }
}
