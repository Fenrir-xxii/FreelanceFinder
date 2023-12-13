using FreelanceFinder.Application.Common;
using FreelanceFinder.Core.Entities;
using FreelanceFinder.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FreelanceFinder.Application.Services
{
    public class FreelancerService : IEntityService<Freelancer>
    {
        private readonly FreelanceContext _dbContext;
        public FreelancerService(FreelanceContext context)
        {
            _dbContext = context;
        }
        public async Task CreateAsync(Freelancer entity)
        {
            _dbContext.Freelancers.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var freelancer = _dbContext.Freelancers.FirstOrDefault(x => x.Id == id);
            if (freelancer == null)
            {
                throw new Exception("Item not found");
            }
            _dbContext.Freelancers.Remove(freelancer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Freelancer>> GetAllAsync()
        {
            return await _dbContext.Freelancers.Include(x => x.Skills).ToListAsync();
        }

        public async Task<Freelancer> GetByIdAsync(int id)
        {
            var freelancer = await _dbContext.Freelancers.Include(x => x.Skills).FirstOrDefaultAsync(x => x.Id == id);
            if (freelancer == null)
            {
                throw new Exception("Item not found");
            }
            return freelancer;
        }

        public async Task UpdateAsync(Freelancer entity)
        {
            var freelancer = _dbContext.Freelancers.Include(x => x.Skills).FirstOrDefault(x => x.Id == entity.Id);
            if (freelancer == null)
            {
                throw new Exception("Item not found");
            }
            freelancer.FirstName = entity.FirstName;
            freelancer.LastName = entity.LastName;
            freelancer.ApprovedProjectsCount = entity.ApprovedProjectsCount;
            freelancer.FinishedProjectsCount = entity.FinishedProjectsCount;
            freelancer.RegistrationDate = entity.RegistrationDate;
            freelancer.Rating = entity.Rating;
            freelancer.Skills = entity.Skills;

            _dbContext.Update(freelancer);
            await _dbContext.SaveChangesAsync();
        }
        public async Task AddSkill(int freelancerId, FreelancerSkill skill)
        {
            var freelancer = _dbContext.Freelancers.Include(x => x.Skills).FirstOrDefault(x => x.Id == freelancerId);
            var skillDb = _dbContext.FreelancerSkills.FirstOrDefault(x => x.Id == skill.Id);
            if (freelancer == null || skillDb == null)
            {
                throw new Exception("Item not found");
            }
            if(freelancer.Skills.Any(x => x.Id != skillDb.Id))
            {
                freelancer.Skills.Add(skillDb);
                _dbContext.Update(freelancer);
                await _dbContext.SaveChangesAsync();
            }
        }
        // TO DO remove skill
    }
}
