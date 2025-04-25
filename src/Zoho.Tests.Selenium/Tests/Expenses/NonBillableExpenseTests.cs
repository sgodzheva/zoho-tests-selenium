using NUnit.Framework;
using OpenQA.Selenium;
using Zoho.Tests.Selenium.Pages;

namespace Zoho.Tests.Selenium.Tests.Expenses
{
    public class NonBillableExpenseTests
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = DriverFactory.CreateDriver();
        }

        [TestCase("IT and Internet Expenses", 62.26)]
        public void TestBasicExpenseCreation(string categoryName, double amount)
        {
            ExpensesPage expensesPage = new ExpensesPage(driver);
            expensesPage.Open();
            NewExpensePage newExpensePage = expensesPage.AddNewExpense();
            newExpensePage.ClickCategoryNameField();
            newExpensePage.ChooseCategoryName(categoryName);
            newExpensePage.PopulateAmount(amount);
            newExpensePage.ClickSaveButton();

            string expenseAmount = expensesPage.GetExpenseAmount().TrimStart('$');
            Assert.That(expenseAmount, Is.EqualTo(amount.ToString()));

            string expenseCategoryName = expensesPage.GetCategoryName();
            Assert.That(expenseCategoryName, Is.EqualTo(categoryName));

            Assert.That(expensesPage.IsNonBillable, Is.True);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }


}
