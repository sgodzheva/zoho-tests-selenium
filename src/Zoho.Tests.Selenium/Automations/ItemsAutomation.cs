using OpenQA.Selenium;
using Zoho.Tests.Selenium.Pages;

namespace Zoho.Tests.Selenium.Automations
{
    public class ItemsAutomation
    {
        private IWebDriver driver;

        public ItemsAutomation(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void CreateItem(string name, double price, ItemType type)
        {
            ItemsPage itemsPage = new ItemsPage(driver);
            itemsPage.Open();
            itemsPage.SearchForItem(name);
            bool successfullySelected = itemsPage.SelectItem(name);
            if (!successfullySelected)
            {
                NewItemPage newItemPage = itemsPage.AddNewItem();

                if (type == ItemType.Service)
                {
                    newItemPage.SelectServiceType();
                }
                else
                {
                    newItemPage.SelectGoodsType();
                }

                newItemPage.PopulateName(name);
                newItemPage.ChooseSellingPrice(price);
                newItemPage.SaveItem();
            }
        }

        public void DeleteItem(string itemName)
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
    }
}