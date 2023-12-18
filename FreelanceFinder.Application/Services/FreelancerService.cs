using FreelanceFinder.Application.Common;
using FreelanceFinder.Core.Entities;
using FreelanceFinder.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public async Task<IReadOnlyList<Freelancer>> GetAllAsync()
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
            if (freelancer == null)
            {
                throw new Exception("Item not found");
            }
            if(freelancer.Skills.Any(x => x.Id != skill.Id))
            {
                var skillDb = _dbContext.FreelancerSkills.FirstOrDefault(x => x.Id == skill.Id);
                if (skillDb == null)
                {
                    throw new Exception("Item not found");
                }
                freelancer.Skills.Add(skillDb);
                _dbContext.Update(freelancer);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task RemoveSkill(int freelancerSkillId)
        {
            var freelancerSkill = _dbContext.FreelancerSkills.FirstOrDefault(x => x.Id == freelancerSkillId);
            if (freelancerSkill == null)
            {
                throw new Exception("Item not found");
            }
            _dbContext.FreelancerSkills.Remove(freelancerSkill);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<FreelancerSkill> GetSkillByIdAsync(int id)
        {
            var freelancerSkill = await _dbContext.FreelancerSkills.Include(x => x.Skill).FirstOrDefaultAsync(x => x.Id == id);
            if (freelancerSkill == null)
            {
                throw new Exception("Item not found");
            }
            return freelancerSkill;
        }
        public async Task UpdateSkillAsync(FreelancerSkill entity)
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

        //public async Task<List<SelectListItem>> GetSelectListItem()
        //{
        //    var list = new List<SelectListItem>();
        //    var freelancers = await GetAllAsync();
        //    foreach (var freelancer in freelancers)
        //    {
        //        list.Add(new SelectListItem { Value = freelancer.Id.ToString(), Text = freelancer.FullName });
        //    }
        //    return list;
        //}
    }
}
