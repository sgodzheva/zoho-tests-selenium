using NUnit.Framework;
using OpenQA.Selenium;
using Zoho.Tests.Selenium.Pages;

namespace Zoho.Tests.Selenium.Tests.Invoices
{
    public class InvoiceDateTests
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = DriverFactory.CreateDriver();
        }

        [Test]
        public void TestInvoiceCreationWithoutDate()
        {
            InvoicesPage invoicesPage = new InvoicesPage(driver);
            invoicesPage.Open();
            NewInvoicePage newInvoicePage = invoicesPage.AddNewInvoice();
            newInvoicePage.ClearInvoiceDate();
            newInvoicePage.SaveAsDraft();

            Assert.That(newInvoicePage.IsErrorMessageVisible("Choose a valid Invoice Date"), Is.True);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}
