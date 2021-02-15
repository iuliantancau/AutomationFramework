using Base.Data;
using Base.PageObjects;
using Base.PageObjects.Common;
using Base.Utils;
using TechTalk.SpecFlow;

namespace Base.BDD.StepDefinition
{
    [Binding]
    public class BaseSteps
    {
        public BritDriver BritDriver;
        public DataReader DataReader => new DataReader();
        public BrokerScreen1 BrokerScreen1;
        public Header Header;

       
    }  

}
