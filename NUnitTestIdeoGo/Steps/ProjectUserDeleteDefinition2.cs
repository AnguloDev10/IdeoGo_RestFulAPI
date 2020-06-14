using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace NUnitTestIdeoGo.Steps
{
    [Binding]
    public sealed class ProjectUserDeleteDefinition2
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext context;

        public ProjectUserDeleteDefinition2(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }

        [Given(@"the user who created the project is in the popup window")]
        public void GivenTheUserWhoCreatedTheProjectIsInThePopupWindow()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"you select a member's withdrawal confirmation")]
        public void WhenYouSelectAMemberSWithdrawalConfirmation()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the system will remove it from the work team")]
        public void ThenTheSystemWillRemoveItFromTheWorkTeam()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
