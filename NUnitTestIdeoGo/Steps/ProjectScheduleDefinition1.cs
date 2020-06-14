using AutoMapper;
using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Services;
using IdeoGo.API.Resources;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace NUnitTestIdeoGo.Steps
{
    [Binding]
    public sealed class ProjectScheduleDefinition1
    {
        private readonly IProjectScheduleService _projectScheduleService;
        private readonly IMapper _mapper;
        private int _projectId;
        private ProjectScheduleResource result;

        [Given(@"I have  selected my project")]
        public void GivenIHaveSelectedMyProject(int projectId)
        {
            _projectId = projectId;
        }

        [When(@"I press see schedule")]
        public async void WhenIPressSeeSchedule()
        {
            var resultt = await _projectScheduleService.GetByIdAsync(_projectId);
             result = _mapper.Map<ProjectSchedule, ProjectScheduleResource>(resultt.Resource);
            
        }

        [Then(@"I get the  specific schedule of my project")]
        public void ThenIGetTheSpecificScheduleOfMyProject(ProjectResource objeto)
        {
            Assert.AreEqual(objeto, result);
        }


    }
}
