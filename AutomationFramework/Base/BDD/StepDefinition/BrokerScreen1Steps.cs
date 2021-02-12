using Base.BDD.TableModels.BrokerScreen1;
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
        BrokerScreen1 BrokerScreen1;

        public BrokerScreen1Steps(BrokerScreen1 brokerScreen1)
        {
            BrokerScreen1 = brokerScreen1;
        }

        [Given(@"The user completes the Insured Details region")]
        public void GivenTheUserEntersTheInsuredDetails(Table table)
        {
            var insuredDetails = table.CreateInstance<InsuredDetailsModel>();
            BrokerScreen1.CompleteInsuredDetails(insuredDetails);            
        }

        [Given(@"The user completes the Policy Details region")]
        public void GivenTheUserCompletesThePolicyDetailsRegion(Table table)
        {
            var policyDetails = table.CreateInstance<PolicyDetailsModel>();
            BrokerScreen1.CompletePolicyDetails(policyDetails);
        }

        [Given(@"The user saves the page")]
        public void GivenTheUserSavesThePage()
        {
            BrokerScreen1 = BrokerScreen1.SavePage();
            Assert.IsTrue(BrokerScreen1.Header.DetailsTab.Displayed);
        }


    }
}
