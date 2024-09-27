using NUnit.Framework;
using OpenQA.Selenium;
using Zoho.Tests.Selenium.Automations;
using Zoho.Tests.Selenium.Pages;

namespace Zoho.Tests.Selenium.Tests.Invoices
{
    public class CustomerNotesTests
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

        [TestCase("Anders", "Martinsson", "Martinsson, Anders", "Canary Testing Services", 230, "Please come again!")]
        public void TestAddingCustomerNotes(string firstName, string lastName, string displayName, string itemName, double price, string note)
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
            newInvoicePage.SelectItem(itemName);
            newInvoicePage.PopulateCustomerNotes(note);
            newInvoicePage.SaveAsDraft();

            string invoiceCustomerNotes = invoicesPage.GetCustomerNotes();
            Assert.That(invoiceCustomerNotes, Is.EqualTo(note));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}
