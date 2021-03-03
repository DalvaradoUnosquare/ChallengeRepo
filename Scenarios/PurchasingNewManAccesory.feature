Feature: PurchasingNewManAccesory
	In order choose the correct product within site
	As an american average consumer
	I want to make the correct purchase testing my CC 

@QA_Practice1
Scenario: Login to Account
	Given I login into the app by entering my given email: 'automation_tester@testingmail.com' and password: 'Automated2021#'
	When Only verifying that I'm just logged in
	Then I log out myself to remove my credentials from the textfields to avoid future frauds