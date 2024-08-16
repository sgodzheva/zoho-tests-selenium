using NUnit.Framework;
using OpenQA.Selenium;
using Zoho.Tests.Selenium.Automations;
using Zoho.Tests.Selenium.Pages;

namespace Zoho.Tests.Selenium.Tests.Invoices
{
    public class SearchCustomerNameTests
    {
        private IWebDriver driver;
        private CustomersAutomation customersAutomation;

        [SetUp]
        public void SetUp()
        {
            driver = DriverFactory.CreateDriver();
            customersAutomation = new CustomersAutomation(driver);
        }

        [Test]
        public void TestSearchWithInvalidCustomerName()
        {
            InvoicesPage invoicesPage = new InvoicesPage(driver);
            invoicesPage.Open();
            NewInvoicePage newInvoicePage = invoicesPage.AddNewInvoice();
            newInvoicePage.ClickCustomerNameField();
            newInvoicePage.PopulateCustomerName("invalid-name");

            Assert.That(newInvoicePage.IsAutoCompleteMessageDisplayed("No results found"), Is.True);
        }

        [TestCase("Algot", "Andersson", "Andersson, Algot")]
        public void TestSearchWithExistingCustomerName(string firstName, string lastName, string displayName)
        {
            customersAutomation.CreateCustomer(firstName, lastName, displayName);

            InvoicesPage invoicesPage = new InvoicesPage(driver);
            invoicesPage.Open();
            NewInvoicePage newInvoicePage = invoicesPage.AddNewInvoice();
            newInvoicePage.ClickCustomerNameField();
            newInvoicePage.PopulateCustomerName(lastName);

            newInvoicePage.SelectCustomer(displayName);

            Assert.That(newInvoicePage.GetCustomerName(), Is.EqualTo(displayName));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}
