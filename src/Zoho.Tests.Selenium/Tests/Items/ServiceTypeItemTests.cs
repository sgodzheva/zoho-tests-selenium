using NUnit.Framework;
using OpenQA.Selenium;
using Zoho.Tests.Selenium.Pages;

namespace Zoho.Tests.Selenium.Tests.Items
{
    public class ServiceTypeItemTests
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = DriverFactory.CreateDriver();
        }

        public void CleanUp(string itemName)
        {
            ItemsPage itemsPage = new ItemsPage(driver);
            itemsPage.Open();

            if (itemsPage.SelectItem(itemName))
            {
                itemsPage.ClickMoreOptionsButton();
                itemsPage.ClickDeleteButton();
                itemsPage.ClickDeletePopupConfirmation();
            }
        }

        [TestCase("End-to-end Testing Services", 100)]
        public void TestServiceTypeItemCreation(string itemName, double price)
        {
            CleanUp(itemName);

            ItemsPage itemsPage = new ItemsPage(driver);
            itemsPage.Open();

            NewItemPage newItemPage = itemsPage.AddNewItem();

            newItemPage.SelectServiceType();

            newItemPage.PopulateName(itemName);

            newItemPage.ChooseSellingPrice(price);

            newItemPage.SaveItem();

            string title = itemsPage.GetSelectedItemTitle();
            Assert.That(title, Is.EqualTo(itemName));

            string activeTabName = itemsPage.GetActiveTabName();
            Assert.That(activeTabName, Is.EqualTo(itemName));

            string itemType = itemsPage.GetItemType();
            Assert.That(itemType, Is.EqualTo("Sales Items (Service)"));

            double itemSellingPrice = itemsPage.GetItemSellingPrice();
            Assert.That(itemSellingPrice, Is.EqualTo(price));

            CleanUp(itemName);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}