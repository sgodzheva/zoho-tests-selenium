using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Zoho.Tests.Selenium.Pages
{
    public class SignInPage : Page
    {
        private IWebDriver driver;

        public SignInPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public void PopulateUsername(string username)
        {
            IWebElement emailField = Wait.Until(d => d.FindElement(By.Id("login_id")));
            emailField.SendKeys(username);

            IWebElement nextButton = driver.FindElement(By.Id("nextbtn"));
            nextButton.Click();
        }

        public void PopulatePassword(string password)
        {
            By xPath = By.Id("password");

            Func<IWebDriver, IWebElement> func = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement passwordField = Wait.Until(func);
            passwordField.SendKeys(password);
        }

        public void ClickSignInButton()
        {
            IWebElement signInLastButton = driver.FindElement(By.Id("nextbtn"));
            signInLastButton.Click();
            IWebElement profileIcon = Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("profile-section")));
        }
    }
}
