using OpenQA.Selenium;

namespace ParaBankAutomation.Pages
{
    public class ProductsPage : BasePage
    {
        private readonly By productsLink = By.LinkText("Products");
        private readonly By productsText = By.XPath("//h1[contains(text(),'P')]");
        private readonly By loansLink = By.LinkText("Loans");
        private readonly By checkingLink = By.LinkText("Checking");
        private readonly By savingsLink = By.LinkText("Savings");
        private readonly By productItems = By.XPath("//div[@class='product']");

        public ProductsPage(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateToProducts()
        {
            Driver.Navigate().GoToUrl("https://parabank.parasoft.com");
            WaitForPageLoad();
            Click(productsLink);
        }

        public bool IsProductsPageDisplayed()
        {
            return IsElementDisplayed(productsText);
        }

        public string GetPageTitle()
        {
            return GetText(productsText);
        }

        public void ClickLoansProduct()
        {
            Click(loansLink);
            WaitForPageLoad();
        }

        public void ClickCheckingProduct()
        {
            Click(checkingLink);
            WaitForPageLoad();
        }

        public void ClickSavingsProduct()
        {
            Click(savingsLink);
            WaitForPageLoad();
        }

        public int GetProductCount()
        {
            var products = Driver.FindElements(productItems);
            return products.Count;
        }

        public List<string> GetAllProductNames()
        {
            var products = Driver.FindElements(productItems);
            return products.Select(p => p.Text).ToList();
        }

        public bool IsProductAvailable(string productName)
        {
            var productLocator = By.XPath($"//a[contains(text(),'{productName}')]");
            return IsElementDisplayed(productLocator);
        }
    }
}