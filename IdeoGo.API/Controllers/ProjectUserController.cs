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
    [Route("/api/[controller]")]
    public class ProjectUserController: Controller
    {
        private readonly ITagService _tagService;
        private readonly IProjectTagService _projectTagService;
        private readonly IMapper _mapper;


        public ProjectUserController(ITagService tagService, IProjectTagService projectTagService, IMapper mapper)
        {
            _tagService = tagService;
            _projectTagService = projectTagService;
            _mapper = mapper;
        }

        //[HttpGet]
        //public async Task<IEnumerable<UserResource>> GetAllByProductIdAsync(int productId)
        //{
        //    var tags = await _tagService.Lis(productId);
        //    var resources = _mapper
        //        .Map<IEnumerable<Tag>, IEnumerable<TagResource>>(tags);
        //    return resources;
        //}

        [HttpPost("{tagId}")]
        public async Task<IActionResult> AssignProductTag(int productId, int tagId)
        {

            var result = await _projectTagService.AssignProjectTagAsync(productId, tagId);
            if (!result.Success)
                return BadRequest(result.Message);

            var tagResource = _mapper.Map<Tag, TagResource>(result.Resource.Tag);
            return Ok(tagResource);

        }

    }
}
