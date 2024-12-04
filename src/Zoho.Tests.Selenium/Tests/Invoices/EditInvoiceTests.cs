using NUnit.Framework;
using OpenQA.Selenium;
using Zoho.Tests.Selenium.Automations;
using Zoho.Tests.Selenium.Pages;

namespace Zoho.Tests.Selenium.Tests.Invoices
{
    public class EditInvoiceTests
    {
        private IWebDriver driver;
        private CustomersAutomation customersAutomation;
        private ItemsAutomation itemsAutomation;
        private InvoicesAutomation invoicesAutomation;



        [SetUp]
        public void SetUp()
        {
            driver = DriverFactory.CreateDriver();
            customersAutomation = new CustomersAutomation(driver);
            itemsAutomation = new ItemsAutomation(driver);
            invoicesAutomation = new InvoicesAutomation(driver);
        }

        [Ignore("The search is currently not working")]
        [TestCase("Laurence", "Hansson", "Hansson, Laurence")]
        public void TestChangingInvoiceCustomerName(string updatedFirstName, string updatedLastName, string updatedDisplayName)
        {
            string firstName = "Gustav";
            string lastName = "Sigurdsson";
            string displayName = "Sigurdsson, Gustav";
            string itemName = "Spike Testing Services";
            double price = 225.35;
            int itemsNumber = 1;
            string invoiceNumber = invoicesAutomation.CreateInvoice(firstName, lastName, displayName, itemName, price, itemsNumber);

            customersAutomation.CreateCustomer(updatedFirstName, updatedLastName, updatedDisplayName);

            InvoicesPage invoicesPage = new InvoicesPage(driver);
            invoicesPage.Open();

            invoicesPage.SearchForInvoice(invoiceNumber);
            Thread.Sleep(1000);
            invoicesPage.SelectInvoice(invoiceNumber);
            NewInvoicePage editInvoicePage = invoicesPage.ClickEditButton();
            Thread.Sleep(1000);

            Assert.That(editInvoicePage.GetCustomerName(), Is.EqualTo(displayName));
            Assert.That(editInvoicePage.GetInvoiceNumber, Is.EqualTo(invoiceNumber));
            for (int i = 1; i <= itemsNumber; i++)
            {
                Assert.That(editInvoicePage.IsItemVisible($"{itemName} {i}"), Is.True);
            }
            Assert.That(editInvoicePage.GetTotal(), Is.EqualTo(price));

            editInvoicePage.ClickCustomerNameField();
            editInvoicePage.PopulateCustomerName(updatedDisplayName);
            editInvoicePage.SelectCustomer(updatedDisplayName);
            Thread.Sleep(1000);
            editInvoicePage.ClickSaveButton();
            Thread.Sleep(1000);
            string customerName = invoicesPage.GetCustomerName();
            Assert.That(customerName, Is.EqualTo(updatedDisplayName));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}
