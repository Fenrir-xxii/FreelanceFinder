using FreelanceFinder.Application.Common;
using FreelanceFinder.Core.Entities;
using FreelanceFinder.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FreelanceFinder.Application.Services
{
    public class SkillAreaService : IEntityService<SkillArea>
    {
        private readonly FreelanceContext _dbContext;
        public SkillAreaService(FreelanceContext context)
        {
            _dbContext = context;
        }
        public async Task CreateAsync(SkillArea entity)
        {
            _dbContext.SkillAreas.Add(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var skillArea = _dbContext.SkillAreas.FirstOrDefault(x => x.Id == id);
            if (skillArea == null)
            {
                throw new Exception("Item not found");
            }
            _dbContext.SkillAreas.Remove(skillArea);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<IReadOnlyList<SkillArea>> GetAllAsync()
        {
            return await _dbContext.SkillAreas.ToListAsync();
        }
        public async Task<SkillArea> GetByIdAsync(int id)
        {
            var skillArea = await _dbContext.SkillAreas.FirstOrDefaultAsync(x => x.Id == id);
            if (skillArea == null)
            {
                throw new Exception("Item not found");
            }
            return skillArea;
        }
        public async Task UpdateAsync(SkillArea entity)
        {
            var skillArea = _dbContext.SkillAreas.FirstOrDefault(x =>x.Id == entity.Id); 
            if (skillArea == null)
            {
                throw new Exception("Item not found");
            }
            skillArea.Title = entity.Title;
            _dbContext.Update(skillArea);
            await _dbContext.SaveChangesAsync();
        }
    }
}
