using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Zoho.Tests.Selenium.Pages
{
    public class CustomersPage : Page
    {
        private IWebDriver driver;

        public CustomersPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public void Open()
        {
            INavigation navigation = driver.Navigate();
            navigation.GoToUrl(TestConfigurations.ResolveUrl("#/contacts"));
            Func<IWebDriver, IWebElement> check = driver => driver.FindElement(By.TagName("body"));
            Wait.Until(check);

            SignIn();
        }

        public NewCustomerPage AddNewCustomer()
        {
            By xPath = By.XPath("//button[text()='New']");
            Func<IWebDriver, IWebElement> findNewCustomerButton = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement newCustomerButton = Wait.Until(findNewCustomerButton);
            newCustomerButton.Click();

            NewCustomerPage newCustomersPage = new NewCustomerPage(driver);
            return newCustomersPage;
        }

        public string GetSelectedCustomerTitle()
        {
            By xPath = By.XPath("//div[contains(@class,'details-actions-header')]/h3/div[contains(@class,'over-flow')]");
            Func<IWebDriver, IWebElement> findCustomerTitle = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement customerTitle = Wait.Until(findCustomerTitle);

            return customerTitle.Text;
        }

        public string GetActiveTabName()
        {
            By xPath = By.XPath("//div[@class='list-primary']/div[@class='name']/span[contains(@class,'active')]");
            Func<IWebDriver, IWebElement> findCustomerTab = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement customerTab = Wait.Until(findCustomerTab);
            return customerTab.Text;
        }

        public string GetCustomerType()
        {
            By xPath = By.XPath("//label[text()='Customer Type']/following-sibling::div//div[@class='flex-grow-1']");
            Func<IWebDriver, IWebElement> findCustomerType = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement customerType = Wait.Until(findCustomerType);
            return customerType.Text;
        }

        public void SearchForCustomer(string displayName)
        {
            By xPath = By.XPath("//input[@placeholder='Search in Customers ( / )']");
            Func<IWebDriver, IWebElement> findSearchField = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement searchField = Wait.Until(findSearchField);
            searchField.Click();
            searchField.SendKeys(displayName);
            searchField.SendKeys(Keys.Enter);

        }

        public bool SelectCustomer(string displayName)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
                By xPath = By.XPath($"//a[text()='{displayName}']");
                Func<IWebDriver, IWebElement> findCustomer = ExpectedConditions.ElementIsVisible(xPath);
                IWebElement customer = wait.Until(findCustomer);
                customer.Click();

                return true;
            }
            catch (WebDriverTimeoutException)
            {

                return false;
            }
        }

        public void ClickMoreOptionsButton()
        {
            By xPath = By.XPath("//div[@class='btn-toolbar']//button[text()='More']");
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