using FreelanceFinder.Application.Common;
using FreelanceFinder.Core.Entities;
using FreelanceFinder.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FreelanceFinder.Application.Services
{
    public class StatusService : IEntityService<Status>
    {
        private readonly FreelanceContext _dbContext;
        public StatusService(FreelanceContext context)
        {
            _dbContext = context;
        }
        public async Task CreateAsync(Status entity)
        {
            _dbContext.Statuses.Add(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var status = _dbContext.Statuses.FirstOrDefault(x => x.Id == id);
            if (status == null)
            {
                throw new Exception("Item not found");
            }
            _dbContext.Statuses.Remove(status);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<Status>> GetAllAsync()
        {
            return await _dbContext.Statuses.ToListAsync();
        }
        public async Task<Status> GetByIdAsync(int id)
        {
            var status = await _dbContext.Statuses.FirstOrDefaultAsync(x => x.Id == id);
            if (status == null)
            {
                throw new Exception("Item not found");
            }
            return status;
        }
        public async Task UpdateAsync(Status entity)
        {
            var status = _dbContext.Statuses.FirstOrDefault(x => x.Id == entity.Id);
            if (status == null)
            {
                throw new Exception("Item not found");
            }
            status.Title = entity.Title;
            _dbContext.Update(status);
            await _dbContext.SaveChangesAsync();
        }
    }
}
