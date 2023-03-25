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