using Application.Services;
using Database;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokédex_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly PokemonService _pokemonService;

        public HomeController(ApplicationContext dbContext)
        {
            _pokemonService = new(dbContext);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _pokemonService.GetAllViewModel());
        }
    }
}
