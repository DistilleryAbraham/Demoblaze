using Demoblaze.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Demoblaze.Pages
{
    public class CartPage : BasePage
    {
        public CartPage(IWebDriver driver) { Driver = driver; }

        protected By Item = By.XPath("//tr[@class='success']");
        public string btnDeleteProduct = "Delete";
        public int numberOfProducts = 0;
        protected By btnPlaceOrder = By.XPath("//button[@class='btn btn-success']");
        protected By txtName = By.Id("name");
        protected By txtCountry = By.Id("country");
        protected By txtCity = By.Id("city");
        protected By txtCreditCard = By.Id("card");
        protected By txtMonth = By.Id("month");
        protected By txtYear = By.Id("year");
        protected By btnPurchase = By.XPath("//button[@onclick='purchaseOrder()']");
        protected By btnClosePurchase = By.XPath("//button[@class='btn btn-secondary']");
        protected By lblPurchase = By.XPath("//p[@class='lead text-muted ']");

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
        public void clickOnPlaceOrder() => click(btnPlaceOrder);
        public void enterClientName(string name)
        {
            Helper.wait(Helper.tLow);
            sendKeys(txtName, name);
        }
        public void enterClientCountry(string country) => sendKeys(txtCountry, country);
        public void enterClientCity(string city) => sendKeys(txtCity, city);
        public void enterClientCreditCard(string creditCard) => sendKeys(txtCreditCard, creditCard);
        public void enterMonth(string month) => sendKeys(txtMonth, month);
        public void enterYear(string year) => sendKeys(txtYear, year);
        public void clickPurchase() => click(btnPurchase);
        public void clickClosePurchase() => click(btnClosePurchase);

        public bool validateInformation(string name, string card)
        {
            Helper.wait(Helper.tLow);
            int cont = 0;
            string text = findElement(lblPurchase).Text;
            if (text.Contains("Id"))
            {
                cont = cont + 1;
            }
            if (text.Contains("Amount"))
            {
                cont = cont + 1;
            }
            if (text.Contains($"Card Number: {card}"))
            {
                cont = cont + 1;
            }
            if (text.Contains($"Name: {name}"))
            {
                cont = cont + 1;
            }
            if (text.Contains("Date"))
            {
                cont = cont + 1;
            }
            if (cont == 5)
            {
                return true;
            }
            return false;
        }
    }
}
