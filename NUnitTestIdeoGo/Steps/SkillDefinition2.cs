using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace NUnitTestIdeoGo.Steps
{
    [Binding]
    public sealed class SkillDefinition2
    {
        [Given(@"I have added skills")]
        public void GivenIHaveAddedSkills()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I press Add")]
        public void WhenIPressAdd()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I will create specific skills")]
        public void ThenIWillCreateSpecificSkills()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
