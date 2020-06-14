Feature: ProjectScheduleFeature1
	

@mytag
Scenario: see the schedule of my project
	
	Given I have  selected my project
	When I press see schedule
	Then I get the  specific schedule of my project
