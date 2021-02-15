using Base.BDD.TableModels;
using Base.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Base.PageObjects.Common
{
    class LeftMenu : BasePage
    {
        IWebElement LeftHandMenuTab => FindElementById("");
        IWebElement ActionsTab => FindElementById("");

        SelectElement Action => FindSelectElementById("");
        SelectElement Reason => FindSelectElementById("");
        IWebElement EffectiveDate => FindElementById("");
        IWebElement SendBrokerEmailYES => FindElementById("");
        IWebElement SendBrokerEmailNO => FindElementById("");
        IWebElement Save => FindElementById("");


        public LeftMenu(BritDriver britDriver) : base(britDriver) { }      


        public T SelectAction<T>(SelectActionModel data) 
        {            
            OpenLeftMenu(ActionsTab);
            SelectByText(Action, data.Action);
            SelectByText(Reason, data.Reason);
            SendBrokerEmail(data.SendBrokerEmail);
            SendKeys(EffectiveDate, data.EffectiveDate);
            Click(Save);

            return (T)Activator.CreateInstance(typeof(T));
        }

        private void OpenLeftMenu(IWebElement tab)
        {
            int retryCount = 0;
            while (!IsLeftMenuExpanded() && retryCount < 10)
            {
                Click(tab);
                retryCount++;
            }
        }

        private void SendBrokerEmail(string sendBrokerEmail)
        {
            if (sendBrokerEmail != null)
            {
                if (sendBrokerEmail.ToUpper().Equals("TRUE")) SendBrokerEmailYES.Click();
                else if (sendBrokerEmail.ToUpper().Equals("FALSE")) SendBrokerEmailNO.Click();
                else throw new ArgumentException("Invalid option selected");
            }
        }

        private bool IsLeftMenuExpanded()
        {
            Thread.Sleep(200);
            return Convert.ToBoolean(LeftHandMenuTab.GetAttribute("class").Equals("is-open"));
        }
    }
}
