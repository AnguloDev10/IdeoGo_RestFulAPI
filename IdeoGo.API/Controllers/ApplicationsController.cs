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

    public class ApplicationsController:Controller
    {
        private readonly IProfileService _profileService;
        private readonly IProjectService _projectService;
        private readonly IApplicationService _applicationService;
        private readonly IMapper _mapper;

        public ApplicationsController(IApplicationService applicationService, IMapper mapper,IProjectService projectService,IProfileService profileService )
        {
            _applicationService = applicationService;
            _mapper = mapper;
            _projectService = projectService;
            _profileService = profileService;
        }



        [HttpGet]
        public async Task<IEnumerable<ApplicationResource>> GetAllAsync()
        {
            var Applications = await _applicationService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Application>, IEnumerable<ApplicationResource>>(Applications);
            return resources;
        }
        [HttpGet("user/{id}")]
        public async Task<IActionResult> ListProjectByAppUserIdAsync(int id)
        {
            var result = await _projectService.ListByApplicationUserIdAsync(id);
            var projectResource = _mapper.Map<IEnumerable<Project>, IEnumerable<ProjectResource>>(result);
            return Ok(projectResource);
        }
        [HttpGet("project/{id}")]
        public async Task<IActionResult> ListProfiletByAppProjectIdAsync(int id)
        {
            var result = await _profileService.ListByApplicationProjectIdAsync(id);
            var resources = _mapper.Map<IEnumerable<Domain.Models.Profile>, IEnumerable<ProfileResource>>(result);
            return Ok(resources);
        }


        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveApplicationResource resource)
        {


            var applications = _mapper.Map<SaveApplicationResource, Application>(resource);

            var result = await _applicationService.SaveAsync(applications);



            if (!result.Success)
                return BadRequest(result.Message);

            //

            var ApplicationResource = _mapper.Map<Application, ApplicationResource>(result.Resource);

            return Ok(ApplicationResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, SaveApplicationResource resource)
        {
            var applications = _mapper.Map<SaveApplicationResource, Application>(resource);
            var result = await _applicationService.UpdateAsync(id, applications);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var ApplicationResource = _mapper.Map<Application, ApplicationResource>(result.Resource);
            return Ok(ApplicationResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {

            var result = await _applicationService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var applicationResource = _mapper.Map<Application, ApplicationResource>(result.Resource);
            return Ok(applicationResource);
        }

        [HttpPost("{projectId}")]
        public async Task<IActionResult> AssignApplicationProject(int applicationId, int projectId)
        {

            var result = await _applicationService.AssignApplicationProjectAsync(applicationId, projectId);
            if (!result.Success)
                return BadRequest(result.Message);

            var scheduleResource = _mapper.Map<Project, ProjectResource>(result.Resource.Project);
            return Ok(scheduleResource);

        }

        [HttpPost("{userId}")]
        public async Task<IActionResult> AssignApplicationUser(int applicationId, int userId)
        {

            var result = await _applicationService.AssignApplicationUserAsync(applicationId, userId);
            if (!result.Success)
                return BadRequest(result.Message);

            var scheduleResource = _mapper.Map<User, UserResource>(result.Resource.User);
            return Ok(scheduleResource);

        }
    }
}
