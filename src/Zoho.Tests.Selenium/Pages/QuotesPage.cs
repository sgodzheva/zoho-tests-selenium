using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Zoho.Tests.Selenium.Pages
{
    public class QuotesPage : Page
    {
        private IWebDriver driver;

        public QuotesPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public void Open()
        {
            INavigation navigation = driver.Navigate();
            navigation.GoToUrl(TestConfigurations.ResolveUrl("#/quotes"));
            Func<IWebDriver, IWebElement> check = ExpectedConditions.ElementIsVisible(By.TagName("body"));
            Wait.Until(check);

            SignIn();
        }

        public NewQuotePage AddNewQuote()
        {
            By xPath = By.XPath("//button[text()='New']");
            Func<IWebDriver, IWebElement> newQuoteButton = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement newButton = Wait.Until(newQuoteButton);
            newButton.Click();

            NewQuotePage newQuotePage = new NewQuotePage(driver);
            return newQuotePage;
        }

        public string GetSelectedQuoteID()
        {
            By xPath = By.ClassName("page-header-title");
            Func<IWebDriver, IWebElement> findTitleQuoteID = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement titleQuoteID = Wait.Until(findTitleQuoteID);
            return titleQuoteID.Text;
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

        public double GetLineItemDiscount(int lineItemNumber)
        {
            By xPath = By.XPath($"//tbody[@class='itemBody']/tr[{lineItemNumber}]/td[@id='tmp_item_discount']");
            Func<IWebDriver, IWebElement> findLineItemDiscount = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement lineItemDiscount = Wait.Until(findLineItemDiscount);

            string trimmedDiscount = lineItemDiscount.Text.TrimEnd('%');
            return double.Parse(trimmedDiscount);
        }

        public double GetQuoteSubTotal()
        {
            By xPath = By.XPath("//td[@id='tmp_subtotal']");
            Func<IWebDriver, IWebElement> findQuoteSubtotal = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement quoteSubtotal = Wait.Until(findQuoteSubtotal);
            return double.Parse(quoteSubtotal.Text);
        }

        public double GetQuoteShippingCharge()
        {
            By xPath = By.XPath("//tbody//td[@id='tmp_subtotal']/following::td[contains(@class,'total-section-value')]");
            Func<IWebDriver, IWebElement> findShippingCharge = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement shippingCharge = Wait.Until(findShippingCharge);
            return double.Parse(shippingCharge.Text);
        }

        public double GetQuoteTotal()
        {
            By xPath = By.XPath("//td[@id='tmp_total']");
            Func<IWebDriver, IWebElement> findQuoteTotal = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement quoteTotal = Wait.Until(findQuoteTotal);
            string trimmedTotal = quoteTotal.Text.TrimStart('$'); //remove leading dollar sign
            return double.Parse(trimmedTotal);
        }
    }
}