using NUnit.Framework;
using OpenQA.Selenium;
using Zoho.Tests.Selenium.Automations;
using Zoho.Tests.Selenium.Pages;

namespace Zoho.Tests.Selenium.Tests.Payments
{
    public class PaymentRecordTests
    {
        private IWebDriver driver;
        private CustomersAutomation customersAutomation;

        [SetUp]
        public void Setup()
        {
            driver = DriverFactory.CreateDriver();
            customersAutomation = new CustomersAutomation(driver);
        }

        [TestCase("Doris", "Robertsson", "Robertsson, Doris", 20)]
        public void TestPaymentRecordCreation(string firstName, string lastName, string displayName, double amount)
        {
            customersAutomation.CreateCustomer(firstName, lastName, displayName);

            PaymentsPage paymentsPage = new PaymentsPage(driver);
            paymentsPage.Open();
            NewPaymentPage newPaymentPage = paymentsPage.AddNewPayment();
            newPaymentPage.ClickCustomerNameField();
            newPaymentPage.PopulateCustomerName(displayName);
            newPaymentPage.SelectCustomer(displayName);
            newPaymentPage.ChooseAmountReceived(amount);
            DateTime onCreationReceiptDate = newPaymentPage.GetReceiptDate();
            string onCreationReceiptNumber = newPaymentPage.GetReceiptNumber();
            string defaultPaymentMode = newPaymentPage.GetPaymentMode();
            newPaymentPage.ClickSaveButton();
            newPaymentPage.ClickContinueToSaveButton();

            string receiptNumber = paymentsPage.GetReceiptNumber();
            Assert.That(receiptNumber, Is.EqualTo(onCreationReceiptNumber));

            DateTime receiptPaymentDate = paymentsPage.GetPaymentDate();
            Assert.That(receiptPaymentDate, Is.EqualTo(onCreationReceiptDate));

            string paymentMode = paymentsPage.GetPaymentMode();
            Assert.That(paymentMode, Is.EqualTo(defaultPaymentMode));


            string payerName = paymentsPage.GetPayerName();
            Assert.That(payerName, Is.EqualTo(displayName));

            double amountReceived = paymentsPage.GetAmountReceived();
            Assert.That(amountReceived, Is.EqualTo(amount));

            Assert.That(paymentsPage.IsBalanceTypeVisible("Over payment"), Is.True);

            double balanceAmount = paymentsPage.GetBalanceAmount("Over payment");
            Assert.That(balanceAmount, Is.EqualTo(amountReceived));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}