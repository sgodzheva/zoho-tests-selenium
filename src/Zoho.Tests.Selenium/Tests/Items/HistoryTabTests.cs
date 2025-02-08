using NUnit.Framework;
using OpenQA.Selenium;
using Zoho.Tests.Selenium.Automations;
using Zoho.Tests.Selenium.Pages;

namespace Zoho.Tests.Selenium.Tests.Items
{
    public class HistoryTabTests
    {
        private IWebDriver driver;
        private ItemsAutomation itemsAutomation;

        [SetUp]
        public void SetUp()
        {
            driver = DriverFactory.CreateDriver();
            itemsAutomation = new ItemsAutomation(driver);
        }

        [TestCase("Printer Brother HL-L2400D", 159.98)]
        public void TestNewItemEntryCreation(string itemName, double price)
        {
            itemsAutomation.DeleteItem(itemName);

            itemsAutomation.CreateItem(itemName, price, ItemType.Goods);

            ItemsPage itemsPage = new ItemsPage(driver);
            itemsPage.Open();
            itemsPage.SelectItem(itemName);
            itemsPage.ClickHistoryTab();

            DateTime entryDate = itemsPage.GetTopEntryDateFromHistoryTab();
            Assert.That(entryDate, Is.AtMost(DateTime.Now.AddMinutes(1)));
            Assert.That(entryDate, Is.AtLeast(DateTime.Now.Subtract(TimeSpan.FromMinutes(2))));

            string entryDetailText = itemsPage.GetTopEntryDetailsText();
            Assert.That(entryDetailText, Is.EqualTo("created by"));
        }

        [TestCase("Logitech MX Master 2S", 99.99, 109.99)]
        public void TestUpdatedItemEntryCreation(string itemName, double price, double updatedPrice)
        {
            itemsAutomation.DeleteItem(itemName);

            itemsAutomation.CreateItem(itemName, price, ItemType.Goods);

            ItemsPage itemsPage = new ItemsPage(driver);
            itemsPage.Open();
            itemsPage.SelectItem(itemName);
            NewItemPage editItemPage = itemsPage.ClickEditButton();
            editItemPage.UpdateSellingPrice(updatedPrice);
            editItemPage.SaveItem();
            itemsPage.ClickHistoryTab();

            DateTime entryDate = itemsPage.GetTopEntryDateFromHistoryTab();
            Assert.That(entryDate, Is.AtMost(DateTime.Now.AddMinutes(1)));
            Assert.That(entryDate, Is.AtLeast(DateTime.Now.Subtract(TimeSpan.FromMinutes(2))));

            string entryDetailText = itemsPage.GetTopEntryDetailsText();
            Assert.That(entryDetailText, Is.EqualTo("updated by"));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}
