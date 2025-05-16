using Xunit;
using OpenQA.Selenium;
using NETAutomationFramework.Utils;
using System;

namespace NETAutomationFramework.Core
{
    public class TestBase : IDisposable
    {
        protected IWebDriver Driver { get; private set; }
        protected SeleniumExecutor SeleniumExecutor { get; private set; }

        public TestBase()
        {
            Driver = WebDriverFactory.CreateDriver();
            SeleniumExecutor = new SeleniumExecutor(Driver);
        }

        public virtual void Dispose()
        {
            Driver?.Quit();
            Driver?.Dispose();
        }
    }
}
