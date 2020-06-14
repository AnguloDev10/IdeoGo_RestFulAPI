using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace NUnitTestIdeoGo.Steps
{
    [Binding]
    public sealed class UserDefinition2
    {
        [Given(@"I have registered")]
        public void GivenIHaveRegistered()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I press register")]
        public void WhenIPressRegister()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"my account will have been created")]
        public void ThenMyAccountWillHaveBeenCreated()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
