using Base.Utils;
using OpenQA.Selenium;
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


        public LeftMenu(BritDriver britDriver) : base(britDriver) { }

        public void OpenLeftMenu(IWebElement tab)
        {
            int retryCount = 0;
            while (!IsLeftMenuExpanded() && retryCount < 10)
            {
                Click(tab);
                retryCount++;
            }
        }       

        private bool IsLeftMenuExpanded()
        {
            Thread.Sleep(200);
            return Convert.ToBoolean(LeftHandMenuTab.GetAttribute("class").Equals("is-open"));
        }
    }
}
