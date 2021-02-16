using Base.PageObjects;
using Base.PageObjects.Common;
using TechTalk.SpecFlow;

namespace Base.BDD.StepDefinition
{
    [Binding]
    class HeaderSteps
    {
        Header Header;
        PriorClaimsScreen PriorClaimsScreen;
        DetailsScreen DetailsScreen;

        public HeaderSteps(Header header)
        {
            Header = header;
        }

        [When(@"The user navigates to Details screen")]
        public void WhenTheUserNavigatesToDetailsScreen()
        {
            DetailsScreen = Header.GoToDetailsScreen();
        }

        [When(@"The user navigates to Prior Claims screen")]
        public void WhenTheUserNavigatestoPriorClaimsScreen()
        {
            PriorClaimsScreen = Header.GoToPriorClaimsScreen();
        }

       


    }
}
