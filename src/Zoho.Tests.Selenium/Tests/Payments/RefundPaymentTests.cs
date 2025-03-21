using NUnit.Framework;
using OpenQA.Selenium;
using Zoho.Tests.Selenium.Automations;
using Zoho.Tests.Selenium.Pages;

namespace Zoho.Tests.Selenium.Tests.Payments
{
    public class RefundPaymentTests
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

        [TestCase("Hanna", "Solberg", "Solberg, Hanna", 400)]
        public void TestPaymentRefund(string firstName, string lastName, string displayName, double amount)
        {
            string paymentNumber = paymentsAutomation.CreatePayment(firstName, lastName, displayName, amount);
            PaymentsPage paymentsPage = new PaymentsPage(driver);
            paymentsPage.Open();
            driver.Navigate().Refresh();
            paymentsPage.SelectPayment(paymentNumber);
            paymentsPage.ClickKebabMenu();
            paymentsPage.ClickRefundButton();
            paymentsPage.ClickRefundTypeField();
            paymentsPage.SelectExcessAmountRefundType();
            paymentsPage.PopulateAmount(amount);
            paymentsPage.ClickSaveButton();

            Assert.That(paymentsPage.IsBalanceTypeVisible("Payment Refund"), Is.True);

            double amountReceived = paymentsPage.GetAmountReceived();
            double balanceAmount = paymentsPage.GetBalanceAmount("Payment Refund");
            Assert.That(balanceAmount, Is.EqualTo(amountReceived));

            paymentsPage.CloseActivePaymentReceipt();
            Assert.That(paymentsPage.IsUnusedAmountZero(paymentNumber), Is.True);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}
