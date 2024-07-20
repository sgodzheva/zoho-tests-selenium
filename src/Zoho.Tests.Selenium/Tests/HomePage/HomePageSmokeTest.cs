using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Zoho.Tests.Selenium.Pages;

namespace Zoho.Tests.Selenium.Tests
{
    public class HomePageSmokeTest
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void OpenHomePage()
        {
            HomePage homePage = new HomePage(driver);
            homePage.Open();
            Assert.That(driver.Title, Is.EqualTo("Dashboard | Zoho Invoice"));
        }

        [TearDown]
        public void CleanupAfterEveryTest()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
