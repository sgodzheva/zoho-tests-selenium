using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Zoho.Tests.Selenium.Pages
{
    public abstract class Page
    {
        private IWebDriver driver;

        private string username;

        private string password;

        public WebDriverWait Wait { get; private set; }

        public Page(IWebDriver driver)
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
                SignInPage signInPage = new SignInPage(driver);
                signInPage.PopulateUsername(username);
                signInPage.PopulatePassword(password);
                signInPage.ClickSignInButton();
            }
        }
    }
}