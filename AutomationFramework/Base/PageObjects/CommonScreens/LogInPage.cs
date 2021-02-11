using Base.Data;
using Base.Data.Models;
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

        public HomePage LogIn(LogInDataSet data)
        {
            UserName.SendKeys(data.Username);
            Password.SendKeys( data.Password);
            SignInButton.Click();            

            return new HomePage(Driver);
        }       

    }
}
