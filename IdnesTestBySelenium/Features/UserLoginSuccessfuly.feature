Feature: UserLogin

User is successfuly loged to its account

@UserLogin
Scenario: User is successfuly loged to its account
	Given User go to login page
	And User set right e-mail
	And User click on Continue button
	And User set right password
	When User click on Login button	
	Then User is loged to account
