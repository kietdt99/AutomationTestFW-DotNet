// <copyright file="SeleniumExecutor.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NETAutomationFramework.Core
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using SeleniumExtras.WaitHelpers;

    public class SeleniumExecutor
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public SeleniumExecutor(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        public void OpenPage(string url)
        {
            try
            {
                this.driver.Navigate().GoToUrl(url);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to navigate to URL: {url}", ex);
            }
        }

        public void Click(By locator)
        {
            try
            {
                var element = this.wait.Until(ExpectedConditions.ElementToBeClickable(locator));
                element.Click();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to click element with locator: {locator}", ex);
            }
        }

        public void TypeText(By locator, string text)
        {
            try
            {
                var element = this.wait.Until(ExpectedConditions.ElementToBeClickable(locator));
                element.Clear();
                element.SendKeys(text);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to type text into element with locator: {locator}", ex);
            }
        }

        public string GetText(By locator)
        {
            try
            {
                var element = this.wait.Until(ExpectedConditions.ElementIsVisible(locator));
                return element.Text;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get text from element with locator: {locator}", ex);
            }
        }

        public bool IsElementDisplayed(By locator)
        {
            try
            {
                return this.wait.Until(ExpectedConditions.ElementIsVisible(locator)).Displayed;
            }
            catch
            {
                return false;
            }
        }

        public void WaitForElementToBeVisible(By locator)
        {
            try
            {
                this.wait.Until(ExpectedConditions.ElementIsVisible(locator));
            }
            catch (Exception ex)
            {
                throw new Exception($"Element with locator {locator} was not visible within timeout", ex);
            }
        }

        public void SelectDropdownByText(By locator, string text)
        {
            try
            {
                var element = this.wait.Until(ExpectedConditions.ElementIsVisible(locator));
                var select = new SelectElement(element);
                select.SelectByText(text);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to select text '{text}' from dropdown with locator: {locator}", ex);
            }
        }

        public void SelectDropdownByValue(By locator, string value)
        {
            try
            {
                var element = this.wait.Until(ExpectedConditions.ElementIsVisible(locator));
                var select = new SelectElement(element);
                select.SelectByValue(value);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to select value '{value}' from dropdown with locator: {locator}", ex);
            }
        }

        public void ScrollToElement(By locator)
        {
            try
            {
                var element = this.wait.Until(ExpectedConditions.ElementExists(locator));
                ((IJavaScriptExecutor)this.driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
                Thread.Sleep(500); // Small pause to allow scroll to complete
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to scroll to element with locator: {locator}", ex);
            }
        }

        public void HoverOverElement(By locator)
        {
            try
            {
                var element = this.wait.Until(ExpectedConditions.ElementExists(locator));
                var actions = new OpenQA.Selenium.Interactions.Actions(this.driver);
                actions.MoveToElement(element).Perform();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to hover over element with locator: {locator}", ex);
            }
        }

        public string GetAttributeValue(By locator, string attributeName)
        {
            try
            {
                var element = this.wait.Until(ExpectedConditions.ElementExists(locator));
                return element.GetAttribute(attributeName) ?? string.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get attribute '{attributeName}' from element with locator: {locator}", ex);
            }
        }

        public void WaitForTextToBePresentInElement(By locator, string text)
        {
            try
            {
                this.wait.Until(ExpectedConditions.TextToBePresentInElementLocated(locator, text));
            }
            catch (Exception ex)
            {
                throw new Exception($"Text '{text}' was not present in element with locator {locator} within timeout", ex);
            }
        }

        public IReadOnlyCollection<IWebElement> FindElements(By locator)
        {
            try
            {
                return this.wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(locator));
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to find elements with locator: {locator}", ex);
            }
        }

        public void SwitchToFrame(By frameLocator)
        {
            try
            {
                this.wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(frameLocator));
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to switch to frame with locator: {frameLocator}", ex);
            }
        }

        public void SwitchToDefaultContent()
        {
            try
            {
                this.driver.SwitchTo().DefaultContent();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to switch to default content", ex);
            }
        }

        public IWebElement WaitForElement(By locator)
        {
            try
            {
                return this.wait.Until(ExpectedConditions.ElementExists(locator));
            }
            catch (Exception ex)
            {
                throw new Exception($"Element with locator {locator} was not found within timeout", ex);
            }
        }

        public void AcceptAlert()
        {
            try
            {
                this.wait.Until(ExpectedConditions.AlertIsPresent());
                this.driver.SwitchTo().Alert().Accept();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to accept alert", ex);
            }
        }

        public void DismissAlert()
        {
            try
            {
                this.wait.Until(ExpectedConditions.AlertIsPresent());
                this.driver.SwitchTo().Alert().Dismiss();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to dismiss alert", ex);
            }
        }
    }
}
