using OpenQA.Selenium;
using Zoho.Tests.Selenium.Pages;

namespace Zoho.Tests.Selenium.Automations
{
    public class CustomersAutomation
    {
        private IWebDriver driver;

        public CustomersAutomation(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void CreateCustomer(string firstName, string lastName, string displayName)
        {
            CustomersPage customersPage = new CustomersPage(driver);
            customersPage.Open();
            customersPage.SearchForCustomer(displayName);

            bool successfullySelected = customersPage.SelectCustomer(displayName);
            if (!successfullySelected)
            {
                NewCustomerPage newCustomerPage = customersPage.AddNewCustomer();
                newCustomerPage.SelectIndividualCustomerType();
                newCustomerPage.PopulateFirstName(firstName);
                newCustomerPage.PopulateLastName(lastName);
                newCustomerPage.SelectCustomerDisplayName(displayName);
                newCustomerPage.SaveCustomer();
            }
        }
    }
}
