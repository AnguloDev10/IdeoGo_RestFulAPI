using AutoMapper;
using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Services;
using IdeoGo.API.Resources;
using IdeoGo.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdeoGo.API.Extensions;

namespace IdeoGo.API.Controllers
{
    public class SubscriptionController : Controller
    {
        private readonly ISubscriptionService _subscriptionService;
        private readonly IMapper _mapper;


        public SubscriptionController(ISubscriptionService subscriptionService, IMapper mapper)
        {
            _subscriptionService = subscriptionService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<SubscriptionResource>> GetAllAsync()
        {
            var subscription = await _subscriptionService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Subscription>, IEnumerable<SubscriptionResource>>(subscription);
            return resources;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _subscriptionService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var subscriptionResource = _mapper.Map<Subscription, SubscriptionResource>(result.Resource);
            return Ok(subscriptionResource);

        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveSubscriptionResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var membership = _mapper.Map<SaveSubscriptionResource, Subscription>(resource);
            var result = await _subscriptionService.SaveAsync(membership);

            if (!result.Success)
                return BadRequest(result.Message);

            var subscriptionResource = _mapper.Map<Subscription, SubscriptionResource>(result.Resource);
            return Ok(subscriptionResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveSubscriptionResource resource)
        {
            var subscription = _mapper.Map<SaveSubscriptionResource, Subscription>(resource);
            var result = await _subscriptionService.UpdateAsync(id, subscription);

            if (!result.Success)
                return BadRequest(result.Message);
            var subscriptionResource = _mapper.Map<Subscription, SubscriptionResource>(result.Resource);
            return Ok(subscriptionResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _subscriptionService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            var subscriptionResource = _mapper.Map<Subscription, SubscriptionResource>(result.Resource);
            return Ok(subscriptionResource);
        }

    }
}