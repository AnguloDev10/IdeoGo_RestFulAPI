using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using IdeoGo.API.Domain.Models;

namespace NUnitTestIdeoGo.Steps
{
    [Binding]
    public sealed class ProjectDefinition1
    {
        private User user = new User();
        [Given(@"I have entered my password  to register")]
        public void GivenIHaveEnteredMyPasswordToRegister(string _password)
        {
            user.Password = _password;
        }

        [Given(@"I have entered my email  to register")]
        public void GivenIHaveEnteredMyEmailToRegister(string _email)
        {
            user.Email = _email;
        }

        [When(@"I press register")]
        public void WhenIPressRegister()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the user should be created")]
        public void ThenTheUserShouldBeCreated()
        {
            ScenarioContext.Current.Pending();
        }


    }
}
