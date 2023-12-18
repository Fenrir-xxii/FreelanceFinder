using AutoMapper;
using FreelanceFinder.Application.Common;
using FreelanceFinder.Application.Common.Models;
using FreelanceFinder.Application.Services;
using FreelanceFinder.Core.Entities;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FreelanceFinder.WebUI.Controllers.EmployerController
{
    public class ProjectAdvertisementController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ProjectAdvertisementService _projectAdvertisementService;
        private readonly CurrencyService _currencyService;
        private readonly SkillService _skillService;
        private readonly RequiredSkillService _requiredSkillService;
        private readonly FreelancerService _freelancerService;
        private readonly EmployerService _employerService;

        public ProjectAdvertisementController(IMapper mapper, IEntityService<ProjectAdvertisement> projectAdvertisementService, IEntityService<Currency> currencyService, IEntityService<Skill> skillService, IEntityService<RequiredSkill> requiredSkillService, IEntityService<Freelancer> freelancerService, IEntityService<Employer> employerService)
        {
            _mapper = mapper;
            _projectAdvertisementService = (ProjectAdvertisementService)projectAdvertisementService;
            _currencyService = (CurrencyService)currencyService;
            _skillService = (SkillService)skillService;
            _requiredSkillService = (RequiredSkillService)requiredSkillService;
            _freelancerService = (FreelancerService)freelancerService;
            _employerService = (EmployerService)employerService;
        }
        [HttpGet("/employer/advertisements")]
        public async Task<IActionResult> Index()
        {
            var projectAdvertisements = await _projectAdvertisementService.GetAllByEmployerIdAsync(1); // fix when will be Identity
            ViewData["ProjectAdvertisements"] = _mapper.Map<IReadOnlyList<ProjectAdvertisementDTO>>(projectAdvertisements);
            return View();
        }
        [HttpGet("/employer/advertisements/new-advertisement")]
        public async Task<IActionResult> AddProjectAdvertisement()
        {
            var employer = await _employerService.GetByIdAsync(1); // fix
            ViewData["Currencies"] = await GetCurrenciesSelectListItem();
            ViewData["Freelancers"] = await GetFreelancersSelectListItem();
            return View(new ProjectAdvertisementCreateDTO{ EmployerId = employer.Id });
        }
        [HttpPost("/employer/advertisements/new-advertisement")]
        public async Task<IActionResult> AddProjectAdvertisement([FromForm] ProjectAdvertisementCreateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            
            var entity = _mapper.Map<ProjectAdvertisement>(dto);
            await _projectAdvertisementService.CreateAsync(entity);
            return RedirectToAction("Index");
        }
        [HttpGet("/employer/advertisements/add-required-skill/{id:int}")]
        public async Task<IActionResult> AddRequiredSkill(int id)
        {
            ViewData["Skills"] = await GetSkillsSelectListItem();
            //ViewData["ProjectAdvertisementId"] = id;
            return View(new RequiredSkillDTO{ ProjectAdvertisementId = id });
        }
        [HttpPost("/employer/advertisements/add-required-skill/{id:int}")]
        public async Task<IActionResult> AddRequiredSkill([FromForm] RequiredSkillDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            var entity = _mapper.Map<RequiredSkill>(dto);
            await _requiredSkillService.CreateAsync(entity);
            return RedirectToAction("Index");
        }
        [HttpGet("/employer/advertisements/edit-advertisement/{id:int}")]
        public async Task<IActionResult> EditProjectAdvertisement(int id)
        {
            var projectAdvertisement = await _projectAdvertisementService.GetByIdAsync(id);
            var dto = _mapper.Map<ProjectAdvertisementEditDTO>(projectAdvertisement);
            ViewData["Currencies"] = await GetCurrenciesSelectListItem();
            ViewData["Freelancers"] = await GetFreelancersSelectListItem();
            return View(dto);
        }
        [HttpPost("/employer/advertisements/edit-advertisement/{id:int}")]
        public async Task<IActionResult> EditProjectAdvertisement([FromForm] ProjectAdvertisementEditDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            var entity = _mapper.Map<ProjectAdvertisement>(dto);
            await _projectAdvertisementService.UpdateAsync(entity);
            return RedirectToAction("Index");
        }
        [HttpPost("/employer/advertisements/delete-advertisement/{id:int}")]
        public async Task<IActionResult> DeleteProjectAdvertisement(int id)
        {
            await _projectAdvertisementService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
        // All SelectListItems Change later to some Helper that coulb be used by Freelancer / Home Controller as well
        public async Task<List<SelectListItem>> GetCurrenciesSelectListItem()
        {
            var list = new List<SelectListItem>();
            var currencies = await _currencyService.GetAllAsync();
            foreach (var currency in currencies)
            {
                list.Add(new SelectListItem { Value = currency.Id.ToString(), Text = currency.Title });
            }
            return list;
        }
        public async Task<List<SelectListItem>> GetFreelancersSelectListItem()
        {
            var list = new List<SelectListItem>();
            var freelancers = await _freelancerService.GetAllAsync();
            foreach (var freelancer in freelancers)
            {
                list.Add(new SelectListItem { Value = freelancer.Id.ToString(), Text = freelancer.FullName });
            }
            return list;
        }
        public async Task<List<SelectListItem>> GetSkillsSelectListItem()
        {
            var list = new List<SelectListItem>();
            var skills = await _skillService.GetAllAsync();
            foreach (var skill in skills)
            {
                list.Add(new SelectListItem { Value = skill.Id.ToString(), Text = skill.Title });
            }
            return list;
        }
    }
}
