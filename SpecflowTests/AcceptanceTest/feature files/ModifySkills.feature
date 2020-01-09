Feature: ModifySkills
	In order to Update the profile 
	as a seller i need to modify the skill details

@mytag
Scenario: As a Seller I can able to modify the skill details in the profile section
	Given I have clicked on the skill Details under the profle section
	And I have modified already existing skill data 
	When When I Press add
	Then Then the Modified data should be listed in skills details.
