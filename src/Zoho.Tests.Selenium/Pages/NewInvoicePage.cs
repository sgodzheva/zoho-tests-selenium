using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Zoho.Tests.Selenium.Pages
{
    public class NewInvoicePage : ZohoPage
    {
        private IWebDriver driver;

        public NewInvoicePage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public void UseSimplifiedView()
        {
            By xPath = By.XPath("//label[span/text()='Use Simplified View']/following-sibling::span");
            Func<IWebDriver, IWebElement> findSimplifiedViewRadioButton = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement simplifiedViewRadioButton = Wait.Until(findSimplifiedViewRadioButton);

            var radioButtonClass = simplifiedViewRadioButton.GetAttribute("class");
            if (!radioButtonClass.Contains("toggle-button-selected"))
            {
                simplifiedViewRadioButton.Click();
            }
        }

        public void SelectCustomer(string customerDisplayName)
        {
            By xPath = By.XPath("//span[text()='Select or add a customer']");
            Func<IWebDriver, IWebElement> findCustomerNameField = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement customerNameField = Wait.Until(findCustomerNameField);
            customerNameField.Click();

            By xPathDropdown = By.XPath($"//div[@title='{customerDisplayName}']");
            Func<IWebDriver, IWebElement> findDropdownOption = ExpectedConditions.ElementIsVisible(xPathDropdown);
            IWebElement dropdownOption = Wait.Until(findDropdownOption);
            dropdownOption.Click();
        }

        public string GetInvoiceNumber()
        {
            By xPath = By.XPath("//label[text()='Invoice#']/following-sibling::div/input");
            Func<IWebDriver, IWebElement> findInvoiceNumber = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement invoiceNumber = Wait.Until(findInvoiceNumber);

            return invoiceNumber.GetAttribute("value");
        }

        public DateTime GetInvoiceDate()
        {
            By xPath = By.XPath("//label[text()='Invoice Date']/following-sibling::div/input");
            Func<IWebDriver, IWebElement> findInvoiceDate = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement invoiceDate = Wait.Until(findInvoiceDate);
            string dateValue = invoiceDate.GetAttribute("value");

            DateTime parsedInvoiceDateTime = DateTime.Parse(dateValue);
            return parsedInvoiceDateTime;
        }

        public DateTime GetInvoiceDueDate()
        {
            By xPath = By.XPath("//p[text()='Due Date']/following::input");
            Func<IWebDriver, IWebElement> findInvoiceDueDate = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement invoiceDueDate = Wait.Until(findInvoiceDueDate);
            string dueDateValue = invoiceDueDate.GetAttribute("value");

            DateTime parsedInvoiceDueDate = DateTime.Parse(dueDateValue);
            return parsedInvoiceDueDate;
        }

        public void SelectTerms(string terms)
        {
            By xPath = By.XPath("//p[text()='Terms']/following::div[contains(@class,'payment-terms-selection')]");
            Func<IWebDriver, IWebElement> findTermsDropdown = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement termsDropdown = Wait.Until(findTermsDropdown);
            termsDropdown.Click();

            By xPathDropdownOption = By.XPath($"//span[text()='{terms}']");
            Func<IWebDriver, IWebElement> findDropdownOption = ExpectedConditions.ElementIsVisible(xPathDropdownOption);
            IWebElement dropdownOption = Wait.Until(findDropdownOption);
            dropdownOption.Click();
        }

        public void SelectItem(string itemName)
        {
            By xPathTextField = By.XPath("//textarea[@placeholder='Type or click to select an item.']");
            IWebElement itemTextField = driver.FindElement(xPathTextField);
            itemTextField.Click();
            Func<IWebDriver, IWebElement> findDropdownOptionsItem = ExpectedConditions.ElementIsVisible(By.XPath($"//div[@title='{itemName}']"));
            IWebElement dropdownOptionItem = Wait.Until(findDropdownOptionsItem);
            dropdownOptionItem.Click();

            By xPathNextLineItem = By.XPath("//textarea[@placeholder='Type or click to select an item.']");
            Func<IWebDriver, IWebElement> findNextLineItem = ExpectedConditions.ElementIsVisible(xPathNextLineItem);
            IWebElement nextLineItem = Wait.Until(findNextLineItem);
        }

        public void SaveAsDraft()
        {
            IWebElement saveAsDraftButton = driver.FindElement(By.XPath("//button[text()='Save as Draft']"));
            saveAsDraftButton.Click();
        }
    }
}