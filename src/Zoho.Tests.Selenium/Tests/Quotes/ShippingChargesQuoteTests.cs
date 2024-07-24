using NUnit.Framework;
using OpenQA.Selenium;
using Zoho.Tests.Selenium.Automations;
using Zoho.Tests.Selenium.Pages;

namespace Zoho.Tests.Selenium.Tests.Quotes
{
    public class ShippingChargesQuoteTests
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

        [TestCase("Freya", "Thorsten", "Thorsten, Freya", "Combo Pack Ink Cartridges", 43.97, 15, 58.97)]
        [TestCase("Astrid", "Blom", "Blom, Astrid", "Printer Paper,8.5 x 11 Inches(500 Sheets)", 10, 0, 10.00)]
        public void TestQuoteCreationWithShippingCharges(string firstName, string lastName, string displayName, string itemName, double itemPrice, double shippingPrice, double expectedTotalPrice)
        {
            customersAutomation.CreateCustomer(firstName, lastName, displayName);

            itemsAutomation.CreateItem(itemName, itemPrice, ItemType.Goods);

            QuotesPage quotesPage = new QuotesPage(driver);
            quotesPage.Open();

            NewQuotePage newQuotePage = quotesPage.AddNewQuote();
            newQuotePage.DeselectSimplifiedView();
            newQuotePage.SelectCustomer(displayName);

            string quoteNumber = newQuotePage.GetQuoteNumber();

            newQuotePage.SelectItem(itemName);
            newQuotePage.PopulateShippingCharges(shippingPrice);
            newQuotePage.SaveAsDraft();

            string title = quotesPage.GetSelectedQuoteID();
            Assert.That(title, Is.EqualTo(quoteNumber));

            string lineItemName = quotesPage.GetLineItemName(1);
            Assert.That(lineItemName, Is.EqualTo(itemName));

            double lineItemQuantity = quotesPage.GetLineItemQuantity(1);
            Assert.That(lineItemQuantity, Is.EqualTo(1));

            double subTotal = quotesPage.GetQuoteSubTotal();
            Assert.That(subTotal, Is.EqualTo(itemPrice));

            if (shippingPrice > 0)
            {
                double shippingCharge = quotesPage.GetQuoteShippingCharge();
                Assert.That(Math.Round(shippingCharge), Is.EqualTo(shippingPrice));
            }

            double totalPrice = quotesPage.GetQuoteTotal();
            Assert.That(totalPrice, Is.EqualTo(expectedTotalPrice));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}