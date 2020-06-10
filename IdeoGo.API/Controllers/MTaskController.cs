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
    public class MTaskController : Controller
    {
        private readonly IMTaskService _mTaskService;
        private readonly IMapper _mapper;

        public MTaskController(IMTaskService mTaskService, IMapper mapper)
        {
            _mTaskService = mTaskService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<MTaskResource>> GetAllAsync()
        {
            var mTask = await _mTaskService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<MTask>, IEnumerable<MTaskResource>>(mTask);
            return resources;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _mTaskService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var mTaskResource = _mapper.Map<MTask, MTaskResource>(result.Resource);
            return Ok(mTaskResource);

        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveMTaskResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var mTask = _mapper.Map<SaveMTaskResource, MTask>(resource);
            var result = await _mTaskService.SaveAsync(mTask);

            if (!result.Success)
                return BadRequest(result.Message);

            var mTaskResource = _mapper.Map<MTask, MTaskResource>(result.Resource);
            return Ok(mTaskResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveMTaskResource resource)
        {
            var mTask = _mapper.Map<SaveMTaskResource, MTask>(resource);
            var result = await _mTaskService.UpdateAsync(id, mTask);

            if (!result.Success)
                return BadRequest(result.Message);
            var mTaskResource = _mapper.Map<MTask, MTaskResource>(result.Resource);
            return Ok(mTaskResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _mTaskService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            var mTaskResource = _mapper.Map<MTask, MTaskResource>(result.Resource);
            return Ok(mTaskResource);
        }
    }
}
