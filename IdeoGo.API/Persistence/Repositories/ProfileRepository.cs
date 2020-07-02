using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Persistence.Contexts;
using IdeoGo.API.Domain.Repositories;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Persistence.Repositories
{
    public class ProfileRepository : BaseRepository, IProfileRepository
    {
        public ProfileRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(Profile profile)
        {
            await _context.Profiles.AddAsync(profile);
        }

        public async Task<Profile> FindById(int id)
        {
            return await _context.Profiles.FindAsync(id);
        }

        public async Task<IEnumerable<Profile>> ListAsync()
        {
            return await _context.Profiles.ToListAsync();
        }

        public void Remove(Profile profile)
        {
            _context.Profiles.FindAsync(profile);
        }

        public void Update(Profile profile)
        {
            _context.Profiles.Update(profile);
        }

        public async Task AssignProfileTag(int profileId, int tagId)
        {
            Profile profileTag = await FindById(profileId);
            if (profileTag == null)
            {
                profileTag = new Profile { Id = profileId, TagId = tagId };
                await AddAsync(profileTag);
            }
        }

        public async Task AssignProfileUser(int profileId, int userId)
        {
            Profile profileUser = await FindById(profileId);
            if (profileUser == null)
            {
                profileUser = new Profile { Id = profileId, UserId = userId };
                await AddAsync(profileUser);
            }
        }


        public async void UnassignProfileTag(int profileId, int tagId)
        {
            Profile profileTag = await FindById(profileId);
            if (profileTag == null)
            {
                Remove(profileTag);
            }
        }

        public async void UnassignProfileUser(int profileId, int userId)
        {
            Profile profileUser = await FindById(profileId);
            if (profileUser == null)
            {
                Remove(profileUser);
            }
        }


    }
}
