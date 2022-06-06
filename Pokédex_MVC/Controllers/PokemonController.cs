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
    public class PokemonController : Controller
    {
        private readonly PokemonService _pokemonService;
        private readonly RegionService _regionService;
        private readonly TypeService _typeService;

        public PokemonController(ApplicationContext dbContext)
        {
            _pokemonService = new(dbContext);
            _regionService = new(dbContext);
            _typeService = new(dbContext);
        }

        public async Task<IActionResult> PokemonListView()
        {
            return View(await _pokemonService.GetAllViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SavePokemonViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SavePokemon", vm);
            }

            await _pokemonService.Add(vm);
            return RedirectToRoute(new { controller="Pokemon", action="PokemonListView"});
        }

        public async Task<IActionResult> Create()
        {
            if (await _pokemonService.GetTypesAndRegionsCount() == true)
            {
                return View("ErrorView");
            }
            ViewData["Regions"] = await _regionService.GetAllViewModel();
            ViewData["Types"] = await _typeService.GetAllViewModel();

            return View("SavePokemon", new SavePokemonViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Update(SavePokemonViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SavePokemon", vm);
            }
            ViewData["Regions"] = await _regionService.GetAllViewModel();
            ViewData["Types"] = await _typeService.GetAllViewModel();

            await _pokemonService.Update(vm);
            return RedirectToRoute(new { controller = "Pokemon", action = "PokemonListView" });
        }

        public async Task<IActionResult> Update(int id)
        {
            ViewData["Regions"] = await _regionService.GetAllViewModel();
            ViewData["Types"] = await _typeService.GetAllViewModel();

            return View("SavePokemon", await _pokemonService.GetByIdSaveViewModel(id));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _pokemonService.Delete(id);
            return RedirectToRoute(new { controller="Pokemon", action = "PokemonListView" });
        }
    }
}
