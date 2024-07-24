using NUnit.Framework;
using OpenQA.Selenium;
using Zoho.Tests.Selenium.Automations;
using Zoho.Tests.Selenium.Pages;

namespace Zoho.Tests.Selenium.Tests.Customers
{
    public class SearchCustomerTests
    {
        private IWebDriver driver;
        private CustomersAutomation customersAutomation;
        [SetUp]
        public void SetUp()
        {
            driver = DriverFactory.CreateDriver();

            customersAutomation = new CustomersAutomation(driver);
        }

        [TestCase("Einar", "Forsberg", "Forsberg, Einar")]
        public void TestCustomerSearch(string firstName, string lastName, string displayName)
        {
            customersAutomation.CreateCustomer(firstName, lastName, displayName);

            CustomersPage customersPage = new CustomersPage(driver);
            customersPage.Open();

            // there is a delay between the creation of a customer and the customer being searchable
            // retry 3 times to find it
            for (int i = 0; i < 3; i++)
            {
                customersPage.SearchForCustomer(displayName);
                bool found = customersPage.SelectCustomer(displayName);
                if (found)
                {
                    break;
                }
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }

            string title = customersPage.GetSelectedCustomerTitle();
            Assert.That(title, Is.EqualTo(displayName));

            string customerType = customersPage.GetCustomerType();
            Assert.That(customerType, Is.EqualTo("Individual"));

            string activeTabName = customersPage.GetActiveTabName();
            Assert.That(activeTabName, Is.EqualTo(displayName));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}