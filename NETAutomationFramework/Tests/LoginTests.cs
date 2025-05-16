// <copyright file="LoginTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NETAutomationFramework.Tests
{
    using FluentAssertions;
    using NETAutomationFramework.Core;
    using NETAutomationFramework.Pages;
    using NETAutomationFramework.Utils;

    public class LoginTests : TestBase
    {
        private readonly LoginPage loginPage;

        public LoginTests()
        {
            this.loginPage = new LoginPage(this.Driver);
        }

        [Fact]
        public void SuccessfulLogin_WhenValidCredentialsProvided()
        {
            // Verify the login page is displayed
            this.loginPage.IsPageDisplayed().Should().BeTrue("The login page should be displayed");

            // Test with credentials from config
            this.loginPage.Login(Config.Credentials.StandardUsername, Config.Credentials.StandardPassword);

            // Add assertions for successful login
            this.loginPage.GetLogoText().Should().Be("Swag Labs", "The logo text should match after successful login");
        }
    }
}
