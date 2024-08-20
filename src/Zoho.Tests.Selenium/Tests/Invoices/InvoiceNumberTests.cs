using NUnit.Framework;
using OpenQA.Selenium;
using Zoho.Tests.Selenium.Pages;

namespace Zoho.Tests.Selenium.Tests.Invoices
{
    public class InvoiceNumberTests
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = DriverFactory.CreateDriver();
        }

        [Test]
        public void ValidateInvoiceNumberFormat()
        {
            InvoicesPage invoicesPage = new InvoicesPage(driver);
            invoicesPage.Open();

            NewInvoicePage newInvoicePage = invoicesPage.AddNewInvoice();
            string invoiceNumber = newInvoicePage.GetInvoiceNumber();

            Assert.That(invoiceNumber, Is.Not.Empty);
            Assert.That(invoiceNumber, Does.StartWith("INV-"));

            string trimmedNumber = invoiceNumber.Replace("INV-", string.Empty).Trim('0');
            Assert.That(() => int.Parse(trimmedNumber), Throws.Nothing);
        }

        [Test]
        public void TestInvoiceCreationWithoutNumber()
        {
            InvoicesPage invoicesPage = new InvoicesPage(driver);
            invoicesPage.Open();

            NewInvoicePage newInvoicePage = invoicesPage.AddNewInvoice();
            newInvoicePage.ClearInvoiceNumber();
            newInvoicePage.CloseInvoicePreferencesPopup();

            string invoiceNumber = newInvoicePage.GetInvoiceNumber();
            Assert.That(invoiceNumber, Is.Not.Empty);

            string trimmedNumber = invoiceNumber.Replace("INV-", string.Empty).Trim('0');
            Assert.That(() => int.Parse(trimmedNumber), Throws.Nothing);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}
