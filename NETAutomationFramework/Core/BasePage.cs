using OpenQA.Selenium;
using NETAutomationFramework.Utils;

namespace NETAutomationFramework.Core
{    public abstract class BasePage
    {
        protected readonly IWebDriver Driver;
        protected readonly SeleniumExecutor SeleniumExecutor;

        protected BasePage(IWebDriver driver)
        {
            // Initialize the WebDriver and SeleniumExecutor
            Driver = driver;
            SeleniumExecutor = new SeleniumExecutor(driver);
            
            // Navigate to page URL on initialization
            SeleniumExecutor.OpenPage($"{Config.BaseUrl}{PageUrl}");

            // Check if the page is displayed
            WaitForPageToLoad();
        }

        protected abstract string PageUrl { get; }

        public abstract bool IsPageDisplayed();

        protected virtual void WaitForPageToLoad()
        {
            // Default implementation. Override in specific pages if needed
            SeleniumExecutor.WaitForElementToBeVisible(GetPageIdentifier());
        }

        protected abstract By GetPageIdentifier();
    }
}
