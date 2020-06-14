using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using IdeoGo.API.Domain.Models;
using IdeoGo.API.Resources;
using IdeoGo.API.Domain.Services;
using AutoMapper;
using IdeoGo.API.Controllers;
using NUnit.Framework;

namespace NUnitTestIdeoGo.Steps
{
    [Binding]
    public sealed class UserDefinition1
    {
        private IEnumerable<UserResource> result;
        int _idproject;
        private readonly IMapper _mapper;
        private readonly IUserService _userservice;
        
        

        [Given(@"I have selected my project")]
        public void GivenIHaveSelectedMyProject(int idProject)
        {
            _idproject = idProject;
        }

        [When(@"I press search for users")]
        public async void WhenIPressSearchForUsers()
        {
            var users =await _userservice.ListByProjectIdAsync(_idproject);
            result = _mapper
                .Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
        }

        [Then(@"I get the whole list of users the  my project")]
        public void ThenIGetTheWholeListOfUsersTheMyProject(IEnumerable<UserResource> lista)
        {
            Assert.AreEqual(lista, result);
        }

    }
}
