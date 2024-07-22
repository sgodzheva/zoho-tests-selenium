using NUnit.Framework;
using OpenQA.Selenium;
using Zoho.Tests.Selenium.Automations;
using Zoho.Tests.Selenium.Pages;

namespace Zoho.Tests.Selenium.Tests.Quotes
{
    public class DiscountedQuoteTests
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

        [TestCase("Jarl", "Gustavsson", "Gustavsson, Jarl", "GUI Testing Services", 240.75, 10, 216.67)]
        [TestCase("Klara", "Nordin", "Nordin, Klara", "Stress Testing Services", 240.75, 1, 238.34)]
        [TestCase("Hasse", "Mikaelsson", "Mikaelsson, Hasse", "Volume Testing Services", 240.75, 0, 240.75)]
        [TestCase("Gertrud", "Solberg", "Solberg, Gertrud", "Penetration Testing Services", 240.75, 99, 2.41)]
        [TestCase("Folke", "Larson", "Larson, Folke", "Load Testing Services", 240.75, 100, 0)]
        [TestCase("Kristin", "Bergman", "Bergman, Kristin", "regression Testing Services", 240.75, -5, 240.75)]
        public void TestDiscountedQuoteCreation(string firstName, string lastName, string displayName, string itemName, double price, double discount, double expectedPrice)
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
            newQuotePage.PopulateDiscount(1, discount);
            newQuotePage.ChooseDiscountType(1, "%");
            newQuotePage.SaveAsDraft();

            string title = quotesPage.GetSelectedQuoteID();
            Assert.That(title, Is.EqualTo(quoteNumber));

            string lineItemName = quotesPage.GetLineItemName(1);
            Assert.That(lineItemName, Is.EqualTo(itemName));

            double lineItemQuantity = quotesPage.GetLineItemQuantity(1);
            Assert.That(lineItemQuantity, Is.EqualTo(1));

            if (discount > 0)
            {
                double lineItemDiscount = quotesPage.GetLineItemDiscount(1);
                Assert.That(lineItemDiscount, Is.EqualTo(discount));
            }

            double subTotal = quotesPage.GetQuoteSubTotal();

            Assert.That(subTotal, Is.EqualTo(expectedPrice));

            double totalPrice = quotesPage.GetQuoteTotal();
            Assert.That(totalPrice, Is.EqualTo(expectedPrice));
        }

        [TearDown]
        public void CleanAfterEveryTest()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}