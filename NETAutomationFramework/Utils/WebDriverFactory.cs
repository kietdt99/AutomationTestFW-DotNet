// <copyright file="WebDriverFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NETAutomationFramework.Utils
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    public static class WebDriverFactory
    {
        public static IWebDriver CreateDriver()
        {
            return Config.Browser.ToLower() switch
            {
                "chrome" => CreateChromeDriver(),
                _ => throw new ArgumentException($"Browser type {Config.Browser} is not supported.")
            };
        }

        private static IWebDriver CreateChromeDriver()
        {
            var options = new ChromeOptions();

            if (Config.Headless)
            {
                options.AddArgument("--headless");
            }

            // Add common Chrome options
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-notifications");
            options.AddArgument("--disable-popup-blocking");

            return new ChromeDriver(options);
        }
    }
}
