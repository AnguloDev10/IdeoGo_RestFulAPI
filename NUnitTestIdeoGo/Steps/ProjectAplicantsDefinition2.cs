using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace NUnitTestIdeoGo.Steps
{
    [Binding]
    public sealed class ProjectAplicantsDefinition2
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext context;

        public ProjectAplicantsDefinition2(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }

        [Given(@"the author user is in the preview of the postulates")]
        public void GivenTheAuthorUserIsInThePreviewOfThePostulates()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"you select the box for each applicant")]
        public void WhenYouSelectTheBoxForEachApplicant()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"it will redirect you to the applicant's profile")]
        public void ThenItWillRedirectYouToTheApplicantSProfile()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
