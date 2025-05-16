// <copyright file="LoginPage.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NETAutomationFramework.Pages
{
    using NETAutomationFramework.Core;
    using NETAutomationFramework.Utils;
    using OpenQA.Selenium;

    public class LoginPage : BasePage
    {
        private readonly By usernameInput = By.Id("user-name");
        private readonly By passwordInput = By.Id("password");
        private readonly By loginButton = By.Id("login-button");

        private IWebElement LogoText => this.Driver.FindElement(By.ClassName("app_logo"));

        protected override string PageUrl => string.Empty;

        protected override By GetPageIdentifier() => this.loginButton;

        public LoginPage(IWebDriver driver)
            : base(driver)
        {
        }

        public override bool IsPageDisplayed()
        {
            return this.SeleniumExecutor.IsElementDisplayed(this.usernameInput) &&
                   this.SeleniumExecutor.IsElementDisplayed(this.passwordInput) &&
                   this.SeleniumExecutor.IsElementDisplayed(this.loginButton);
        }

        public void Login(string? username = null, string? password = null)
        {
            this.SeleniumExecutor.TypeText(this.usernameInput, username ?? string.Empty);
            this.SeleniumExecutor.TypeText(this.passwordInput, password ?? string.Empty);
            this.SeleniumExecutor.Click(this.loginButton);
        }

        public string GetLogoText() => this.LogoText.Text;
    }
}
