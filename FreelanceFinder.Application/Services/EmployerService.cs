using FreelanceFinder.Application.Common;
using FreelanceFinder.Core.Entities;
using FreelanceFinder.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FreelanceFinder.Application.Services
{
    public class EmployerService : IEntityService<Employer>
    {
        private readonly FreelanceContext _dbContext;
        public EmployerService(FreelanceContext context)
        {
            _dbContext = context;
        }
        public async Task CreateAsync(Employer entity)
        {
            _dbContext.Employers.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var employer = _dbContext.Employers.FirstOrDefault(x => x.Id == id);
            if (employer == null)
            {
                throw new Exception("Item not found");
            }
            _dbContext.Employers.Remove(employer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employer>> GetAllAsync()
        {
            return await _dbContext.Employers.ToListAsync();
        }

        public async Task<Employer> GetByIdAsync(int id)
        {
            var employer = await _dbContext.Employers.FirstOrDefaultAsync(x => x.Id == id);
            if (employer == null)
            {
                throw new Exception("Item not found");
            }
            return employer;
        }

        public async Task UpdateAsync(Employer entity)
        {
            var employer = _dbContext.Employers.FirstOrDefault(x => x.Id == entity.Id);
            if (employer == null)
            {
                throw new Exception("Item not found");
            }
            employer.Name = entity.Name;
            employer.ProjectOffersCount = entity.ProjectOffersCount;
            employer.FinishedProjectsCount = entity.FinishedProjectsCount;
            employer.RegistrationDate = entity.RegistrationDate;

            _dbContext.Update(employer);
            await _dbContext.SaveChangesAsync();
        }
    }
}
