using AutoMapper;
using FreelanceFinder.Application.Common;
using FreelanceFinder.Application.Common.Models;
using FreelanceFinder.Application.Services;
using FreelanceFinder.Core.Entities;
using FreelanceFinder.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FreelanceFinder.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;
        private readonly ProjectAdvertisementService _projectAdvertisementService;

        public HomeController(ILogger<HomeController> logger, IMapper mapper, IEntityService<ProjectAdvertisement> projectAdvertisementService)
        {
            _logger = logger;
            _mapper = mapper;
            _projectAdvertisementService = (ProjectAdvertisementService)projectAdvertisementService;
        }

        public async Task<IActionResult> Index()
        {
            var projectAdvertisements = await _projectAdvertisementService.GetAllAsync();
            ViewData["ProjectAdvertisements"] = _mapper.Map<IReadOnlyList<ProjectAdvertisementDTO>>(projectAdvertisements);
            //ViewData["ProjectAdvertisements"] = projectAdvertisements.ToList();
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ShowProjectAdvertisementDetails(int id)
        {
            var projectAdvertisement = await _projectAdvertisementService.GetByIdAsync(id);
            var dto = _mapper.Map<ProjectAdvertisementDTO>(projectAdvertisement);
            return View(dto);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
