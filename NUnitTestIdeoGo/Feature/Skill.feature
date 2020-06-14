Feature: Skill
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Get list of skills
	Given I have selected skills
	When I press skills
	Then I get the whole list of skills to choose
