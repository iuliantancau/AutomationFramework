using Base.BDD.TableModels;
using Base.PageObjects.Common;
using Base.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.PageObjects
{
    class PriorClaimsScreen : BasePage
    {
        IWebElement PriorClaimsYES => FindElementByXPath("//*[@id='PriorClaimsQuestionYN_0_0'][1]");
        IWebElement PriorClaimsNO => FindElementByXPath("//*[@id='PriorClaimsQuestionYN_0_0'][2]");
        IWebElement Disclosure => FindElementByXPath("/DisclosureCheckBox_0");

        public PriorClaimsScreen(BritDriver britDriver) : base(britDriver) { }

        public void AnswerPriorClaims(PriorClaimsModel answers)
        {
            AnswerQuestion(answers.PriorClaimsQuestion1, PriorClaimsYES, PriorClaimsNO);
        }

        public void ConfirmDisclosures()
        {
            Click(Disclosure);
        }
    }
}
