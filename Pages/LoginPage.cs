using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace LoginAutomationTest.Pages
{
    public class LoginPage : BasePage
    {
        
        public LoginPage(IWebDriver driver) : base(driver)
        { 

        }

        private By emailField = By.Id("username");
        private By passwordField = By.XPath("//input[@placeholder='Enter Password']");
        private By loginButton = By.XPath("//button[@type='submit']");
        private By continueButton = By.XPath("//button[contains(text(), 'Continue')]");
        private By otpField = By.XPath("/html/body/app-root/layout/empty-layout/div/div/auth-sign-in/section/div/div[2]/form/code-input/span[1]/input");
        private By submitButton = By.XPath("//button[contains(text(), 'Submit') or @type='submit']");
        private By userProfile = By.XPath("//fuse-vertical-navigation/div/div[2]/div[1]/div/div[2]/div[1]");
        private By errorMessage = By.XPath("//*[@id='toast-container']");

        public void Open(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void Login(string email, string password)
        {
            Type(emailField, email);
            Type(passwordField, password);
            Click(loginButton);
        }

        public void ClickContinueAuthentication()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(continueButton));
            Click(continueButton);
        }

        public void EnterOTPAndSubmit(string otp)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.Until(ExpectedConditions.ElementIsVisible(otpField));
            Type(otpField, otp);

            wait.Until(ExpectedConditions.ElementToBeClickable(submitButton));
            Click(submitButton);
        }

        public bool IsLoginSuccessful()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementIsVisible(userProfile));
                return Find(userProfile).Displayed;
            }
            catch
            {
                return false;
            }
        }

        public string GetErrorMessage()
        {
            try
            {
                return GetText(errorMessage);
            }
            catch
            {
                return "";
            }
        }
    }
}
