Feature: EditShareSkill
	Check if the user is able to Edit the shareskills

@mytag
Scenario: Edit the ShareSkill
	Given I have Loggined and Clicked on manage listing
	And I have Clicked on Edit and Edited details
	When I press Save
	Then the Shareskills should be added
