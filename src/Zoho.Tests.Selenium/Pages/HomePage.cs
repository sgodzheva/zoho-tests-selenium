using OpenQA.Selenium;

namespace Zoho.Tests.Selenium.Pages
{
    public class HomePage : ZohoPage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public void Open()
        {
            INavigation navigation = driver.Navigate();
            navigation.GoToUrl(TestConfigurations.ResolveUrl("#/home/dashboard"));
            Func<IWebDriver, IWebElement> check = driver => driver.FindElement(By.TagName("body"));
            Wait.Until(check);

            SignIn();
        }

        public CustomersPage GoToCustomersPage()
        {
            IWebElement customerButton = driver.FindElement(By.XPath("//a[text()='Customers']"));
            customerButton.Click();

            CustomersPage customersPage = new CustomersPage(driver);
            return customersPage;
        }

        public ItemsPage GoToItemsPage()
        {
            IWebElement itemButton = driver.FindElement(By.XPath("//a[text()='Items']"));
            itemButton.Click();

            ItemsPage itemsPage = new ItemsPage(driver);
            return itemsPage;
        }

        public QuotesPage GoToQuotesPage()
        {
            IWebElement quotesButton = driver.FindElement(By.XPath("//a[text()='Quotes']"));
            quotesButton.Click();
            QuotesPage quotesPage = new QuotesPage(driver);
            return quotesPage;
        }
    }
}
