using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demoblaze.Pages
{
    internal class ProductStorePage : BasePage
    {
        public ProductStorePage(IWebDriver driver) { Driver = driver; }

        protected By lblProductStore = By.Id("nava");
        protected By lblCategories = By.Id("cat");
        protected By lblProducts = By.Id("tbodyid");
        protected By product = By.Id("article");
        protected By price = By.XPath("//div[@class='card-block']");

        public bool hasTitle() => hasElement(lblProductStore);
        public bool hasCategories() => hasElement(lblCategories);
        public bool hasProducts() => hasElement(lblProducts);

        public bool hasDescrionProducts()
        {
            bool response = false;
            int cont = 0;
            for (int i = 0; i < findElements(product).Count; i++)
            {
                if (getText(findElements(product)[i]).Length > 0)
                {
                    cont = cont + 1;
                }
            }
            if (cont.Equals(findElements(product).Count))
            {
                response = true;
            };
            return response;
        }

        public bool hasPriceProducts()
        {
            bool response = false;
            int cont = 0;
            for (int i = 0; i < findElements(price).Count; i++)
            {
                if (getText(findElements(price)[i]).Contains("$"))
                {
                    cont = cont + 1;
                }
            }
            if (cont.Equals(findElements(price).Count))
            {
                response = true;
            };
            return response;
        }

    }
}
