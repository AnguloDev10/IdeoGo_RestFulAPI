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
    public class MTaskService : IMTaskService
    {
        private readonly IMTaskRepository _mTaskRepository;
        public readonly IUnitOfWork _unitOfWork;

        public MTaskService(IMTaskRepository mTaskRepository, IUnitOfWork unitOfWork)
        {
            _mTaskRepository = mTaskRepository;
            _unitOfWork = unitOfWork;
        }

        public MTaskService(IMTaskRepository mTaskRepository)
        {
            _mTaskRepository = mTaskRepository;
        }

        public async Task<IEnumerable<MTask>> ListAsync()
        {
            return await _mTaskRepository.ListAsync();
        }

        public async Task<MTaskResponse> GetByIdAsync(int id)
        {
            var existingMTask = await _mTaskRepository.FindById(id);

            if (existingMTask == null)
                return new MTaskResponse("MTask not found");
            return new MTaskResponse(existingMTask);
        }

        public async Task<MTaskResponse> SaveAsync(MTask mTask)
        {
            try
            {
                await _mTaskRepository.AddAsync(mTask);
                await _unitOfWork.CompleteAsync();
                return new MTaskResponse(mTask);
            }
            catch (Exception ex)
            {
                return new MTaskResponse($"An error ocurred while saving the MTask: {ex.Message}");
            }
        }

        public async Task<MTaskResponse> UpdateAsync(int id, MTask mTask)
        {
            var existingMTask = await _mTaskRepository.FindById(id);

            if (existingMTask == null)
                return new MTaskResponse("MTask not found");

            existingMTask.Name = mTask.Name;

            try
            {
                _mTaskRepository.Update(existingMTask);
                await _unitOfWork.CompleteAsync();
                return new MTaskResponse(existingMTask);
            }
            catch (Exception ex)
            {
                return new MTaskResponse($"An error ocurred while updating MTask: {ex.Message}");
            }

        }

        public async Task<MTaskResponse> DeleteAsync(int id)
        {
            var existingMTask = await _mTaskRepository.FindById(id);

            if (existingMTask == null)
                return new MTaskResponse("MTask not found");

            try
            {
                _mTaskRepository.Remove(existingMTask);
                await _unitOfWork.CompleteAsync();
                return new MTaskResponse(existingMTask);
            }
            catch (Exception ex)
            {
                return new MTaskResponse($"An error ocurred while deleting MTask: {ex.Message}");
            }
        }

        public async Task<MTaskResponse> AssignTaskScheduleAsync(int taskId, int scheduleId)
        {
            try
            {

                await _mTaskRepository.AssignTaskSchedule(taskId, scheduleId);
                await _unitOfWork.CompleteAsync();
                MTask goal = await _mTaskRepository.FindById(taskId);
                return new MTaskResponse(goal);
            }
            catch (Exception ex)
            {
                return new MTaskResponse($"An error ocurred while assigning: {ex.Message}");
            }
        }

        public async Task<MTaskResponse> UnassignTaskScheduleAsync(int taskId, int scheduleId)
        {
            try
            {
                MTask task = await _mTaskRepository.FindById(taskId);
                _mTaskRepository.Remove(task);
                await _unitOfWork.CompleteAsync();
                return new MTaskResponse(task);
            }
            catch (Exception ex)
            {
                return new MTaskResponse($"An error ocurred while assigning: {ex.Message}");
            }
        }
    }
}
