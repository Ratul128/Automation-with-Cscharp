using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using LoginAutomationTest.Pages;
using LoginAutomationTest.Utils;
using Newtonsoft.Json.Linq;
using System.IO;

namespace LoginAutomationTest.Tests
{
    public class LoginTests
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private string baseUrl;

        [SetUp]
        public void Setup()
        {
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();

            baseUrl = ConfigReader.Config["BaseUrl"];
            loginPage = new LoginPage(driver); //constractor
        }

        [Test]
        public void Successful_Login_Test()
        {
            var data = JObject.Parse(File.ReadAllText("Data/testdata.json"))["positive_case"];

            // Step 1: Open URL
            loginPage.Open(baseUrl);
            //WaitHelper.Wait();

            // Step 2: Login with username & password
            loginPage.Login(
                data["email"].ToString(),
                data["password"].ToString()
            );
            //WaitHelper.Wait(2);

            // Step 3: Click Continue Authentication
            loginPage.ClickContinueAuthentication();
            //WaitHelper.Wait(2);

            // Step 4: Enter OTP and Submit
            loginPage.EnterOTPAndSubmit("1111");
            //WaitHelper.Wait(2);

            // Step 5: Verify login success
            Assert.IsTrue(loginPage.IsLoginSuccessful(), "Login Failed!");
        }

        [Test]
        public void Invalid_Login_Test()
        {
            var data = JObject.Parse(File.ReadAllText("Data/testdata.json"))["negative_case"];

            // Open URL
            loginPage.Open(baseUrl);
            //WaitHelper.Wait();

            // Enter invalid credentials
            loginPage.Login(
                data["email"].ToString(),
                data["password"].ToString()
            );
            //WaitHelper.Wait(2);

            // Verify error message displayed
            Assert.IsNotEmpty(loginPage.GetErrorMessage(), "Error message not displayed!");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
