Feature: Test
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario: Test Scenario 1
	Given The user navigates to website
	And The user logs in as a broker
	And The user selects product 'Terror' and scheme 'Terror 24'
	And The user completes the Insured Details region
		| Insured Type | Insured Name | Choose Insured                                                |
		| Corporate    | Test         | Test Partners, Centurion House London Road, STAINES, TW18 4AX |
	And The user completes the Policy Details region
		| QuotableCoverage1    |
		| Property Damage Only |
	And The user saves the page