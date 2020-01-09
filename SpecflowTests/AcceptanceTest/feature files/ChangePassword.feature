Feature: Change Password
	In order to update my profile 
	As a skill trader
	I want to change my password

@mytag
Scenario: Check if user could able to change the password
	Given I clicked on the change password on Profile page
	When I add a new password
	Then that password should be changed