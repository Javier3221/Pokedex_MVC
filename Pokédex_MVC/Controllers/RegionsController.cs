using Application.Repositories;
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
        private readonly RegionRepository _regionRepository;

        public RegionsController(ApplicationContext dbContext)
        {
            _regionRepository = new(dbContext);
        }

        public async Task<IActionResult> RegionList()
        {
            return View(await _regionRepository.GetAllAsync());
        }
    }
}
