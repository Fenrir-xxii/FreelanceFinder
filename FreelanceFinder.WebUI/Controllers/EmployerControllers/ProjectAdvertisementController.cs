using FreelanceFinder.Application.Common;
using FreelanceFinder.Application.Services;
using FreelanceFinder.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FreelanceFinder.WebUI.Controllers.EmployerController
{
    public class ProjectAdvertisementController : Controller
    {
        private readonly ProjectAdvertisementService _projectAdvertisementService;
        private readonly CurrencyService _currencyService;
        private readonly SkillService _skillService;
        private readonly RequiredSkillService _requiredSkillService;
        private readonly FreelancerService _freelancerService;
        private readonly EmployerService _employerService;

        public ProjectAdvertisementController(IEntityService<ProjectAdvertisement> projectAdvertisementService, IEntityService<Currency> currencyService, IEntityService<Skill> skillService, IEntityService<RequiredSkill> requiredSkillService, IEntityService<Freelancer> freelancerService, IEntityService<Employer> employerService)
        {
            _projectAdvertisementService = (ProjectAdvertisementService)projectAdvertisementService;
            _currencyService = (CurrencyService)currencyService;
            _skillService = (SkillService)skillService;
            _requiredSkillService = (RequiredSkillService)requiredSkillService;
            _freelancerService = (FreelancerService)freelancerService;
            _employerService = (EmployerService)employerService;
        }
        [HttpGet("employer/advertisements")]
        public async Task<IActionResult> Index()
        {
            var projectAdvertisements = await _projectAdvertisementService.GetAllByEmployerIdAsync(1); // fix when will be Identity
            ViewData["ProjectAdvertisements"] = projectAdvertisements.ToList();
            return View();
        }
        [HttpGet("/employer/advertisements/new-advertisement")]
        public async Task<IActionResult> AddProjectAdvertisement()
        {
            ViewData["Currencies"] = await _currencyService.GetSelectListItem();
            ViewData["Freelancers"] = await _freelancerService.GetSelectListItem();
            return View(new ProjectAdvertisement());
        }
        [HttpPost("/employer/advertisements/new-advertisement")]
        public async Task<IActionResult> AddProjectAdvertisement([FromForm] ProjectAdvertisement projectAdvertisement)
        {
            // TO DO
            projectAdvertisement.Employer = await _employerService.GetByIdAsync(1);  //change
            projectAdvertisement.EmployerId = projectAdvertisement.Employer.Id;
            projectAdvertisement.Currency = await _currencyService.GetByIdAsync(projectAdvertisement.CurrencyId);
            await _projectAdvertisementService.CreateAsync(projectAdvertisement);
            return RedirectToAction("Index");
        }
        [HttpGet("/employer/advertisements/add-required-skill/{id:int}")]
        public async Task<IActionResult> AddRequiredSkill(int id)
        {
            ViewData["Skills"] = await _skillService.GetSelectListItem();
            ViewData["ProjectAdvertisementId"] = id;
            return View(new RequiredSkill());
        }
        [HttpPost("/employer/advertisements/add-required-skill/{id:int}")]
        public async Task<IActionResult> AddRequiredSkill(int id, [FromForm] RequiredSkill requiredSkill)
        {
            requiredSkill.Skill = await _skillService.GetByIdAsync(requiredSkill.SkillId);
            requiredSkill.ProjectAdvertisement = await _projectAdvertisementService.GetByIdAsync(id);
            requiredSkill.ProjectAdvertisementId = id;
            await _requiredSkillService.CreateAsync(requiredSkill);
            return RedirectToAction("Index");
        }
        [HttpGet("/employer/advertisements/edit-advertisement/{id:int}")]
        public async Task<IActionResult> EditProjectAdvertisement(int id)
        {
            var projectAdvertisement = await _projectAdvertisementService.GetByIdAsync(id);
            ViewData["Currencies"] = await _currencyService.GetSelectListItem();
            ViewData["Freelancers"] = await _freelancerService.GetSelectListItem();
            var employer = await _employerService.GetByIdAsync(1); // change
            ViewData["EmployerId"] = employer.Id;
            return View(projectAdvertisement);
        }
        [HttpPost("/employer/advertisements/edit-advertisement/{id:int}")]
        public async Task<IActionResult> EditProjectAdvertisement([FromForm] ProjectAdvertisement projectAdvertisement)
        {
            await _projectAdvertisementService.UpdateAsync(projectAdvertisement);
            return RedirectToAction("Index");
        }
        [HttpPost("/employer/advertisements/delete-advertisement/{id:int}")]
        public async Task<IActionResult> DeleteProjectAdvertisement(int id)
        {
            await _projectAdvertisementService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
