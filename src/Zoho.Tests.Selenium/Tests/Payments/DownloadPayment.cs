using NUnit.Framework;
using OpenQA.Selenium;
using Zoho.Tests.Selenium.Automations;
using Zoho.Tests.Selenium.Pages;

namespace Zoho.Tests.Selenium.Tests.Payments
{
    public class DownloadPayment
    {
        private IWebDriver driver;
        private PaymentsAutomation paymentsAutomation;

        [SetUp]
        public void SetUp()
        {
            driver = DriverFactory.CreateDriver();
            paymentsAutomation = new PaymentsAutomation(driver);
        }

        [TestCase("Edwin", "Davidsen", "Davidsen, Edwin", 70)]
        public void TestPaymentDownload(string firstName, string lastName, string displayName, double amount)
        {
            string paymentNumber = paymentsAutomation.CreatePayment(firstName, lastName, displayName, amount);
            string fileName = $"Payment-{paymentNumber}.pdf";
            string fullPath = $"{TestConfigurations.GetDownloadLocation()}\\{fileName}";
            DeleteFile(fullPath);

            PaymentsPage paymentsPage = new PaymentsPage(driver);
            paymentsPage.Open();
            paymentsPage.SelectPayment(paymentNumber);
            paymentsPage.ClickPdfPrintButton();
            paymentsPage.ClickPdfButton();

            bool fileExists = paymentsPage.Wait.Until(x => File.Exists(fullPath));
            Assert.That(fileExists, Is.True);
        }

        private void DeleteFile(string fullPath)
        {
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}