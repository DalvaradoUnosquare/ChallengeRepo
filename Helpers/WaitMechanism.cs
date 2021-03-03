using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace InterviewPractice.Helpers
{
    public class WaitMechanism
    {
        #region Constructors
        private WebDriverWait webDriverWait = null;
        #endregion

        public enum ScriptWaits
		{
			SmallerWait = 2000,
			SmallWait = 3000,
			MediumWait = 5000,
			LargeWait = 8000,
			LargerWait = 12000,
			HugeWait = 150000
		}

        #region Methods
		public void ExplicitWaitByXPath(IWebDriver webDriver, int seconds, string XPath)
        {
			webDriverWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds));
			webDriverWait.Until(webElement => webDriver.FindElement(By.XPath(XPath)));
		}

		public void ExplicitWaitById(IWebDriver webDriver, int seconds, string Id)
		{
			webDriverWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds));
			webDriverWait.Until(webElement => webDriver.FindElement(By.XPath(Id)));
		}

		public void ExplicitWaitByWebElement(IWebDriver webDriver, int seconds, IWebElement element)
		{
			webDriverWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds));
			webDriverWait.Until(webElement => element);
		}

		public void ExplicitWaitElementUntilClickableByXpath(IWebDriver webDriver, int seconds, string XPath)
		{
			webDriverWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds));
			webDriverWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(XPath)));
		}

		public void ExplicitWaitElementUntilIsVisibleXpath(IWebDriver webDriver, int seconds, string XPath)
		{
			webDriverWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds));
			webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath(XPath)));
		}
		#endregion
	}
}
