Feature: Project
	
As an entrepreneur, I want to list all the users of my project

@mytag
Scenario: list user of my project
	Given  I have selected my project
	
	When  I press search for users
	Then  I get the whole list of users the  my project
