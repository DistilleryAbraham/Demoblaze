using Microsoft.Extensions.Configuration;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace Demoblaze.Hooks
{
    [Binding]
    public class InitialHooks
    {
        public static IWebDriver Driver;
        public static string baseURL = "https://www.demoblaze.com/";
        [BeforeScenario]
        public static void BeforeScenario()
        {
            CreateWebDriver();
        }
        public static void CreateWebDriver()
        {
            //   var baseDir = AppDomain.CurrentDomain.BaseDirectory;

            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--no-sandbox");
            options.AddArguments("--enable-automation");
            options.AddArguments("--disable-infobars");
            options.AddArguments("--incognito");
            options.AddArguments("--test-type");

            Driver = new ChromeDriver(options);
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(baseURL);
        }

        [AfterScenario]
        public void AfterTest()
        {
            Driver.Quit();
        }
    }
}