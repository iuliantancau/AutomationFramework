using Base.PageObjects;
using Base.PageObjects.Common;
using Base.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace Base.BDD.StepDefinition
{
    [Binding]
    public class HomePageSteps : BaseSteps
    {      
        HomePage HomePage;
        BrokerScreen1 BrokerScreen1;

        public HomePageSteps(HomePage homePage)
        {           
            HomePage = homePage;
        }      

        [Given(@"The user selects product '(.*)' and scheme '(.*)'")]
        public void GivenTheUserSelectsProductAndScheme(string product, string scheme)
        {
            HomePage.CompleteScreen(product, scheme);
            BrokerScreen1 = HomePage.GoToBrokerScreens();            
        }



    }
}
