Feature: AddEarnTaget
	Check if the user is able add EarnTarget

@mytag
Scenario: AddEarnTarget
	Given I loggined and Clicked on EarnTarget and EarnTarget field,added EarnTarget
	Then the EarnTarget should be added
