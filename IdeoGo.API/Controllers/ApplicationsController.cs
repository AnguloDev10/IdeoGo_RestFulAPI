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
        private readonly IApplicationService _applicationService;
        private readonly IMapper _mapper;

        public ApplicationsController(IApplicationService applicationService, IMapper mapper)
        {
            _applicationService = applicationService;
            _mapper = mapper;
        }



        [HttpGet]
        public async Task<IEnumerable<ApplicationResource>> GetAllAsync()
        {
            var Applications = await _applicationService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Application>, IEnumerable<ApplicationResource>>(Applications);
            return resources;
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


    }
}
