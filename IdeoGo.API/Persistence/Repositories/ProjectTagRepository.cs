using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Persistence.Contexts;
using IdeoGo.API.Domain.Repositories;

namespace IdeoGo.API.Persistence.Repositories
{
    public class ProjectTagRepository : BaseRepository, IProjectTagRepository
    {
        public ProjectTagRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(ProjectTag projectTag)
        {
           await _context.ProjectTags.AddAsync(projectTag);
        }

        public async Task AssignProjectTag(int projectId, int tagId)
        {
            ProjectTag projectTag = await FindByProjectIdAndTagId(projectId, tagId);
            if (projectTag == null)
            {
                projectTag = new ProjectTag { ProjectId = projectId, TagId = tagId };
                await AddAsync(projectTag);
            }
        }

        public async Task<ProjectTag> FindByProjectIdAndTagId(int projectId, int tagId)
        {
            return await _context.ProjectTags.FindAsync(projectId, tagId);
        }

        public async Task<IEnumerable<ProjectTag>> ListAsync()
        {
            return await _context.ProjectTags
                .Include(pt => pt.Project)
                .Include(pt => pt.Tag)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProjectTag>> ListByProjectIdAsync(int projectId)
        {
            return await _context.ProjectTags
             .Where(pt => pt.ProjectId == projectId)
             .Include(pt => pt.Project)
             .Include(pt => pt.Tag)
             .ToListAsync();
        }

        public async Task<IEnumerable<ProjectTag>> ListByTagIdAsync(int tagId)
        {
            return await _context.ProjectTags
               .Where(pt => pt.TagId == tagId)
               .Include(pt => pt.Project)
               .Include(pt => pt.Tag)
               .ToListAsync();
        }

        public void Remove(ProjectTag projectTag)
        {
            _context.ProjectTags.Remove(projectTag);
        }

        public async  void UnassignProjectTag(int projectId, int tagId)
        {
            ProjectTag projectTag = await FindByProjectIdAndTagId(projectId, tagId);
            if (projectTag != null)
            {
                Remove(projectTag);
            }
        }
    }
}
