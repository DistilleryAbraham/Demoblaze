Feature: Cart
Test cases for cart in the application

Background:
	Given Open demoblaze application
	And Login application userNameSame passwordSame


@cart
Scenario Outline: 01_Add_product_to_cart
	Given Go to category product <produtType>
	Given Open product to add
	When Click on add to cart
	Then Show message that produt added

Examples:
	| produtType |
	| phone      |
	| notebook   |
	| monitor    |

@cart
Scenario Outline: 02_Delete_product_from_cart
	Given Go to category product <produtType>
	Given Open product to add
	When Click on add to cart
	And Click on acept to addproduct
	And Go to cart
	And Click on delete product from cart
	And verify that the product was deleted

Examples:
	| produtType |
	| phone      |
	| notebook   |
	| monitor    |


@cart
Scenario Outline: 03_Place_to_order
	Given Go to category product <produtType>
	Given Open product to add
	When Click on add to cart
	And Click on acept to addproduct
	And Go to cart
	And Click on place order
	And Enter client name <name>
	And Enter client country <country>
	And Enter client city <city>
	And Enter client credit card <creditCard>
	And Enter month of credit card <creditcardmonth>
	And Enter year of credit card <creditCardYear>
	And Click on purchase button
	Then Validate the information <name> <creditCard>

Examples:
	| produtType | name    | country | city   | creditCard  | creditcardmonth | creditCardYear |
	| phone      | Abraham | Mexico  | Puebla | 12345678934 | 12              | 2029           |
	| notebook   | Juan    | Spain   | Madrid | 123         | 01              | 2000           |
	| monitor    | 123     | 123     | 123    | 123         | 123             | 123            |

@cart
Scenario Outline: 04_Place_to_order_cancel
	Given Go to category product <produtType>
	Given Open product to add
	When Click on add to cart
	And Click on acept to addproduct
	And Go to cart
	And Click on place order
	And Enter client name <name>
	And Enter client country <country>
	And Enter client city <city>
	And Enter client credit card <creditCard>
	And Enter month of credit card <creditcardmonth>
	And Enter year of credit card <creditCardYear>
	And Click on cancel purchase button

Examples:
	| produtType | name    | country | city   | creditCard  | creditcardmonth | creditCardYear |
	| phone      | Abraham | Mexico  | Puebla | 12345678934 | 12              | 2029           |
	| notebook   | Juan    | Spain   | Madrid | 123         | 01              | 2000           |
	| monitor    | 123     | 123     | 123    | 123         | 123             | 123            |