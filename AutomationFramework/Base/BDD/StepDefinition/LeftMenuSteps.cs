using Base.BDD.TableModels;
using Base.PageObjects;
using Base.PageObjects.Common;
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
    class LeftMenuSteps
    {
        LeftMenu LeftMenu;
        BrokerScreen1 BrokerScreen1;
        BrokerScreen3 BrokerScreen3;

        public LeftMenuSteps(LeftMenu leftMenu)
        {
            LeftMenu = leftMenu;
        }      

        [When(@"The user Creates a MTA")]
        public void WhenTheUserCreatesAMTA(Table table)
        {
            var mtaData = table.CreateInstance<SelectActionModel>();
            BrokerScreen1 = LeftMenu.CreateMTA(mtaData);
        }

        [When(@"The user creates a Cancellation")]
        public void WhenTheUserCreatesACancellation(Table table)
        {
            var cancellationData = table.CreateInstance<SelectActionModel>();
            BrokerScreen3 = LeftMenu.CreateCancellation(cancellationData);
        }

        [When(@"the user creates a Renewal")]
        public void WhenTheUserCreatesARenewal()
        {
            BrokerScreen1 = LeftMenu.CreateRenewal();
        }

        [StepDefinition(@"The user downloads '(.*)' document")]
        public void WhenTheUserDownloadsDocument(string documentName)
        {
            LeftMenu.DownloadDocument(documentName);
        }


    }
}
