using Base.Data;
using Base.Data.Models;
using Base.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;

namespace Base.PageObjects.Common
{
    public class LogInPage : BasePage
    {
        public LogInPage(BritDriver britDriver) : base(britDriver) { }

        IWebElement UserName => FindElementById("UserName");
        IWebElement Password => FindElementById("Password");
        IWebElement Region => FindElementByXPath("//*[@id='RB_selLanguage-button']/span[2]");       
        IReadOnlyCollection<IWebElement> RegionList => FindElementsByXPath("//*[@id='RB_selLanguage-menu']/li");
        IWebElement SignInButton => FindElementById("loginbutton");

        public HomePage LogIn(LogInDataSet data)
        {
            ChangeRegion(data.Region);
            UserName.SendKeys(data.Username);
            Password.SendKeys(data.Password);
            SignInButton.Click();

            return new HomePage(BritDriver);
        }

        private void ChangeRegion(string regionToSelect)
        {
            Click(Region);
            var currentRegion = RegionList.Where(rl => GetInnerText(rl).Equals(regionToSelect)).FirstOrDefault();
            Click(currentRegion);
        }
    }
}
