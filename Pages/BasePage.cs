using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace LoginAutomationTest.Pages
{
    public class BasePage
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        protected IWebElement Find(By locator)
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        protected void Click(By locator)
        {
            IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            element.Click();
        }

        protected void Type(By locator, string text)
        {
            IWebElement element = Find(locator);
            element.Clear();
            element.SendKeys(text);
        }

        protected string GetText(By locator)
        {
            return Find(locator).Text;
        }
    }
}
