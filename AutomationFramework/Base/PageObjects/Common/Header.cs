using Base.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.PageObjects.Common
{
    public class Header : BasePage
    {
        IWebElement SignOutButton => FindElementById("");
        IWebElement SearchBox => FindElementById("");
        IWebElement SearchButton => FindElementById("");
        IWebElement DetailsTab => FindElementByXPath("//*[@id='RB_tabContent']//span[text()='Details']");
        IWebElement PropertySummaryTab => FindElementByXPath("");
        IWebElement ExtensionTab => FindElementByXPath("");
        IWebElement EndorsementTab => FindElementByXPath("");
        IWebElement PriorClaimsTab => FindElementByXPath("");
        IWebElement PremiumSummaryTab => FindElementByXPath("");
        IWebElement Save => FindElementById("btnSave");

        public Header(BritDriver britDriver) : base(britDriver) { }

        public LogInPage SignOut()
        {
            Click(SignOutButton);
            return new LogInPage(BritDriver);
        }

        public T SearchRecord<T>(string policyReference) where T : BasePage
        {
            SendKeys(SearchBox, policyReference);
            SearchButton.Click();
            Click(SearchBox);

            return (T)Activator.CreateInstance(typeof(T));
        }      

        public T SavePage<T>() where T : BasePage
        {
            Click(Save);
            return (T)Activator.CreateInstance(typeof(T), BritDriver);
        }

        public void SavePage()
        {
            Click(Save);
        }

        public DetailsScreen GoToDetailsScreen()
        {
            return ChangeTab<DetailsScreen>();
        }

        public PropertySummaryScreen GoToPropertySummaryScreen()
        {
            return ChangeTab<PropertySummaryScreen>();
        }

        public ExtensionScreen GoExtensionScreen()
        {
            return ChangeTab<ExtensionScreen>();
        }

        public EndorsementScreen GoEndorsementScreen()
        {
            return ChangeTab<EndorsementScreen>();
        }

        public PriorClaimsScreen GoToPriorClaimsScreen()
        {
            return ChangeTab<PriorClaimsScreen>();
        }

        public PremiumSummaryScreen GoToPremiumSummaryScreen()
        {
            return ChangeTab<PremiumSummaryScreen>();
        }

        #region Private Methods
        private T ChangeTab<T>() where T : BasePage
        {
            switch (typeof(T).Name)
            {
                case nameof(DetailsScreen): Click(DetailsTab); break;
                case nameof(PropertySummaryScreen): Click(PropertySummaryTab); break;
                case nameof(ExtensionScreen): Click(EndorsementTab); break;
                case nameof(EndorsementScreen): Click(PriorClaimsTab); break;
                case nameof(PriorClaimsScreen): Click(PriorClaimsTab); break;
                case nameof(PremiumSummaryScreen): Click(PremiumSummaryTab); break;
                default: throw new ArgumentException();
            }

            return (T)Activator.CreateInstance(typeof(T));
        }
        #endregion
    }
}
