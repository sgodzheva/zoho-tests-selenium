using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Zoho.Tests.Selenium.Pages
{
    public class NewCustomerPage : ZohoPage
    {
        private IWebDriver driver;

        public NewCustomerPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public void SelectIndividualCustomerType()
        {
            By xPath = By.XPath("//input[@value='individual']");
            Func<IWebDriver, IWebElement> findIndividualButton = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement individualRadioButton = Wait.Until(findIndividualButton);
            individualRadioButton.Click();
        }

        public void SelectBusinessCustomerType()
        {
            By xPath = By.XPath("//input[@value='business']");
            Func<IWebDriver, IWebElement> findBusinessRadioButton = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement businessRadioButton = Wait.Until(findBusinessRadioButton);
            businessRadioButton.Click();
        }

        public void PopulateFirstName(string firstName)
        {
            IWebElement firstNamePlaceholder = driver.FindElement(By.XPath("//input[@placeholder='First Name']"));
            firstNamePlaceholder.SendKeys(firstName);
        }

        public void PopulateLastName(string lastName)
        {
            IWebElement lastNamePlaceholder = driver.FindElement(By.XPath("//input[@placeholder='Last Name']"));
            lastNamePlaceholder.SendKeys(lastName);
        }

        public void PopulateCompanyName(string companyName)
        {
            By xPath = By.XPath("//label[text()='Company Name']/following-sibling::div/input[@type='text']");
            IWebElement companyNamePlaceholder = driver.FindElement(xPath);
            companyNamePlaceholder.SendKeys(companyName);
        }

        public void SelectCustomerDisplayName(string displayName)
        {
            IWebElement dropdown = driver.FindElement(By.XPath("//label[span/text()='Customer Display Name']/following-sibling::div//div[contains(@class,'ac-dropdown')]"));
            dropdown.Click();

            By xpath = By.XPath($"//div[@title='{displayName}']");
            Func<IWebDriver, IWebElement> findDropdownOptions = ExpectedConditions.ElementIsVisible(xpath);
            IWebElement dropdownOption = Wait.Until(findDropdownOptions);
            dropdownOption.Click();
        }

        public void SaveCustomer()
        {
            IWebElement saveButton = driver.FindElement(By.XPath("//button[@type='submit']"));
            saveButton.Click();

            Func<IWebDriver, IWebElement> findSuccessPopup = ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='The contact has been added.']"));
            Wait.Until(findSuccessPopup);
        }
    }
}