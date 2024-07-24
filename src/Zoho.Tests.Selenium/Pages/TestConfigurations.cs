namespace Zoho.Tests.Selenium.Pages
{
    public class TestConfigurations
    {
        public static string ReadEnvironmentVariable(string name)
        {
            string value = Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.User);
            if (value == null)
            {
                value = Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Machine);
            }
            return value;
        }

        public static string GetDefaultUsername()
        {
            return ReadEnvironmentVariable("ZOHO_TESTS_USERNAME");
        }

        public static string GetDefaultPassword()
        {
            return ReadEnvironmentVariable("ZOHO_TESTS_PASSWORD");
        }

        public static string GetSessionLocation()
        {
            return ReadEnvironmentVariable("ZOHO_TESTS_SESSION_LOCATION");
        }

        public static string GetAccountNumber()
        {
            return ReadEnvironmentVariable("ZOHO_TESTS_ACCOUNT_NUMBER");
        }

        public static string ResolveUrl(string path)
        {
            return $"https://invoice.zohocloud.ca/app/{GetAccountNumber()}{path}";
        }
    }
}