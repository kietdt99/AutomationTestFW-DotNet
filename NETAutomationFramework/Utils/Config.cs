using System;

namespace NETAutomationFramework.Utils
{
    public static class Config
    {
        public static string BaseUrl => Environment.GetEnvironmentVariable("TEST_BASE_URL") ?? "https://candymapper.com";
        public static int DefaultTimeout => int.Parse(Environment.GetEnvironmentVariable("TEST_TIMEOUT") ?? "30");
        public static string Browser => Environment.GetEnvironmentVariable("TEST_BROWSER") ?? "chrome";
        public static bool Headless => bool.Parse(Environment.GetEnvironmentVariable("TEST_HEADLESS") ?? "false");
    }
}
