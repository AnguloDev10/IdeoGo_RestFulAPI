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
    public class ResourcesController:Controller
    {
       
          private readonly IResourceService _resourceService;
            private readonly IMapper _mapper;
        
            public ResourcesController(IResourceService resourceService, IMapper mapper)
            {
                _resourceService = resourceService;
                _mapper = mapper;
            }
        
            [HttpGet]
            public async Task<IEnumerable<ResourceResource>> GetAllAsync()
            {
                var resources = await _resourceService.ListAsync();
                var _resources = _mapper.Map<IEnumerable<Resource>, IEnumerable<ResourceResource>>(resources);
                return _resources;
            }
        
        
            [HttpPost]
            public async Task<IActionResult> PostAsync([FromBody] SaveResourceResource resource)
            {
        
        
                var _resource = _mapper.Map<SaveResourceResource, Resource>(resource);
        
                var result = await _resourceService.SaveAsync(_resource);
        
        
        
                if (!result.Success)
                    return BadRequest(result.Message);
        
                //
        
                var _ResourceResource = _mapper.Map<Resource, ResourceResource>(result.Resource);
        
                return Ok(_ResourceResource);
            }
        
            [HttpPut("{id}")]
            public async Task<IActionResult> PutAsync(int id, SaveResourceResource resource)
            {
                var _resource = _mapper.Map<SaveResourceResource, Resource>(resource);
                var result = await _resourceService.UpdateAsync(id, _resource);
        
                if (!result.Success)
                {
                    return BadRequest(result.Message);
                }
        
                var _ResourceResource = _mapper.Map<Resource, ResourceResource>(result.Resource);
                return Ok(_ResourceResource);
            }
        
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteAsync(int id)
            {
        
                var result = await _resourceService.DeleteAsync(id);
        
                if (!result.Success)
                {
                    return BadRequest(result.Message);
                }
        
                var _ResourceResource = _mapper.Map<Resource, ResourceResource>(result.Resource);
                return Ok(_ResourceResource);
            }
        
    }
}
