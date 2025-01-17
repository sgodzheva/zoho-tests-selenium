using NUnit.Framework;
using OpenQA.Selenium;
using Zoho.Tests.Selenium.Automations;
using Zoho.Tests.Selenium.Pages;

namespace Zoho.Tests.Selenium.Tests.Customers
{
    public class InactiveCustomerTests
    {
        private IWebDriver driver;
        private CustomersAutomation customersAutomation;

        [SetUp]
        public void SetUp()
        {
            driver = DriverFactory.CreateDriver();
            customersAutomation = new CustomersAutomation(driver);
        }

        [TestCase("Fredrik", "Olsson", "Olsson, Fredrik")]
        public void TestMakingCustomerInactive(string firstName, string lastName, string displayName)
        {
            customersAutomation.CreateCustomer(firstName, lastName, displayName);
            Thread.Sleep(1000);
            CustomersPage customersPage = new CustomersPage(driver);
            customersPage.Open();
            Thread.Sleep(1000);
            customersPage.SelectCustomerCheckbox(displayName);
            customersPage.ClickKebabMenu();
            customersPage.MarkAsInactiveFromKebabMenu();
            customersPage.SelectCustomer(displayName);
            Assert.That(customersPage.IsMarkAsActiveButtonDisplayed(), Is.True);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}
