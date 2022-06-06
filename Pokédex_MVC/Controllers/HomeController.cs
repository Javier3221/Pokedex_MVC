using Application.Services;
using Database;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.ViewModels;

namespace Pokédex_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly PokemonService _pokemonService;
        private readonly RegionService _regionService;

        public HomeController(ApplicationContext dbContext)
        {
            _pokemonService = new(dbContext);
            _regionService = new(dbContext);
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Regions"] = await _regionService.GetAllViewModel();
            ViewData["methodPost"] = false;
            return View(await _pokemonService.GetAllViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(int region = 0, string name = "")
        {
            ViewData["Regions"] = await _regionService.GetAllViewModel();
            ViewData["methodPost"] = true;
            if (region != 0)
            {
                return View(await _pokemonService.GetAllByRegionViewModel(region));
            }

            return View(await _pokemonService.GetAllByNameViewModel(name));
        }
    }
}
