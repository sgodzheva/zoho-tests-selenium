﻿using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Zoho.Tests.Selenium.Pages
{
    public class NewItemPage : Page
    {
        private IWebDriver driver;

        public NewItemPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public void SelectServiceType()
        {
            By xPath = By.XPath("//input[@value='service']");
            Func<IWebDriver, IWebElement> findServiceRadioButton = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement serviceRadioButton = Wait.Until(findServiceRadioButton);
            serviceRadioButton.Click();
        }

        public void SelectGoodsType()
        {
            By xPath = By.XPath("//label[text()='Goods']");
            Func<IWebDriver, IWebElement> findGoodsRadioButton = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement goodsRadioButton = Wait.Until(findGoodsRadioButton);
            goodsRadioButton.Click();
        }

        public void PopulateName(string itemName)
        {
            By xPath = By.XPath("//legend[span[text()='Name']]/following-sibling::div//input");
            IWebElement nameField = driver.FindElement(xPath);
            nameField.Click();
            nameField.SendKeys(itemName);
        }

        public void ChooseSellingPrice(double price)
        {
            By xPath = By.XPath("//label[span/span[text()='Selling Price']]/following-sibling::div//input");
            IWebElement sellingPriceField = driver.FindElement(xPath);
            sellingPriceField.Click();
            sellingPriceField.SendKeys(price.ToString());
        }

        public void SaveItem()
        {
            IWebElement saveButton = driver.FindElement(By.XPath("//button[text()='Save']"));
            saveButton.Click();
        }


        public void UpdateSellingPrice(double price)
        {
            By xPath = By.XPath("//label[span/span[text()='Selling Price']]/following-sibling::div//input");
            Func<IWebDriver, IWebElement> findSellingPriceField = ExpectedConditions.ElementIsVisible(xPath);
            IWebElement sellingPriceField = Wait.Until(findSellingPriceField);
            sellingPriceField.Click();
            sellingPriceField.Clear();
            sellingPriceField.SendKeys(price.ToString());
        }
    }
}