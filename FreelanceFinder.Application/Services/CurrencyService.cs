using FreelanceFinder.Application.Common;
using FreelanceFinder.Core.Entities;
using FreelanceFinder.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FreelanceFinder.Application.Services
{
    public class CurrencyService : IEntityService<Currency>
    {
        private readonly FreelanceContext _dbContext;
        public CurrencyService(FreelanceContext context)
        {
            _dbContext = context;
        }
        public async Task CreateAsync(Currency entity)
        {
            _dbContext.Currencies.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var currency = _dbContext.Currencies.FirstOrDefault(x => x.Id == id);
            if (currency == null)
            {
                throw new Exception("Item not found");
            }
            _dbContext.Currencies.Remove(currency);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Currency>> GetAllAsync()
        {
            return await _dbContext.Currencies.ToListAsync();
        }

        public async Task<Currency> GetByIdAsync(int id)
        {
            var currency = await _dbContext.Currencies.FirstOrDefaultAsync(x => x.Id == id);
            if (currency == null)
            {
                throw new Exception("Item not found");
            }
            return currency;
        }

        public async Task UpdateAsync(Currency entity)
        {
            var currency = _dbContext.Currencies.FirstOrDefault(x => x.Id == entity.Id);
            if (currency == null)
            {
                throw new Exception("Item not found");
            }
            currency.Title = entity.Title;
            currency.CurrencyISONumber = entity.CurrencyISONumber;
            currency.CurrencyISOCode = entity.CurrencyISOCode;

            _dbContext.Update(currency);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<List<SelectListItem>> GetSelectListItem()
        {
            var list = new List<SelectListItem>();
            var currencies = await GetAllAsync();
            foreach (var currency in currencies)
            {
                list.Add(new SelectListItem { Value = currency.Id.ToString(), Text = currency.Title });
            }
            return list;
        }
    }
}
