Feature: Project
	
As a user I want to add a my password and email 

@mytag
Scenario: Create password and email
	Given I have entered my password  to register 
	And I have entered my email  to register
	
	When I press register
	Then  the user should be created
