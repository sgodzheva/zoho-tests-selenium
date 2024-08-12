using NUnit.Framework;
using OpenQA.Selenium;
using Zoho.Tests.Selenium.Pages;

namespace Zoho.Tests.Selenium.Tests.Invoices
{
    public class CloseInvoiceTests
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = DriverFactory.CreateDriver();
        }

        [Test]
        public void TestClosingNewInvoiceCreation()
        {
            InvoicesPage invoicesPage = new InvoicesPage(driver);
            invoicesPage.Open();
            NewInvoicePage newInvoicePage = invoicesPage.AddNewInvoice();
            newInvoicePage.ClickCloseButton();

            Assert.That(invoicesPage.IsNewInvoiceButtonVisible(), Is.True);

            Assert.That(driver.Title, Is.EqualTo("Invoices | Zoho Invoice"));
        }

        [Test]
        public void TestCancellingInvoiceCreation()
        {
            InvoicesPage invoicesPage = new InvoicesPage(driver);
            invoicesPage.Open();
            NewInvoicePage newInvoicePage = invoicesPage.AddNewInvoice();
            newInvoicePage.SelectTerms("Due end of the month");
            newInvoicePage.ClickCloseButton();
            newInvoicePage.ClickLeaveButton();

            Assert.That(invoicesPage.IsNewInvoiceButtonVisible(), Is.True);

            Assert.That(driver.Title, Is.EqualTo("Invoices | Zoho Invoice"));
        }

        [Test]
        public void TestInterruptingInvoiceCreation()
        {
            InvoicesPage invoicesPage = new InvoicesPage(driver);
            invoicesPage.Open();
            NewInvoicePage newInvoicePage = invoicesPage.AddNewInvoice();
            newInvoicePage.SelectTerms("Net 15");
            newInvoicePage.ClickCloseButton();
            newInvoicePage.ClickStayButton();

            Assert.That(newInvoicePage.IsSaveAsDraftButtonVisible(), Is.True);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}