// <copyright file="TestBase.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NETAutomationFramework.Core
{
    using System;
    using System.IO;
    using System.Runtime.CompilerServices;
    using NETAutomationFramework.Utils;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.Extensions;
    using Xunit;

    public class TestBase : IDisposable
    {
        protected IWebDriver Driver { get; private set; }

        protected SeleniumExecutor SeleniumExecutor { get; private set; }

        public TestBase()
        {
            this.Driver = WebDriverFactory.CreateDriver();
            this.SeleniumExecutor = new SeleniumExecutor(this.Driver);
        }

        public virtual void Dispose()
        {
            if (this.Driver != null)
            {
                try
                {
                    this.TakeScreenshot();
                }
                catch (Exception)
                {
                    // Ignore screenshot errors during disposal
                }
                finally
                {
                    this.Driver.Quit();
                    this.Driver.Dispose();
                }
            }
        }

        protected void TakeScreenshot([CallerMemberName] string testName = "")
        {
            try
            {
                var screenshot = ((ITakesScreenshot)this.Driver).GetScreenshot();
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
