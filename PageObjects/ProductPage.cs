using InterviewPractice.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using static InterviewPractice.Helpers.WaitMechanism;

namespace InterviewPractice.PageObjects
{
    public class ProductPage
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
        SelectElement dropdownElement = null;
        #endregion

        #region Locator Strings
        private string FirstProductXPath
        {
            get
            {
                string xpath = "//div[@id='search']/div[1]/div[2]/div/span[3]/div[2]/div[2]";

                return xpath;
            }
        }

        private string FirstProductSpanXPath
        {
            get
            {
                string xpath = "//div[@id='search']/div[1]/div[2]/div/span[3]/div[2]/div[2]";

                return xpath;
            }
        }

        private string FirstProductPriceXPath
        {
            get
            {
                string xpath = "//div[@id='search']/div[1]/div[2]/div/span[3]/div[2]/div[2]/div/span//div[4]//a/span[1]/span[2]";

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
        private IWebElement FirstProduct
        {
            get
            {
                IWebElement element = webDriver.FindElement(By.XPath(FirstProductXPath));

                return element;
            }
        }

        private IWebElement FirstProductSpan
        {
            get
            {
                IWebElement element = webDriver.FindElement(By.XPath(FirstProductSpanXPath));

                return element;
            }
        }

        private IWebElement FirstProductPrice
        {
            get
            {
                IWebElement element = webDriver.FindElement(By.XPath(FirstProductPriceXPath));

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
        public bool IsProductDisplayedOnPage(string searchedProduct)
        {
            string firstProductText = string.Empty;
            bool isDisplayed = false;
            waitMechanism.ExplicitWaitByXPath(webDriver, 30, FirstProductXPath);

            firstProductText = FirstProductSpan.Text;

            if (firstProductText.Contains("\r"))
            {
                firstProductText = firstProductText.Replace("\r", " ");
                if (firstProductText.Contains("\n"))
                {
                    firstProductText = firstProductText.Replace("\n", "");
                }
            }

            if (firstProductText.ToLower().Contains(searchedProduct.ToLower()))
            {
                isDisplayed = true;
            }

            return isDisplayed;
        }

        public string GetFirstProductPrice()
        {
            string productPrice = string.Empty;

            productPrice = FirstProductPrice.Text.Length > 0 ? FirstProductPrice.Text : string.Empty;
            productPrice = Regex.Replace(productPrice, @"\s+", ".");

            return productPrice;
        }

        public void SelectFirstProduct()
        {
            FirstProductSpan.Click();
            Thread.Sleep((int)ScriptWaits.SmallWait);
        }

        //public void SelectWalletQuantity(string quantity)
        //{
        //    waitMechanism.ExplicitWaitByXPath(webDriver, 20, QuantityDropdownXPath);

        //    dropdownElement = new SelectElement(QuantityDropdown);
        //    dropdownElement.SelectByText(quantity);
        //}

        public void GetProductPageScreenShot()
        {
            // Tomando screenshot
            Screenshot image = ((ITakesScreenshot)webDriver).GetScreenshot();
            Thread.Sleep((int)ScriptWaits.MediumWait);

            // Salvando screenshot
            FileInfo file = new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"TestEvidence\ProductPage_Screenshot.png"));
            Thread.Sleep((int)ScriptWaits.SmallWait);

            image.SaveAsFile(file.ToString(), ScreenshotImageFormat.Png);
            Thread.Sleep((int)ScriptWaits.LargerWait);
        }
        #endregion
    }
}

