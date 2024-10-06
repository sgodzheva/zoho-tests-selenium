using NUnit.Framework;
using OpenQA.Selenium;
using Zoho.Tests.Selenium.Automations;
using Zoho.Tests.Selenium.Pages;

namespace Zoho.Tests.Selenium.Tests.Invoices
{
    public class TermsAndConditionsTests
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

        [TestCase("Carl", "Nilsson", "Nilsson, Carl", "Acceptance Testing Services", 500, "Invoice and purchase details must remain confidential.")]
        public void TestAddingTermsAndConditions(string firstName, string lastName, string displayName, string itemName, double price, string termsAndConditions)
        {
            customersAutomation.CreateCustomer(firstName, lastName, displayName);
            itemsAutomation.CreateItem(itemName, price, ItemType.Service);

            InvoicesPage invoicesPage = new InvoicesPage(driver);
            invoicesPage.Open();
            NewInvoicePage newInvoice = invoicesPage.AddNewInvoice();
            newInvoice.UseSimplifiedView();
            newInvoice.ClickCustomerNameField();
            newInvoice.PopulateCustomerName(displayName);
            newInvoice.SelectCustomer(displayName);
            newInvoice.SelectItem(itemName);
            newInvoice.AddTermsAndConditions();
            newInvoice.PopulateTermsAndConditions(termsAndConditions);
            newInvoice.SaveAsDraft();

            string invoiceTermsAndConditions = invoicesPage.GetTermsAndConditions();
            Assert.That(invoiceTermsAndConditions, Is.EqualTo(termsAndConditions));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}