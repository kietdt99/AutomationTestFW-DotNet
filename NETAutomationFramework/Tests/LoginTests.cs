using NETAutomationFramework.Core;
using NETAutomationFramework.Pages;
using NETAutomationFramework.Utils;
using FluentAssertions;

namespace NETAutomationFramework.Tests
{
    public class LoginTests : TestBase
    {        
        private readonly LoginPage _loginPage;

        public LoginTests()
        {
            _loginPage = new LoginPage(Driver);
        }

        [Fact]
        public void SuccessfulLogin_WhenValidCredentialsProvided()
        {
            // Verify the login page is displayed
            _loginPage.IsPageDisplayed().Should().BeTrue("The login page should be displayed");

            // Test with credentials from config
            _loginPage.Login(Config.Credentials.StandardUsername, Config.Credentials.StandardPassword);

            // Add assertions for successful login
            _loginPage.GetLogoText().Should().Be("Swag Labs", "The logo text should match after successful login");
        }
    }
}
