using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Zoho.Tests.Selenium.Pages
{
    public class ZohoPage
    {
        private IWebDriver driver;

        private string username;

        private string password;

        public WebDriverWait Wait { get; private set; }

        public ZohoPage(IWebDriver driver)
        {
            this.driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            username = TestConfigurations.GetDefaultUsername();
            password = TestConfigurations.GetDefaultPassword();
        }

        public void SignIn()
        {
            if (driver.Title == "Zoho Accounts") //if we are on the login page
            {
                IWebElement emailField = Wait.Until(d => d.FindElement(By.Id("login_id")));
                emailField.SendKeys(username);

                IWebElement nextButton = driver.FindElement(By.Id("nextbtn"));
                nextButton.Click();

                By xPath = By.Id("password");

                Func<IWebDriver, IWebElement> func = ExpectedConditions.ElementIsVisible(xPath);
                IWebElement passwordField = Wait.Until(func);
                passwordField.SendKeys(password);

                IWebElement signInLastButton = driver.FindElement(By.Id("nextbtn"));
                signInLastButton.Click();

                IWebElement profileIcon = Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("profile-section")));

                Assert.That(profileIcon.Displayed, Is.True);
            }
        }
    }
}