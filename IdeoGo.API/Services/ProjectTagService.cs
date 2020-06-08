using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Repositories;
using IdeoGo.API.Domain.Services;
using IdeoGo.API.Domain.Services.Communications;

namespace IdeoGo.API.Services
{
    public class ProjectTagService: IProjectTagService
    {
         private readonly IProjectTagRepository _projectTagRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ProjectTagService(IProjectTagRepository projectTagRepository, IUnitOfWork unitOfWork)
    {
        _projectTagRepository = projectTagRepository;
        _unitOfWork = unitOfWork;
    }

        public async Task<ProjectTagResponse> AssignProjectTagAsync(int projectId, int tagId)
        {

            try
            {

                await _projectTagRepository.AssignProjectTag(projectId, tagId);
                await _unitOfWork.CompleteAsync();
                ProjectTag productTag = await _projectTagRepository.FindByProjectIdAndTagId(projectId, tagId);
                return new ProjectTagResponse(productTag);
            }
            catch (Exception ex)
            {
                return new ProjectTagResponse($"An error ocurred while assigning Tag to Product: {ex.Message}");
            }
        }

        public Task<IEnumerable<ProjectTag>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public  async Task<IEnumerable<ProjectTag>> ListByProjectIdAsync(int projectId)
        {
            return await _projectTagRepository.ListByProjectIdAsync(projectId);
        }

        public async  Task<IEnumerable<ProjectTag>> ListByTagIdAsync(int tagId)
        {
            return await _projectTagRepository.ListByTagIdAsync(tagId);
        }

        public async  Task<ProjectTagResponse> UnassignProjectTagAsync(int projectId, int tagId)
        {
            try
            {
                ProjectTag projectTag = await _projectTagRepository.FindByProjectIdAndTagId(projectId, tagId);
                _projectTagRepository.Remove(projectTag);
                await _unitOfWork.CompleteAsync();
                return new ProjectTagResponse(projectTag);
            }
            catch (Exception ex)
            {
                return new ProjectTagResponse($"An error ocurred while assigning Tag to Product: {ex.Message}");
            }
        }
    }
}
