Feature: Login

Test cases for login in the application

@login
Scenario Outline: 01_Login
	Given Open demoblaze application
	When Click on Login option
	And Enter username to login <userName>
	And Enter password to login <password>
	And Click on Login button
	Then Show the userName logged <userName>

Examples:
	| userName     | password     |
	| userNameSame | passwordSame |


@login
Scenario Outline: 02_Login_empty
	Given Open demoblaze application
	When Click on Login option
	And Enter username to login <userName>
	And Enter password to login <password>
	And Click on Login button
	Then Show the message to login <typeMessage>

Examples:
	| userName | password | typeMessage |
	|          |          | empty       |

@login
Scenario Outline: 03_Login_wrong_password
	Given Open demoblaze application
	When Click on Login option
	And Enter username to login <userName>
	And Enter password to login <password>
	And Click on Login button
	Then Show the message to login <typeMessage>

Examples:
	| userName     | password   | typeMessage |
	| userNameSame | password   | wPassword   |
	| userNameSame | 123        | wPassword   |
	| userNameSame | */@#$@#%$% | wPassword   |

@login
Scenario Outline: 04_Login_wrong_username
	Given Open demoblaze application
	When Click on Login option
	And Enter username to login <userName>
	And Enter password to login <password>
	And Click on Login button
	Then Show the message to login <typeMessage>

Examples:
	| userName     | password     | typeMessage |
	| 123sddf      | passwordSame | wUser       |
	| !@$#%$#%#    | passwordSame | wUser       |
	| user98574ame | passwordSame | wUser       |

@login
Scenario Outline: 05_Login_cancel
	Given Open demoblaze application
	When Click on Login option
	And Enter username to login <userName>
	And Enter password to login <password>
	And Click on cancel login button
	Then Show the login option

Examples:
	| userName     | password     |
	| 123sddf      | passwordSame |
	| !@$#%$#%#    | passwordSame |
	| user98574ame | passwordSame |
