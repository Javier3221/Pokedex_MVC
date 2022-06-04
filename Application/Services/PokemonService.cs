using Application.Repositories;
using Application.ViewModels;
using Database;
using Database.Models;
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

        private readonly TypeRepository _typeRepository;

        public PokemonService(ApplicationContext dbContext)
        {
            _pokemonRepository = new(dbContext);

            _regionRepository = new(dbContext);

            _typeRepository = new(dbContext);
        }

        public async Task Add(SavePokemonViewModel vm)
        {
            Pokemon pokemon = new();
            pokemon.Name = vm.Name;
            pokemon.ImgUrl = vm.ImgUrl;
            pokemon.PrimaryTypeId = vm.PrimaryTypeId;
            pokemon.SecondaryTypeId = vm.SecondaryTypeId;
            pokemon.RegionId = vm.RegionId;

            await _pokemonRepository.AddAsync(pokemon);
        }

        public async Task Update(SavePokemonViewModel vm)
        {
            Pokemon pokemon = new();
            pokemon.Id = vm.Id;
            pokemon.Name = vm.Name;
            pokemon.ImgUrl = vm.ImgUrl;
            pokemon.PrimaryTypeId = vm.PrimaryTypeId;
            pokemon.SecondaryTypeId = vm.SecondaryTypeId;
            pokemon.RegionId = vm.RegionId;

            await _pokemonRepository.EditAsync(pokemon);
        }

        public async Task<List<GetPokemonViewModel>> GetAllViewModel()
        {
            var pokemonList = await _pokemonRepository.GetAllAsync();
            return pokemonList.Select(pokemon => new GetPokemonViewModel
            {
                Id = pokemon.Id,
                Name = pokemon.Name,
                ImgUrl = pokemon.ImgUrl,
                PrimaryType = _typeRepository.GetNameById(pokemon.PrimaryTypeId),
                SecondaryType = _typeRepository.GetNameById(pokemon.SecondaryTypeId),
                Region = _regionRepository.GetNameById(pokemon.RegionId)
            }).ToList();
        }

        public async Task<SavePokemonViewModel> GetByIdSaveViewModel(int id)
        {
            var pokemon = await _pokemonRepository.GetByIdAsync(id);

            SavePokemonViewModel vm = new();
            vm.Id = pokemon.Id;
            vm.Name = pokemon.Name;
            vm.ImgUrl = pokemon.ImgUrl;
            vm.PrimaryTypeId = pokemon.PrimaryTypeId;
            vm.SecondaryTypeId = pokemon.SecondaryTypeId;
            vm.RegionId = pokemon.RegionId;

            return vm;
        }
    }
}
