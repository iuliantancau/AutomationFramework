using Base.Data;
using Base.PageObjects;
using Base.Utils;
using TechTalk.SpecFlow;

namespace Base.BDD.StepDefinition
{
    [Binding]
    public class BaseSteps
    {
        public BritDriver Driver;
        public DataReader DataReader => new DataReader();       
    }
}
