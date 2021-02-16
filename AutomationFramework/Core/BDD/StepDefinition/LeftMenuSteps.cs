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
        dynamic Page;

        public LeftMenuSteps(LeftMenu leftMenu)
        {
            LeftMenu = leftMenu;
        }
        
        [When(@"the user selects an action from left menu")]
        public void WhenTheUserSelectsAnActionFromLeftMenu(Table table)
        {
            var data = table.CreateInstance<SelectActionModel>();
            Page = LeftMenu.SelectAction<object>(data);            
        }




    }
}
