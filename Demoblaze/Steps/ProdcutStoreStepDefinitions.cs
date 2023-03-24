using Demoblaze.Hooks;
using Demoblaze.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace Demoblaze.Steps
{
    [Binding]
    public class ProdcutStoreStepDefinitions : InitialHooks
    {
        ProductStorePage productStorePage = new ProductStorePage(Driver);

        [Given(@"Validate name of product store")]
        public void GivenValidateNameOfProductStore()
        {
            Assert.IsTrue(productStorePage.hasTitle());
        }

        [Given(@"Validate categories menu")]
        public void GivenValidateCategoriesMenu()
        {
            Assert.IsTrue(productStorePage.hasCategories());
        }

        [Given(@"Validate products")]
        public void GivenValidateProducts()
        {
            Assert.IsTrue(productStorePage.hasProducts());
        }

        [Given(@"Validate products description")]
        public void GivenValidateProductsDescription()
        {
            Assert.IsTrue(productStorePage.hasDescrionProducts());
        }

        [Given(@"Validate products price")]
        public void GivenValidateProductsPrice()
        {
            Assert.IsTrue(productStorePage.hasPriceProducts());
        }


    }
}
