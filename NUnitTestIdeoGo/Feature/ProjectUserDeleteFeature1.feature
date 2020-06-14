Feature: ProjectUserDeleteFeature1
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: popup before deleting
	Given that the creator user of the project is in the section of his team
	When ou select the delete member option
	Then a pop-up window will appear for your confirmation.
