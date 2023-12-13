using FreelanceFinder.Application.Common;
using FreelanceFinder.Core.Entities;
using FreelanceFinder.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FreelanceFinder.Application.Services
{
    public class SkillService : IEntityService<Skill>
    {
        private readonly FreelanceContext _dbContext;
        public SkillService(FreelanceContext context)
        {
            _dbContext = context;
        }
        public async Task CreateAsync(Skill entity)
        {
            _dbContext.Skills.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var skill = _dbContext.Skills.FirstOrDefault(x => x.Id == id);
            if (skill == null)
            {
                throw new Exception("Item not found");
            }
            _dbContext.Skills.Remove(skill);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Skill>> GetAllAsync()
        {
            return await _dbContext.Skills.Include(x => x.SkillArea).ToListAsync();
        }

        public async Task<Skill> GetByIdAsync(int id)
        {
            var skill = await _dbContext.Skills.Include(x => x.SkillArea).FirstOrDefaultAsync(x => x.Id == id);
            if (skill == null)
            {
                throw new Exception("Item not found");
            }
            return skill;
        }

        public async Task UpdateAsync(Skill entity)
        {
            var skill = _dbContext.Skills.Include(x => x.SkillArea).FirstOrDefault(x => x.Id == entity.Id);
            if (skill == null)
            {
                throw new Exception("Item not found");
            }
            skill.Title = entity.Title;
            skill.SkillArea = entity.SkillArea;
            skill.SkillAreaId = entity.SkillAreaId;
            _dbContext.Update(skill);
            await _dbContext.SaveChangesAsync();
        }
    }
}
