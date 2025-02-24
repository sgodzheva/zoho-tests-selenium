using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Zoho.Tests.Selenium.Pages
{
    public class NewPaymentPage : Page
    {
        private IWebDriver driver;

        public NewPaymentPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public void ClickCustomerNameField()
        {
            By xPath = By.XPath("//span[text()='Select Customer']");
            Func<IWebDriver, IWebElement> findCustomerNameField = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement customerNameField = Wait.Until(findCustomerNameField);
            customerNameField.Click();
        }

        public void PopulateCustomerName(string customerDisplayName)
        {
            By xPathSearchField = By.XPath("//div[@class='ac-search']//input[@placeholder='Search']");
            Func<IWebDriver, IWebElement> findSearchFIeld = ExpectedConditions.ElementIsVisible(xPathSearchField);
            IWebElement searchField = Wait.Until(findSearchFIeld);
            searchField.SendKeys(customerDisplayName);
        }

        public void SelectCustomer(string customerDisplayName)
        {
            By xPath = By.XPath($"//div[@title='{customerDisplayName}']");
            Func<IWebDriver, IWebElement> findDropdownOption = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement dropdownOption = Wait.Until(findDropdownOption);
            dropdownOption.Click();
        }

        public void ChooseAmountReceived(double amount)
        {
            By xPath = By.XPath("//label[text()='Amount Received']/following-sibling::div//input");
            Func<IWebDriver, IWebElement> findAmoutReceivedField = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement amountReceivedField = Wait.Until(findAmoutReceivedField);
            amountReceivedField.Click();
            amountReceivedField.SendKeys(amount.ToString());
        }

        public DateTime GetReceiptDate()
        {
            By xPath = By.XPath("//label[text()='Payment Date']/following-sibling::div//input");
            Func<IWebDriver, IWebElement> findReceiptDate = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement receiptDate = Wait.Until(findReceiptDate);
            string dateValue = receiptDate.GetAttribute("value");

            DateTime parsedReceiptDate = DateTime.Parse(dateValue);
            return parsedReceiptDate;
        }

        public string GetReceiptNumber()
        {
            By xPath = By.XPath("//label[text()='Payment #']/following-sibling::div//input");
            Func<IWebDriver, IWebElement> findPaymentNumber = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement paymentNumber = Wait.Until(findPaymentNumber);

            return paymentNumber.GetAttribute("value");
        }

        public string GetPaymentMode()
        {
            By xPath = By.XPath("//label[text()='Payment Mode']//following::div[contains(@class,'ac-selected')]/span");
            Func<IWebDriver, IWebElement> findPaymentMode = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement paymentMode = Wait.Until(findPaymentMode);

            return paymentMode.Text;
        }

        public void ClickSaveButton()
        {
            IWebElement saveAsDraftButton = driver.FindElement(By.XPath("//button[text()='Save']"));
            saveAsDraftButton.Click();
        }

        public void ClickContinueToSaveButton()
        {
            By xPath = By.XPath("//button[text()='Continue to Save']");
            Func<IWebDriver, IWebElement> findContinueToSaveButton = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement continueToSaveButton = Wait.Until(findContinueToSaveButton);
            continueToSaveButton.Click();
        }
    }
}