using NUnit.Framework;
using OpenQA.Selenium;
using Zoho.Tests.Selenium.Automations;
using Zoho.Tests.Selenium.Pages;

namespace Zoho.Tests.Selenium.Tests.Invoices
{
    public class VoidInvoiceTests
    {
        private IWebDriver driver;
        private InvoicesAutomation invoicesAutomation;

        [SetUp]
        public void SetUp()
        {
            driver = DriverFactory.CreateDriver();
            invoicesAutomation = new InvoicesAutomation(driver);
        }

        [TestCase("Hilde", "Lindgren", "Lindgren, Hilde", "Globalization Testing Services", 500, 1)]
        public void TestVoidingInvoice(string firstName, string lastName, string displayName, string itemName, double price, int itemNumber)
        {
            string invoiceNumber = invoicesAutomation.CreateInvoice(firstName, lastName, displayName, itemName, price, itemNumber);
            InvoicesPage invoicesPage = new InvoicesPage(driver);
            invoicesPage.SelectInvoice(invoiceNumber);
            invoicesPage.ClickKebabMenuSelectedInvoice();
            invoicesPage.ClickKebabMenuVoidButton();
            invoicesPage.PopulateTextForVoidingInvoice("The invoice was issued to the wrong customer.");
            invoicesPage.ClickVoidItButton();
            Assert.That(invoicesPage.IsInvoiceVoided(), Is.True);
            Assert.That(invoicesPage.IsEditButtonVisible, Is.False);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}
