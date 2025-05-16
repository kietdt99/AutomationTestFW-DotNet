# .NET Test Automation Framework

A modern, robust test automation framework built with C#, .NET 9, and XUnit, implementing the Page Object Model (POM) pattern. The framework includes integrated code quality checks, test reporting, and CI/CD pipeline configuration.

## 🌟 Features

- **Modern Tech Stack**: 
  - .NET 9 and XUnit for reliable test execution
  - Selenium WebDriver with enhanced wrapper
  - FluentAssertions for readable assertions
  - StyleCop for code quality enforcement

- **Architecture & Design**:
  - Page Object Model (POM) pattern
  - Smart wait strategies using SeleniumExtras.WaitHelpers
  - WebDriver Factory for dynamic browser management
  - Organized structure with clear separation of concerns

- **Quality Assurance**:
  - StyleCop code analysis integration
  - Code formatting verification
  - Consistent coding standards

- **CI/CD & Reporting**:
  - Automated GitHub Actions pipeline
  - Test execution with detailed logging
  - Code coverage reporting
  - Test results in TRX format
  - Failure screenshots capture
  - Artifact collection

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

### Environment Variables
```bash
TEST_BASE_URL=https://www.saucedemo.com
TEST_BROWSER=chrome
TEST_HEADLESS=true
```

### StyleCop Configuration
The project includes StyleCop.Analyzers for enforcing coding standards:
- File header requirements
- Code formatting rules
- Naming conventions
- Documentation rules
- Code organization

### test.runsettings
Test execution configuration including:
- Test parallelization
- Code coverage settings
- Test environment parameters

## 🔄 CI/CD Pipeline

The framework includes a GitHub Actions workflow that:

1. **Build & Analysis**
   - Restores dependencies
   - Verifies code formatting
   - Runs StyleCop analysis
   - Builds the solution

2. **Testing**
   - Executes all tests
   - Collects code coverage
   - Captures screenshots on failures

3. **Reporting**
   - Generates test reports
   - Creates coverage report
   - Collects test artifacts

4. **Artifacts**
   - Test results (TRX format)
   - Code coverage reports
   - Failure screenshots

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
