using OpenQA.Selenium;

namespace Base.PageObjects.CommonScreens
{
    public class LogInPage
    {
        IWebDriver driver;

        private IWebElement UserName => driver.FindElement(By.Id("UserName"));
        private IWebElement Password => driver.FindElement(By.Id("Password"));
        private IWebElement SignInButton => driver.FindElement(By.Id("loginbutton"));

        public LogInPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void SignIn()
        {
            UserName.SendKeys("Terror 24 Broker");
            Password.SendKeys("Twenty20");
            SignInButton.Click();
        }
    }
}
