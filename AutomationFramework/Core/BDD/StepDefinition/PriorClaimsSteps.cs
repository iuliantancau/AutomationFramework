using Base.BDD.TableModels;
using Base.PageObjects;
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
    class PriorClaimsSteps
    {
        PriorClaimsScreen PriorClaimsScreen;

        [When(@"The user answers Prior Claims Questions")]
        public void WhenTheUserAnswersPriorClaimsQuestions(Table table)
        {
            var prioClaimsAnswers = table.CreateInstance<PriorClaimsModel>();
            PriorClaimsScreen.AnswerPriorClaims(prioClaimsAnswers);
        }

        [When(@"The user confirms the disclosures")]
        public void WhenTheUserConfirmsTheDisclosures()
        {
            PriorClaimsScreen.ConfirmDisclosures();
        }





    }
}
