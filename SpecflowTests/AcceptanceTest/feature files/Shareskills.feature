Feature: Shareskills
	Check if the user is able to add new skill

@mytag
Scenario: Check if the user is able to add new skill
	Given I have loggined and clicked on shareskill button
	And I have entered all the data in to the fields
	When I press save
	Then the shareskill details should be added
