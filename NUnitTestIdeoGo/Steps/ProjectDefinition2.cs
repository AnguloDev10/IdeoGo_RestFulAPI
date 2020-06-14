using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace NUnitTestIdeoGo.Steps
{
    [Binding]
    public sealed class ProjectDefinition2
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext context;

        public ProjectDefinition2(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }

        [Given(@"the user is in the project box")]
        public void GivenTheUserIsInTheProjectBox()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"selecting the project to view")]
        public void WhenSelectingTheProjectToView()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"you will then be redirected to the group consisting of the project and the project details")]
        public void ThenYouWillThenBeRedirectedToTheGroupConsistingOfTheProjectAndTheProjectDetails()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
