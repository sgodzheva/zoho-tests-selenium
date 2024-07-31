using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Zoho.Tests.Selenium.Pages
{
    public class SignOutPage : Page
    {
        private IWebDriver driver;

        public SignOutPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public string GetSuccessMessage()
        {
            By xPath = By.XPath("//div[@class='log-msg']");
            Func<IWebDriver, IWebElement> findSuccessMessage = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement successMessage = Wait.Until(findSuccessMessage);
            return successMessage.Text;
        }

        public bool IsVisibleSignInButton()
        {
            By xpath = By.XPath("//a[@class='zgh-login']");
            Func<IWebDriver, IWebElement> findSignInButton = ExpectedConditions.ElementIsVisible(xpath);
            IWebElement signInButton = Wait.Until(findSignInButton);

            return signInButton.Text.Contains("SIGN IN");
        }
    }
}
