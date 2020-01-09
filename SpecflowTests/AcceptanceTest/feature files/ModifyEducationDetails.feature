Feature: ModifyEducationDetails
	In order to Update the profile 
	as a seller i need to modify the education details
@mytag
Scenario: As a Seller I can able to modify the education details in the profile section
	Given I have clicked on the Education Details under the profle section
	And I have modified already existing data 
	When I Press add
	Then the Modified data should be listed in education details.
