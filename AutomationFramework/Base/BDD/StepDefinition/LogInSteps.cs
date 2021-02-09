using Base.PageObjects.CommonScreens;
using Base.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Base.BDD.StepDefinition
{
    [Binding]
    public class LogInSteps
    {
        private IWebDriver Driver;
        LogInPage logInPage => new LogInPage(Driver);

        public LogInSteps(IWebDriver driver)
        {
            Driver = driver;
        }

        [Given(@"The user navigates to website")]
        public void GivenTheUserNavigatesToWebsite()
        {
            Driver.Navigate().GoToUrl(Environments.DEV);
            Assert.AreEqual("RuleBook", Driver.Title);
        }


        [Given(@"The user logs in as a broker")]
        public void GivenTheUserLogsInAsABroker()
        {
            logInPage.SignIn();
            Assert.AreEqual("RuleBook - Quotes", Driver.Title);
        }






    }
}
