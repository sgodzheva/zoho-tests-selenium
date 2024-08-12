using NUnit.Framework;
using OpenQA.Selenium;
using Zoho.Tests.Selenium.Pages;

namespace Zoho.Tests.Selenium.Tests.Dashboard
{
    public class SignOutTests
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = DriverFactory.CreateChromeDriver();
        }

        [TestCase]
        public void TestSignOutProcess()
        {
            DashboardPage dashboardPage = new DashboardPage(driver);
            dashboardPage.Open();
            dashboardPage.ClickProfileIcon();
            SignOutPage signOutPage = dashboardPage.ClickSignOutButton();

            Assert.That(driver.Title, Is.EqualTo("Logout | Zoho Invoice"));

            string successMessage = signOutPage.GetSuccessMessage();
            Assert.That(successMessage, Is.EqualTo("You've logged out successfully!"));

            bool isVisibleSignInButton = signOutPage.IsVisibleSignInButton();
            Assert.That(isVisibleSignInButton, Is.True);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}
