using NUnit.Framework;
using OpenQA.Selenium;
using Zoho.Tests.Selenium.Automations;
using Zoho.Tests.Selenium.Pages;

namespace Zoho.Tests.Selenium.Tests.Invoices
{
    public class InvoiceDueDateTests
    {
        private IWebDriver driver;
        private CustomersAutomation customersAutomation;
        private ItemsAutomation itemsAutomation;

        [SetUp]
        public void SetUp()
        {
            driver = DriverFactory.CreateDriver();
            customersAutomation = new CustomersAutomation(driver);
            itemsAutomation = new ItemsAutomation(driver);
        }

        [TestCase("Folke", "Johansson", "Johansson, Folke", "System Testing Services", 300)]
        public void TestInvoiceCreationWithoutDueDate(string firstName, string lastName, string displayName, string itemName, double price)
        {
            customersAutomation.CreateCustomer(firstName, lastName, displayName);
            itemsAutomation.CreateItem(itemName, price, ItemType.Service);

            InvoicesPage invoicesPage = new InvoicesPage(driver);
            invoicesPage.Open();
            NewInvoicePage newInvoicePage = invoicesPage.AddNewInvoice();
            newInvoicePage.UseSimplifiedView();
            newInvoicePage.ClickCustomerNameField();
            newInvoicePage.PopulateCustomerName(displayName);
            newInvoicePage.SelectCustomer(displayName);

            DateTime invoiceDate = newInvoicePage.GetInvoiceDate();

            newInvoicePage.ClearInvoiceDueDate();
            newInvoicePage.SelectItem(itemName);
            newInvoicePage.SaveAsDraft();

            DateTime selectedDueDate = invoicesPage.GetSelectedDueDate();
            Assert.That(invoiceDate, Is.EqualTo(selectedDueDate));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}
