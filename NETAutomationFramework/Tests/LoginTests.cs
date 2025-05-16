using NETAutomationFramework.Core;
using NETAutomationFramework.Pages;
using Xunit;

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
            Assert.True(_loginPage.IsPageDisplayed(), "Login page is not displayed");

            // Test with default credentials
            _loginPage.Login();

            // Test with custom credentials
            _loginPage.Login("customuser", "custompass");

            // Add assertions for successful login
            // For example:
            // Assert.That(_dashboardPage.IsPageDisplayed(), Is.True, "Dashboard page is not displayed after login");
        }
    }
}
