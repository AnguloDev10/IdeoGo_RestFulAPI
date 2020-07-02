using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Repositories;
using IdeoGo.API.Domain.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Persistence.Repositories
{
    public class GoalRepository : BaseRepository, IGoalRepository
    {
        public GoalRepository(AppDbContext context) : base(context) { }
        public async Task AddAsync(Goal goal)
        {
            await _context.Goals.AddAsync(goal);
        }

        public async Task<Goal> FindByIDAsync(int id)
        {
            return await _context.Goals.FindAsync(id);
        }

        public async Task<IEnumerable<Goal>> ListAsync()
        {
            return await _context.Goals.ToListAsync();
        }

        public void Remove(Goal goal)
        {
            _context.Goals.FindAsync(goal); 
        }

        public void Update(Goal goal)
        {
            _context.Goals.Update(goal);
        }

        public async Task AssignGoalProject(int goalId, int projectId)
        {
            Goal GoalProject = await FindByIDAsync(goalId);
            if (GoalProject == null)
            {
                GoalProject = new Goal { Id = goalId, ProjectId = projectId };
                await AddAsync(GoalProject);
            }
        }

        public async void UnassignGoalProject(int goalId, int projectId)
        {
            Goal GoalProject = await FindByIDAsync(goalId);
            if (GoalProject == null)
            {
                Remove(GoalProject);
            }
        }
    }
}
