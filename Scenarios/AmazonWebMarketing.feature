Feature: AmazonWebMarketing
	In order choose the correct product within site
	As an american average consumer
	I want to make the correct verifications in Amazon website 

@TestCase1_LowPriority
Scenario: Samsung Galaxy Note 20 Price Compare Verification
	Given I execute the: 'TestCase1' to go to Amazon website with the user: 'Administrators'
	And Search for a 'Samsung Galaxy Note 20' in the search box
	And Verifying the item is displayed on screen and select the first one located by storing the price
	When I click on the first result, once in the details page compare this price vs the above
	And Clicking on add to cart button
	When I am on cart page I verify again the price of the phone and click on Proceed to Checkout button
	Then Finally delete the item

@TestCase2_MediumPriority
Scenario: Samsung Galaxy FE 5G Price Compare Verification
	Given I run the: 'TestCase2' to get into Amazon website
	And Search for another 'Samsung Galaxy S20 FE 5G' in the search box
	And Verify if the item is displayed on screen to select the first one located by storing the price
	And I click on the first result, once in the details page I compare this price vs the above one
	And Clicking on add to cart cart button
	When Getting on Cart page and verify again the price of the phone and click on Proceed to Checkout button
	Then I delete the item before making a charge into my account

@TestCase3_HighPriority
Scenario: New Customer Registration
	Given I need to run the: 'TestCase3' to go to Amazon site
	And Locate the Hello Sign In Account & lists upper right button and click on it
	When I click on New customer? start right here link
	And Fill the Name and Email fields with the API response
	And Clicking on Condition of use link
	And Locate the search bar and Search for Echo
	When I Locate "Echo support" options and click on it
	Then Following elements should be displayed: Getting Started, Wi-Fi and Bluetooth, Device Software and Hardware, TroubleShooting 