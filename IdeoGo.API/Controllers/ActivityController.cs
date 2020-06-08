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

    public class ActivityController :Controller
    {
        private readonly IActivityService _activityService;
        private readonly IMapper _mapper;

        public ActivityController(IActivityService activityService,IMapper mapper)
        {
            _activityService = activityService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ActivityResource>> GetAllAsync()
        {
            var activity = await _activityService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Activity>, IEnumerable<ActivityResource>>(activity);
            return resources;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _activityService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var activityResource = _mapper.Map<Activity, ActivityResource>(result.Resource);
            return Ok(activityResource);

        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveActivityResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var activity = _mapper.Map<SaveActivityResource, Activity>(resource);
            var result = await _activityService.SaveAsync(activity);

            if (!result.Success)
                return BadRequest(result.Message);

            var activityResource = _mapper.Map<Activity, ActivityResource>(result.Resource);
            return Ok(activityResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveActivityResource resource)
        {
            var activity = _mapper.Map<SaveActivityResource, Activity>(resource);
            var result = await _activityService.UpdateAsync(id, activity);

            if (!result.Success)
                return BadRequest(result.Message);
            var activityResource = _mapper.Map<Activity, ActivityResource>(result.Resource);
            return Ok(activityResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _activityService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            var activityResource = _mapper.Map<Activity, ActivityResource>(result.Resource);
            return Ok(activityResource);
        }
    }
}
