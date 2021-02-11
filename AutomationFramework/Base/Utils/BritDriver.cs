using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

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
                case Browser.Chrome: Driver = new ChromeDriver(); break;

                default: throw new ArgumentException();
            }

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(60));
            Wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
        }

        public IWebDriver GetDriver()
        {
            return Driver;
        }

        #region Actions
        public void Click(IWebElement element)
        {
            WaitForVisibility(element);
            WaitForBeClickable(element);
            element.Click();
        }

        public void SendKeys(IWebElement element, string value)
        {
            WaitForVisibility(element);
            WaitForBeClickable(element);
            element.SendKeys(value);
        }

        public void SelectByIndex(SelectElement element, int index)
        {
            WaitForVisibility(element.WrappedElement);
            WaitForBeClickable(element.WrappedElement);
            element.SelectByIndex(index);
        }

        public void SelectByText(SelectElement element, string text)
        {
            WaitForVisibility(element.WrappedElement);
            WaitForBeClickable(element.WrappedElement);
            element.SelectByText(text);
        }

        public void SelectByValue(SelectElement element, string value)
        {
            WaitForVisibility(element.WrappedElement);
            WaitForBeClickable(element.WrappedElement);
            element.SelectByValue(value);
        }
        #endregion

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
        #endregion

        #region Element Locators
        public IWebElement FindElementById(string id)
        {
            return Driver.FindElement(By.Id(id));
        }

        public IWebElement FindElementByClassName(string className)
        {
            return Driver.FindElement(By.ClassName(className));
        }

        public IWebElement FindElementByXPath(string xPath)
        {
            return Driver.FindElement(By.XPath(xPath));
        }

        public IReadOnlyCollection<IWebElement> FindElementsById(string id)
        {
            return Driver.FindElements(By.Id(id));
        }

        public IReadOnlyCollection<IWebElement> FindElementsByClassName(string className)
        {
            return Driver.FindElements(By.ClassName(className));
        }

        public IReadOnlyCollection<IWebElement> FindElementsByXPath(string xPath)
        {
            return Driver.FindElements(By.XPath(xPath));
        }

        public SelectElement FindSelectElementById(string id)
        {
            return new SelectElement(Driver.FindElement(By.Id(id)));
        }

        public SelectElement FindSelectElementByClassName(string className)
        {
            return new SelectElement(Driver.FindElement(By.ClassName(className)));
        }

        public SelectElement FindSelectElementByXPath(string xPath)
        {
            return new SelectElement(Driver.FindElement(By.XPath(xPath)));
        }

        public IReadOnlyCollection<SelectElement> FindSelectElementsById(string id)
        {
            var iWebElements = FindElementsById(id);
            return BuildSelectElementsList(iWebElements);
        }

        public List<SelectElement> FindSelectElementsByClassName(string className)
        {
            var iWebElements = FindElementsByClassName(className);
            return BuildSelectElementsList(iWebElements);
        }

        public IReadOnlyCollection<SelectElement> FindSelectElementsByXPath(string xPath)
        {
            var iWebElements = FindElementsByXPath(xPath);
            return BuildSelectElementsList(iWebElements);
        }

        private List<SelectElement> BuildSelectElementsList(IReadOnlyCollection<IWebElement> iWebElements)
        {
            List<SelectElement> selectElements = null;

            foreach (var item in iWebElements)
            {
                selectElements.Add(new SelectElement(item));
            }

            return selectElements;
        }
        #endregion
    }
}
