using NUnit.Framework;
using OpenQA.Selenium;
using Zoho.Tests.Selenium.Automations;
using Zoho.Tests.Selenium.Pages;

namespace Zoho.Tests.Selenium.Tests.Invoices
{
    public class AddItemsInBulkTests
    {
        private IWebDriver driver;
        private ItemsAutomation itemsAutomation;

        [SetUp]
        public void SetUp()
        {
            driver = DriverFactory.CreateDriver();
            itemsAutomation = new ItemsAutomation(driver);
        }

        [TestCase("Usability Testing Services", 400, 2)]
        public void TestAddItemsInBulkFeature(string itemName, double price, int itemsNumber)
        {
            for (int i = 1; i <= itemsNumber; i++)
            {
                itemsAutomation.CreateItem($"{itemName} {i}", price, ItemType.Service);
            }
            Thread.Sleep(500); // otherwise the front end app navigates away after the item creation
            InvoicesPage invoicesPage = new InvoicesPage(driver);
            invoicesPage.Open();
            NewInvoicePage newInvoicePage = invoicesPage.AddNewInvoice();
            newInvoicePage.AddItemsInBulk();

            for (int i = 1; i <= itemsNumber; i++)
            {
                newInvoicePage.SelectItemFromAddItemsInBulkModal($"{itemName} {i}");
            }
            newInvoicePage.AddItems();

            for (int i = 1; i <= itemsNumber; i++)
            {
                Assert.That(newInvoicePage.IsItemVisible($"{itemName} {i}"), Is.True);
            }
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}
