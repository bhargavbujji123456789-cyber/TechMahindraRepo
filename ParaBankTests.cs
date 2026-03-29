using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ParaBankAutomation.Pages;

namespace ParaBankAutomation.Tests
{
    [TestFixture]
    public class ParaBankTests
    {
        private IWebDriver driver;
        private const string BaseUrl = "https://parabank.parasoft.com/";

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }


        [Test]
        public void RegisterNewUser_ShouldSucceed()
        {
            var loginPage = new LoginPage(driver);
            loginPage.NavigateToLoginPage(BaseUrl);
            var registerPage = loginPage.ClickRegisterLink();
            var username = $"user{DateTime.Now:yyyyMMddHHmmss}";

            registerPage.RegisterUser("John", "Doe", "123 Main St", 
                "New York", "NY", "10001", "455-1234", "133-45-6789", 
                username, "Password123");

            Assert.That(registerPage.IsRegistrationSuccessful(), Is.True);
        }


        [Test]
        public void ValidLogin_ShouldSucceed()
        {
            var loginPage = new LoginPage(driver);
            loginPage.NavigateToLoginPage(BaseUrl);
            loginPage.Login("john", "demo");
            Assert.That(loginPage.IsLoginSuccessful(), Is.True);
        }

        [Test]
        public void InvalidLogin_ShouldShowError()
        {
            var loginPage = new LoginPage(driver);
            loginPage.NavigateToLoginPage(BaseUrl);
            loginPage.Login("invalidUser", "invalidPass");
            Assert.That(loginPage.IsErrorMessageDisplayed(), Is.True);
        }

        [Test]
        public void NavigateToProducts_ShouldDisplayProducts()
        {
            var productsPage = new ProductsPage(driver);
            productsPage.NavigateToProducts();
            Assert.That(productsPage.IsProductsPageDisplayed(), Is.True);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}