﻿using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Repositories;
using IdeoGo.API.Domain.Services;
using IdeoGo.API.Domain.Services.Communication;
using IdeoGo.API.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Services
{
    public class MembershipService : IMembershipService
    {
        private readonly IMembershipRepository _membershipRepository;
        public readonly IUnitOfWork _unitOfWork;

        public MembershipService(IMembershipRepository membershipRepository, IUnitOfWork unitOfWork)
        {
            _membershipRepository = membershipRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<MembershipResponse> DeleteAsync(int id)
        {
            var existingMembership = await _membershipRepository.FindByIdAsync(id);

            if (existingMembership == null)
                return new MembershipResponse("membership not found.");

            try
            {
                _membershipRepository.Remove(existingMembership);
                await _unitOfWork.CompleteAsync();

                return new MembershipResponse(existingMembership);

            }
            catch (Exception ex)
            {
                return new MembershipResponse($"An error ocurred while deleting the membership : {ex.Message}");
            }
        }

        public async Task<IEnumerable<Membership>> ListAsync()
        {
            return await _membershipRepository.ListAsync();
        }

        public async Task<MembershipResponse> SaveAsync(Membership membership)
        {
            try
            {
                await _membershipRepository.AddAsync(membership);
                await _unitOfWork.CompleteAsync();
                return new MembershipResponse(membership);
            }
            catch (Exception ex)
            {

                return new MembershipResponse($"An error ocurred while saving the membership : {ex.Message}");
            }
            throw new NotImplementedException();
        }

        public async Task<MembershipResponse> GetByIdAsync(int id)
        {
            var existingMembership = await _membershipRepository.FindByIdAsync(id);

            if (existingMembership == null)
                return new MembershipResponse("Membership not found");
            return new MembershipResponse(existingMembership);
        }

        public async Task<MembershipResponse> UpdateAsync(int id, Membership membership)
        {
            var existingMembership = await _membershipRepository.FindByIdAsync(id);

            if (existingMembership == null)
                return new MembershipResponse("Membership not found");

            existingMembership.Name = membership.Name;

            try
            {
                _membershipRepository.Update(existingMembership);
                await _unitOfWork.CompleteAsync();
                return new MembershipResponse(existingMembership);
            }
            catch (Exception ex)
            {
                return new MembershipResponse($"An error ocurred while updating Membership: {ex.Message}");
            }
        }

        public async Task<MembershipResponse> AssignMemberUserAsync(int memberId, int userId)
        {
            try
            {

                await _membershipRepository.AssigMembershipUser(memberId, userId);
                await _unitOfWork.CompleteAsync();
                Membership goal = await _membershipRepository.FindByIdAsync(memberId);
                return new MembershipResponse(goal);
            }
            catch (Exception ex)
            {
                return new MembershipResponse($"An error ocurred while assigning: {ex.Message}");
            }
        }

        public async Task<MembershipResponse> UnassignMemberUserAsync(int memberId, int userId)
        {
            try
            {
                Membership goal = await _membershipRepository.FindByIdAsync(memberId);
                _membershipRepository.Remove(goal);
                await _unitOfWork.CompleteAsync();
                return new MembershipResponse(goal);
            }
            catch (Exception ex)
            {
                return new MembershipResponse($"An error ocurred while assigning: {ex.Message}");
            }
        }
    }
}
