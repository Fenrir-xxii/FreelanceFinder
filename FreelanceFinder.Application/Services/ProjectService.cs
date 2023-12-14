using FreelanceFinder.Application.Common;
using FreelanceFinder.Core.Entities;
using FreelanceFinder.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FreelanceFinder.Application.Services
{
    public class ProjectService : IEntityService<Project>
    {
        private readonly FreelanceContext _dbContext;
        public ProjectService(FreelanceContext context)
        {
            _dbContext = context;
        }
        public async Task CreateAsync(Project entity)
        {
            _dbContext.Projects.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var project = _dbContext.Projects.FirstOrDefault(x => x.Id == id);
            if (project == null)
            {
                throw new Exception("Item not found");
            }
            _dbContext.Projects.Remove(project);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            return await _dbContext.Projects                // find better solution
               .Include(x => x.ProjectAdvertise)
               .ThenInclude(x => x.Employer)
               .Include(x => x.ProjectAdvertise)
               .ThenInclude(x => x.Currency)
               .Include(x => x.ProjectAdvertise)
               .ThenInclude(x => x.Freelancer)
               .Include(x => x.ProjectAdvertise)
               .ThenInclude(x => x.RequiredSkills)
               .ThenInclude(x => x.Skill)
               .Include(x => x.Freelancers)
               .ThenInclude(x => x.Skills)
               .ThenInclude(x => x.Skill)
               .Include(x => x.Status)
               .ToListAsync();
        }

        public async Task<Project> GetByIdAsync(int id)
        {
            var project = await _dbContext.Projects
               .Include(x => x.ProjectAdvertise)
               .ThenInclude(x => x.Employer)
               .Include(x => x.ProjectAdvertise)
               .ThenInclude(x => x.Currency)
               .Include(x => x.ProjectAdvertise)
               .ThenInclude(x => x.Freelancer)
               .Include(x => x.ProjectAdvertise)
               .ThenInclude(x => x.RequiredSkills)
               .ThenInclude(x => x.Skill)
               .Include(x => x.Freelancers)
               .ThenInclude(x => x.Skills)
               .ThenInclude(x => x.Skill)
               .Include(x => x.Status)
               .FirstOrDefaultAsync(x => x.Id == id);
            if (project == null)
            {
                throw new Exception("Item not found");
            }
            return project;
        }

        public async Task UpdateAsync(Project entity)
        {
            var project = _dbContext.Projects
               .Include(x => x.ProjectAdvertise)
               .ThenInclude(x => x.Employer)
               .Include(x => x.ProjectAdvertise)
               .ThenInclude(x => x.Currency)
               .Include(x => x.ProjectAdvertise)
               .ThenInclude(x => x.Freelancer)
               .Include(x => x.ProjectAdvertise)
               .ThenInclude(x => x.RequiredSkills)
               .ThenInclude(x => x.Skill)
               .Include(x => x.Freelancers)
               .ThenInclude(x => x.Skills)
               .ThenInclude(x => x.Skill)
               .Include(x => x.Status)
               .FirstOrDefault(x => x.Id == entity.Id);

            if (project == null)
            {
                throw new Exception("Item not found");
            }
            project.ProjectAdvertise = entity.ProjectAdvertise;
            project.ProjectAdvertiseId = entity.ProjectAdvertiseId;
            project.Status = entity.Status;
            project.StatusId = entity.StatusId;
            project.Freelancers = entity.Freelancers;
            _dbContext.Update(project);
            await _dbContext.SaveChangesAsync();
        }
        public async Task AddFreelancer(int projectId, Freelancer freelancer)
        {
            // TO DO
        }
        public async Task RemoveFreelancer(int projectId, Freelancer freelancer)
        {
            // TO DO
        }
    }
}
