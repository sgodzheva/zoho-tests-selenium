using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Zoho.Tests.Selenium.Pages;

namespace Zoho.Tests.Selenium.Tests
{
    public class DriverFactory
    {
        public static IWebDriver CreateDriver()
        {
            var options = new ChromeOptions();
            string folderPathToStoreSession = TestConfigurations.GetSessionLocation();
            options.AddArgument("--user-data-dir=" + folderPathToStoreSession);

            IWebDriver driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}