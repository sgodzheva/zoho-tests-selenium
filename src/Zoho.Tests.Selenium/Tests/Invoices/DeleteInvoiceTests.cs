using NUnit.Framework;
using OpenQA.Selenium;
using Zoho.Tests.Selenium.Automations;
using Zoho.Tests.Selenium.Pages;

namespace Zoho.Tests.Selenium.Tests.Invoices
{
    public class DeleteInvoiceTests
    {
        private IWebDriver driver;
        private InvoicesAutomation invoicesAutomation;

        [SetUp]
        public void SetUp()
        {
            driver = DriverFactory.CreateDriver();
            invoicesAutomation = new InvoicesAutomation(driver);
        }

        [TestCase("Helene", "Olander", "Olander, Helene", "Localization Testing Services", 330, 1)]
        public void TestInvoiceDeletion(string firstName, string lastName, string displayName, string itemName, double price, int itemNumber)
        {
            string invoiceNumber = invoicesAutomation.CreateInvoice(firstName, lastName, displayName, itemName, price, itemNumber);

            InvoicesPage invoicesPage = new InvoicesPage(driver);
            invoicesPage.SelectInvoiceCheckbox(invoiceNumber);
            invoicesPage.ClickKebabMenu();
            invoicesPage.DeleteInvoiceFromKebabMenu();

            invoicesPage.SearchForInvoice(invoiceNumber);
            Assert.That(invoicesPage.IsTableEmpty(), Is.True);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}
