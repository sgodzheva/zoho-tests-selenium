﻿using NUnit.Framework;
using OpenQA.Selenium;
using Zoho.Tests.Selenium.Automations;
using Zoho.Tests.Selenium.Pages;

namespace Zoho.Tests.Selenium.Tests.Invoices
{
    public class InvoiceItemsTests
    {
        private IWebDriver driver;
        private CustomersAutomation customersAutomation;

        [SetUp]
        public void SetUp()
        {
            driver = DriverFactory.CreateDriver();
            customersAutomation = new CustomersAutomation(driver);
        }

        [TestCase("Agnetha", "Fisker", "Fisker, Agnetha")]
        public void TestInvoiceCreationWithoutItems(string firstName, string lastName, string displayName)
        {
            customersAutomation.CreateCustomer(firstName, lastName, displayName);
            InvoicesPage invoicesPage = new InvoicesPage(driver);
            invoicesPage.Open();
            NewInvoicePage newInvoicePage = invoicesPage.AddNewInvoice();
            newInvoicePage.UseSimplifiedView();
            newInvoicePage.ClickCustomerNameField();
            newInvoicePage.PopulateCustomerName(displayName);
            newInvoicePage.SelectCustomer(displayName);
            newInvoicePage.SaveAsDraft();
            Assert.That(newInvoicePage.IsErrorMessageVisible("Enter the valid item name or description."), Is.True);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}