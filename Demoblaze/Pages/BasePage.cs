using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TechTalk.SpecFlow;
using Demoblaze.Helpers;

namespace Demoblaze.Pages
{
    [Binding]
    public class BasePage
    {
        protected IWebDriver Driver;
        public IWebElement findElement(By element)
        {
            return waitForElement(element);
        }
        public IWebElement findElement(string text)
        {
            return waitForElement(text);
        }
        public ReadOnlyCollection<IWebElement> findElements(By element)
        {
            return Driver.FindElements(element);
        }
        public ReadOnlyCollection<IWebElement> findElements(string element)
        {
            waitForElement(element);
            return Driver.FindElements(By.XPath("//*[text() = '" + element + "']"));
        }
        public void sendKeys(By element, string text)
        {
            findElement(element).SendKeys(text);
        }
        public void sendKeys(IWebElement element, string text)
        {
            element.SendKeys(text);
        }

        public void clear(IWebElement element)
        {
            element.Clear();
        }
        public void clear(By element)
        {
            findElement(element).Clear();
        }
        public void click(By element)
        {
            findElement(element).Click();
        }
        public void click(IWebElement element)
        {
            element.Click();
        }
        public bool hasElement(By element)
        {
            try
            {
                if (findElements(element).Count > 0)
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
        public bool hasElement(string text)
        {
            try
            {
                findElement(text);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool isEnabled(IWebElement element)
        {
            return element.Enabled;
        }
        public string getText(IWebElement element)
        {
            return element.Text;
        }
        public string getValue(IWebElement element)
        {
            return element.GetAttribute("value");

        }
        public IWebElement waitForElement(By element)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(element));
            }
            catch
            {
                return null;
            }
        }
        public IWebElement waitForElement(string element)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//*[text() = '" + element + "']")));
        }
        public void scrollToElement(IWebElement element)
        {
            IJavaScriptExecutor js = Driver as IJavaScriptExecutor;
            js.ExecuteScript("arguments[0].scrollIntoView({ block: 'center' });", new object[] { element });
        }
        public void scrollAndClick(By element)
        {
            scrollToElement(findElement(element));
            click(element);
        }
        public void ScrollAndClick(string element)
        {
            scrollToElement(findElement(element));
            click(findElement(element));
        }
        public void scrollAndClick(IWebElement element)
        {
            scrollToElement(element);
            click(element);
        }

        public bool hasFormElement(By element, string text)
        {
            if (hasElement(element))
            {
                if (findElement(element).Text.Contains(text))
                    return true;
            }
            else
                if (text.Equals(""))
                return true;

            return false;
        }

        public bool hasTableElements(String[] data, string startPath, string endPath)
        {
            for (int row = 1; row <= data.Length; row++)
            {
                By element = By.XPath(startPath + row + endPath);
                String debug = findElement(element).Text;
                if (!hasFormElement(element, data[row - 1]))
                    return false;
            }
            return true;
        }
    }
}
