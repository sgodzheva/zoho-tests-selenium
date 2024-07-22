using NUnit.Framework;
using OpenQA.Selenium;
using Zoho.Tests.Selenium.Pages;

namespace Zoho.Tests.Selenium.Tests.Customers
{
    public class BusinessCustomerTests
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = DriverFactory.CreateDriver();
        }

        public void CleanUp(string companyName)
        {
            CustomersPage customersPage = new CustomersPage(driver);
            customersPage.Open();
            if (customersPage.SelectCustomer(companyName))
            {
                customersPage.ClickMoreOptionsButton();
                customersPage.ClickDeleteButton();
                customersPage.ClickDeletePopupConfirmation();
            }
        }

        [TestCase("Ingrid", "Nygard", "Automated Tests LTD")]
        public void TestBusinessTypeCustomerCreation(string firstName, string lastName, string companyName)
        {
            CleanUp(companyName);

            CustomersPage customersPage = new CustomersPage(driver);
            customersPage.Open();

            NewCustomerPage newCustomerPage = customersPage.AddNewCustomer();
            newCustomerPage.SelectBusinessCustomerType();
            newCustomerPage.PopulateFirstName(firstName);
            newCustomerPage.PopulateLastName(lastName);
            newCustomerPage.PopulateCompanyName(companyName);
            newCustomerPage.SelectCustomerDisplayName(companyName);
            newCustomerPage.SaveCustomer();

            string title = customersPage.GetSelectedCustomerTitle();
            Assert.That(title, Is.EqualTo(companyName));

            string activeTabName = customersPage.GetActiveTabName();
            Assert.That(activeTabName, Is.EqualTo(companyName));

            string customerType = customersPage.GetCustomerType();
            Assert.That(customerType, Is.EqualTo("Business"));

            CleanUp(companyName);
        }

        [TearDown]
        public void ClearAfterEveryTest()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
