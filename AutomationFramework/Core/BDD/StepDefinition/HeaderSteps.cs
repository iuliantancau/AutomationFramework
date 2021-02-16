
using Base.PageObjects;
using Base.PageObjects.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Base.BDD.StepDefinition
{
    [Binding]
    class HeaderSteps
    {
        Header Header;
        PriorClaimsScreen PriorClaimsScreen;

        public HeaderSteps(Header header)
        {
            Header = header;
        }

        [When(@"The user navigates to '(.*)' tab")]
        public void GivenTheUserNavigatesToTab(string tabName)
        {
            PriorClaimsScreen = Header.ChangeTab<PriorClaimsScreen>();           
        }
    }
}
