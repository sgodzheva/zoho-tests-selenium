using NUnit.Framework;
using OpenQA.Selenium;
using Zoho.Tests.Selenium.Automations;
using Zoho.Tests.Selenium.Pages;

namespace Zoho.Tests.Selenium.Tests.Payments
{
    public class DeletePaymentRecordTests
    {
        private IWebDriver driver;
        private CustomersAutomation customersAutomation;
        private PaymentsAutomation paymentsAutomation;

        [SetUp]
        public void SetUp()
        {
            driver = DriverFactory.CreateDriver();
            customersAutomation = new CustomersAutomation(driver);
            paymentsAutomation = new PaymentsAutomation(driver);
        }

        [TestCase("Beate", "Tolken", "Tolken, Beate", 300)]
        public void TestPaymentReceiptDeletion(string firstName, string lastName, string displayName, double amount)
        {
            customersAutomation.CreateCustomer(firstName, lastName, displayName);

            string receiptNumber = paymentsAutomation.CreatePayment(firstName, lastName, displayName, amount);

            PaymentsPage paymentsPage = new PaymentsPage(driver);
            paymentsPage.SelectPayment(receiptNumber);
            paymentsPage.ClickKebabMenu();
            paymentsPage.DeletePaymentFromKebabMenu();
            paymentsPage.ClickOkButton();
            driver.Navigate().Refresh();
            bool isPaymentVisible = paymentsPage.SelectPayment(receiptNumber);
            Assert.That(isPaymentVisible, Is.EqualTo(false));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}
