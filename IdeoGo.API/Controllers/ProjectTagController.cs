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
    public class ProjectTagController :Controller
    {
        private readonly ITagService _tagService;
        private readonly IProjectTagService _projectTagService;
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public ProjectTagController(ITagService tagService, IProjectTagService productTagService, IMapper mapper
            ,IProjectService projectService)
        {
            _tagService = tagService;
            _projectTagService = productTagService;
            _mapper = mapper;
            _projectService = projectService;
        }

       /// [HttpGet]
       /// public async Task<IEnumerable<TagResource>> GetAllByProjectIdAsync(int productId)
       /// {
       ///     var tags = await _tagService.ListByProjectIdAsync(productId);
       ///     var resources = _mapper
       ///         .Map<IEnumerable<Tag>, IEnumerable<TagResource>>(tags);
       ///     return resources;
       /// }

        [HttpPost("{tagId}")]
        public async Task<IActionResult> AssignProjectTag(int productId, int tagId)
        {

            var result = await _projectTagService.AssignProjectTagAsync(productId, tagId);
            if (!result.Success)
                return BadRequest(result.Message);

            var tagResource = _mapper.Map<Tag, TagResource>(result.Resource.Tag);
            return Ok(tagResource);

        }
        [HttpGet("tag/{tag}")]
        public async Task<IActionResult> ListProjectByTagNameAsync(string tag)
        {
            var result = await _projectService.ListByTagName(tag);
            var resources = _mapper.Map<IEnumerable<Project>, IEnumerable<ProjectResource>>(result);
            return Ok(resources);
        }
    }
}
