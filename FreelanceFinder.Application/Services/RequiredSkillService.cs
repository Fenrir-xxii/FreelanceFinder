using FreelanceFinder.Application.Common;
using FreelanceFinder.Core.Entities;
using FreelanceFinder.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FreelanceFinder.Application.Services
{
    public class RequiredSkillService : IEntityService<RequiredSkill>
    {
        private readonly FreelanceContext _dbContext;
        public RequiredSkillService(FreelanceContext context)
        {
            _dbContext = context;
        }
        public async Task CreateAsync(RequiredSkill entity)
        {
            _dbContext.RequiredSkills.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var requiredSkill = _dbContext.RequiredSkills.FirstOrDefault(x => x.Id == id);
            if (requiredSkill == null)
            {
                throw new Exception("Item not found");
            }
            _dbContext.RequiredSkills.Remove(requiredSkill);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<RequiredSkill>> GetAllAsync()
        {
            return await _dbContext.RequiredSkills.Include(x => x.Skill).ToListAsync();
        }

        public async Task<RequiredSkill> GetByIdAsync(int id)
        {
            var requiredSkill = await _dbContext.RequiredSkills.Include(x => x.Skill).FirstOrDefaultAsync(x => x.Id == id);
            if (requiredSkill == null)
            {
                throw new Exception("Item not found");
            }
            return requiredSkill;
        }

        public async Task UpdateAsync(RequiredSkill entity)
        {
            var requiredSkill = _dbContext.RequiredSkills.Include(x => x.Skill).FirstOrDefault(x => x.Id == entity.Id);
            if (requiredSkill == null)
            {
                throw new Exception("Item not found");
            }
            requiredSkill.Skill = entity.Skill;
            requiredSkill.SkillId = entity.SkillId;
            requiredSkill.MonthsOfExperience = entity.MonthsOfExperience;
            requiredSkill.FinishedProjectCount = entity.FinishedProjectCount;
            _dbContext.Update(requiredSkill);
            await _dbContext.SaveChangesAsync();
        }
    }
}
