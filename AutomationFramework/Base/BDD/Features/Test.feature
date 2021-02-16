Feature: Test

Scenario:  Test Scenario 1
	Given The user navigates to website	
	And The user logs in as an underwriter
	And The user selects product 'Terror' and scheme 'Terror 24'
	And The user completes the Insured Details region
		| Insured Type | Country                  | Insured Name | Choose Insured                                       |
		| Corporate    | United States of America | Test         | TEST CORP, 132 HOCKHOCKSON RD, COLTS NECK, NJ, 07722 |
	And The user completes the Broker Details region
		| Broker       |
		| BGSU Brokers |
	And The user completes the Policy Details region
		| Expiry Date | QuotableCoverage1    |
		| 30/09/2021  | Property Damage Only |
	When The user saves the page
	And The user navigates to Prior Claims screen
	And The user answers Prior Claims Questions
		| Prior Question1 |
		| true            |
	And The user confirms the disclosures
	And The user downloads 'Broker Quote' document