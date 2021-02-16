using Base.Utils;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace Base.BDD.Hooks
{
    [Binding]
    class ScenarioHooks
    {
        private IObjectContainer objectContainer;
        public BritDriver BritDriver;

        public ScenarioHooks(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            BritDriver = new BritDriver(Browser.Chrome);
            objectContainer.RegisterInstanceAs(BritDriver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            BritDriver.GetDriver().Quit();
        }
    }
}
