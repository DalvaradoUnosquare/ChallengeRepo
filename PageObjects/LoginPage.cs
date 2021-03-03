using System;
using OpenQA.Selenium;
using System.Threading;
using System.Configuration;
using InterviewPractice.Helpers;
using static InterviewPractice.Helpers.WaitMechanism;
using System.Drawing.Imaging;
using System.IO;

namespace InterviewPractice.PageObjects
{
    public class LoginPage
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

        private string EmailTextFieldXPath
        {
            get
            {
                string xpath = "//input[@id='customer_email']";

                return xpath;
            }
        }

        private string PasswordTextFieldXPath
        {
            get
            {
                string xpath = "//input[@id='customer_password']";

                return xpath;
            }
        }

        private string SignInButtonXPath
        {
            get
            {
                string xpath = "//input[@value='Sign In']";

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

        private IWebElement EmailTextField
        {
            get
            {
                IWebElement element = webDriver.FindElement(By.XPath(EmailTextFieldXPath));

                return element;
            }
        }

        private IWebElement PasswordTextField
        {
            get
            {
                IWebElement element = webDriver.FindElement(By.XPath(PasswordTextFieldXPath));

                return element;
            }
        }

        private IWebElement SignInButton
        {
            get
            {
                IWebElement element = webDriver.FindElement(By.XPath(SignInButtonXPath));

                return element;
            }
        }
        #endregion

        #region Methods
        public void LoginToApp(string username, string password)
        {
            AccountIcon.Click();
            Thread.Sleep((int)ScriptWaits.SmallerWait);

            EmailTextField.Clear();
            EmailTextField.SendKeys(username);

            PasswordTextField.Clear();
            PasswordTextField.SendKeys(password);

            SignInButton.Click();

            waitMechanism.ExplicitWaitByXPath(webDriver, 20, NavBarXPath);
        }

        public string GetHomePageTitle()
        {
            string pageTitle = string.Empty;

            pageTitle = webDriver.Title;
            Thread.Sleep((int)ScriptWaits.SmallWait);

            return pageTitle;
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
