using Base.Data;
using Base.PageObjects;
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
            var logInData = DataReader.GetLogInData(1);
            HomePage = LogInPage.LogIn(logInData);           
        }

        [Given(@"The user logs in as an underwriter")]
        public void GivenTheUserLogsInAnUnderwriter()
        {
            var logInData = DataReader.GetLogInData(2);
            HomePage = LogInPage.LogIn(logInData);         
        }






    }
}
