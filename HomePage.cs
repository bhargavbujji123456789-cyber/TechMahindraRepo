using OpenQA.Selenium;

namespace ParaBankAutomation.Pages
{
    public class LoginPage : BasePage
    {
        private readonly By usernameInput = By.Name("username");
        private readonly By passwordInput = By.Name("password");
        private readonly By loginButton = By.XPath("//input[@value='Log In']");
        private readonly By errorMessage = By.ClassName("error");
        private readonly By registerLink = By.LinkText("Register");
        private readonly By forgotLoginLink = By.LinkText("Forgot login info?");
        private readonly By welcomeMessage = By.XPath("//h1[contains(text(),'Accounts Overview')] | //p[@class='smallText']");

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateToLoginPage(string url)
        {
            Driver.Navigate().GoToUrl(url);
            WaitForPageLoad();
        }

        public void EnterUsername(string username)
        {
            EnterText(usernameInput, username);
        }

        public void EnterPassword(string password)
        {
            EnterText(passwordInput, password);
        }

        public void ClickLoginButton()
        {
            Click(loginButton);
            WaitForPageLoad();
        }

        public void Login(string username, string password)
        {
            EnterUsername(username);
            EnterPassword(password);
            ClickLoginButton();
        }

        public bool IsErrorMessageDisplayed()
        {
            return IsElementDisplayed(errorMessage);
        }

        public string GetErrorMessage()
        {
            return GetText(errorMessage);
        }

        public bool IsLoginSuccessful()
        {
            return Driver.Title.Contains("Accounts Overview") || IsElementDisplayed(welcomeMessage);
        }

        public RegisterPage ClickRegisterLink()
        {
            Click(registerLink);
            return new RegisterPage(Driver);
        }

        public void ClickForgotLoginLink()
        {
            Click(forgotLoginLink);
        }

        public bool IsUsernameFieldEmpty()
        {
            return string.IsNullOrEmpty(Driver.FindElement(usernameInput).GetAttribute("value"));
        }

        public bool IsPasswordFieldEmpty()
        {
            return string.IsNullOrEmpty(Driver.FindElement(passwordInput).GetAttribute("value"));
        }
    }
}