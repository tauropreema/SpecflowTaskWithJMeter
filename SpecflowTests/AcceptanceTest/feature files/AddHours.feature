Feature: AddHours
	Check if the user is able to add Hours

@mytag
Scenario: Check if the user is able to add Hours
	Given I loggined and Clicked on Hours and Hours field,added Hours
	Then the Hours should be added
	
	
