using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using IdeoGo.API.Resources;
using IdeoGo.API.Services;
using AutoMapper;
using IdeoGo.API.Domain.Services;
using IdeoGo.API.Domain.Models;
using NUnit.Framework;

namespace NUnitTestIdeoGo.Steps
{
    [Binding]
    public sealed class SkillDefinition1
    {
        private readonly ISkillService _skillService;
        private readonly IMapper _mapper;
        private IEnumerable<SkillResource> result;

        [Given(@"I have selected skills")]
        public void GivenIHaveSelectedSkills()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I press skills")]
        public async void WhenIPressSkills()
        {
            var skills = await _skillService.ListAsync();
            result = _mapper.Map<IEnumerable<Skill>, IEnumerable<SkillResource>>(skills);
        }

        [Then(@"I get the whole list of skills to choose")]
        public void ThenIGetTheWholeListOfSkillsToChoose(IEnumerable<SkillResource> lista)
        {
            Assert.AreEqual(lista, result);
        }

    }
}
