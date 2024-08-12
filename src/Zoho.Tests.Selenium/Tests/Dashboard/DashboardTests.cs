using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using Zoho.Tests.Selenium.Pages;

namespace Zoho.Tests.Selenium.Tests.LandingPage
{
    public class DashboardTests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void OpenDashboard()
        {
            DashboardPage dashboardPage = new DashboardPage(driver);
            dashboardPage.Open();
            Assert.That(driver.Title, Is.EqualTo("Dashboard | Zoho Invoice"));

            Assert.That(dashboardPage.IsActiveSidebarButton("Home"), Is.True);
            Assert.That(dashboardPage.IsActiveTab("dashboard"), Is.True);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}