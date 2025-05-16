// <copyright file="Config.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NETAutomationFramework.Utils
{
    public static class Config
    {
        public static string BaseUrl => Environment.GetEnvironmentVariable("TEST_BASE_URL") ?? "https://www.saucedemo.com";

        public static int DefaultTimeout => int.Parse(Environment.GetEnvironmentVariable("TEST_TIMEOUT") ?? "30");

        public static string Browser => Environment.GetEnvironmentVariable("TEST_BROWSER") ?? "chrome";

        public static bool Headless => bool.Parse(Environment.GetEnvironmentVariable("TEST_HEADLESS") ?? "false");

        public static class Credentials
        {
            public static string StandardUsername => Environment.GetEnvironmentVariable("TEST_USERNAME") ?? "standard_user";

            public static string StandardPassword => Environment.GetEnvironmentVariable("TEST_PASSWORD") ?? "secret_sauce";
        }
    }
}
