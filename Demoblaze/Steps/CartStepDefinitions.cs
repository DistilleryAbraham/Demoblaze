using Demoblaze.Hooks;
using Demoblaze.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace Demoblaze.Steps
{
    [Binding]
    public class CartStepDefinitions : InitialHooks
    {
        CartPage cartPage = new CartPage(Driver);
        ProductDetailsPage productDetailsPage = new ProductDetailsPage(Driver);
        ProductStorePage productStore = new ProductStorePage(Driver);

        [Given(@"Go to category product (.*)")]
        public void GivenGoToCategoryProduct(string producttype)
        {
            productStore.clickProductType(producttype);
        }

        [Given(@"Open product to add")]
        public void GivenOpenProductToAdd()
        {
            productStore.selectProduct();
        }

        [When(@"Click on add to cart")]
        public void WhenClickOnAddToCart()
        {
            productDetailsPage.addToCart();
        }

        [Then(@"Show message that produt added")]
        public void ThenShowMessageThatProdutAdded()
        {
            Assert.IsTrue(productDetailsPage.validateMessageAddToCart());
        }

        [When(@"Click on acept to addproduct")]
        public void WhenClickOnAceptToAddproduct()
        {
            productDetailsPage.clickAcceptAddProduct();
        }

        [When(@"Go to cart")]
        public void WhenGoToCart()
        {
            productDetailsPage.goToCartModule();
        }

        [When(@"Click on delete product from cart")]
        public void WhenClickOnDeleteProductFromCart()
        {
            cartPage.clickOnDeleteProduct();
        }

        [When(@"verify that the product was deleted")]
        public void WhenVerifyThatTheProductWasDeleted()
        {
            Assert.IsTrue(cartPage.validateProducts());
        }

        [When(@"Click on place order")]
        public void WhenClickOnPlaceOrder()
        {
            cartPage.clickOnPlaceOrder();
        }

        [When(@"Enter client name (.*)")]
        public void WhenEnterClientName(string name)
        {
            cartPage.enterClientName(name);
        }

        [When(@"Enter client country (.*)")]
        public void WhenEnterClientCountry(string country)
        {
            cartPage.enterClientCountry(country);
        }

        [When(@"Enter client city (.*)")]
        public void WhenEnterClientCity(string city)
        {
            cartPage.enterClientCity(city);
        }

        [When(@"Enter client credit card (.*)")]
        public void WhenEnterClientCreditCard(string card)
        {
            cartPage.enterClientCreditCard(card);
        }

        [When(@"Enter month of credit card (.*)")]
        public void WhenEnterMonthOfCreditCard(string month)
        {
            cartPage.enterMonth(month);
        }

        [When(@"Enter year of credit card (.*)")]
        public void WhenEnterYearOfCreditCard(string year)
        {
            cartPage.enterYear(year);
        }

        [When(@"Click on purchase button")]
        public void WhenClickOnPurchaseButton()
        {
            cartPage.clickPurchase();
        }

        [Then(@"Validate the information (.*) (.*)")]
        public void ThenValidateTheInformation(string name, string card)
        {
            Assert.IsTrue(cartPage.validateInformation(name, card));
        }
        [When(@"Click on cancel purchase button")]
        public void WhenClickOnCancelPurchaseButton()
        {
            cartPage.clickClosePurchase();
        }

    }
}
