// <copyright file="BasePage.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NETAutomationFramework.Core
{
    using NETAutomationFramework.Utils;
    using OpenQA.Selenium;

    public abstract class BasePage
    {
        protected readonly IWebDriver Driver;
        protected readonly SeleniumExecutor SeleniumExecutor;

        protected BasePage(IWebDriver driver)
        {
            // Initialize the WebDriver and SeleniumExecutor
            this.Driver = driver;
            this.SeleniumExecutor = new SeleniumExecutor(driver);

            // Navigate to page URL on initialization
            this.SeleniumExecutor.OpenPage($"{Config.BaseUrl}{this.PageUrl}");

            // Check if the page is displayed
            this.WaitForPageToLoad();
        }

        protected abstract string PageUrl { get; }

        public abstract bool IsPageDisplayed();

        protected virtual void WaitForPageToLoad()
        {
            // Default implementation. Override in specific pages if needed
            this.SeleniumExecutor.WaitForElementToBeVisible(this.GetPageIdentifier());
        }

        protected abstract By GetPageIdentifier();
    }
}
