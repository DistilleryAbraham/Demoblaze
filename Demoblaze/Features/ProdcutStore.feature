Feature: ProdcutStore

Test cases for productstore in the application

Background:
	Given Open demoblaze application
	And Login application userNameSame passwordSame


@productstore
Scenario Outline: 01_Validate_page
	And Validate name of product store
	And Validate categories menu
	And Validate products

@productstore
Scenario Outline: 02_Validate_products_description
	And Validate products
	And Validate products description

@productstore
Scenario Outline: 03_Validate_products_price
	And Validate products
	And Validate products price

