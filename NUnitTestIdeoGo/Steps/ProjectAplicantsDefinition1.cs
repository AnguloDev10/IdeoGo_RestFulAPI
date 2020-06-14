using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace NUnitTestIdeoGo.Steps
{
    [Binding]
    public sealed class ProjectAplicantsDefinition1
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext context;

        public ProjectAplicantsDefinition1(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }

        [Given(@"Given the author user is in the box of his projects")]
        public void GivenGivenTheAuthorUserIsInTheBoxOfHisProjects()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"you select the project")]
        public void WhenYouSelectTheProject()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"you can select the option to view the applicants")]
        public void ThenYouCanSelectTheOptionToViewTheApplicants()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
