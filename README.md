# .NET Automation Framework

A modern and robust test automation framework built with C#, .NET 9, and XUnit, implementing the Page Object Model (POM) pattern. This framework provides a scalable and maintainable solution for web application testing.

## 🌟 Features

- **Modern Stack**: Built on .NET 9 and XUnit for reliable test execution
- **Page Object Model**: Clean separation of test logic and page interactions
- **Enhanced Selenium Wrapper**: Custom `SeleniumExecutor` class for robust element interactions
- **Smart Waits**: Intelligent wait strategies using SeleniumExtras.WaitHelpers
- **Organized Structure**: Clear project organization with regions and proper separation of concerns
- **Configuration Management**: Flexible configuration system for different environments
- **WebDriver Factory**: Dynamic browser management with factory pattern
- **Maintainable Tests**: Easy-to-read and maintain test cases
- **Cross-browser Support**: Ready for multiple browser testing

## 🏗️ Architecture

### Project Structure
```
NETAutomationFramework/
├── Core/
│   ├── BasePage.cs         # Base functionality for all page objects
│   ├── SeleniumExecutor.cs # Enhanced Selenium wrapper with custom actions
│   └── TestBase.cs         # Base test class with setup/teardown
├── Pages/
│   └── LoginPage.cs        # Page object for login functionality
├── Tests/
│   └── LoginTests.cs       # Test cases for login scenarios
└── Utils/
    ├── Config.cs           # Configuration management
    └── WebDriverFactory.cs # Browser factory implementation
```

### Key Components

#### Core
- **BasePage**: Implements common page functionality and navigation
- **SeleniumExecutor**: Provides robust element interaction methods with built-in waits
- **TestBase**: Handles test lifecycle and WebDriver management

#### Pages
- Implements Page Object Model pattern
- Each page class represents a web page or component
- Encapsulates page elements and actions

#### Utils
- **Config**: Manages test configuration and environment settings
- **WebDriverFactory**: Handles browser instance creation and configuration

## 🚀 Getting Started

### Prerequisites
- .NET 9 SDK
- Visual Studio 2022 or VS Code with C# extension
- Chrome or Firefox browser installed
- Git (for version control)

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/kietdt99/AutomationTestFW-DotNet.git
   cd AutomationTestFW-DotNet
   ```

2. Install dependencies:
   ```bash
   dotnet restore
   ```

3. Build the project:
   ```bash
   dotnet build
   ```

### Running Tests

Run all tests:
```bash
dotnet test
```

Run specific test class:
```bash
dotnet test --filter "FullyQualifiedName~NETAutomationFramework.Tests.LoginTests"
```

## 🔧 Configuration

The framework supports configuration through the `Config.cs` class:
- Base URL configuration
- Browser settings
- Default credentials
- Timeouts and waits

## 📝 Writing Tests

### Page Object Example
```csharp
public class LoginPage : BasePage
{
    // Page elements
    private readonly By _usernameInput = By.Id("username");
    private readonly By _passwordInput = By.Id("password");
    
    // Page actions
    public void Login(string username, string password)
    {
        SeleniumExecutor.TypeText(_usernameInput, username);
        SeleniumExecutor.TypeText(_passwordInput, password);
    }
}
```

### Test Example
```csharp
public class LoginTests : TestBase
{
    [Fact]
    public void SuccessfulLogin_WhenValidCredentialsProvided()
    {
        var loginPage = new LoginPage(Driver);
        loginPage.Login("username", "password");
        Assert.True(loginPage.IsPageDisplayed());
    }
}
```

## 🤝 Contributing

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📄 License

This project is licensed under the MIT License - see the LICENSE file for details.

## ✨ Best Practices

1. Follow the Page Object Model pattern
2. Use meaningful names for variables and methods
3. Keep page objects focused and maintainable
4. Implement proper wait strategies
5. Write clear and specific assertions
6. Document complex functionality
7. Follow C# coding conventions

## 🔍 Debugging

- Use Visual Studio's debugging tools
- Check the test output for detailed logs
- Verify element locators
- Ensure proper waits are implemented
- Check browser console for JavaScript errors

## 🌐 Supported Browsers

- Google Chrome (default)
- Firefox
- Edge (coming soon)

For questions or issues, please open an issue in the GitHub repository.
