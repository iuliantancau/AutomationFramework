using Base.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Base.PageObjects.Common
{
    public class HomePage : BasePage
    {
        SelectElement Product => FindSelectElementById("RB_CreateQuoteProduct");
        SelectElement Scheme => FindSelectElementById("RB_CreateQuoteScheme");
        IWebElement Save => FindElementByClassName("RB_WidgetCreateRecordEntrySave");

        public HomePage(BritDriver britDriver) : base(britDriver) { }

        public void CompleteScreen(string product, string scheme)
        {
            Product.SelectByText(product);
            Scheme.SelectByText(scheme);
        }

        public BrokerScreen1 GoToBrokerScreens()
        {
            Save.Click();

            return new BrokerScreen1(BritDriver);
        }
    }
}
