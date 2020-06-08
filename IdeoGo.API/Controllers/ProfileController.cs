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
    public class ProfileController : Controller
    {
        private readonly IProfileService _profileService;
        private readonly IMapper _mapper;

        public ProfileController(IProfileService  profileService, IMapper mapper)
        {
            _profileService = profileService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProfileResource>> GetAllAsync()
        {
            var profiles = await _profileService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Domain.Models.Profile>, IEnumerable<ProfileResource>>(profiles);
            return resources;
        }



        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveProfileResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var profile = _mapper.Map<SaveProfileResource, Domain.Models.Profile>(resource);

            var result = await _profileService.SaveAsync(profile);



            if (!result.Success)
                return BadRequest(result.Message);

            var profileResource = _mapper.Map<Domain.Models.Profile, ProfileResource>(result.Resource);

            return Ok(profileResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, SaveProfileResource resource)
        {
            var profile = _mapper.Map<SaveProfileResource, Domain.Models.Profile>(resource);
            var result = await _profileService.UpdateAsync(id, profile);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var categoryResource = _mapper.Map<Domain.Models.Profile, ProfileResource>(result.Resource);
            return Ok(categoryResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {

            var result = await _profileService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var profileResource = _mapper.Map<Domain.Models.Profile, ProfileResource>(result.Resource);
            return Ok(profileResource);
        }
    }
}


