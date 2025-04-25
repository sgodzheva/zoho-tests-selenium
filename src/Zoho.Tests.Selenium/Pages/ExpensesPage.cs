using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Zoho.Tests.Selenium.Pages
{
    public class ExpensesPage : Page
    {
        private IWebDriver driver;

        public ExpensesPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public void Open()
        {
            INavigation navigation = driver.Navigate();
            navigation.GoToUrl(TestConfigurations.ResolveUrl("#/expenses"));
            Func<IWebDriver, IWebElement> check = driver => driver.FindElement(By.TagName("body"));
            Wait.Until(check);

            SignIn();
        }

        public NewExpensePage AddNewExpense()
        {
            By xPath = By.XPath("//button[text()='New']");
            Func<IWebDriver, IWebElement> findNewButton = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement newButton = Wait.Until(findNewButton);
            newButton.Click();
            NewExpensePage newExpense = new NewExpensePage(driver);
            return newExpense;
        }

        public bool IsNonBillable()
        {
            By xPath = By.XPath("//p[contains(@class,'non-billable')]");
            Func<IWebDriver, IWebElement> findNonBillableElement = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement nonBillableElement = Wait.Until(findNonBillableElement);
            return nonBillableElement.Displayed;
        }

        public string GetExpenseAmount()
        {
            By xPath = By.XPath("//div[text()='Expense Amount']/following::span");
            Func<IWebDriver, IWebElement> findamount = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement amount = Wait.Until(findamount);
            return amount.Text;
        }

        public string GetCategoryName()
        {
            By xPath = By.XPath("//h4//span[contains(@class,'badge')]");
            Func<IWebDriver, IWebElement> findCategoryName = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement categoryName = Wait.Until(findCategoryName);
            return categoryName.Text;
        }
    }
}
