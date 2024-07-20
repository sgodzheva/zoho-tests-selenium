using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Zoho.Tests.Selenium.Pages;

namespace Zoho.Tests.Selenium.Tests.Customers
{
    public class IndividualCustomerTests
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            var options = new ChromeOptions();
            string folderPathToStoreSession = TestConfigurations.GetSessionLocation();
            options.AddArgument("--user-data-dir=" + folderPathToStoreSession);

            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
        }

        public void CleanUp(string customerDisplayName)
        {
            CustomersPage customersPage = new CustomersPage(driver);
            customersPage.Open();
            if (customersPage.SelectCustomer(customerDisplayName))
            {
                customersPage.ClickMoreOptionsButton();
                customersPage.ClickDeleteButton();
                customersPage.ClickDeletePopupConfirmation();
            }
        }

        [TestCase("Erik", "Ericsson", "Erik Ericsson")]
        [TestCase("Magnus", "Carlson", "Carlson, Magnus")]
        public void TestIndividualTypeCustomerCreation(string firstName, string lastName, string displayName)
        {
            // remove data from previous test runs and prepare for test execution
            CleanUp(displayName);

            CustomersPage customersPage = new CustomersPage(driver);
            customersPage.Open();

            NewCustomerPage newCustomerPage = customersPage.AddNewCustomer();
            newCustomerPage.SelectIndividualCustomerType();
            newCustomerPage.PopulateFirstName(firstName);
            newCustomerPage.PopulateLastName(lastName);
            newCustomerPage.SelectCustomerDisplayName(displayName);
            newCustomerPage.SaveCustomer();

            string title = customersPage.GetSelectedCustomerTitle();
            Assert.That(title, Is.EqualTo(displayName));

            string activeTabName = customersPage.GetActiveTabName();
            Assert.That(activeTabName, Is.EqualTo(displayName));

            string customerType = customersPage.GetCustomerType();
            Assert.That(customerType, Is.EqualTo("Individual"));

            // remove data after successful test run
            CleanUp(displayName);
        }

        [TearDown]
        public void CleanupAfterEveryTest()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
