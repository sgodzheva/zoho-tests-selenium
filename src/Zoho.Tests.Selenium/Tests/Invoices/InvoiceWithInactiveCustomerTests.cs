using NUnit.Framework;
using OpenQA.Selenium;
using Zoho.Tests.Selenium.Automations;
using Zoho.Tests.Selenium.Pages;

namespace Zoho.Tests.Selenium.Tests.Invoices
{
    public class InvoiceWithInactiveCustomerTests
    {
        private IWebDriver driver;
        private CustomersAutomation customersAutomation;

        [SetUp]
        public void SetUp()
        {
            driver = DriverFactory.CreateDriver();
            customersAutomation = new CustomersAutomation(driver);
        }

        [TestCase("Linn", "Vinter", "Vinter, Linn")]
        public void TestUsingInactiveCustomerForInvoiceCreation(string firstName, string lastName, string displayName)
        {
            customersAutomation.CreateCustomer(firstName, lastName, displayName);
            Thread.Sleep(1000);
            CustomersPage customersPage = new CustomersPage(driver);
            customersPage.Open();
            customersPage.SelectCustomerCheckbox(displayName);
            customersPage.ClickKebabMenu();
            customersPage.MarkAsInactiveFromKebabMenu();

            InvoicesPage invoicesPage = new InvoicesPage(driver);
            invoicesPage.Open();
            NewInvoicePage newInvoicePage = invoicesPage.AddNewInvoice();
            newInvoicePage.ClickCustomerNameField();
            newInvoicePage.PopulateCustomerName(displayName);

            Assert.That(newInvoicePage.IsAutoCompleteMessageDisplayed("No results found"), Is.True);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}
