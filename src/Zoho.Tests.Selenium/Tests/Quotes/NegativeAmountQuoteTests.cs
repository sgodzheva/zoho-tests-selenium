using NUnit.Framework;
using OpenQA.Selenium;
using Zoho.Tests.Selenium.Automations;
using Zoho.Tests.Selenium.Pages;

namespace Zoho.Tests.Selenium.Tests.Quotes
{
    public class NegativeAmountQuoteTests
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

        [TestCase("Hilda", "Rosenberg", "Rosenberg, Hilda", "User Acceptance Testing Services", -50)]
        public void TestQuoteCreationWithNegativeAmount(string firstName, string lastName, string displayName, string itemName, double price)
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

            string errorMessage = newQuotePage.GetErrorMessage();
            Assert.That(errorMessage, Is.EqualTo("Please ensure that the total amount is greater than or equal to zero."));
        }

        [TearDown]
        public void ClearAfterEveryTest()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}