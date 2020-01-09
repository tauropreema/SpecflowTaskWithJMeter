Feature: ModifyCertification
	In order to Update the profile 
	as a seller i need to modify the Certification details

@mytag
Scenario:  As a Seller I can able to modify the Certification details in the profile section
	Given I have clicked on the Certification Details under the profle section
	And I have modified already existing cerification data 
	When I Press add button
	Then the Modified data should be listed in Certification details.
