using NUnit.Framework;
using OpenQA.Selenium;
using Zoho.Tests.Selenium.Automations;
using Zoho.Tests.Selenium.Pages;

namespace Zoho.Tests.Selenium.Tests.Quotes
{
    public class BasicQuoteTests
    {
        private IWebDriver driver;
        private CustomersAutomation customersAutomation;
        private ItemsAutomation itemsAutomation;

        [SetUp]
        public void SetUp()
        {
            driver = DriverFactory.CreateDriver();

            customersAutomation = new CustomersAutomation(driver);
            itemsAutomation = new ItemsAutomation(driver);
        }

        [TestCase("Leif", "Haraldson", "Haraldson, Leif", "Smoke Testing Services", 150.75)]
        public void TestBasicQuoteCreation(string firstName, string lastName, string displayName, string itemName, double price)
        {
            customersAutomation.CreateCustomer(firstName, lastName, displayName);

            itemsAutomation.CreateItem(itemName, price, ItemType.Service);

            QuotesPage quotesPage = new QuotesPage(driver);
            quotesPage.Open();

            NewQuotePage newQuotePage = quotesPage.AddNewQuote();
            newQuotePage.UseSimplifiedView();
            newQuotePage.SelectCustomer(displayName);

            string quoteNumber = newQuotePage.GetQuoteNumber();

            newQuotePage.SelectItem(itemName);
            newQuotePage.SaveAsDraft();

            string titleQuoteID = quotesPage.GetSelectedQuoteID();
            Assert.That(titleQuoteID, Is.EqualTo(quoteNumber));

            string customername = quotesPage.GetCustomerName();
            Assert.That(customername, Is.EqualTo(displayName));

            string lineItemName = quotesPage.GetLineItemName(1);
            Assert.That(lineItemName, Is.EqualTo(itemName));

            double lineItemQuantity = quotesPage.GetLineItemQuantity(1);
            Assert.That(lineItemQuantity, Is.EqualTo(1));

            double quoteSubtotal = quotesPage.GetQuoteSubTotal();
            Assert.That(quoteSubtotal, Is.EqualTo(price));

            double quoteTotal = quotesPage.GetQuoteTotal();
            Assert.That(quoteTotal, Is.EqualTo(price));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}