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
    [Route("/api/[controller]")]
    public class TagController : Controller
    {
        private readonly ITagService _tagService;
        private readonly IMapper _mapper;

        public TagController(ITagService tagService, IMapper mapper)
        {
            _tagService = tagService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<TagResource>> GetAllAsync()
        {
            var publications = await _tagService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Tag>, IEnumerable<TagResource>>(publications);
            return resources;
        }


        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveTagResource resource)
        {
            // if (!ModelState.IsValid)
            //     return BadRequest(ModelState.GetErrorMessages());

            var tag = _mapper.Map<SaveTagResource, Tag>(resource);

            var result = await _tagService.SaveAsync(tag);



            if (!result.Success)
                return BadRequest(result.Message);

            //

            var tagResource = _mapper.Map<Tag, TagResource>(result.Tag);

            return Ok(tagResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, SaveTagResource resource)
        {
            var tag = _mapper.Map<SaveTagResource, Tag>(resource);
            var result = await _tagService.UpdateAsync(id, tag);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var categoryResource = _mapper.Map<Tag, TagResource>(result.Tag);
            return Ok(categoryResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {

            var result = await _tagService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var tagResource = _mapper.Map<Tag, TagResource>(result.Tag);
            return Ok(tagResource);
        }
    }
}

