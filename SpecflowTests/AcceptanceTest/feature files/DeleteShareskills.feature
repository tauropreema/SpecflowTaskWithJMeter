Feature: DeleteShareskills
	Check if the user is able to Delete the Shareskills

@mytag
Scenario: Delete Shareskills
	Given I have Loggined and clicked on Manage Listing
	When I press Delete
	Then the Shareskill details should be deleted
	
