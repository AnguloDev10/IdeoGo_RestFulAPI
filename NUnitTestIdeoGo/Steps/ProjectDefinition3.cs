using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace NUnitTestIdeoGo.Steps
{
    [Binding]
    public sealed class ProjectDefinition3
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext context;

        public ProjectDefinition3(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }
        [Given(@"I have select the project")]
        public void GivenIHaveSelectTheProject()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"they select the project")]
        public void WhenTheySelectTheProject()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"they can see the applicants\.")]
        public void ThenTheyCanSeeTheApplicants_()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
