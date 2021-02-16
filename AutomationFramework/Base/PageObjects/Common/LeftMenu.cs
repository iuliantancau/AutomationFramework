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
        IWebElement LeftHandMenuTab => FindElementById("panel");

        #region Actions tab
        IWebElement ActionsTab => FindElementById("historytab");
        SelectElement Action => FindSelectElementById("UpdateStatus");
        SelectElement Reason => FindSelectElementById("UpdateReason");
        IWebElement EffectiveDate => FindElementById("");
        IWebElement SendBrokerEmailYES => FindElementById("");
        IWebElement SendBrokerEmailNO => FindElementById("");
        IWebElement Save => FindElementById("");
        #endregion

        #region Documnts tab
        SelectElement DocumentsTab => FindSelectElementById("RD_doctab");
        IReadOnlyCollection<IWebElement> DocumentList => FindElementsByXPath("//div[@class = 'document']//span");
        #endregion

        public LeftMenu(BritDriver britDriver) : base(britDriver) { }

        #region Public Methods
        public void DownloadDocument(string documentName)
        {            
            var document = DocumentList.Where(dl => GetInnerText(dl).Equals(documentName)).FirstOrDefault();
            Click(document);
            new FileHandler(documentName).WaitFileToDownload();
        }

        public BrokerScreen1 CreateMTA(SelectActionModel mtaData)
        {
            mtaData.Action = "Create MTA";
            return SelectAction<BrokerScreen1>(mtaData);
        }

        public BrokerScreen3 CreateCancellation(SelectActionModel cancellationData)
        {
            cancellationData.Action = "Create Cancellation";
            return SelectAction<BrokerScreen3>(cancellationData);
        }

        public BrokerScreen1 CreateRenewal()
        {
            return SelectAction<BrokerScreen1>(new SelectActionModel() { Action = "Create Renwal" });
        }

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
        #endregion

        #region Private Methods
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
        #endregion
    }
}
