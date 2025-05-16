using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using NETAutomationFramework.Utils;
using System;
using System.IO;
using System.Runtime.CompilerServices;

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
            if (Driver != null)
            {
                try
                {
                    TakeScreenshot();
                }
                catch (Exception)
                {
                    // Ignore screenshot errors during disposal
                }
                finally
                {
                    Driver.Quit();
                    Driver.Dispose();
                }
            }
        }

        protected void TakeScreenshot([CallerMemberName] string testName = "")
        {
            try
            {
                var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                var artifactDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestResults", "Screenshots");
                Directory.CreateDirectory(artifactDirectory);
                
                var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                var fileName = Path.Combine(artifactDirectory, $"{testName}_{timestamp}.png");
                
                File.WriteAllBytes(fileName, screenshot.AsByteArray);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to take screenshot: {ex.Message}");
            }
        }
    }
}
