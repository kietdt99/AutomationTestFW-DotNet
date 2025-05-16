using OpenQA.Selenium;
using NETAutomationFramework.Utils;

namespace NETAutomationFramework.Core
{    public abstract class BasePage
    {
        protected readonly IWebDriver Driver;
        protected readonly SeleniumExecutor SeleniumExecutor;

        private static By WelcomeDialog => By.XPath("//div[@role='dialog']");
        private static By CloseButton => By.CssSelector("popup-widget190298-close-icon");

        protected BasePage(IWebDriver driver)
        {
            // Initialize the WebDriver and SeleniumExecutor
            Driver = driver;
            SeleniumExecutor = new SeleniumExecutor(driver);
            
            // Navigate to page URL on initialization
            SeleniumExecutor.OpenPage($"{Config.BaseUrl}{PageUrl}");

            // Check if the welcome dialog is displayed
            if (SeleniumExecutor.WaitForElement(WelcomeDialog).Displayed)
            {
                // Close the welcome dialog if it appears
                SeleniumExecutor.Click(CloseButton);
            }

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
