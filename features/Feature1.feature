Feature: Feature1

A short summary of the feature

@smoke_test
Scenario: Get by Id
	Given I have a valid number 200
	When I send Get request to server
	Then Expect a valid record response

