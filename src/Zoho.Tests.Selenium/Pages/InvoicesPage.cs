using OpenQA.Selenium;
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

        public bool IsNewInvoiceButtonVisible()
        {
            By xPath = By.XPath("//button[text()='New']");
            Func<IWebDriver, IWebElement> findNewInvoiceButton = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement newInvoiceButton = Wait.Until(findNewInvoiceButton);
            return newInvoiceButton.Displayed;
        }
    }
}