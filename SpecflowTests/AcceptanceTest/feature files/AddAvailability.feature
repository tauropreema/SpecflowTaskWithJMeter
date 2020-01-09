Feature: AddAvailability
	Check if the User is able to add Availability in the skillswap.

@mytag
Scenario: AddAvailability
	Given I have loggined and Clicked on Availability
	And I have Added Availability
	Then the Availability should be added
	
