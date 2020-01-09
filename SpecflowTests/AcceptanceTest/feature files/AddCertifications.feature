Feature: AddCertifications
	In order to add profile details 
	as a Seller i need to add Certification details

@mytag
Scenario: check if seller could able to add certification details
	Given I have clicked on Certification tab under profile 
	And I have clicked on add new and given details 
	When I press add
	Then i should me able to add certification details
