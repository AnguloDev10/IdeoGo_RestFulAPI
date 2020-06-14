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
    public class MembershipController : Controller
    {
        private readonly IMembershipService _membershipService;
        private readonly IMapper _mapper;


        public MembershipController(IMembershipService membershipService, IMapper mapper)
        {
            _membershipService = membershipService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<MembershipResource>> GetAllAsync()
        {
            var membership = await _membershipService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Membership>, IEnumerable<MembershipResource>>(membership);
            return resources;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _membershipService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var membershipResource = _mapper.Map<Membership, MembershipResource>(result.Resource);
            return Ok(membershipResource);

        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveMembershipResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var membership = _mapper.Map<SaveMembershipResource, Membership>(resource);
            var result = await _membershipService.SaveAsync(membership);

            if (!result.Success)
                return BadRequest(result.Message);

            var membershipResource = _mapper.Map<Membership, MembershipResource>(result.Resource);
            return Ok(membershipResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveMembershipResource resource)
        {
            var membership = _mapper.Map<SaveMembershipResource, Membership>(resource);
            var result = await _membershipService.UpdateAsync(id, membership);

            if (!result.Success)
                return BadRequest(result.Message);
            var membershipResource = _mapper.Map<Membership, MembershipResource>(result.Resource);
            return Ok(membershipResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _membershipService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            var membershipResource = _mapper.Map<Membership, MembershipResource>(result.Resource);
            return Ok(membershipResource);
        }

    }
}
