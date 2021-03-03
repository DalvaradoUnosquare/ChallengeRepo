using System;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace InterviewPractice.Helpers
{
    [Binding]
    public class WebDriverInstantiator
    {
        #region Constructors
        // Declarando Constructores
        public static IWebDriver webDriver;
        #endregion

        public enum WebDriverBrowsers
        {
            Chrome,
            ChromeIncognito,
            Firefox,
            InternetExplorer,
        }

        #region Methods
        // Instanciando WebDriver
        public static IWebDriver GetInstance(WebDriverBrowsers browser)
        {
            if (webDriver == null)
            {
                switch (browser)
                {
                    case WebDriverBrowsers.Chrome:
                        webDriver = new ChromeDriver();
                        //WebDriverInstantiator.webDriver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), new ChromeOptions(), TimeSpan.FromSeconds(120));
                        break;

                    case WebDriverBrowsers.ChromeIncognito:
                        ChromeOptions options = new ChromeOptions();
                        options.AddArguments("--incognito");
                        webDriver = new ChromeDriver(options);
                        break;

                    case WebDriverBrowsers.Firefox:
                        webDriver = new FirefoxDriver();
                        break;

                    case WebDriverBrowsers.InternetExplorer:
                        webDriver = new InternetExplorerDriver();
                        break;

                    default:
                        throw new NotImplementedException($"Webdriver Browser ({ browser.ToString() }) instanciation not implemented");
                }
            }

            return webDriver;
        }

        // Cerrando WebDriver
        public static void DisposeWebDriver()
        {
            if (webDriver != null)
            {
                webDriver.Quit();
                webDriver.Dispose();
                webDriver = null;
            }
        }
        #endregion
    }
}
