using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Zoho.Tests.Selenium.Pages
{
    public class NewInvoicePage : Page
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

        public void ClickCustomerNameField()
        {
            By xPath = By.XPath("//label[text()='Customer Name']/following::div//div[contains(@class,'ac-selected')]");
            Func<IWebDriver, IWebElement> findCustomerNameField = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement customerNameField = Wait.Until(findCustomerNameField);
            customerNameField.Click();
        }

        public void PopulateCustomerName(string name)
        {
            By xPathSearch = By.XPath("//div[@class='ac-search']//input[@placeholder='Search']");
            Func<IWebDriver, IWebElement> findSearchField = ExpectedConditions.ElementIsVisible(xPathSearch);
            IWebElement searchField = Wait.Until(findSearchField);
            searchField.SendKeys(name);
            Thread.Sleep(500);//wait some time for search results to appear
        }

        public bool IsAutoCompleteMessageDisplayed(string text)
        {
            By xPath = By.XPath($"//div[@class='autocomplete-option' and text()='{text}']");
            Func<IWebDriver, IWebElement> findMessage = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement message = Wait.Until(findMessage);
            return message.Displayed;
        }

        public string GetCustomerName()
        {
            By xPath = By.XPath($"//label[text()='Customer Name']/following::div//div[contains(@class,'ac-selected')]/span");
            Func<IWebDriver, IWebElement> findCustomerName = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement customerName = Wait.Until(findCustomerName);
            return customerName.Text;
        }

        public void SelectCustomer(string customerDisplayName)
        {
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

        public void ClearInvoiceNumber()
        {
            By xPath = By.XPath("//label[text()='Invoice#']/following-sibling::div/input");
            Func<IWebDriver, IWebElement> findInvoiceNumber = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement invoiceNumber = Wait.Until(findInvoiceNumber);
            invoiceNumber.Clear();
        }

        public void CloseInvoicePreferencesPopup()
        {
            By xPath = By.XPath("//div[contains(@class,'modal-dialog')]//span[contains(@class,'close')]");
            Func<IWebDriver, IWebElement> findCloseButton = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement closeButton = Wait.Until(findCloseButton);
            closeButton.Click();
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

        public void ClearInvoiceDate()
        {
            By xPath = By.XPath("//label[text()='Invoice Date']/following-sibling::div/input");
            Func<IWebDriver, IWebElement> findInvoiceDate = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement invoiceDate = Wait.Until(findInvoiceDate);
            invoiceDate.Clear();
        }

        public bool IsErrorMessageVisible(string message)
        {
            By xPath = By.XPath($"//div[contains(@class,'alert')]/ul/li[@class='pe-4' and text()='{message}']");
            Func<IWebDriver, IWebElement> findErrorMessage = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement errorMessage = Wait.Until(findErrorMessage);
            return errorMessage.Displayed;
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

        public void ClearInvoiceDueDate()
        {
            By xPath = By.XPath("//p[text()='Due Date']/following::input");
            Func<IWebDriver, IWebElement> findInvoiceDueDate = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement invoiceDueDate = Wait.Until(findInvoiceDueDate);
            invoiceDueDate.Clear();
        }

        public void SelectTerms(string terms)
        {
            By xPath = By.XPath("//p[text()='Terms']/following::div[contains(@class,'payment-terms-selection')]");
            Func<IWebDriver, IWebElement> findTermsDropdown = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement termsDropdown = Wait.Until(findTermsDropdown);
            termsDropdown.Click();
            By xPathDropdownOption = By.XPath($"//div[@class='ac-dropdown-menu']//div[@title='{terms}']");
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

        public void DeleteItem(string itemName)
        {
            By xPath = By.XPath($"//tr//td//label[text()='{itemName}']//following::td[contains(@class,'item-amount')]//button[contains(@class,'icon-button')]");
            Func<IWebDriver, IWebElement> findDeleteButton = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement deleteButton = Wait.Until(findDeleteButton);
            deleteButton.Click();
        }

        public bool IsItemVisible(string itemName)
        {
            try
            {
                By xPath = By.XPath($"//label[text()='{itemName}']");
                Func<IWebDriver, IWebElement> findItemName = ExpectedConditions.ElementIsVisible(xPath);
                IWebElement item = Wait.Until(findItemName); //true -> when not present on the screen 
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public bool IsItemNotPresent(string itemName)
        {
            try
            {
                By xPath = By.XPath($"//label[text()='{itemName}']");
                Func<IWebDriver, bool> findItemName = ExpectedConditions.InvisibilityOfElementLocated(xPath);
                bool isInvisible = Wait.Until(findItemName); //true -> when not present on the screen 
                return isInvisible;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public double GetTotal()
        {
            By xPath = By.XPath("//div[text()='Total']/following-sibling::div[contains(@class,'total-amount')]");
            Func<IWebDriver, IWebElement> findTotal = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement total = Wait.Until(findTotal);

            return double.Parse(total.Text);
        }

        public void AddItemsInBulk()
        {
            By xPath = By.XPath("//button[text()='Add Items in Bulk']");
            Func<IWebDriver, IWebElement> findAddItemsInBulkButton = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement addItemsInBulkButton = Wait.Until(findAddItemsInBulkButton);
            addItemsInBulkButton.Click();
        }

        public void SelectItemFromAddItemsInBulkModal(string itemName)
        {
            By xPath = By.XPath($"//ul[contains(@class,'ac-dropdown-results')]/li[contains(@class,'ac-option')]//div[@title='{itemName}']");
            Func<IWebDriver, IWebElement> findItemListOption = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement itemListOption = Wait.Until(findItemListOption);
            itemListOption.Click();
        }

        public void AddItems()
        {
            By xPath = By.XPath("//button[@type='submit' and text()='Add Items']");
            Func<IWebDriver, IWebElement> findAddItemsButton = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement addItemsButton = Wait.Until(findAddItemsButton);
            addItemsButton.Click();
        }

        public void PopulateCustomerNotes(string note)
        {
            By xPath = By.XPath("//textarea[@aria-label='Customer Notes']");
            Func<IWebDriver, IWebElement> findTextField = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement textField = Wait.Until(findTextField);
            textField.Clear();
            textField.SendKeys(note);
        }

        public void AddTermsAndConditions()
        {
            By xPath = By.XPath("//button[text()='Add Terms and conditions']");
            Func<IWebDriver, IWebElement> findAddTermsAndConditionsButton = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement addTermsAndConditionsButton = Wait.Until(findAddTermsAndConditionsButton);
            addTermsAndConditionsButton.Click();
        }

        public void PopulateTermsAndConditions(string text)
        {
            By xPath = By.XPath("//label[text()='Terms & Conditions']/following::div/textarea");
            Func<IWebDriver, IWebElement> findTextField = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement textField = Wait.Until(findTextField);
            textField.SendKeys(text);
        }

        public void SaveAsDraft()
        {
            IWebElement saveAsDraftButton = driver.FindElement(By.XPath("//button[text()='Save as Draft']"));
            saveAsDraftButton.Click();
        }

        public bool IsSaveAsDraftButtonVisible()
        {
            By xPath = By.XPath("//button[text()='Save as Draft']");
            Func<IWebDriver, IWebElement> findSaveAsDraftButton = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement saveAsDraftButton = Wait.Until(findSaveAsDraftButton);

            return saveAsDraftButton.Displayed;
        }

        public void ClickCloseButton()
        {
            By xPath = By.XPath("//div[@class='header']/descendant::button[contains(@class,'close-details')]");
            Func<IWebDriver, IWebElement> findCloseButton = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement closeButton = Wait.Until(findCloseButton);
            closeButton.Click();
        }

        public void ClickLeaveButton()
        {
            By xPath = By.XPath("//div[@class='modal-footer']/child::button[text()='Leave & Discard Changes']");
            Func<IWebDriver, IWebElement> findLeaveButton = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement leaveButton = Wait.Until(findLeaveButton);
            leaveButton.Click();
        }

        public void ClickStayButton()
        {
            By xPtah = By.XPath("//div[@class='modal-footer']/child::button[text()='Stay Here']");
            Func<IWebDriver, IWebElement> findStayButton = ExpectedConditions.ElementIsVisible(xPtah);
            IWebElement stayButton = Wait.Until(findStayButton);

            stayButton.Click();
        }

        public void ClickSaveButton()
        {
            IWebElement saveButton = driver.FindElement(By.XPath("//button[text()='Save']"));
            saveButton.Click();
        }
    }
}