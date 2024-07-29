using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Zoho.Tests.Selenium.Pages
{
    public class DashboardPage : Page
    {
        private IWebDriver driver;

        public DashboardPage(IWebDriver driver) : base(driver)
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

        public bool IsActiveSidebarButton(string buttonName)
        {
            By xPath = By.XPath($"//a[contains(@class,'nav-link' ) and text()='{buttonName}']");
            Func<IWebDriver, IWebElement> findActiveButton = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement activeButton = Wait.Until(findActiveButton);
            return activeButton.GetAttribute("class").Contains("active");
        }

        public bool IsActiveTab(string tabName)
        {
            string screenTab = $"#/home/{tabName}";
            By xPath = By.XPath($"//a[contains(@class,'nav-link' ) and @href='{screenTab}']");
            Func<IWebDriver, IWebElement> findActiveTab = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement activeTab = Wait.Until(findActiveTab);

            return activeTab.GetAttribute("class").Contains("active");
        }
    }
}