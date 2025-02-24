using OpenQA.Selenium;
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

        public double GetBalanceAmount()
        {
            By xPath = By.XPath("//p[text()='Over payment']/following-sibling::div");
            Func<IWebDriver, IWebElement> findBalanceAmount = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement balanceAmount = Wait.Until(findBalanceAmount);

            string trimmedAmount = balanceAmount.Text.TrimStart('$');

            double parsedAmount = double.Parse(trimmedAmount);
            return parsedAmount;
        }
    }
}