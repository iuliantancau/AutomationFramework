using Base.Data;
using Base.Data.Models;
using Base.Utils;
using OpenQA.Selenium;

namespace Base.PageObjects.Common
{
    public class LogInPage : BasePage
    {
        public LogInPage(BritDriver britDriver) : base(britDriver) { }

        IWebElement UserName => FindElementById("UserName");
        IWebElement Password => FindElementById("Password");
        IWebElement SignInButton => FindElementById("loginbutton");

        public HomePage LogIn(LogInDataSet data)
        {
            UserName.SendKeys(data.Username);
            Password.SendKeys(data.Password);
            SignInButton.Click();

            return new HomePage(BritDriver);
        }
    }
}
