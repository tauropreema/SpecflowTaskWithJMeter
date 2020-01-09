Feature: AddEducationdetails
	In order to add profile details 
	as a Seller i need to add education details
@mytag
Scenario: check if seller could able to add education details
	Given I have clicked on Education tab
	And I have entered Education Deatils
	Then Education Details should be added.
