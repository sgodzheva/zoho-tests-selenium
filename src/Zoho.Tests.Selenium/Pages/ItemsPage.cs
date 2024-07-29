using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Zoho.Tests.Selenium.Pages
{
    public class ItemsPage : Page
    {
        private IWebDriver driver;

        public ItemsPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public void Open()
        {
            INavigation navigation = driver.Navigate();
            navigation.GoToUrl(TestConfigurations.ResolveUrl("#/inventory/items"));
            Func<IWebDriver, IWebElement> check = driver => driver.FindElement(By.TagName("body"));
            Wait.Until(check);

            SignIn();
        }

        public NewItemPage AddNewItem()
        {
            By xPath = By.XPath("//button[text()='New']");
            Func<IWebDriver, IWebElement> findNewItemButton = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement newItemButton = Wait.Until(findNewItemButton);
            newItemButton.Click();

            NewItemPage newItem = new NewItemPage(driver);
            return newItem;
        }

        public string GetSelectedItemTitle()
        {
            By xPath = By.XPath("//div[contains(@class,'details-actions-header')]/h3[contains(@class,'over-flow')]/span");
            Func<IWebDriver, IWebElement> findItemTitle = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement itemTitle = Wait.Until(findItemTitle);
            return itemTitle.Text;
        }

        public string GetActiveTabName()
        {
            By xPath = By.XPath("//div[contains(@class,'list-primary')]/descendant::div/a[contains(@class,'active')]");
            Func<IWebDriver, IWebElement> findItemTab = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement itemTab = Wait.Until(findItemTab);
            return itemTab.Text;
        }

        public string GetItemType()
        {
            By xPath = By.XPath("//label[text()='Item Type']/following-sibling::label");
            Func<IWebDriver, IWebElement> findItemType = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement itemType = Wait.Until(findItemType);
            return itemType.Text;
        }

        public double GetItemSellingPrice()
        {
            By xPath = By.XPath("//label[text()='Selling Price']/following-sibling::label");
            Func<IWebDriver, IWebElement> findSellingPrice = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement sellingPrice = Wait.Until(findSellingPrice);
            string trimmedPrice = sellingPrice.Text.TrimStart('$');
            return double.Parse(trimmedPrice);
        }

        public void SearchForItem(string name)
        {
            By xPath = By.XPath("//input[@placeholder='Search in Items ( / )']");
            Func<IWebDriver, IWebElement> findSearchField = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement searchField = Wait.Until(findSearchField);
            searchField.Click();
            searchField.SendKeys(name);
            searchField.SendKeys(Keys.Enter);
        }

        public bool SelectItem(string name)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
                By xPath = By.XPath($"//a[text()='{name}']");
                Func<IWebDriver, IWebElement> findItem = ExpectedConditions.ElementIsVisible(xPath);
                IWebElement item = wait.Until(findItem);
                item.Click();
                return true;
            }
            catch (WebDriverTimeoutException)
            {

                return false;
            }
        }

        public void ClickMoreOptionsButton()
        {
            By xPath = By.XPath("//button[contains(@class,'dropdown-toggle') and text()='More']");
            Func<IWebDriver, IWebElement> findMoreOptionsButton = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement moreOptionsButton = Wait.Until(findMoreOptionsButton);
            moreOptionsButton.Click();
        }

        public void ClickDeleteButton()
        {
            By xPath = By.XPath("//button[contains(@class,'dropdown-item') and text()='Delete']");
            Func<IWebDriver, IWebElement> findDeleteButton = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement deleteButton = Wait.Until(findDeleteButton);
            deleteButton.Click();
        }

        public void ClickDeletePopupConfirmation()
        {
            By xPath = By.XPath("//button[contains(@class,'btn-primary') and text()='Delete']");
            Func<IWebDriver, IWebElement> findPopupDeleteButton = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement popupDeleteButton = Wait.Until(findPopupDeleteButton);
            popupDeleteButton.Click();
        }
    }
}