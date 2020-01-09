Feature: Chat
	In order to search profile 
	As a skill trader
	I want to send a chat message

@mytag
Scenario: Check if user could able to send a chat message
	Given I write and clicked on the search on Profile page
	When I enter the user name
	Then the results should be displayed on the Search Page
	And I should be able to choose a user and send a chat message