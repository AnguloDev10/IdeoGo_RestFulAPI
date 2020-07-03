using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdeoGo.API.Resources;
using IdeoGo.API.Domain.Services;
using IdeoGo.API.Domain.Models;
using AutoMapper;
using IdeoGo.API.Extensions;


namespace IdeoGo.API.Controllers
{


    [Produces("application/json")]
    [Route("/api/[controller]")]
    public class AppoitmentController :Controller
    {
        private readonly IAppoitmentService _appoitmentService;
        private readonly IMapper _mapper;

        public AppoitmentController(IAppoitmentService appoitmentService,IMapper mapper)
        {
            _appoitmentService = appoitmentService;
            _mapper = mapper;
        }




        [HttpGet]
        public async Task<IEnumerable<AppoitmentResource>> GetAllAsync()
        {


            var products = await _appoitmentService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Appoitment>, IEnumerable<AppoitmentResource>>(products);
            return resources;


        }

        ///[HttpGet("{id}")]
        ///public async Task<IActionResult> GetAsync(int id)
        ///{
        ///    var result = await _appoitmentService.GetByIdAsync(id);
        ///    if (!result.Success)
        ///        return BadRequest(result.Message);
        ///    var mTaskResource = _mapper.Map<MTask, MTaskResource>(result.Resource);
        ///    return Ok(mTaskResource);
        ///
        ///}

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveAppoitmentResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var appoint = _mapper.Map<SaveAppoitmentResource, Appoitment>(resource);
            var result = await _appoitmentService.SaveAsync(appoint);

            if (!result.Success)
                return BadRequest(result.Message);

            var appointmentResource = _mapper.Map<Appoitment, AppoitmentResource>(result.Resource);
            return Ok(appointmentResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveAppoitmentResource resource)
        {
            var appoint = _mapper.Map<SaveAppoitmentResource, Appoitment>(resource);
            var result = await _appoitmentService.UpdateAsync(id, appoint);

            if (!result.Success)
                return BadRequest(result.Message);
            var mTaskResource = _mapper.Map<Appoitment, MTaskResource>(result.Resource);
            return Ok(mTaskResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _appoitmentService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            var appontResource = _mapper.Map<Appoitment, AppoitmentResource>(result.Resource);
            return Ok(appontResource);
        }


    }
}
