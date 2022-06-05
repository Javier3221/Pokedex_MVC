using Application.Services;
using Application.ViewModels;
using Database;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokédex_MVC.Controllers
{
    public class RegionsController : Controller
    {
        private readonly RegionService _regionService;

        public RegionsController(ApplicationContext dbContext)
        {
            _regionService = new(dbContext);
        }

        public async Task<IActionResult> RegionList()
        {
            return View(await _regionService.GetAllViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(RegionViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveRegion", vm);
            }

            await _regionService.Add(vm);
            return RedirectToRoute(new { controller = "Regions", action = "RegionList" });
        }

        public IActionResult Create()
        {
            return View("SaveRegion", new RegionViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Update(RegionViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveRegion", vm);
            }

            await _regionService.Update(vm);
            return RedirectToRoute(new { controller = "Regions", action = "RegionList" });
        }

        public async Task<IActionResult> Update(int id)
        {
            return View("SaveRegion", await _regionService.GetByIdViewModel(id));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _regionService.Delete(id);
            return RedirectToRoute(new { controller = "Regions", action = "RegionList" });
        }
    }
}
