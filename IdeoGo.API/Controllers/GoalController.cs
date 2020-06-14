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
    public class GoalController : Controller
    {
        private readonly IGoalService _goalService;
        private readonly IMapper _mapper;

        public GoalController(IGoalService goalService, IMapper mapper)
        {
            _goalService = goalService;  
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<GoalResource>> GetAllAsync()
        {
            var goals = await _goalService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Goal>, IEnumerable<GoalResource>>(goals);
            return resources;
        }
        

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveTagResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var goal = _mapper.Map<SaveTagResource, Goal>(resource); 

            var result = await _goalService.SaveAsync(goal); 


        
            if (!result.Success)
                return BadRequest(result.Message);

            //

            var goalResource = _mapper.Map<Goal, GoalResource>(result.Resource);

            return Ok(goalResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, SaveTagResource resource)
        {
            var goal = _mapper.Map<SaveTagResource, Goal>(resource);
            var result = await _goalService.UpdateAsync(id, goal);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var goalResource = _mapper.Map<Goal, GoalResource>(result.Resource);
            return Ok(goalResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {

            var result = await _goalService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var goalResource = _mapper.Map<Goal, GoalResource>(result.Resource);
            return Ok(goalResource);
        }
    }
}

