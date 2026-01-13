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

        public BasePage(IWebDriver driver) //constractor
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        // Find element with wait
        protected IWebElement Find(By locator)
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        // Click element with wait
        protected void Click(By locator)
        {
            IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            element.Click();
        }

        // Type text into field with wait
        protected void Type(By locator, string text)
        {
            IWebElement element = Find(locator);
            element.Clear();
            element.SendKeys(text);
        }

        // Get text from element
        protected string GetText(By locator)
        {
            return Find(locator).Text;
        }
    }
}
