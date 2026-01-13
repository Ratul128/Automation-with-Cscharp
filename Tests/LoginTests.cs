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
            loginPage = new LoginPage(driver);
        }

        [Test]
        public void Successful_Login_Test()
        {
            var data = JObject.Parse(File.ReadAllText("Data/testdata.json"))["positive_case"];

            loginPage.Open(baseUrl);

            loginPage.Login(
                data["email"].ToString(),
                data["password"].ToString()
            );

            loginPage.ClickContinueAuthentication();

            loginPage.EnterOTPAndSubmit("1111");

            Assert.IsTrue(loginPage.IsLoginSuccessful(), "Login Failed!");
        }

        [Test]
        public void Invalid_Login_Test()
        {
            var data = JObject.Parse(File.ReadAllText("Data/testdata.json"))["negative_case"];

            loginPage.Open(baseUrl);

            loginPage.Login(
                data["email"].ToString(),
                data["password"].ToString()
            );

            Assert.IsNotEmpty(loginPage.GetErrorMessage(), "Error message not displayed!");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
