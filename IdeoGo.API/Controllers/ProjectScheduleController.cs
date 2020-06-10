using AutoMapper;
using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Services;
using IdeoGo.API.Extensions;
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
    public class ProjectScheduleController : Controller
    {
        private readonly IProjectScheduleService _projectScheduleService;
        private readonly IMapper _mapper;

        public ProjectScheduleController(IProjectScheduleService projectScheduleService, IMapper mapper)
        {
            _projectScheduleService = projectScheduleService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProjectScheduleResource>> GetAllAsync()
        {
            var projectSchedule = await _projectScheduleService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<ProjectSchedule>, IEnumerable<ProjectScheduleResource>>(projectSchedule);
            return resources;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _projectScheduleService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var projectScheduleResource = _mapper.Map<ProjectSchedule, ProjectScheduleResource>(result.Resource);
            return Ok(projectScheduleResource);

        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveProjectScheduleResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var projectSchedule = _mapper.Map<SaveProjectScheduleResource, ProjectSchedule>(resource);
            var result = await _projectScheduleService.SaveAsync(projectSchedule);

            if (!result.Success)
                return BadRequest(result.Message);

            var projectScheduleResource = _mapper.Map<ProjectSchedule, ProjectScheduleResource>(result.Resource);
            return Ok(projectScheduleResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveProjectScheduleResource resource)
        {
            var projectSchedule = _mapper.Map<SaveProjectScheduleResource, ProjectSchedule>(resource);
            var result = await _projectScheduleService.UpdateAsync(id, projectSchedule);

            if (!result.Success)
                return BadRequest(result.Message);
            var projectScheduleResource = _mapper.Map<ProjectSchedule, ProjectScheduleResource>(result.Resource);
            return Ok(projectScheduleResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _projectScheduleService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            var projectScheduleResource = _mapper.Map<ProjectSchedule, ProjectScheduleResource>(result.Resource);
            return Ok(projectScheduleResource);
        }
    }
}
