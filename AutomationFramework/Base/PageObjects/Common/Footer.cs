using Base.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.PageObjects.Common
{
    class Footer : BasePage
    {
        IWebElement Save => FindElementByXPath("");
        IWebElement Next => FindElementByXPath("");
        IWebElement Back => FindElementByXPath("");
        IWebElement Status => FindElementByXPath("");
        IWebElement Reference => FindElementByXPath("");

        public Footer(BritDriver britDriver) : base(britDriver)
        {

        }        

        public T GoToNextScreen<T>() where T : BasePage
        {
            Click(Next);
            BritDriver.WaitForPendingAjaxTasks();
            return (T)Activator.CreateInstance(typeof(T));
        }
         
        public T GoToPreviosScreen<T>() where T : BasePage
        {
            Click(Back);
            BritDriver.WaitForPendingAjaxTasks();
            return (T)Activator.CreateInstance(typeof(T));
        }

        public BrokerScreen4 GoToSummaryPage()
        {      
            return new BrokerScreen4(BritDriver);
        }

        public string GetPolicyStatus()
        {
            return GetInnerText(Status);
        }

        public string GetPolicyReference()
        {
            return GetInnerText(Reference);
        }
    }
}
