Feature: AddSkill
	In order to Update the profile 
	as a seller i need to add the skill details under profile section

@mytag
Scenario: As a seller i should be able to add the skill details under profile
	Given I have clicked on skill tab under profile
	And I have clicked on add new and entered details
	When I click on add
	Then I should be able to add skill details
