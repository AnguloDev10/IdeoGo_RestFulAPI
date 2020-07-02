﻿using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Repositories;
using IdeoGo.API.Domain.Services;
using IdeoGo.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Services
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;
        public readonly IUnitOfWork _unitOfWork;

        public SkillService(ISkillRepository skillRepository, IUnitOfWork unitOfWork)
        {
            _skillRepository = skillRepository;
            _unitOfWork = unitOfWork;
        }

        public SkillService(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<SkillResponse> DeleteAsync(int id)
        {
            var existingSkill = await _skillRepository.FindByIdAsync(id);

            if (existingSkill == null)
                return new SkillResponse("skill not found.");

            try
            {
                _skillRepository.Remove(existingSkill);
                await _unitOfWork.CompleteAsync();

                return new SkillResponse(existingSkill);

            }
            catch (Exception ex)
            {
                return new SkillResponse($"An error ocurred while deleting the skill : {ex.Message}");
            }
        }

        public async Task<IEnumerable<Skill>> ListAsync()
        {
            return await _skillRepository.ListAsync();
        }

        public async Task<SkillResponse> SaveAsync(Skill skill)
        {
            try
            {
                await _skillRepository.AddAsync(skill);
                await _unitOfWork.CompleteAsync();
                return new SkillResponse(skill);
            }
            catch (Exception ex)
            {

                return new SkillResponse($"An error ocurred while saving the skill : {ex.Message}");
            }
            throw new NotImplementedException();
        }

        public async Task<SkillResponse> UpdateAsync(int id, Skill skill)
        {
            var existingSkill = await _skillRepository.FindByIdAsync(id);

            if (existingSkill == null)
                return new SkillResponse("Skill not found.");
            existingSkill.Id = skill.Id;
            try
            {
                _skillRepository.Update(existingSkill);
                await _unitOfWork.CompleteAsync();
                return new SkillResponse(existingSkill);
            }
            catch (Exception ex)
            {
                return new SkillResponse($"An error ocurred while updating the skill : {ex.Message}");
            }

            throw new NotImplementedException();
        }

        public async Task<SkillResponse> AssignSkillTagAsync(int skillId, int tagId)
        {
            try
            {
                await _skillRepository.AssignSkillTag(skillId, tagId);
                await _unitOfWork.CompleteAsync();
                Skill skill = await _skillRepository.FindByIdAsync(skillId);
                return new SkillResponse(skill);
            }
            catch (Exception ex)
            {
                return new SkillResponse($"An error ocurred while assigning: {ex.Message}");
            }
        }

        public async Task<SkillResponse> UnassignSkillTagAsync(int skillId, int tagId)
        {
            try
            {
                Skill skill = await _skillRepository.FindByIdAsync(skillId);
                _skillRepository.Remove(skill);
                await _unitOfWork.CompleteAsync();
                return new SkillResponse(skill);
            }
            catch (Exception ex)
            {
                return new SkillResponse($"An error ocurred while assigning: {ex.Message}");
            }
        }

        public async Task<SkillResponse> AssignSkillProfileAsync(int skillId, int profileId)
        {
            try
            {
                await _skillRepository.AssignSkillTag(skillId, profileId);
                await _unitOfWork.CompleteAsync();
                Skill skill = await _skillRepository.FindByIdAsync(skillId);
                return new SkillResponse(skill);
            }
            catch (Exception ex)
            {
                return new SkillResponse($"An error ocurred while assigning: {ex.Message}");
            }
        }

        public async Task<SkillResponse> UnassignSkillProfileAsync(int skillId, int profileId)
        {
            try
            {
                Skill skill = await _skillRepository.FindByIdAsync(skillId);
                _skillRepository.Remove(skill);
                await _unitOfWork.CompleteAsync();
                return new SkillResponse(skill);
            }
            catch (Exception ex)
            {
                return new SkillResponse($"An error ocurred while assigning: {ex.Message}");
            }
        }
    }
}
