using AutoMapper;
using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Services;
using IdeoGo.API.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Controllers
{
    [Produces("application/json")]
    [Route("/api/[controller]")]
    public class SkillsController:Controller
    {
        private readonly ISkillService _skillService;
        private readonly IMapper _mapper;
       
        public SkillsController(ISkillService skillService, IMapper mapper)
        {
            _skillService = skillService;
            _mapper = mapper;
        }
       
        [HttpGet]
        public async Task<IEnumerable<SkillResource>> GetAllAsync()
        {
            var skills = await _skillService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Skill>, IEnumerable<SkillResource>>(skills);
            return resources;
        }
       
       
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveSkillResource resource)
        {
            var skill = _mapper.Map<SaveSkillResource, Skill>(resource);
       
            var result = await _skillService.SaveAsync(skill);
       
       
       
            if (!result.Success)
                return BadRequest(result.Message);
       
            //
       
            var SkillResource = _mapper.Map<Skill, SkillResource>(result.Resource);
       
            return Ok(SkillResource);
        }
       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, SaveSkillResource resource)
        {
            var skills = _mapper.Map<SaveSkillResource, Skill>(resource);
            var result = await _skillService.UpdateAsync(id, skills);
       
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
       
            var SkillResource = _mapper.Map<Skill, SkillResource>(result.Resource);
            return Ok(SkillResource);
        }
       
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
       
            var result = await _skillService.DeleteAsync(id);
       
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
       
            var skillResource = _mapper.Map<Skill, SkillResource>(result.Resource);
            return Ok(skillResource);
        }
    }
}
