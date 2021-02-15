using Base.Data;
using Base.Data.Models;
using Base.PageObjects;
using Base.PageObjects.Common;
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
        LogInDataSet logInData;

        public LogInSteps(BritDriver driver)
        {
            BritDriver = driver;
        }

        [Given(@"The user navigates to website")]
        public void GivenTheUserNavigatesToWebsite()
        {
            BritDriver.GetDriver().Navigate().GoToUrl(Environments.DEV);
            LogInPage = new LogInPage(BritDriver);
        }

        [Given(@"The user logs in as a broker")]
        public void GivenTheUserLogsInAsABroker()
        {
            logInData = DataReader.GetLogInData(1);
            HomePage = LogInPage.LogIn(logInData);
        }

        [Given(@"The user logs in as an underwriter")]
        public void GivenTheUserLogsInAnUnderwriter()
        {
            logInData = DataReader.GetLogInData(2);
            HomePage = LogInPage.LogIn(logInData);
        }






    }
}
