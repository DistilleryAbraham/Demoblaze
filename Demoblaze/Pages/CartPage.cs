using Demoblaze.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demoblaze.Pages
{
    public class CartPage : BasePage
    {
        public CartPage(IWebDriver driver) { Driver = driver; }


        protected By Item = By.XPath("//tr[@class='success']");
        string btnDeleteProduct = "Delete";
        public int numberOfProducts = 0;
        public void clickOnDeleteProduct()
        {
            numberOfProducts = findElements(Item).Count;
            click(findElement(btnDeleteProduct)); Helper.wait(Helper.tLow);
        }
        public bool validateProducts()
        {
            if (findElements(Item).Count == (numberOfProducts - 1))
            {
                return true;
            }
            return false;
        }
    }
}
