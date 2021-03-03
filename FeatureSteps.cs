using System.Threading;
using TechTalk.SpecFlow;
using System.Configuration;
using InterviewPractice.Helpers;
using InterviewPractice.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static InterviewPractice.Helpers.WaitMechanism;

// Namespace se refiere a las collecciones de clases
namespace InterviewPractice 
{
    [Binding]
    // Abstracta ya sólo se va a utilizar como una clase base
    public abstract class FeatureSteps
    {
        protected string siteURL = ConfigurationManager.AppSettings["SiteUrl"];
        protected static bool ExecutedAfterFeature { get; set; }


        protected void LogIntoApplication(string username, string password)
        {
            string currentPageTitle = string.Empty;
            ExecutedAfterFeature = false;

            // Lanzando Browser
            BrowserManager browserManager = new BrowserManager();
            currentPageTitle = browserManager.InitializeBrowser(siteURL);
            Assert.IsTrue(currentPageTitle != string.Empty, "The browser wasn't launched correctly");

            // Login
            LoginPage loginPage = new LoginPage();
            loginPage.LoginToApp(username, password);
            Assert.IsTrue(currentPageTitle != string.Empty, "The browser wasn't launched correctly");
        }

        protected void SwitchToAppOriginalTab()
        {
            BrowserManager.SwitchToOriginalTab();
            Thread.Sleep((int)ScriptWaits.SmallWait);
        }

        protected void SwitchToAppOriginalWindow()
        {
            BrowserManager.SwitchToOriginalWindow();
            Thread.Sleep((int)ScriptWaits.SmallWait);
        }

        [AfterFeature]
        public static void PostConditions()
        {
            if (!ExecutedAfterFeature)
            {
                BrowserManager.FinalizeBrowser();
                ExecutedAfterFeature = true;
            }
        }
    }
}
