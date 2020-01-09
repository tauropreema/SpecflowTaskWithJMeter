Feature: DeleteEducationDetails
	DeleteEducationdetailsandValidate
	As a Seller i should be able to 
	delete the education details 

@mytag
Scenario:DeleteEducationdetailsandValidate
	Given I have clicked on Education details which is present under the profile
	When I press delete
	Then the education details should be deleted
