using Base.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.PageObjects.Common
{
    public class BasePage
    {
        protected BritDriver BritDriver;

        public BasePage(BritDriver britDriver)
        {
            BritDriver = britDriver;
        }

        #region Actions
        public void Click(IWebElement element)
        {
            BritDriver.WaitForVisibility(element);
            BritDriver.WaitForBeClickable(element);
            element.Click();
            BritDriver.WaitForPendingAjaxTasks();
        }

        public void SendKeys(IWebElement element, string value)
        {
            if (value != null)
            {
                BritDriver.WaitForVisibility(element);
                BritDriver.WaitForBeClickable(element);
                element.Clear();
                element.SendKeys(value + "\t");
                BritDriver.WaitForPendingAjaxTasks();
            }
        }

        public void SelectByIndex(SelectElement element, string index)
        {
            if (index != null)
            {
                BritDriver.WaitForVisibility(element.WrappedElement);
                BritDriver.WaitForBeClickable(element.WrappedElement);
                element.SelectByIndex(int.Parse(index));
                BritDriver.WaitForPendingAjaxTasks();
            }
        }

        public void SelectByText(SelectElement element, string text)
        {
            if (text != null)
            {
                BritDriver.WaitForVisibility(element.WrappedElement);
                BritDriver.WaitForBeClickable(element.WrappedElement);
                element.SelectByText(text);
                BritDriver.WaitForPendingAjaxTasks();
            }            
        }

        public void SelectByValue(SelectElement element, string value)
        {
            if (value != null)
            {
                BritDriver.WaitForVisibility(element.WrappedElement);
                BritDriver.WaitForBeClickable(element.WrappedElement);
                element.SelectByValue(value);
                BritDriver.WaitForPendingAjaxTasks();
            }
        }

        public string GetValue(IWebElement element)
        {
            BritDriver.WaitForVisibility(element);
            return GetTextFromElement(element, "Value");
        }

        public string GetInnerText(IWebElement element)
        {
            BritDriver.WaitForVisibility(element);
            return GetTextFromElement(element, "InnerText");
        }

        public void SelectCheckBox(IWebElement element, string option)
        {
            if (option != null && option.ToUpper().Equals("TRUE"))
            {
                Click(element);
            }
        }

        public void AnswerQuestion(string answer, IWebElement yesRadioButton, IWebElement noRadioButton, IWebElement triggeredElement = null)
        {
            if (answer != null)
            {
                if (answer.ToUpper().Equals("TRUE"))
                    Click(yesRadioButton);
                else if (answer.ToUpper().Equals("FALSE"))
                {
                    Click(noRadioButton);
                    if (triggeredElement != null)
                        SendKeys(triggeredElement, "Test text");
                }
                else throw new ArgumentException("Invalid answer option selected");
            }
        }
        #endregion

        #region Element Locators
        public IWebElement FindElementById(string id)
        {
            BritDriver.WaitForVisibility(By.Id(id));
            return BritDriver.GetDriver().FindElement(By.Id(id));
        }

        public IWebElement FindElementByClassName(string className)
        {
            BritDriver.WaitForVisibility(By.ClassName(className));
            return BritDriver.GetDriver().FindElement(By.ClassName(className));
        }

        public IWebElement FindElementByXPath(string xPath)
        {
            BritDriver.WaitForVisibility(By.XPath(xPath));
            return BritDriver.GetDriver().FindElement(By.XPath(xPath));
        }

        public IReadOnlyCollection<IWebElement> FindElementsById(string id)
        {
            BritDriver.WaitForVisibility(By.Id(id));
            return BritDriver.GetDriver().FindElements(By.Id(id));
        }

        public IReadOnlyCollection<IWebElement> FindElementsByClassName(string className)
        {
            BritDriver.WaitForVisibility(By.ClassName(className));
            return BritDriver.GetDriver().FindElements(By.ClassName(className));
        }

        public IReadOnlyCollection<IWebElement> FindElementsByXPath(string xPath)
        {
            BritDriver.WaitForVisibility(By.XPath(xPath));
            return BritDriver.GetDriver().FindElements(By.XPath(xPath));
        }

        public SelectElement FindSelectElementById(string id)
        {
            return new SelectElement(FindElementById(id));
        }

        public SelectElement FindSelectElementByClassName(string className)
        {

            return new SelectElement(FindElementByClassName(className));
        }

        public SelectElement FindSelectElementByXPath(string xPath)
        {
            return new SelectElement(FindElementByXPath(xPath));
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
        #endregion

        private string GetTextFromElement(IWebElement element, string type)
        {
            string text = string.Empty;
            int i = 0;
            try
            {
                i++;
                BritDriver.WaitForVisibility(element);
                if (type == "InnerText") text = element.Text;
                else if (type == "Value") text = element.GetAttribute("value");
            }
            catch (Exception e)
            {
                if (i == 15) throw;
                if (e.GetType() == typeof(StaleElementReferenceException) || e.GetType() == typeof(NullReferenceException))
                    GetInnerText(element);
                else throw e;
            }
            return text;
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
    }
}
