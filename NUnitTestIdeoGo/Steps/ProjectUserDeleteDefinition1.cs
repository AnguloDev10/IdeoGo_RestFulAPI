using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace NUnitTestIdeoGo.Steps
{
    [Binding]
    public sealed class ProjectUserDeleteDefinition1
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext context;

        public ProjectUserDeleteDefinition1(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }

        [Given(@"that the creator user of the project is in the section of his team")]
        public void GivenThatTheCreatorUserOfTheProjectIsInTheSectionOfHisTeam()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"ou select the delete member option")]
        public void WhenOuSelectTheDeleteMemberOption()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"a pop-up window will appear for your confirmation\.")]
        public void ThenAPop_UpWindowWillAppearForYourConfirmation_()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
