using Application.Repositories;
using Application.ViewModels;
using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PokemonService
    {
        private readonly PokemonRepository _pokemonRepository;

        private readonly RegionRepository _regionRepository;

        public PokemonService(ApplicationContext dbContext)
        {
            _pokemonRepository = new(dbContext);

            _regionRepository = new(dbContext);
        }

        public async Task<List<GetPokemonViewModel>> GetAllViewModel()
        {
            var pokemonList = await _pokemonRepository.GetAllAsync();
            return pokemonList.Select(pokemon => new GetPokemonViewModel
            {
                Id = pokemon.Id,
                Name = pokemon.Name,
                ImgUrl = pokemon.ImgUrl,
                PrimaryType = "eldiablo",
                SecondaryType = "eldiablo2",
                Region = _regionRepository.GetNameById(pokemon.RegionId)
            }).ToList();
        }
    }
}
