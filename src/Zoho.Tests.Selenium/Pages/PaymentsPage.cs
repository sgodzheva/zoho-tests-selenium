using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
namespace Zoho.Tests.Selenium.Pages

{
    public class PaymentsPage : Page
    {
        private IWebDriver driver;

        public PaymentsPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public void Open()
        {
            INavigation navigation = driver.Navigate();
            navigation.GoToUrl(TestConfigurations.ResolveUrl("#/paymentsreceived"));
            Func<IWebDriver, IWebElement> check = driver => driver.FindElement(By.TagName("body"));
            Wait.Until(check);

            SignIn();
        }

        public NewPaymentPage AddNewPayment()
        {
            By xPath = By.XPath("//button[text()='New']");
            Func<IWebDriver, IWebElement> findNewPaymentButton = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement newPaymentButton = Wait.Until(findNewPaymentButton);
            newPaymentButton.Click();

            NewPaymentPage newPaymentPage = new NewPaymentPage(driver);
            return newPaymentPage;
        }

        public string GetReceiptNumber()
        {
            By xPath = By.XPath("//span[@class='page-header-title']");
            Func<IWebDriver, IWebElement> findReceiptNumber = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement receiptNumber = Wait.Until(findReceiptNumber);
            return receiptNumber.Text;
        }

        public DateTime GetPaymentDate()
        {
            By xPath = By.XPath("//div[text()='Payment Date']//following::div/b");
            Func<IWebDriver, IWebElement> findPaymentDate = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement paymentDate = Wait.Until(findPaymentDate);

            string dateValue = paymentDate.Text;

            DateTime parsedDateValue = DateTime.Parse(dateValue);
            return parsedDateValue;
        }

        public string GetPaymentMode()
        {
            By xPath = By.XPath("//div[text()='Payment Mode']/following::div/b");
            Func<IWebDriver, IWebElement> findPaymentMode = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement paymentMode = Wait.Until(findPaymentMode);
            return paymentMode.Text;
        }

        public string GetPayerName()
        {
            By xPath = By.XPath("//p[text()='Received From']/following::a");
            Func<IWebDriver, IWebElement> findPayerName = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement payer = Wait.Until(findPayerName);
            return payer.Text;
        }

        public double GetAmountReceived()
        {
            By xPath = By.XPath("//span[text()=' Amount Received']/following::span[@class='pcs-total']");
            Func<IWebDriver, IWebElement> findAmountReceived = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement amountReceived = Wait.Until(findAmountReceived);

            string trimmedAmount = amountReceived.Text.TrimStart('$');

            double parsedAmount = double.Parse(trimmedAmount);
            return parsedAmount;
        }

        public bool IsBalanceTypeVisible(string balance)
        {
            try
            {
                By xPath = By.XPath($"//p[text()='{balance}']");
                Func<IWebDriver, IWebElement> findBalanceType = ExpectedConditions.ElementIsVisible(xPath);
                IWebElement balanceType = Wait.Until(findBalanceType);
                return balanceType.Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }

        }

        public double GetBalanceAmount(string balanceTypeName)
        {
            By xPath = By.XPath($"//p[text()='{balanceTypeName}']/following-sibling::div");
            Func<IWebDriver, IWebElement> findBalanceAmount = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement balanceAmount = Wait.Until(findBalanceAmount);

            string trimmedAmount = balanceAmount.Text.TrimStart('$');

            double parsedAmount = double.Parse(trimmedAmount);
            return parsedAmount;
        }

        public void WaitToLoad()
        {
            By xPath = By.XPath("//span[text()='All Received Payments']");
            Func<IWebDriver, IWebElement> findText = ExpectedConditions.ElementIsVisible(xPath);
            Wait.Until(findText);
        }

        public bool SelectPayment(string paymentNumber)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
                By xPath = By.XPath($"//a[text()='{paymentNumber}']");
                Func<IWebDriver, IWebElement> findPayment = ExpectedConditions.ElementIsVisible(xPath);
                IWebElement payment = Wait.Until(findPayment);
                payment.Click();
                return true;
            }
            catch (WebDriverTimeoutException)
            {

                return false;
            }
        }

        public void ClickKebabMenu()
        {
            By xPtah = By.XPath("//ul[contains(@class,'details-menu-bar')]/li[7]//button[contains(@class,'dropdown-toggle')]");
            Func<IWebDriver, IWebElement> findKebabMenu = ExpectedConditions.ElementIsVisible(xPtah);
            IWebElement kebabMenu = Wait.Until(findKebabMenu);
            kebabMenu.Click();
        }

        public void DeletePaymentFromKebabMenu()
        {
            By xPath = By.XPath("//button[text()='Delete']");
            Func<IWebDriver, IWebElement> findDeleteButton = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement deleteButton = Wait.Until(findDeleteButton);
            deleteButton.Click();
        }

        public void ClickRefundButton()
        {
            By xPath = By.XPath("//button[text()='Refund']");
            Func<IWebDriver, IWebElement> findRefundButton = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement refundButton = Wait.Until(findRefundButton);
            refundButton.Click();
        }

        public void ClickOkButton()
        {
            By xPath = By.XPath("//button[text()='OK']");
            Func<IWebDriver, IWebElement> findOkButton = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement okButton = Wait.Until(findOkButton);
            okButton.Click();
        }

        public void PopulateAmount(double amount)
        {
            By xPath = By.XPath("//label[text()='Amount']//following::span[text()='CAD']/following::input");
            Func<IWebDriver, IWebElement> findField = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement field = Wait.Until(findField);
            field.Click();
            field.SendKeys(Keys.Control + 'a');
            field.SendKeys(Keys.Delete);
            field.SendKeys(amount.ToString());
        }

        public void ClickSaveButton()
        {
            By xPath = By.XPath("//button[text()='Save']");
            Func<IWebDriver, IWebElement> findSaveButton = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement saveButton = Wait.Until(findSaveButton);
            saveButton.Click();
        }

        public void CloseActivePaymentReceipt()
        {
            By xPath = By.XPath("//button[@aria-label='Close']");
            Func<IWebDriver, IWebElement> findCloseButton = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement closeButton = Wait.Until(findCloseButton);
            closeButton.Click();
        }

        public bool IsUnusedAmountZero(string paymentNumber)
        {
            try
            {
                By xPath = By.XPath($"//td/following::a[text()='{paymentNumber}']/following::td[text()='$0.00']");
                Func<IWebDriver, IWebElement> findUnusedAmount = ExpectedConditions.ElementIsVisible(xPath);
                IWebElement unusedAmount = Wait.Until(findUnusedAmount);
                return unusedAmount.Displayed;
            }
            catch (WebDriverTimeoutException)
            {

                return false;
            }
        }

        public void ClickPdfPrintButton()
        {
            By xpath = By.XPath("//span[text()='PDF/Print']");
            Func<IWebDriver, IWebElement> findPdfPrintButton = ExpectedConditions.ElementIsVisible(xpath);
            IWebElement pdfPrintButton = Wait.Until(findPdfPrintButton);
            pdfPrintButton.Click();
        }

        public void ClickPdfButton()
        {
            By xpath = By.XPath("//button[text()='PDF']");
            Func<IWebDriver, IWebElement> findPdfButton = ExpectedConditions.ElementIsVisible(xpath);
            IWebElement pdfButton = Wait.Until(findPdfButton);
            pdfButton.Click();
        }
    }
}