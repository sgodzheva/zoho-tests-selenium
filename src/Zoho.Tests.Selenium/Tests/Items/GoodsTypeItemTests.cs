using NUnit.Framework;
using OpenQA.Selenium;
using Zoho.Tests.Selenium.Pages;

namespace Zoho.Tests.Selenium.Tests.Items
{
    public class GoodsTypeItemTests
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

        [TestCase("Canon PIXMA TS3720 All-in-One Printer", 59.97)]
        public void TestGoodsTypeItemCreation(string itemName, double price)
        {
            CleanUp(itemName);

            ItemsPage itemsPage = new ItemsPage(driver);
            itemsPage.Open();

            NewItemPage newItemPage = itemsPage.AddNewItem();

            newItemPage.SelectGoodsType();

            newItemPage.PopulateName(itemName);

            newItemPage.ChooseSellingPrice(price);

            newItemPage.SaveItem();

            string title = itemsPage.GetSelectedItemTitle();
            Assert.That(title, Is.EqualTo(itemName));

            string activeTabTitle = itemsPage.GetActiveTabName();
            Assert.That(activeTabTitle, Is.EqualTo(itemName));

            string itemType = itemsPage.GetItemType();
            Assert.That(itemType, Is.EqualTo("Sales Items"));

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