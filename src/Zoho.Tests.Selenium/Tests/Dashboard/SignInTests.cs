using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Zoho.Tests.Selenium.Pages;

namespace Zoho.Tests.Selenium.Tests.LandingPage
{
    public class SignInTests
    {
        private IWebDriver driver;
        private string username;
        private string password;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            username = TestConfigurations.GetDefaultUsername();
            password = TestConfigurations.GetDefaultPassword();
        }

        [TestCase]
        public void TestSignInProcess()
        {
            SignInPage signInPage = new SignInPage(driver);
            signInPage.Open();
            signInPage.ClickFirstSignInButton();
            signInPage.PopulateUsername(username);
            signInPage.PopulatePassword(password);
            signInPage.ClickSignInButton();

            Assert.That(driver.Title, Is.EqualTo("Dashboard | Zoho Invoice"));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
