using FreelanceFinder.Application.Common;
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
        private readonly IEntityService<ProjectAdvertisement> _projectAdvertisementService;

        public HomeController(ILogger<HomeController> logger, IEntityService<ProjectAdvertisement> projectAdvertisementService)
        {
            _logger = logger;
            _projectAdvertisementService = projectAdvertisementService;
        }

        public async Task<IActionResult> Index()
        {
            var projectAdvertisements = await _projectAdvertisementService.GetAllAsync();
            ViewData["ProjectAdvertisementCount"] = projectAdvertisements.Count();
            return View();
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
