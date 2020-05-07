using AutoMapper;
using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Services.Communication;
using IdeoGo.API.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Controllers
{
    [Route("/api/[controller]")]
    public class ProjectController : Controller
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
            var projects = await _projectService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Project>, IEnumerable<ProjectResource>>(projects);
            return resources;
        }


        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveProjectResource resource)
        {
            // if (!ModelState.IsValid)
            //     return BadRequest(ModelState.GetErrorMessages());

            var project = _mapper.Map<SaveProjectResource, Project>(resource);

            var result = await _projectService.SaveAsync(project);



            if (!result.Success)
                return BadRequest(result.Message);

            //

            var categoryResource = _mapper.Map<Project, ProjectResource>(result.Project);

            return Ok(categoryResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, SaveProjectResource resource)
        {
            var project = _mapper.Map<SaveProjectResource, Project>(resource);
            var result = await _projectService.UpdateAsync(id, project);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var categoryResource = _mapper.Map<Project, ProjectResource>(result.Project);
            return Ok(categoryResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {

            var result = await _projectService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var categoryResource = _mapper.Map<Project, ProjectResource>(result.Project);
            return Ok(categoryResource);
        }
    }
}
