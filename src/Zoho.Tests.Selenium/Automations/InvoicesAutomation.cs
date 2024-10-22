using OpenQA.Selenium;
using Zoho.Tests.Selenium.Pages;

namespace Zoho.Tests.Selenium.Automations
{
    public class InvoicesAutomation
    {
        private IWebDriver driver;
        private CustomersAutomation customersAutomation;
        private ItemsAutomation itemsAutomation;

        public InvoicesAutomation(IWebDriver driver)
        {
            this.driver = driver;
            customersAutomation = new CustomersAutomation(driver);
            itemsAutomation = new ItemsAutomation(driver);
        }

        public string CreateInvoice(string firstName, string lastName, string displayName, string itemName, double price, int itemNumber)
        {
            customersAutomation.CreateCustomer(firstName, lastName, displayName);
            for (int i = 1; i <= itemNumber; i++)
            {
                itemsAutomation.CreateItem($"{itemName} {i}", price, ItemType.Service);
            }
            InvoicesPage invoicesPage = new InvoicesPage(driver);
            invoicesPage.Open();
            NewInvoicePage newInvoicePage = invoicesPage.AddNewInvoice();
            newInvoicePage.UseSimplifiedView();
            newInvoicePage.ClickCustomerNameField();
            newInvoicePage.PopulateCustomerName(displayName);
            newInvoicePage.SelectCustomer(displayName);
            string invoiceNumber = newInvoicePage.GetInvoiceNumber();
            for (int i = 1; i <= itemNumber; i++)
            {
                newInvoicePage.SelectItem($"{itemName} {i}");
            }
            newInvoicePage.SaveAsDraft();
            invoicesPage.WaitToLoad();
            return invoiceNumber;
        }
    }
}
