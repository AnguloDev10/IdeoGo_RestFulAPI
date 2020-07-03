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
    public class ProjectController: Controller
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public ProjectController(IProjectService projectService, IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProjectResource>> GetAllAsync()
        {
            var products = await _projectService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Project>, IEnumerable<ProjectResource>>(products);
            return resources;
        }

   

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _projectService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var projectResource = _mapper.Map<Project, ProjectResource>(result.Resource);
            return Ok(projectResource);

        }
        [HttpGet("leader/{projectLeaderId}")]
        public async Task<IActionResult> ListByProjectLeaderIdAsync(int projectLeaderId)
        {
            var result = await _projectService.ListByProjectLeaderIdAsync(projectLeaderId);
            var projectResource = _mapper.Map<IEnumerable<Project>,IEnumerable<ProjectResource>>(result);
            return Ok(projectResource);
        }
        

        [HttpPost]   //er
        public async Task<IActionResult> PostAsync([FromBody] SaveProjectResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var guardian = _mapper.Map<SaveProjectResource, Project>(resource);
            var result = await _projectService.SaveAsync(guardian);

            if (!result.Success)
                return BadRequest(result.Message);

            var projectResource = _mapper.Map<Project, ProjectResource>(result.Resource);
            return Ok(projectResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveProjectResource resource)
        {
            var guardian = _mapper.Map<SaveProjectResource, Project>(resource);
            var result = await _projectService.UpdateAsync(id, guardian);

            if (!result.Success)
                return BadRequest(result.Message);
            var projectResource = _mapper.Map<Project, SaveProjectResource>(result.Resource);
            return Ok(projectResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _projectService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            var projectResource = _mapper.Map<Project, ProjectResource>(result.Resource);
            return Ok(projectResource);
        }

        [HttpPost("{userId}")]
        public async Task<IActionResult> AssignProjectLeader(int projectId, int userId)
        {

            var result = await _projectService.AssignProjectLeaderAsync(projectId, userId);
            if (!result.Success)
                return BadRequest(result.Message);

            var Resource = _mapper.Map<User, UserResource>(result.Resource.ProjectLeader);
            return Ok(Resource);

        }


        [HttpPost("{tagId}")]
        public async Task<IActionResult> AssignProjectTag(int projectId, int tagId)
        {

            var result = await _projectService.AssignProjectTagAsync(projectId, tagId);
            if (!result.Success)
                return BadRequest(result.Message);

            var Resource = _mapper.Map<Tag, TagResource>(result.Resource.Tag);
            return Ok(Resource);

        }


    }
}
