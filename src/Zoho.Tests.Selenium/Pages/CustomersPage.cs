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
            By xPath = By.XPath("//span[text()='New']");
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
            By xPath = By.XPath("//div[@class='list-primary']/div/div[@class='name']/span[contains(@class,'active')]");
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

        public void SelectCustomerCheckbox(string displayName)
        {
            By xPath = By.XPath($"//td/a[text()='{displayName}']/parent::td/preceding-sibling::td/input[@type='checkbox']");
            Func<IWebDriver, IWebElement> findCustomerCheckbox = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement customerCheckbox = Wait.Until(findCustomerCheckbox);
            customerCheckbox.Click();
        }

        public void ClickKebabMenu()
        {
            By xPath = By.XPath("//div[contains(@class,'btn-toolbar')]//button[contains(@class,'dropdown-toggle')]");
            Func<IWebDriver, IWebElement> findKebabMenu = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement kebabMenu = Wait.Until(findKebabMenu);
            kebabMenu.Click();
        }

        public void MarkAsInactiveFromKebabMenu()
        {
            By xPath = By.XPath("//button[text()='Mark as Inactive']");
            Func<IWebDriver, IWebElement> findMarkAsInactiveButton = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement markAsInactiveButton = Wait.Until(findMarkAsInactiveButton);
            markAsInactiveButton.Click();
        }

        public bool IsMarkAsActiveButtonDisplayed()
        {
            By xPath = By.XPath("//button[text()='Mark as Active']");
            Func<IWebDriver, IWebElement> findMarkAsActiveButton = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement markAsActiveButton = Wait.Until(findMarkAsActiveButton);
            return markAsActiveButton.Displayed;
        }

        public void ClickCommentsButton()
        {
            By xPath = By.XPath("//a[text()='Comments']");
            Func<IWebDriver, IWebElement> findCommentsButton = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement commentsButton = Wait.Until(findCommentsButton);
            commentsButton.Click();
        }

        public void PopulateCustomerComment(string comment)
        {
            By xPath = By.XPath("//div[contains(@class,'add-comment-text-area')]//p");
            Func<IWebDriver, IWebElement> findTextArea = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement textArea = Wait.Until(findTextArea);
            textArea.Click();
            textArea.SendKeys($"{comment}");
        }

        public void ClickAddCommentButton()
        {
            By xPath = By.XPath("//button[text()='Add Comment']");
            Func<IWebDriver, IWebElement> findAddCommentButton = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement addCommentButton = Wait.Until(findAddCommentButton);
            addCommentButton.Click();
        }

        public string GetTopCustomerCommentFromCommentTab()
        {
            By xPath = By.XPath("//div[@class='zfrc-preview']//p[1]");
            Func<IWebDriver, IWebElement> findTopComment = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement topComment = Wait.Until(findTopComment);
            return topComment.Text;
        }

        public DateTime GetTopCommentDateFromCommentTab()
        {

            By xPath = By.XPath("//div[contains(@class,'comments-history')]/ul/li[1]//span[contains(@class,'date-formatted')]");
            Func<IWebDriver, IWebElement> findTopCommentDate = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement topCommentDate = Wait.Until(findTopCommentDate);
            string topCommentDateValue = topCommentDate.Text;

            DateTime parsedTopCommentDateValue = DateTime.Parse(topCommentDateValue);
            return parsedTopCommentDateValue;
        }
    }
}