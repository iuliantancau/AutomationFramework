using Base.PageObjects.CommonScreens;
using Base.Utils.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Base.BDD.StepDefinition
{
    [Binding]
   public class HomePageSteps
    {
        ScenarioContext scenarioContext;
        BritDriver britDriver;
        HomePage homePage;

        public HomePageSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            britDriver = scenarioContext.Get<BritDriver>("BritDriver");
            homePage = new HomePage(britDriver);
        }


    }
}
