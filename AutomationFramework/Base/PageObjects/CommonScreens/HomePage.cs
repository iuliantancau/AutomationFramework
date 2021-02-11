using Base.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Base.PageObjects.CommonScreens
{
    public class HomePage
    {
        BritDriver Driver;

        SelectElement Product => Driver.FindSelectElementById("RB_CreateQuoteProduct");
        SelectElement Scheme => Driver.FindSelectElementById("RB_CreateQuoteScheme");
        IWebElement Save => Driver.FindElementByClassName("RB_WidgetCreateRecordEntrySave");

        public HomePage(BritDriver driver)
        {
            Driver = driver;
        }

        public void CompleteScreen(string product, string scheme)
        {
            Product.SelectByText(product);
            Scheme.SelectByText(scheme);
        }

        public BrokerScreen1 GoToBrokerScreens()
        {
            Save.Click();

            return new BrokerScreen1(Driver);
        }
    }
}
