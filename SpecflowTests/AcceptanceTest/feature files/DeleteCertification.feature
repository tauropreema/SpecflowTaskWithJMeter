Feature: DeleteCertification
	Delete Certificationdetails and Validate
	As a Seller i should be able to 
	delete the certification details 

@mytag
Scenario: Delete certification detailsandValidate
	Given I have clicked on certification details which is present under the profile
	When I press delete certication button
	Then the certification details should be deleted
