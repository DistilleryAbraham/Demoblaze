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
    }
}
