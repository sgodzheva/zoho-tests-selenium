using NUnit.Framework;
using OpenQA.Selenium;
using Zoho.Tests.Selenium.Automations;
using Zoho.Tests.Selenium.Pages;

namespace Zoho.Tests.Selenium.Tests.Invoices
{
    public class MultipleItemsInvoiceTests
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

        [TestCase("Gottfrid", "Olander", "Olander, Gottfrid", "Due On Receipt", "A/B Testing Services", 200, 2, 400)]
        public void TestInvoiceWithMultipleItems(string firstName, string lastName, string displayName, string terms, string itemName, double price, int itemsNumber, double expectedTotal)
        {
            customersAutomation.CreateCustomer(firstName, lastName, displayName);

            for (int i = 1; i <= itemsNumber; i++)
            {
                itemsAutomation.CreateItem($"{itemName} {i}", price, ItemType.Service);
            }

            InvoicesPage invoicesPage = new InvoicesPage(driver);
            invoicesPage.Open();

            NewInvoicePage newInvoicePage = invoicesPage.AddNewInvoice();
            newInvoicePage.UseSimplifiedView();
            newInvoicePage.ClickCustomerNameField();
            newInvoicePage.PopulateCustomerName(displayName);
            newInvoicePage.SelectCustomer(displayName);

            string invoiceNumber = newInvoicePage.GetInvoiceNumber();

            DateTime invoiceDate = newInvoicePage.GetInvoiceDate();

            newInvoicePage.SelectTerms(terms);

            DateTime dueDate = newInvoicePage.GetInvoiceDate();

            for (int i = 1; i <= itemsNumber; i++)
            {
                newInvoicePage.SelectItem($"{itemName} {i}");
            }

            double total = newInvoicePage.GetTotal();
            Assert.That(total, Is.EqualTo(expectedTotal));

            newInvoicePage.SaveAsDraft();

            string invoiceTitleID = invoicesPage.GetSelectedInvoiceID();
            Assert.That(invoiceTitleID, Is.EqualTo(invoiceNumber));

            DateTime selectedInvoiceDate = invoicesPage.GetSelectedInvoiceDate();
            Assert.That(selectedInvoiceDate, Is.EqualTo(invoiceDate));

            string selectedTerms = invoicesPage.GetSelectedTerms();
            Assert.That(selectedTerms, Is.EqualTo(terms));

            DateTime selectedDueDate = invoicesPage.GetSelectedDueDate();
            Assert.That(selectedDueDate, Is.EqualTo(dueDate));

            string customerName = invoicesPage.GetCustomerName();
            Assert.That(customerName, Is.EqualTo(displayName));

            for (int i = 1; i <= itemsNumber; i++)
            {
                string lineItemName = invoicesPage.GetLineItemName(i);
                Assert.That(lineItemName, Is.EqualTo($"{itemName} {i}"));

                double lineItemQuantity = invoicesPage.GetLineItemQuantity(i);
                Assert.That(lineItemQuantity, Is.EqualTo(1));
            }

            double invoiceSubtotal = invoicesPage.GetInvoiceSubTotal();
            Assert.That(invoiceSubtotal, Is.EqualTo(expectedTotal));

            double invoiceTotal = invoicesPage.GetInvoiceTotal();
            Assert.That(invoiceTotal, Is.EqualTo(expectedTotal));

            double invoiceBalanceDue = invoicesPage.GetBalanceDue();
            Assert.That(invoiceBalanceDue, Is.EqualTo(expectedTotal));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}
