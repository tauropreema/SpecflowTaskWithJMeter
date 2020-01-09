Feature: DeleteSkillsDetails
	As a Seller i should be able to 
	delete the skills details 


@mytag
Scenario: DeleteskilldetailsandValidate
	Given I have clicked on skills details which is present under the profile
	When I click on delete
	Then the skill details should be deleted
