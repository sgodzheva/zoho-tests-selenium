﻿using NUnit.Framework;
using OpenQA.Selenium;
using Zoho.Tests.Selenium.Automations;
using Zoho.Tests.Selenium.Pages;

namespace Zoho.Tests.Selenium.Tests.Invoices
{
    public class SimplifiedInvoiceTests
    {
        private IWebDriver driver;
        private CustomersAutomation customersAutomation;
        private ItemsAutomation itemsAutomation;

        [SetUp]
        public void SetUp()
        {
            driver = DriverFactory.CreateDriver();

            customersAutomation = new CustomersAutomation(driver);

            itemsAutomation = new ItemsAutomation(driver);
        }

        [TestCase("Fredrik", "Bergfalk", "Bergfalk, Fredrik", "Exploratory Testing Services", 140, "Due On Receipt")]
        public void TestBasicInvoiceCreation(string firstName, string lastName, string displayName, string itemName, double price, string terms)
        {
            customersAutomation.CreateCustomer(firstName, lastName, displayName);
            itemsAutomation.CreateItem(itemName, price, ItemType.Service);

            InvoicesPage invoicesPage = new InvoicesPage(driver);
            invoicesPage.Open();

            NewInvoicePage newInvoicePage = invoicesPage.AddNewInvoice();
            newInvoicePage.UseSimplifiedView();
            newInvoicePage.ClickCustomerNameField();
            newInvoicePage.PopulateCustomerName(displayName);
            newInvoicePage.SelectCustomer(displayName);

            string invoiceNumber = newInvoicePage.GetInvoiceNumber();

            DateTime invoiceDate = newInvoicePage.GetInvoiceDate();

            newInvoicePage.SelectTerms(terms);

            DateTime dueDate = newInvoicePage.GetInvoiceDueDate();

            newInvoicePage.SelectItem(itemName);
            newInvoicePage.SaveAsDraft();

            string invoiceTitleID = invoicesPage.GetSelectedInvoiceID();
            Assert.That(invoiceTitleID, Is.EqualTo(invoiceNumber));

            DateTime selectedInvoiceDate = invoicesPage.GetSelectedInvoiceDate();
            Assert.That(selectedInvoiceDate, Is.EqualTo(invoiceDate));

            string selectedTerms = invoicesPage.GetSelectedTerms();
            Assert.That(selectedTerms, Is.EqualTo(terms));

            DateTime selectedDueDate = invoicesPage.GetSelectedDueDate();
            Assert.That(selectedDueDate, Is.EqualTo(dueDate));

            string customername = invoicesPage.GetCustomerName();
            Assert.That(customername, Is.EqualTo(displayName));

            string lineItemName = invoicesPage.GetLineItemName(1);
            Assert.That(lineItemName, Is.EqualTo(itemName));

            double lineItemQuantity = invoicesPage.GetLineItemQuantity(1);
            Assert.That(lineItemQuantity, Is.EqualTo(1));

            double invoiceSubtotal = invoicesPage.GetInvoiceSubTotal();
            Assert.That(invoiceSubtotal, Is.EqualTo(price));

            double invoiceTotal = invoicesPage.GetInvoiceTotal();
            Assert.That(invoiceTotal, Is.EqualTo(price));

            double invoiceBalanceDue = invoicesPage.GetBalanceDue();
            Assert.That(invoiceBalanceDue, Is.EqualTo(price));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}