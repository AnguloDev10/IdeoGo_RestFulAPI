using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Services;
using IdeoGo.API.Resources;

namespace IdeoGo.API.Controllers
{
    [Produces("application/json")]
    [Route("/api/[controller]")]
    public class ProjectUserController: Controller
    {
        private readonly IUserService _userservice;
        private readonly IProfileService _profileService;
        private readonly IProjectService _projectService;
        private readonly IProjectUserService _projectUserService;
        private readonly IMapper _mapper;


        public ProjectUserController(IUserService userservice, IProjectUserService projectUserService,
            IMapper mapper,IProfileService profileService,IProjectService projectService)
        {
            _userservice = userservice;
            _projectUserService = projectUserService;
            _mapper = mapper;
            _profileService = profileService;
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<IEnumerable<UserResource>> GetAllByProjectctIdAsync(int projectId)
        {
            var users = await _userservice.ListByProjectIdAsync(projectId);
            var resources = _mapper
                .Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
            return resources;
        }

        [HttpPost("{userId}")]
        public async Task<IActionResult> AssingProject(int projectId, int userId)
        {

            var result = await _projectUserService.AssignProjectUserAsync(projectId, userId);
            if (!result.Success)
                return BadRequest(result.Message);

            var userResource = _mapper.Map<User, UserResource>(result.Resource.User);
            return Ok(userResource);

        }
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> ListProjectByProjectUsertByUserId( int userId)
        {

            var result = await _projectService.ListByProjectUserByUserIdAsync(userId);
            var resources = _mapper.Map<IEnumerable<Project>, IEnumerable<ProjectResource>>(result);
            return Ok(resources);

        }
        [HttpGet("project/{projectId}")]
        public async Task<IActionResult> ListProfileByProjectUserByProjectId(int projectId)
        {

            var result = await _profileService.ListByProjectUserByProjectIdAsync(projectId);
            var resources = _mapper.Map<IEnumerable<Domain.Models.Profile>, IEnumerable<ProfileResource>>(result);
            return Ok(resources);

        }

    }
}
