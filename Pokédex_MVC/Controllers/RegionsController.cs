using Application.Services;
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
    }
}
