using NUnit.Framework;
using OpenQA.Selenium;
using Zoho.Tests.Selenium.Automations;
using Zoho.Tests.Selenium.Pages;

namespace Zoho.Tests.Selenium.Tests.Customers
{
    public class CommentToExistingCustomerTests
    {
        private IWebDriver driver;
        private CustomersAutomation customersAutomation;


        [SetUp]
        public void SetUp()
        {
            driver = DriverFactory.CreateDriver();
            customersAutomation = new CustomersAutomation(driver);
        }

        [TestCase("Francis", "Lang", "Lang, Francis", "Customer contacted for payment reminder.")]
        public void TestAddingACommentToExistingCustomer(string firstName, string lastName, string displayName, string comment)
        {
            customersAutomation.CreateCustomer(firstName, lastName, displayName);
            CustomersPage customersPage = new CustomersPage(driver);
            customersPage.Open();
            customersPage.SelectCustomer(displayName);
            customersPage.ClickCommentsButton();
            customersPage.PopulateCustomerComment(comment);
            customersPage.ClickAddCommentButton();

            string customerComment = customersPage.GetTopCustomerCommentFromCommentTab();
            Assert.That(customerComment, Is.EqualTo(comment));

            DateTime commentDate = customersPage.GetTopCommentDateFromCommentTab();
            TestContext.WriteLine(commentDate);
            Assert.That(commentDate, Is.AtMost(DateTime.Now.AddMinutes(1)));
            Assert.That(commentDate, Is.AtLeast(DateTime.Now.Subtract(TimeSpan.FromMinutes(2))));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}
