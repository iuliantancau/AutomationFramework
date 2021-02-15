Feature: Test
	

Scenario:  Test Scenario 1
	Given The user navigates to website
	And The user logs in as a broker
	And The user selects product 'Terror' and scheme 'Terror 24'
	And The user completes the Insured Details region
		| Insured Type | Insured Name | Choose Insured                                                |
		| Corporate    | Test         | Test Partners, Centurion House London Road, STAINES, TW18 4AX |
	And The user completes the Policy Details region
		| QuotableCoverage1    |
		| Property Damage Only |
	When The user saves the page
	And The user navigates to 'Prior Claims' tab
	And The user answers Prior Claims Questions
		| Prior Question1 |
		| true            |
	And The user confirms the disclosures
	And the user selects an action from left menu
		| Action     | Reason | Effective Date | Send Broker Email |
		| Create MTA | Other  | 16/03/2021     | false             |

Scenario Outline: Premium Test
	Given The user navigates to website
	And The user logs in as a broker
	And The user selects product 'Terror' and scheme 'Terror 24'
	And The user completes the Insured Details region
		| Insured Type | Insured Name | Choose Insured                                                |
		| Corporate    | Test         | Test Partners, Centurion House London Road, STAINES, TW18 4AX |
	And The user completes the Policy Details region
		| QuotableCoverage1    |
		| Property Damage Only |
	When The user saves the page