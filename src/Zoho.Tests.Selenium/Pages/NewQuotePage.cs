using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Zoho.Tests.Selenium.Pages
{
    public class NewQuotePage : ZohoPage
    {
        private IWebDriver driver;

        public NewQuotePage(IWebDriver driver) : base(driver)
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

        public void DeselectSimplifiedView()
        {
            By xPath = By.XPath("//label[span/text()='Use Simplified View']/following-sibling::span");
            Func<IWebDriver, IWebElement> findSimplifiedViewRadioButton = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement simplifiedViewRadioButton = Wait.Until(findSimplifiedViewRadioButton);

            var radioButtonClass = simplifiedViewRadioButton.GetAttribute("class");
            if (radioButtonClass.Contains("toggle-button-selected"))
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

        public string GetQuoteNumber()
        {
            By xPath = By.XPath("//label[text()='Quote#']/following-sibling::div/input");
            Func<IWebDriver, IWebElement> findQuoteNumber = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement quoteNumber = Wait.Until(findQuoteNumber);

            return quoteNumber.GetAttribute("value");
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

        public void PopulateDiscount(int lineItem, double number)
        {
            int index = lineItem - 1;
            By xPath = By.XPath($"//div[@data-integrity='line_items.{index}.discount']/input[@type='text']");
            Func<IWebDriver, IWebElement> findDiscountField = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement discoutField = Wait.Until(findDiscountField);
            discoutField.Click();
            discoutField.Clear();
            discoutField.SendKeys(number.ToString());
        }

        public void ChooseDiscountType(int lineItem, string type)
        {
            int index = lineItem - 1;
            By xPath = By.XPath($"//div[@data-integrity='line_items.{index}.discount']/div/button");
            Func<IWebDriver, IWebElement> findDiscountType = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement discountType = Wait.Until(findDiscountType);

            string discountTypeSign = discountType.Text;
            if (!discountTypeSign.Contains(type))
            {
                discountType.Click();
                By xPathDropdown = By.XPath($"//button[contains(@class,'dropdown-item') and text()='{type}']");
                Func<IWebDriver, IWebElement> findDropdownOption = ExpectedConditions.ElementIsVisible(xPathDropdown);
                IWebElement dropdownOption = Wait.Until(findDropdownOption);
                dropdownOption.Click();
            }
        }

        public void PopulateShippingCharges(double price)
        {
            By xPath = By.XPath("//div[text()='Shipping Charges']/following::div/input");
            Func<IWebDriver, IWebElement> findShippingChargesField = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement shippingChargesField = Wait.Until(findShippingChargesField);
            shippingChargesField.Click();
            shippingChargesField.SendKeys(price.ToString());
        }

        public void SaveAsDraft()
        {
            IWebElement saveAsDraftButton = driver.FindElement(By.XPath("//button[text()='Save as Draft']"));
            saveAsDraftButton.Click();
        }

        public string GetErrorMessage()
        {
            By xPath = By.XPath("//div[contains(@class,'alert-danger')]//li[@class='pe-4']");
            Func<IWebDriver, IWebElement> findErrormessage = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement errorMessage = Wait.Until(findErrormessage);

            return errorMessage.Text;
        }
    }
}