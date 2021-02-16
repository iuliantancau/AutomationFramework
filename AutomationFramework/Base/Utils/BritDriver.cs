using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Reflection;

namespace Base.Utils
{
    public class BritDriver
    {
        IWebDriver Driver;
        WebDriverWait Wait;        

        public BritDriver(Browser browser)
        {
            switch (browser)
            {
                case Browser.Chrome:
                    var chromeOption = new ChromeOptions();
                    chromeOption.AddUserProfilePreference("disable-popup-blocking", "true");
                    chromeOption.AddUserProfilePreference("download.prompt_for_download", "false");
                    chromeOption.AddUserProfilePreference("directory_upgrade", "true");
                    chromeOption.AddUserProfilePreference("download.default_directory", Assembly.GetExecutingAssembly().Location);
                    Driver = new ChromeDriver(chromeOption);
                    break;

                default: throw new ArgumentException();
            }

            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(60));
            Wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
        }

        public IWebDriver GetDriver()
        {
            return Driver;
        }

        #region Wait Methods
        public void WaitForVisibility(IWebElement element, int timeOut = 60, int pollingInterval = 300)
        {
            Wait.Timeout = TimeSpan.FromSeconds(timeOut);
            Wait.PollingInterval = TimeSpan.FromMilliseconds(pollingInterval);
            Wait.Until(driver => element.Displayed);
        }

        public void WaitForVisibility(By elementBy, int timeOut = 60, int pollingInterval = 300)
        {
            Wait.Timeout = TimeSpan.FromSeconds(timeOut);
            Wait.PollingInterval = TimeSpan.FromMilliseconds(pollingInterval);
            Wait.Until(driver => driver.FindElement(elementBy).Displayed);
        }

        public void WaitForInvisibility(IWebElement element, int timeOut = 60, int pollingInterval = 300)
        {
            Wait.Timeout = TimeSpan.FromSeconds(timeOut);
            Wait.PollingInterval = TimeSpan.FromMilliseconds(pollingInterval);
            Wait.Until(driver => !element.Displayed);
        }

        public void WaitForInvisibility(By elementBy, int timeOut = 60, int pollingInterval = 300)
        {
            Wait.Timeout = TimeSpan.FromSeconds(timeOut);
            Wait.PollingInterval = TimeSpan.FromMilliseconds(pollingInterval);
            Wait.Until(driver => !driver.FindElement(elementBy).Displayed);
        }

        public void WaitForBeClickable(IWebElement element, int timeOut = 60, int pollingInterval = 300)
        {
            Wait.Timeout = TimeSpan.FromSeconds(timeOut);
            Wait.PollingInterval = TimeSpan.FromMilliseconds(pollingInterval);
            Wait.Until(driver => element.Enabled);
        }

        public void WaitForBeClickable(By elementBy, int timeOut = 60, int pollingInterval = 300)
        {
            Wait.Timeout = TimeSpan.FromSeconds(timeOut);
            Wait.PollingInterval = TimeSpan.FromMilliseconds(pollingInterval);
            Wait.Until(driver => driver.FindElement(elementBy).Enabled);
        }

        public void WaitForPendingAjaxTasks(int secondsTimeOut = 60, int millisecondsPollingInterval = 300)
        {
            Wait.Timeout = TimeSpan.FromSeconds(secondsTimeOut);
            Wait.PollingInterval = TimeSpan.FromMilliseconds(millisecondsPollingInterval);
            Wait.Until(driver => (bool)((IJavaScriptExecutor)driver).ExecuteScript("return jQuery.active == 0"));
        }

        public void WaitForStaleness(IWebElement element)
        {
            try
            {
                Wait.PollingInterval = TimeSpan.FromMilliseconds(50);
                Wait.Until(ExpectedConditions.StalenessOf(element));
            }
            catch (WebDriverTimeoutException)
            {
                //sometimes the footer is not stale after save/next 
            }
        }
        #endregion        
    }
}
