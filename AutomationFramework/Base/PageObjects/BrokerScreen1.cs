using Base.BDD.TableModels;
using Base.PageObjects.Common;
using Base.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.PageObjects
{
    public class BrokerScreen1 : BasePage
    {
        public Header Header;


        #region Insured Details
        IWebElement Corporate => FindElementById("CoporateCheckBox_0");
        IWebElement Individual => FindElementById("IndividualCheckBox_0");

        //Corporate
        SelectElement Country => FindSelectElementById("InsuredCountryCountryDropDown_0");
        IWebElement InsuredName => FindElementById("InsuredCoporateName_0");
        SelectElement ChooseInsured => FindSelectElementById("InsuredCoporateChooseInsured_0");
        IWebElement OverrideApplicantDetails => FindElementById("InsuredCoporateOverrideApplicantDetails_0");
        IWebElement OverrideIndustry => FindElementById("InsuredCoporateOverrideIndustry_0");

        //Individual
        IWebElement FirstName => FindElementById("InsuredIndividualFirstName_0");
        IWebElement Surname => FindElementById("InsuredIndividualSurname_0");
        IWebElement StreedAddress => FindElementById("InsuredIndividualDetailsStreetAddress_0");
        IWebElement TownCity => FindElementById("InsuredIndividualDetailsTownCity_0");
        IWebElement Postcode => FindElementById("InsuredIndividualDetailsPostcode_0");
        SelectElement MainBusinessDescription => FindSelectElementById("InsuredIndividualDetailsMainBusinessDescription_0");
        #endregion

        #region Policy Details
        SelectElement QuotableCoverage1 => FindSelectElementById("CoverageDropDown_0");
        #endregion

        public BrokerScreen1(BritDriver britDriver) : base(britDriver)
        {
            Header = new Header(britDriver);
        }

        public void CompleteInsuredDetails(BrokerScreen1Model insuredDetails)
        {
            SelectInsuredType(insuredDetails.InsuredType);
            SelectByText(Country, insuredDetails.Country);
            SendKeys(InsuredName, insuredDetails.InsuredName);
            SelectCheckBox(OverrideApplicantDetails, insuredDetails.OverrideApplicantDetails);
            SelectCheckBox(OverrideIndustry, insuredDetails.OverrideIndustry);
            SelectByText(ChooseInsured, insuredDetails.ChooseInsured);
        }     
        
        public void CompletePolicyDetails(BrokerScreen1Model policyDetails)
        {
            SelectByText(QuotableCoverage1, policyDetails.QuotableCoverage1);
        }        

        public BrokerScreen1 SavePage()
        {
           return Header.SavePage<BrokerScreen1>();
        }

        private void SelectInsuredType(string type)
        {
            if (type != null)
            {
                if (type.Equals("Corporate"))
                    Click(Corporate);
                else if (type.Equals("Individual"))
                    Click(Individual);
                else throw new ArgumentException("Invalid type selected");
            }
        }
    }
}
