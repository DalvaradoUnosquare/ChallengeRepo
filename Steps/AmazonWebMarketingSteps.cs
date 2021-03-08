using TechTalk.SpecFlow;
using InterviewPractice.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using System.Text;

namespace InterviewPractice.Steps
{
    [Binding]
    public class AmazonWebMarketingSteps : FeatureSteps
    {
        #region TestCase1_LowPriority
        [Given(@"I execute the: '(.*)' to go to Amazon website with the user: '(.*)'")]
        public void GivenIExecuteTheToGoToAmazonWebsiteWithTheUser(string testCaseName, string userName)
        {
            this.LaunchBrowser(testCaseName);

            HomePage homepage = new HomePage();
            Dictionary<string, string> currentUserInfo = new Dictionary<string, string>();
            currentUserInfo = homepage.GetCurrtenUserDBInfo(userName);

            Assert.IsTrue(currentUserInfo["UserID"] != string.Empty, "Empty User Id");
            Assert.IsNotNull(Encoding.ASCII.GetBytes(currentUserInfo["Sid"]), "Null Sid");
            Assert.IsTrue(Boolean.Parse(currentUserInfo["UserType"]), "False User Type");
            Assert.IsTrue(Boolean.Parse(currentUserInfo["AuthType"]), "False Auth Type");
            Assert.IsTrue(currentUserInfo["UserName"] != string.Empty, "Empty User Name");
        }

        [Given(@"Search for a '(.*)' in the search box")]
        public void GivenSearchForAInTheSearchBox(string productToSearch)
        {
            HomePage homepage = new HomePage();
            homepage.EnterSearchProduct(productToSearch);

            homepage.GetHomePageScreenShot();


            ScenarioContext.Current["ProductToSearch"] = productToSearch;
        }

        [Given(@"Verifying the item is displayed on screen and select the first one located by storing the price")]
        public void GivenVerifyingTheItemIsDisplayedOnScreenAndSelectTheFirstOneLocatedByStoringThePrice()
        {
            string productToSearch = (string)ScenarioContext.Current["ProductToSearch"];
            
            ProductPage productPage = new ProductPage();
            Assert.IsTrue(productPage.IsProductDisplayedOnPage(productToSearch));

            productPage.GetProductPageScreenShot();

            ScenarioContext.Current["ProductPrice"] = productPage.GetFirstProductPrice();
        }

        [When(@"I click on the first result, once in the details page compare this price vs the above")]
        public void WhenIClickOnTheFirstResultOnceInTheDetailsPageCompareThisPriceVsTheAbove()
        {
            string expectedProductPrice = (string)ScenarioContext.Current["ProductPrice"];

            ProductPage productPage = new ProductPage();
            productPage.SelectFirstProduct();

            ProductDetailsPage productDetailsPage = new ProductDetailsPage();
            string actualProductPrice = productDetailsPage.GetProductDetailsPrice();

            productDetailsPage.GetProductDetailsScreenShot();

            Assert.AreEqual(expectedProductPrice, actualProductPrice, $"Expected: {expectedProductPrice} and Actual:{actualProductPrice} prices aren't equal.");
        }

        [When(@"Clicking on add to cart button")]
        public void WhenClickingOnAddToCartButton()
        {
            ProductDetailsPage productDetailsPage = new ProductDetailsPage();
            productDetailsPage.ClickAddToCartButton();

            productDetailsPage.ClickAddToCartIcon();
        }

        [When(@"I am on cart page I verify again the price of the phone and click on Proceed to Checkout button")]
        public void WhenIAmOnCartPageIVerifyAgainThePriceOfThePhoneAndClickOnProceedToCheckoutButton()
        {
            string expectedProductPrice = (string)ScenarioContext.Current["ProductPrice"];

            CartPage cartPage = new CartPage();
            string actualProductPrice = cartPage.GetAddToCartProductPrice();

            cartPage.GetCartPageScreenShot();

            Assert.AreEqual(expectedProductPrice, actualProductPrice, $"Expected: {expectedProductPrice} and Actual:{actualProductPrice} prices aren't equal.");
        }

        [Then(@"Finally delete the item")]
        public void ThenFinallyDeleteTheItem()
        {
            CartPage cartPage = new CartPage();
            cartPage.RemoveSelectedProduct();
        }
        #endregion

        #region @TestCase2_MediumPriority
        [Given(@"I run the: '(.*)' to get into Amazon website with the user: '(.*)'")]
        public void GivenIRunTheToGetIntoAmazonWebsiteWithTheUser(string testCaseName, string userName)
        {
            this.LaunchBrowser(testCaseName);

            HomePage homepage = new HomePage();
            Dictionary<string, string> currentUserInfo = new Dictionary<string, string>();
            currentUserInfo = homepage.GetCurrtenUserDBInfo(userName);

            Assert.IsTrue(currentUserInfo["UserID"] != string.Empty, "Empty User Id");
            Assert.IsNotNull(Encoding.ASCII.GetBytes(currentUserInfo["Sid"]), "Null Sid");
            Assert.IsTrue(Boolean.Parse(currentUserInfo["UserType"]), "False User Type");
            Assert.IsTrue(Boolean.Parse(currentUserInfo["AuthType"]), "False Auth Type");
            Assert.IsTrue(currentUserInfo["UserName"] != string.Empty, "Empty User Name");
        }

        [Given(@"Search for another '(.*)' in the search box")]
        public void GivenSearchForAnotherInTheSearchBox(string productToSearch)
        {
            HomePage homepage = new HomePage();
            homepage.EnterSearchProduct(productToSearch);

            homepage.GetHomePageScreenShot();

            ScenarioContext.Current["ProductToSearch"] = productToSearch;
        }

        [Given(@"Verify if the item is displayed on screen to select the first one located by storing the price")]
        public void GivenVerifyIfTheItemIsDisplayedOnScreenToSelectTheFirstOneLocatedByStoringThePrice()
        {
            string productToSearch = (string)ScenarioContext.Current["ProductToSearch"];

            ProductPage productPage = new ProductPage();
            Assert.IsTrue(productPage.IsProductDisplayedOnPage(productToSearch));

            productPage.GetProductPageScreenShot();

            ScenarioContext.Current["ProductPrice"] = productPage.GetFirstProductPrice();
        }

        [Given(@"I click on the first result, once in the details page I compare this price vs the above one")]
        public void GivenIClickOnTheFirstResultOnceInTheDetailsPageICompareThisPriceVsTheAboveOne()
        {
            string expectedProductPrice = (string)ScenarioContext.Current["ProductPrice"];

            ProductPage productPage = new ProductPage();
            productPage.SelectFirstProduct();

            ProductDetailsPage productDetailsPage = new ProductDetailsPage();
            string actualProductPrice = productDetailsPage.GetProductDetailsPrice();

            productDetailsPage.GetProductDetailsScreenShot();

            Assert.AreEqual(expectedProductPrice, actualProductPrice, $"Expected: {expectedProductPrice} and Actual:{actualProductPrice} prices aren't equal.");
        }

        [Given(@"Clicking on add to cart cart button")]
        public void GivenClickingOnAddToCartCartButton()
        {
            ProductDetailsPage productDetailsPage = new ProductDetailsPage();
            productDetailsPage.ClickAddToCartButton();

            productDetailsPage.ClickAddToCartIcon();
        }

        [When(@"Getting on Cart page and verify again the price of the phone and click on Proceed to Checkout button")]
        public void WhenGettingOnCartPageAndVerifyAgainThePriceOfThePhoneAndClickOnProceedToCheckoutButton()
        {
            string expectedProductPrice = (string)ScenarioContext.Current["ProductPrice"];

            CartPage cartPage = new CartPage();
            string actualProductPrice = cartPage.GetAddToCartProductPrice();

            cartPage.GetCartPageScreenShot();

            Assert.AreEqual(expectedProductPrice, actualProductPrice, $"Expected: {expectedProductPrice} and Actual:{actualProductPrice} prices aren't equal.");
        }

        [Then(@"I delete the item before making a charge into my account")]
        public void ThenIDeleteTheItemBeforeMakingAChargeIntoMyAccount()
        {
            CartPage cartPage = new CartPage();
            cartPage.RemoveSelectedProduct();
        }
        #endregion

        #region @TestCase3_HighPriority
        [Given(@"I need to run the: '(.*)' to go to Amazon site")]
        public void GivenINeedToRunTheToGoToAmazonSite(string testCaseName)
        {
            this.LaunchBrowser(testCaseName);
        }

        [Given(@"Locate the Hello Sign In Account & lists upper right button and click on it")]
        public void GivenLocateTheHelloSignInAccountListsUpperRightButtonAndClickOnIt()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I click on New customer\? start right here link")]
        public void WhenIClickOnNewCustomerStartRightHereLink()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"Fill the Name and Email fields with the API response")]
        public void WhenFillTheNameAndEmailFieldsWithTheAPIResponse()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"Clicking on Condition of use link")]
        public void WhenClickingOnConditionOfUseLink()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"Locate the search bar and Search for Echo")]
        public void WhenLocateTheSearchBarAndSearchForEcho()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I Locate ""(.*)"" options and click on it")]
        public void WhenILocateOptionsAndClickOnIt(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Following elements should be displayed: Getting Started, Wi-Fi and Bluetooth, Device Software and Hardware, TroubleShooting")]
        public void ThenFollowingElementsShouldBeDisplayedGettingStartedWi_FiAndBluetoothDeviceSoftwareAndHardwareTroubleShooting()
        {
            ScenarioContext.Current.Pending();
        }
        #endregion

        #region PostConditions
        [AfterFeature]
        public static void TearDown()
        {
            FeatureSteps.PostConditions();
        }
        #endregion
    }
}
