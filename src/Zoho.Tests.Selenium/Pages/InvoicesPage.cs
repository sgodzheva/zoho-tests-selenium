using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Zoho.Tests.Selenium.Pages
{
    public class InvoicesPage : Page
    {
        private IWebDriver driver;


        public InvoicesPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public void Open()
        {
            INavigation navigation = driver.Navigate();
            navigation.GoToUrl(TestConfigurations.ResolveUrl("#/invoices"));
            Func<IWebDriver, IWebElement> check = driver => driver.FindElement(By.TagName("body"));
            Wait.Until(check);

            SignIn();

            By headingXPath = By.XPath("//span[text()='All Invoices']");
            Func<IWebDriver, IWebElement> findPageHeading = ExpectedConditions.ElementIsVisible(headingXPath);
            Wait.Until(findPageHeading);
        }

        public NewInvoicePage AddNewInvoice()
        {
            By xPath = By.XPath("//button[text()='New']");
            Func<IWebDriver, IWebElement> findNewInvoiceButton = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement newInvoiceButton = Wait.Until(findNewInvoiceButton);
            newInvoiceButton.Click();

            NewInvoicePage newInvoicePage = new NewInvoicePage(driver);
            return newInvoicePage;
        }

        public string GetSelectedInvoiceID()
        {
            By xPath = By.ClassName("page-header-title");
            Func<IWebDriver, IWebElement> findTitleInvoiceID = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement titleInvoiceID = Wait.Until(findTitleInvoiceID);
            return titleInvoiceID.Text;
        }

        public DateTime GetSelectedInvoiceDate()
        {
            By xPath = By.XPath("//span[@id='tmp_entity_date']");
            Func<IWebDriver, IWebElement> findInvoiceDate = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement invoiceDate = Wait.Until(findInvoiceDate);
            string date = invoiceDate.Text;

            DateTime parsedInvoiceDate = DateTime.Parse(date);
            return parsedInvoiceDate;
        }

        public string GetSelectedTerms()
        {
            By xPath = By.XPath("//span[@id='tmp_payment_terms']");
            Func<IWebDriver, IWebElement> findInvoiceTerms = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement invoiceTerms = Wait.Until(findInvoiceTerms);
            return invoiceTerms.Text;
        }

        public DateTime GetSelectedDueDate()
        {
            By xPath = By.XPath("//span[@id='tmp_due_date']");
            Func<IWebDriver, IWebElement> findInvoiceDueDate = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement invoiceDueDate = Wait.Until(findInvoiceDueDate);
            string dueDate = invoiceDueDate.Text;

            DateTime parsedDueDate = DateTime.Parse(dueDate);
            return parsedDueDate;
        }

        public string GetCustomerName()
        {
            By xPath = By.XPath("//span[@class='pcs-customer-name']/a");
            Func<IWebDriver, IWebElement> findCustomerName = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement customerName = Wait.Until(findCustomerName);
            return customerName.Text;
        }

        public string GetLineItemName(int lineItemNumber)
        {
            By xPath = By.XPath($"//tbody[@class='itemBody']/tr[{lineItemNumber}]//div/div/span");
            Func<IWebDriver, IWebElement> findLineItemName = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement lineItemName = Wait.Until(findLineItemName);
            return lineItemName.Text;
        }

        public double GetLineItemQuantity(int lineItemNumber)
        {
            By xPath = By.XPath($"//tr[{lineItemNumber}]/td[contains(@class,'pcs-item-row')]/span[@id='tmp_item_qty']");
            Func<IWebDriver, IWebElement> findLineItemQuantity = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement LineItemQuantity = Wait.Until(findLineItemQuantity);
            return double.Parse(LineItemQuantity.Text);
        }

        public double GetInvoiceSubTotal()
        {
            By xPath = By.XPath("//td[@id='tmp_subtotal']");
            Func<IWebDriver, IWebElement> findInvoiceSubtotal = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement invoiceSubtotal = Wait.Until(findInvoiceSubtotal);
            return double.Parse(invoiceSubtotal.Text);
        }

        public double GetInvoiceTotal()
        {
            By xPath = By.XPath("//td[@id='tmp_total']");
            Func<IWebDriver, IWebElement> findInvoiceTotal = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement invoiceTotal = Wait.Until(findInvoiceTotal);
            string trimmedTotal = invoiceTotal.Text.TrimStart('$'); //remove leading dollar sign
            return double.Parse(trimmedTotal);
        }

        public double GetBalanceDue()
        {
            By xPath = By.XPath("//td[@id='tmp_balance_due']");
            Func<IWebDriver, IWebElement> findBalanceDue = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement balanceDue = Wait.Until(findBalanceDue);
            string trimmedBalanceDue = balanceDue.Text.TrimStart('$'); //remove leading dollar sign
            return double.Parse(trimmedBalanceDue);
        }

        public string GetCustomerNotes()
        {
            By xPath = By.XPath("//p[@class='pcs-notes']");
            Func<IWebDriver, IWebElement> findCustomerNotes = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement customerNotes = Wait.Until(findCustomerNotes);
            return customerNotes.Text;
        }

        public string GetTermsAndConditions()
        {
            By xPath = By.XPath("//p[@class='pcs-terms']");
            Func<IWebDriver, IWebElement> findTermsAndConsitions = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement termsAndConditions = Wait.Until(findTermsAndConsitions);
            return termsAndConditions.Text;
        }

        public bool IsNewInvoiceButtonVisible()
        {
            By xPath = By.XPath("//button[text()='New']");
            Func<IWebDriver, IWebElement> findNewInvoiceButton = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement newInvoiceButton = Wait.Until(findNewInvoiceButton);
            return newInvoiceButton.Displayed;
        }

        public void WaitToLoad()
        {
            By xPath = By.XPath("//span[text()='All Invoices']");
            Func<IWebDriver, IWebElement> findText = ExpectedConditions.ElementIsVisible(xPath);
            Wait.Until(findText);
        }

        public void SearchForInvoice(string invoiceNumber)
        {
            By xPath = By.XPath("//input[@placeholder='Search in Invoices ( / )']");
            Func<IWebDriver, IWebElement> findSearchField = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement searchField = Wait.Until(findSearchField);
            searchField.Click();
            searchField.SendKeys(invoiceNumber);
            searchField.SendKeys(Keys.Enter);
        }
        public bool IsTableEmpty()
        {
            By xPath = By.XPath("//tr[@class='empty-list']/td/h4[text()='There are no invoices']");
            Func<IWebDriver, IWebElement> findTableResult = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement tableResult = Wait.Until(findTableResult);
            return true;
        }

        public bool SelectInvoice(string invoiceNumber)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
                By xPath = By.XPath($"//a[text()='{invoiceNumber}']");
                Func<IWebDriver, IWebElement> findInvoiceResult = ExpectedConditions.ElementIsVisible(xPath);
                IWebElement invoiceResult = wait.Until(findInvoiceResult);
                invoiceResult.Click();
                return true;

            }
            catch (WebDriverTimeoutException)
            {

                return false;
            }
        }

        public void SelectInvoiceCheckbox(string invoiceNumber)
        {
            By xPath = By.XPath($"//input[@aria-label='Select Invoice {invoiceNumber}']");
            Func<IWebDriver, IWebElement> findCheckbox = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement checkbox = Wait.Until(findCheckbox);
            checkbox.Click();
        }

        public void ClickKebabMenu()
        {
            By xPath = By.XPath("//div[contains(@class,'btn-toolbar')]//button[contains(@class,'dropdown-toggle')]");
            Func<IWebDriver, IWebElement> findKebabMenu = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement kebabMenu = Wait.Until(findKebabMenu);
            kebabMenu.Click();
        }

        public void DeleteInvoiceFromKebabMenu()
        {
            By xPath = By.XPath("//button[text()='Delete']");
            Func<IWebDriver, IWebElement> findDeleteButton = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement deleteButton = Wait.Until(findDeleteButton);
            deleteButton.Click();

            By okButtonPopupXPath = By.XPath("//button[text()='OK']");
            Func<IWebDriver, IWebElement> findOkButton = ExpectedConditions.ElementIsVisible(okButtonPopupXPath);
            IWebElement okButton = Wait.Until(findOkButton);
            okButton.Click();
        }

        public NewInvoicePage ClickEditButtonSelectedInvoice()
        {
            By xPath = By.XPath("//span[@class='ps-1' and text()='Edit']");
            Func<IWebDriver, IWebElement> findEditButton = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement editButton = Wait.Until(findEditButton);
            editButton.Click();

            NewInvoicePage newInvoicePage = new NewInvoicePage(driver);
            return newInvoicePage;
        }

        public bool IsEditButtonVisible()
        {
            try
            {
                By xPath = By.XPath("//span[@class='ps-1' and text()='Edit']");
                Func<IWebDriver, IWebElement> findEditButton = ExpectedConditions.ElementIsVisible(xPath);
                IWebElement editButton = Wait.Until(findEditButton);
                return editButton.Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public void ClickKebabMenuSelectedInvoice()
        {
            By xPath = By.XPath("//ul[contains(@class,'details-menu-bar')]/li[6]/button[contains(@class,'dropdown-toggle')]");
            Func<IWebDriver, IWebElement> findKebabMenuSelectedInvoice = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement kebabMenuSelectedInvoice = Wait.Until(findKebabMenuSelectedInvoice);
            kebabMenuSelectedInvoice.Click();
        }

        public void ClickKebabMenuVoidButton()
        {
            By xPath = By.XPath("//button[text()='Void']");
            Func<IWebDriver, IWebElement> findVoidButton = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement voidButton = Wait.Until(findVoidButton);
            voidButton.Click();
        }

        public void PopulateTextForVoidingInvoice(string text)
        {
            By xPath = By.XPath("//div[contains(@class,'form-group')]/textarea");
            Func<IWebDriver, IWebElement> findTextField = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement textField = Wait.Until(findTextField);
            textField.Click();
            textField.SendKeys(text);
        }

        public void ClickVoidItButton()
        {
            By xPath = By.XPath("//button[text()='Void it']");
            Func<IWebDriver, IWebElement> findVoidItButton = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement voidItButton = Wait.Until(findVoidItButton);
            voidItButton.Click();
        }

        public bool IsInvoiceVoided()
        {
            By xPath = By.XPath("//div[contains(@class,'ribbon-inner') and contains(text(),'Void')]");
            Func<IWebDriver, IWebElement> findVoidRibbon = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement voidRibbon = Wait.Until(findVoidRibbon);
            return voidRibbon.Displayed;
        }
    }
}