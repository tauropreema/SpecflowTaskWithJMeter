Feature: Add Description
	In order to update my profile 
	As a skill trader
	I want to add the Description

@mytag
Scenario: Check if user could able to add a description
	Given I clicked on the Add description icon on Profile page
	When I add a description
	Then that description should be added 