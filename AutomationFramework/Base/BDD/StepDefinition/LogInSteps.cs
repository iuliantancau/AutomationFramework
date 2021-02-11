using Base.PageObjects.CommonScreens;
using Base.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Base.BDD.StepDefinition
{
    [Binding]
    public class LogInSteps : BaseSteps
    {       
        LogInPage LogInPage;
        HomePage HomePage;

        public LogInSteps(BritDriver driver)
        {
            Driver = driver;
        }

        [Given(@"The user navigates to website")]
        public void GivenTheUserNavigatesToWebsite()
        {
            Driver.GetDriver().Navigate().GoToUrl(Environments.DEV);
            LogInPage = new LogInPage(Driver);         
        }

        [Given(@"The user logs in as a broker")]
        public void GivenTheUserLogsInAsABroker()
        {
            HomePage = LogInPage.LogIn();           
        }

        [Given(@"The user logs in as an underwriter")]
        public void GivenTheUserLogsInAnUnderwriter()
        {
            HomePage = LogInPage.LogIn();         
        }






    }
}
