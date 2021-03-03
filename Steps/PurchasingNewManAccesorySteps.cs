using TechTalk.SpecFlow;
using InterviewPractice.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InterviewPractice.Steps
{
    [Binding]
    public class PurchasingNewManAccesorySteps : FeatureSteps
    {
        [Given(@"I login into the app by entering my given email: '(.*)' and password: '(.*)'")]
        public void GivenILoginIntoTheAppByEnteringMyGivenEmailAndPassword(string username, string password)
        {
            this.LogIntoApplication(username, password);
        }

        [When(@"Only verifying that I'm just logged in")]
        public void WhenOnlyVerifyingThatIMJustLoggedIn()
        {
            LoginPage loginPage = new LoginPage();
            Assert.IsTrue(loginPage.GetHomePageTitle() != string.Empty);

            loginPage.GetHomePageScreenShot();
        }
        
        [Then(@"I log out myself to remove my credentials from the textfields to avoid future frauds")]
        public void ThenILogOutMyselfToRemoveMyCredentialsFromTheTextfieldsToAvoidFutureFrauds()
        {
            LogoutPage logoutPage = new LogoutPage();
            logoutPage.LogOutApp();
            Assert.IsTrue(logoutPage.GetMainPageTitle() != string.Empty);
        }

        #region PostConditions
        [AfterFeature]
        public static void TearDown()
        {
            FeatureSteps.PostConditions();
        }
        #endregion
    }
}
