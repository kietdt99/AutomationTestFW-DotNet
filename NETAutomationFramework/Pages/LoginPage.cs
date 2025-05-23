using NETAutomationFramework.Core;
using NETAutomationFramework.Utils;
using OpenQA.Selenium;

namespace NETAutomationFramework.Pages
{
    public class LoginPage : BasePage
    {
        #region Page Objects
        private readonly By _usernameInput = By.Id("user-name");
        private readonly By _passwordInput = By.Id("password");
        private readonly By _loginButton = By.Id("login-button");
        private IWebElement LogoText => Driver.FindElement(By.ClassName("app_logo"));

        protected override string PageUrl => string.Empty;
        protected override By GetPageIdentifier() => _loginButton;
        #endregion

        #region Constructor
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }
        #endregion

        #region Page Actions
        public override bool IsPageDisplayed()
        {
            return SeleniumExecutor.IsElementDisplayed(_usernameInput) &&
                   SeleniumExecutor.IsElementDisplayed(_passwordInput) &&
                   SeleniumExecutor.IsElementDisplayed(_loginButton);
        }

        public void Login(string? username = null, string? password = null)
        {
            SeleniumExecutor.TypeText(_usernameInput, username ?? string.Empty);
            SeleniumExecutor.TypeText(_passwordInput, password ?? string.Empty);
            SeleniumExecutor.Click(_loginButton);
        }
        public string GetLogoText() => LogoText.Text;
        #endregion
    }
}
