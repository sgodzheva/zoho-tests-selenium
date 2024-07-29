using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using Zoho.Tests.Selenium.Pages;

namespace Zoho.Tests.Selenium.Tests
{
    public class DriverFactory
    {
        public static IWebDriver CreateDriver()
        {
            if (TestConfigurations.GetPreferredBrowser() == "edge")
            {
                return CreateEdgeDriver();
            }
            else if (TestConfigurations.GetPreferredBrowser() == "firefox")
            {
                throw new NotImplementedException("Firefox not done yet");
            }
            return CreateChromeDriver();
        }

        public static IWebDriver CreateChromeDriver()
        {
            var options = new ChromeOptions();
            string folderPathToStoreSession = TestConfigurations.GetSessionLocation();
            options.AddArgument("--user-data-dir=" + folderPathToStoreSession);

            IWebDriver driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            return driver;
        }

        public static IWebDriver CreateEdgeDriver()
        {
            var options = new EdgeOptions();
            // string folderPathToStoreSession = TestConfigurations.GetSessionLocation();
            // options.AddArgument("--user-data-dir=" + folderPathToStoreSession);

            IWebDriver driver = new EdgeDriver(options);
            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}