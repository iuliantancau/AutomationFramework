using Base.Utils;
using OpenQA.Selenium;

namespace Base.PageObjects.CommonScreens
{
    public class LogInPage
    {
        BritDriver Driver;

        IWebElement UserName => Driver.FindElementById("UserName");
        IWebElement Password => Driver.FindElementById("Password");
        IWebElement SignInButton => Driver.FindElementById("loginbutton");

        public LogInPage(BritDriver driver)
        {
            Driver = driver;
        }

        public HomePage LogIn()
        {
            UserName.SendKeys("Terror 24 Broker");
            Password.SendKeys("Twenty20");
            SignInButton.Click();

            return new HomePage(Driver);
        }

    }
}
