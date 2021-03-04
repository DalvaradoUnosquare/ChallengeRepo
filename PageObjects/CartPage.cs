using InterviewPractice.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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
    public class CartPage
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
                string xpath = "//span[@id='sc-subtotal-amount-buybox']/span";

                return xpath;
            }
        }

        private string ProceedToCheckoutButtonXPath
        {
            get
            {
                string xpath = "//input[@name='proceedToRetailCheckout']";

                return xpath;
            }
        }

        private string QuantityDropdownXPath
        {
            get
            {
                string xpath = "//span[@id='a-autoid-0-announce']";

                return xpath;
            }
        }

        private string QuantityDropdownRemoveOptionXPath
        {
            get
            {
                string xpath = "//a[@id='dropdown1_0']";

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

        private IWebElement ProceedToCheckoutButton
        {
            get
            {
                IWebElement element = webDriver.FindElement(By.XPath(ProceedToCheckoutButtonXPath));

                return element;
            }
        }

        private IWebElement QuantityDropdown
        {
            get
            {
                IWebElement element = webDriver.FindElement(By.XPath(QuantityDropdownXPath));

                return element;
            }
        }

        private IWebElement QuantityDropdownRemoveOption
        {
            get
            {
                IWebElement element = webDriver.FindElement(By.XPath(QuantityDropdownRemoveOptionXPath));

                return element;
            }
        }
        #endregion

        #region Methods
        public string GetAddToCartProductPrice()
        {
            string productPrice = string.Empty;

            productPrice = ProductPrice.Text.Length > 0 ? ProductPrice.Text : string.Empty;

            return productPrice;
        }

        public void RemoveSelectedProduct()
        {
            waitMechanism.ExplicitWaitByXPath(webDriver, 20, QuantityDropdownXPath);

            QuantityDropdown.Click();
            Thread.Sleep((int)ScriptWaits.SmallWait);

            QuantityDropdownRemoveOption.Click();
        }

        public void GetCartPageScreenShot()
        {
            // Tomando screenshot
            Screenshot image = ((ITakesScreenshot)webDriver).GetScreenshot();
            Thread.Sleep((int)ScriptWaits.MediumWait);

            // Salvando screenshot
            FileInfo file = new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"TestEvidence\CartPage_Screenshot.png"));
            Thread.Sleep((int)ScriptWaits.SmallWait);

            image.SaveAsFile(file.ToString(), ScreenshotImageFormat.Png);
            Thread.Sleep((int)ScriptWaits.LargerWait);
        }
        #endregion
    }
}
