using OpenQA.Selenium;
using Zoho.Tests.Selenium.Pages;

namespace Zoho.Tests.Selenium.Automations
{
    public class PaymentsAutomation
    {
        private IWebDriver driver;
        private CustomersAutomation customersAutomation;

        public PaymentsAutomation(IWebDriver driver)
        {
            this.driver = driver;
            customersAutomation = new CustomersAutomation(driver);
        }

        public string CreatePayment(string firstName, string lastName, string displayName, double amount)
        {
            customersAutomation.CreateCustomer(firstName, lastName, displayName);

            PaymentsPage paymentsPage = new PaymentsPage(driver);
            paymentsPage.Open();
            NewPaymentPage newPaymentsPage = paymentsPage.AddNewPayment();
            newPaymentsPage.ClickCustomerNameField();
            newPaymentsPage.PopulateCustomerName(displayName);
            newPaymentsPage.SelectCustomer(displayName);
            newPaymentsPage.ChooseAmountReceived(amount);

            DateTime receiptDate = newPaymentsPage.GetReceiptDate();
            string receiptNumber = newPaymentsPage.GetReceiptNumber();

            newPaymentsPage.ClickSaveButton();
            newPaymentsPage.ClickContinueToSaveButton();

            paymentsPage.WaitToLoad();
            return receiptNumber;
        }
    }
}