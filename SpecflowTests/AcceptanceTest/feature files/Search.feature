Feature: Search
	In order to search profile 
	As a skill trader
	I want to search by category or subcategory

@mytag
Scenario: Check if user could able to search based on Category or Subcategory
	Given I write and clicked on the search on Profile page.
	When I enter the category or subcategory name. 
	Then the results should be displayed on the Search Page.

Scenario: Check if user could able to search based on User
	Given I write and clicked on the search on Profile page.
	When I enter the user name.
	Then the results should be displayed on the Search Page.
