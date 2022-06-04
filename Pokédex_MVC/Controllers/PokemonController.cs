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

        public PokemonController(ApplicationContext dbContext)
        {
            _pokemonService = new(dbContext);
        }

        public async Task<IActionResult> PokemonListView()
        {
            return View(await _pokemonService.GetAllViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SavePokemonViewModel vm)
        {
            await _pokemonService.Add(vm);
            return RedirectToRoute(new { controller="Pokemon", action="PokemonListView"});
        }

        public IActionResult Create()
        {
            return View("SavePokemon", new SavePokemonViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Update(SavePokemonViewModel vm)
        {
            await _pokemonService.Update(vm);
            return RedirectToRoute(new { controller = "Pokemon", action = "PokemonListView" });
        }

        public async Task<IActionResult> Update(int id)
        {
            return View("SavePokemon", await _pokemonService.GetByIdSaveViewModel(id));
        }
    }
}
