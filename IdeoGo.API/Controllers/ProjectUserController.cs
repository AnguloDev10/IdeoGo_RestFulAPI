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
        private readonly IProjectUserService _projectUserService;
        private readonly IMapper _mapper;


        public ProjectUserController(IUserService userservice, IProjectUserService projectUserService, IMapper mapper)
        {
            _userservice = userservice;
            _projectUserService = projectUserService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<UserResource>> GetAllByProjectctIdAsync(int projectId)
        {
            var users = await _userservice.ListByProjectIdAsync(projectId);
            var resources = _mapper
                .Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
            return resources;
        }

        [HttpPost("{tagId}")]
        public async Task<IActionResult> AssingProject(int projectId, int userId)
        {

            var result = await _projectUserService.AssignProjectUserAsync(projectId, userId);
            if (!result.Success)
                return BadRequest(result.Message);

            var userResource = _mapper.Map<User, UserResource>(result.Resource.User);
            return Ok(userResource);

        }

    }
}
