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
    public class RequierementsController:Controller
    {
        private readonly IRequierementService _requierementService;
        private readonly IMapper _mapper;

        public RequierementsController(IRequierementService requierementService, IMapper mapper)
        {
            _requierementService = requierementService;
            _mapper = mapper;
        }



        [HttpGet]
        public async Task<IEnumerable<RequierementResource>> GetAllAsync()
        {
            var requierement = await _requierementService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Requierement>, IEnumerable<RequierementResource>>(requierement);
            return resources;
        }


        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveRequierementResource resource)
        {


            var requierement = _mapper.Map<SaveRequierementResource, Requierement>(resource);

            var result = await _requierementService.SaveAsync(requierement);



            if (!result.Success)
                return BadRequest(result.Message);

            //

            var requierementResource = _mapper.Map<Requierement, RequierementResource>(result.Resource);

            return Ok(requierementResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, SaveRequierementResource resource)
        {
            var requierements = _mapper.Map<SaveRequierementResource, Requierement>(resource);
            var result = await _requierementService.UpdateAsync(id, requierements);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var requierementResource = _mapper.Map<Requierement, RequierementResource>(result.Resource);
            return Ok(requierementResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {

            var result = await _requierementService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var requierementResource = _mapper.Map<Requierement, RequierementResource>(result.Resource);
            return Ok(requierementResource);
        }

    }
}
