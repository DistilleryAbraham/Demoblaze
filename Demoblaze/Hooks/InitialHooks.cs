using Amazon.DeviceFarm.Model;
using Amazon.DeviceFarm;
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
    public sealed class InitialHooks
    {
        public static IWebDriver Driver;
        [BeforeScenario]
        public static void BeforeScenario()
        {
            CreateWebDriver();
        }
        public static void CreateWebDriver()
        {
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;

            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--no-sandbox");
            options.AddArguments("--enable-automation");
            options.AddArguments("--disable-infobars");
            options.AddArguments("--incognito");
            options.AddArguments("--test-type");

            Driver = new ChromeDriver(baseDir, options);
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("https://www.demoblaze.com/");


        }

        [AfterScenario]
        public void AfterTest()
        {
            Driver.Quit();
        }
    }
}