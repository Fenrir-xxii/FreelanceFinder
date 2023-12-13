using FreelanceFinder.Application.Common;
using FreelanceFinder.Core.Entities;
using FreelanceFinder.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FreelanceFinder.Application.Services
{
    public class FreelancerSkillService : IEntityService<FreelancerSkill>
    {
        private readonly FreelanceContext _dbContext;
        public FreelancerSkillService(FreelanceContext context)
        {
            _dbContext = context;
        }
        public async Task CreateAsync(FreelancerSkill entity)
        {
            _dbContext.FreelancerSkills.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var freelancerSkill = _dbContext.FreelancerSkills.FirstOrDefault(x => x.Id == id);
            if (freelancerSkill == null)
            {
                throw new Exception("Item not found");
            }
            _dbContext.FreelancerSkills.Remove(freelancerSkill);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<FreelancerSkill>> GetAllAsync()
        {
            return await _dbContext.FreelancerSkills.Include(x => x.Skill).ToListAsync();
        }

        public async Task<FreelancerSkill> GetByIdAsync(int id)
        {
            var freelancerSkill = await _dbContext.FreelancerSkills.Include(x => x.Skill).FirstOrDefaultAsync(x => x.Id == id);
            if (freelancerSkill == null)
            {
                throw new Exception("Item not found");
            }
            return freelancerSkill;
        }

        public async Task UpdateAsync(FreelancerSkill entity)
        {
            var freelancerSkill = _dbContext.FreelancerSkills.Include(x => x.Skill).FirstOrDefault(x => x.Id == entity.Id);
            if (freelancerSkill == null)
            {
                throw new Exception("Item not found");
            }
            freelancerSkill.ExperienceInitDate = entity.ExperienceInitDate;
            freelancerSkill.Skill = entity.Skill;
            freelancerSkill.SkillId = entity.SkillId;
            freelancerSkill.FinishedProjectCount = entity.FinishedProjectCount;
            freelancerSkill.Freelancer = entity.Freelancer;
            freelancerSkill.FreelancerId = entity.FreelancerId;
            _dbContext.Update(freelancerSkill);
            await _dbContext.SaveChangesAsync();
        }
        
    }
}
