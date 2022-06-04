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
        public IActionResult Update(SavePokemonViewModel vm)
        {
            return View("SavePokemon", new SavePokemonViewModel());
        }

        public IActionResult Create()
        {
            return View("SavePokemon", new SavePokemonViewModel());
        }
    }
}
