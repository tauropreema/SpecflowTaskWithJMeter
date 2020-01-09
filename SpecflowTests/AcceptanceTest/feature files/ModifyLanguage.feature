Feature: ModifyLanguage
	In order to Update the profile 
	as a seller i need to modify the Language details under profile

@mytag
Scenario: As a Seller I should be able to modify the Language details in the profile section
	Given I have clicked on language tab under profile section
	And i have modified language details
	When I click on Update button
	Then i should be able to update the language details
