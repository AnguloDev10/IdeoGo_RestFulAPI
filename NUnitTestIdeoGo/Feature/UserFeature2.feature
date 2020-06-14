Feature: UserFeature2
	

@mytag
Scenario: create account
	Given I have registered 
	When I press register
	Then my account will have been created
