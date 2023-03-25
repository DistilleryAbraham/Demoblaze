Feature: SignUp

Test cases for signup in the application

@signup
Scenario Outline: 01_SigUp
	Given Open demoblaze application
	When Click on Sign up  option
	And Enter username to singUp <userName> <successful>
	And Enter password to singUp <password> <successful>
	And Click on Signup button
	Then Show the message for signup <successful>

Examples:
	| userName              | password                | successful |
	| userNameForChallenge* | passwordForChallenge    | yes        |
	| us3rN@meForCh@llenge* | passwordForCh@llenge123 | yes        |


@signup
Scenario Outline: 02_SigUp_empty
	Given Open demoblaze application
	When Click on Sign up  option
	And Enter username to singUp <userName> <successful>
	And Enter password to singUp <password> <successful>
	And Click on Signup button
	Then Show the message for signup <successful>

Examples:
	| userName | password | successful |
	|          |          | empty      |


@signup
Scenario Outline: 03_SigUp_already_exist
	Given Open demoblaze application
	When Click on Sign up  option
	And Enter username to singUp <userName> <successful>
	And Enter password to singUp <password> <successful>
	And Click on Signup button
	Then Show the message for signup <successful>

Examples:
	| userName     | password     | successful |
	| userNameSame | passwordSame | no         |

@signup
Scenario Outline: 04_SigUp_by_API
	Given Open demoblaze application
	When Send rest for create user <userName> <password>
	Then Validate status code response <statusCode>

Examples:
	| userName    | password    | statusCode |
	| userNameAPI | passwordAPI | 200        |

@sigup
Scenario Outline: 04_SigUp_by_API_already_exist
	When Send rest for already exist user <userName> <password>
	Then Validate body response <bodyResponse>

Examples:
	| userName    | password    | bodyResponse             |
	| userNameAPI | passwordAPI | This user already exist. |