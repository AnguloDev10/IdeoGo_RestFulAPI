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
        private readonly IMapper _mapper;

        public ProjectTagController(ITagService tagService, IProjectTagService productTagService, IMapper mapper)
        {
            _tagService = tagService;
            _projectTagService = productTagService;
            _mapper = mapper;
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
    }
}
