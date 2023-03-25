using Demoblaze.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.CommonModels;

namespace Demoblaze.Pages
{
    public class ProductDetailsPage : BasePage
    {
        public ProductDetailsPage(IWebDriver driver) { Driver = driver; }

        protected By btnAddCart = By.XPath("//a[@class='btn btn-success btn-lg']");
        protected By btnCartModule = By.Id("cartur");


        public void addToCart()
        {
            Helper.wait(Helper.tLow);
            click(btnAddCart);
            Helper.wait(Helper.tLow);
        }
        public void clickAcceptAddProduct() => Driver.SwitchTo().Alert().Accept();
        public void goToCartModule() { click(btnCartModule); Helper.wait(Helper.tLow); }
        public bool validateMessageAddToCart()
        {
            Helper.wait(Helper.tLow);
            return (Driver.SwitchTo().Alert().Text.Contains("Product added"));
        }



    }
}
