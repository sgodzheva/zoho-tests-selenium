using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Zoho.Tests.Selenium.Pages
{
    public class NewExpensePage : Page
    {
        private IWebDriver driver;

        public NewExpensePage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public void ClickCategoryNameField()
        {
            By xPath = By.XPath("//label[text()='Category Name']/following::div/span[text()='Select Category']");
            Func<IWebDriver, IWebElement> findCategoryNameField = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement categoryNameField = Wait.Until(findCategoryNameField);
            categoryNameField.Click();
        }

        public void ChooseCategoryName(string categoryName)
        {
            By xPath = By.XPath($"//li[@role='option']/div[@class='option-wrapper']/div[@title='{categoryName}']");
            Func<IWebDriver, IWebElement> findCategoryNameOption = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement categoryNameOption = Wait.Until(findCategoryNameOption);
            categoryNameOption.Click();
        }

        public void PopulateAmount(double amount)
        {
            By xPath = By.XPath("//label[text()='Amount']/following::div[@class='input-group']/input[@type='text']");
            Func<IWebDriver, IWebElement> findAmountField = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement amountField = Wait.Until(findAmountField);
            amountField.Click();
            amountField.SendKeys(amount.ToString());
        }

        public void ClickSaveButton()
        {
            By xPath = By.XPath("//button[@type='submit' and text()='Save ']");
            Func<IWebDriver, IWebElement> findSaveButton = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement saveButton = Wait.Until(findSaveButton);
            saveButton.Click();
        }
    }
}
