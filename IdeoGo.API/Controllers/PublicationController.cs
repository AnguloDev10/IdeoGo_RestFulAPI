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
    public class PublicationController : Controller
    {
        private readonly IPublicationService _publicationService;
        private readonly IMapper _mapper;

        public PublicationController(IPublicationService publicationService, IMapper mapper)
        {
            _publicationService = publicationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<PublicationResource>> GetAllAsync()
        {
            var publications = await _publicationService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Publication>, IEnumerable<PublicationResource>>(publications);
            return resources;
        }


        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SavePublicationResource resource)
        {
            // if (!ModelState.IsValid)
            //     return BadRequest(ModelState.GetErrorMessages());

            var Publication = _mapper.Map<SavePublicationResource, Publication>(resource);

            var result = await _publicationService.SaveAsync(Publication);



            if (!result.Success)
                return BadRequest(result.Message);

            //

            var categoryResource = _mapper.Map<Publication, PublicationResource>(result.Publication);

            return Ok(categoryResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, SavePublicationResource resource)
        {
            var goal = _mapper.Map<SavePublicationResource, Publication>(resource);
            var result = await _publicationService.UpdateAsync(id, goal);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var categoryResource = _mapper.Map<Publication, PublicationResource>(result.Publication);
            return Ok(categoryResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {

            var result = await _publicationService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var categoryResource = _mapper.Map<Publication, PublicationResource>(result.Publication);
            return Ok(categoryResource);
        }
    }
}
