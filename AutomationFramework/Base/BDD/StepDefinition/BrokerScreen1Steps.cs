using Base.BDD.TableModels;
using Base.PageObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Base.BDD.StepDefinition
{
    [Binding]
    class BrokerScreen1Steps : BaseSteps
    {        
        public BrokerScreen1Steps(BrokerScreen1 brokerScreen1)
        {
            BrokerScreen1 = brokerScreen1;
        }

        [Given(@"The user completes the Insured Details region")]
        public void GivenTheUserEntersTheInsuredDetails(Table table)
        {
            var insuredDetails = table.CreateInstance<BrokerScreen1Model>();
            BrokerScreen1.CompleteInsuredDetails(insuredDetails);            
        }

        [Given(@"The user completes the Policy Details region")]
        public void GivenTheUserCompletesThePolicyDetailsRegion(Table table)
        {
            var policyDetails = table.CreateInstance<BrokerScreen1Model>();
            BrokerScreen1.CompletePolicyDetails(policyDetails);
        }

        [Given(@"The user saves the page")]
        [When(@"The user saves the page")]
        public void GivenTheUserSavesThePage()
        {
            BrokerScreen1.Header.SavePage();
        }
    }
}
