using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.ComponentModel;
using System.IO;

namespace Base.Utils.Driver
{
    public class BritDriver
    {       
        public RemoteWebDriver WebDriver;
        public WebDriverWait Wait;
        public Actions Actions;
        public IJavaScriptExecutor JsExecutor;

        public BritDriver(Browsers platform = Browsers.Chrome)
        {
            switch (platform)
            {
                case Browsers.Chrome:
                    {
                        ChromeOptions chromeOptions = new ChromeOptions();
                        chromeOptions.AddUserProfilePreference("blocking", "true");
                        chromeOptions.AddUserProfilePreference("download.prompt_for_download", "false");
                        chromeOptions.AddUserProfilePreference("directory_upgrade", "true");
                        chromeOptions.AddUserProfilePreference("download.default_directory", Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
                        chromeOptions.AddArgument("no-sandbox");
                        chromeOptions.AddArgument("disable-backgrounding-occluded-windows");
                        WebDriver = new ChromeDriver(chromeOptions);
                    }
                    break;
                case Browsers.Firefox: throw new NotImplementedException();
                case Browsers.Explorer: throw new NotImplementedException();
                case Browsers.Safari: throw new NotImplementedException();
                default: throw new InvalidEnumArgumentException(platform + " is not an option");
            }

            Wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(60));
            Wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            Actions = new Actions(WebDriver);
            JsExecutor = WebDriver;
        }

        public void ClickWithJsExecutor(IWebElement element)
        {
            JsExecutor.ExecuteScript("arguments[0].click();", element);
        }

        public void SetImplicitWait(int seconds)
        {
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        }

        public void ScrollToElement(IWebElement element)
        {
            Actions.MoveToElement(element);
            Actions.Perform();
        }

        /// <summary>
        /// Method to scroll page into the IWebElement view
        /// </summary>
        /// <param name="element"></param>
        public void ScrollToView(IWebElement element)
        {
            if (element.Location.Y > 200)
            {
                ScrollTo(element.Location.X, element.Location.Y - 100); // Make sure element is in the view but below the top navigation pane
            }
            else
            {
                ScrollTo(element.Location.X, element.Location.Y);
            }
        }

        /// <summary>
        /// Method to scroll the page to specific position into the page
        /// </summary>
        /// <param name="xPosition"></param>
        /// <param name="yPosition"></param>
        public void ScrollTo(int xPosition = 0, int yPosition = 0)
        {
            var js = $"window.scrollTo({xPosition}, {yPosition})";
            var jsExecutor = (WebDriver as IJavaScriptExecutor);
            jsExecutor.ExecuteScript(js);
        }

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

        public void GoToAnSpecificUrl(string url)
        {
            WebDriver.Navigate().GoToUrl(url);
        }
    }
}
