using OpenQA.Selenium;

namespace ParaBankAutomation.Pages
{
    public class RegisterPage : BasePage
    {
        private readonly By firstNameInput = By.Id("customer.firstName");
        private readonly By lastNameInput = By.Id("customer.lastName");
        private readonly By addressInput = By.Id("customer.address.street");
        private readonly By cityInput = By.Id("customer.address.city");
        private readonly By stateInput = By.Id("customer.address.state");
        private readonly By zipCodeInput = By.Id("customer.address.zipCode");
        private readonly By phoneInput = By.Id("customer.phoneNumber");
        private readonly By ssnInput = By.Id("customer.ssn");
        private readonly By usernameInput = By.Id("customer.username");
        private readonly By passwordInput = By.Id("customer.password");
        private readonly By confirmPasswordInput = By.Id("repeatedPassword");
        private readonly By registerButton = By.XPath("//input[@value='Register']");
        private readonly By successMessage = By.XPath("//p[contains(text(),'Your account was created successfully') or contains(text(),'Welcome') or contains(text(),'Congratulations') or contains(text(),'Account has been created')]");
        private readonly By errorMessages = By.ClassName("error");

        public RegisterPage(IWebDriver driver) : base(driver)
        {
        }

        public void EnterFirstName(string firstName)
        {
            EnterText(firstNameInput, firstName);
        }

        public void EnterLastName(string lastName)
        {
            EnterText(lastNameInput, lastName);
        }

        public void EnterAddress(string address)
        {
            EnterText(addressInput, address);
        }

        public void EnterCity(string city)
        {
            EnterText(cityInput, city);
        }

        public void EnterState(string state)
        {
            EnterText(stateInput, state);
        }

        public void EnterZipCode(string zipCode)
        {
            EnterText(zipCodeInput, zipCode);
        }

        public void EnterPhone(string phone)
        {
            EnterText(phoneInput, phone);
        }

        public void EnterSSN(string ssn)
        {
            EnterText(ssnInput, ssn);
        }

        public void EnterUsername(string username)
        {
            EnterText(usernameInput, username);
        }

        public void EnterPassword(string password)
        {
            EnterText(passwordInput, password);
        }

        public void EnterConfirmPassword(string confirmPassword)
        {
            EnterText(confirmPasswordInput, confirmPassword);
        }

        public void ClickRegisterButton()
        {
            Click(registerButton);
            WaitForPageLoad();
        }

        public void RegisterUser(string firstName, string lastName, string address, 
            string city, string state, string zipCode, string phone, string ssn, 
            string username, string password)
        {
            EnterFirstName(firstName);
            EnterLastName(lastName);
            EnterAddress(address);
            EnterCity(city);
            EnterState(state);
            EnterZipCode(zipCode);
            EnterPhone(phone);
            EnterSSN(ssn);
            EnterUsername(username);
            EnterPassword(password);
            EnterConfirmPassword(password);
            ClickRegisterButton();
        }

        public bool IsRegistrationSuccessful()
        {
            return IsElementDisplayed(successMessage) || Driver.Title.Contains("Accounts Overview") || Driver.Title.Contains("Welcome");
        }

        public string GetSuccessMessage()
        {
            try
            {
                return GetText(successMessage);
            }
            catch
            {
                return string.Empty;
            }
        }

        public bool AreErrorMessagesDisplayed()
        {
            return IsElementDisplayed(errorMessages);
        }

        public List<string> GetAllErrorMessages()
        {
            var errorElements = Driver.FindElements(errorMessages);
            return errorElements.Select(e => e.Text).ToList();
        }
    }
}