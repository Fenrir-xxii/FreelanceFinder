using FreelanceFinder.Application.Common;
using FreelanceFinder.Core.Entities;
using FreelanceFinder.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FreelanceFinder.Application.Services
{
    public class ProjectAdvertisementService : IEntityService<ProjectAdvertisement>
    {
        private readonly FreelanceContext _dbContext;
        public ProjectAdvertisementService(FreelanceContext context)
        {
            _dbContext = context;
        }
        public async Task CreateAsync(ProjectAdvertisement entity)
        {
            _dbContext.ProjectAdvertisements.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var projectadvertisement = _dbContext.ProjectAdvertisements.FirstOrDefault(x => x.Id == id);
            if (projectadvertisement == null)
            {
                throw new Exception("Item not found");
            }
            _dbContext.ProjectAdvertisements.Remove(projectadvertisement);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProjectAdvertisement>> GetAllAsync()
        {
            return await _dbContext.ProjectAdvertisements
                .Include(x => x.Employer)
                .Include(x => x.Currency)
                .Include(x => x.Freelancer)
                .Include(x => x.RequiredSkills)
                .ThenInclude(x => x.Skill)
                .ThenInclude(x => x.SkillArea)
                .ToListAsync();
        }

        public async Task<ProjectAdvertisement> GetByIdAsync(int id)
        {
            var projectadvertisement = await _dbContext.ProjectAdvertisements
                .Include(x => x.Employer)
                .Include(x => x.Currency)
                .Include(x => x.Freelancer)
                .Include(x => x.RequiredSkills)
                .ThenInclude(x => x.Skill)
                .ThenInclude(x => x.SkillArea)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (projectadvertisement == null)
            {
                throw new Exception("Item not found");
            }
            return projectadvertisement;
        }

        public async Task UpdateAsync(ProjectAdvertisement entity)
        {
            var projectadvertisement = _dbContext.ProjectAdvertisements
               .Include(x => x.Employer)
               .Include(x => x.Currency)
               .Include(x => x.Freelancer)
               .Include(x => x.RequiredSkills)
               .ThenInclude(x => x.Skill)
               .ThenInclude(x => x.SkillArea)
               .FirstOrDefault(x => x.Id == entity.Id);

            if (projectadvertisement == null)
            {
                throw new Exception("Item not found");
            }
            projectadvertisement.Employer = entity.Employer;
            projectadvertisement.EmployerId = entity.EmployerId;
            projectadvertisement.ExpiredAt = entity.ExpiredAt;
            projectadvertisement.Title = entity.Title;
            projectadvertisement.Price = entity.Price;
            projectadvertisement.Currency = entity.Currency;
            projectadvertisement.CurrencyId = entity.CurrencyId;
            projectadvertisement.Description = entity.Description;
            projectadvertisement.WorkplaceCount = entity.WorkplaceCount;
            projectadvertisement.Freelancer = entity.Freelancer;
            projectadvertisement.FreelancerId = entity.FreelancerId;
            projectadvertisement.RequiredSkills = entity.RequiredSkills;
            _dbContext.Update(projectadvertisement);
            await _dbContext.SaveChangesAsync();
        }
        public async Task AddRequiredSkill(int projectAdvertisementId, RequiredSkill skill)
        {
            // TO DO
        }
        public async Task RemoveRequiredSkill(int projectAdvertisementId, RequiredSkill skill)
        {
            // TO DO
        }
        public async Task AddFreelancer(int projectAdvertisementId, Freelancer freelancer)
        {
            // TO DO
        }
        public async Task RemoveFreelancer(int projectAdvertisementId, Freelancer freelancer)
        {
            // TO DO
        }
    }
}
