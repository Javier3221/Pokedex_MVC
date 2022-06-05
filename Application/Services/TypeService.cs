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
    public class TypeService
    {
        private readonly TypeRepository _typeRepository;

        public TypeService(ApplicationContext dbContext)
        {
            _typeRepository = new(dbContext);
        }

        public async Task Add(TypeViewModel vm)
        {
            PokemonType type = new();
            type.Name = vm.Name;

            await _typeRepository
                .AddAsync(type);
        }

        public async Task Update(TypeViewModel vm)
        {
            PokemonType type = new();
            type.Id = vm.Id;
            type.Name = vm.Name;

            await _typeRepository
                .EditAsync(type);
        }

        public async Task Delete(int id)
        {
            var type = await _typeRepository
                .GetByIdAsync(id);
            await _typeRepository
                .RemoveAsync(type);
        }

        public async Task<List<TypeViewModel>> GetAllViewModel()
        {
            var typeList = await _typeRepository
                .GetAllAsync();
            return typeList.Select(type => new TypeViewModel
            {
                Id = type.Id,
                Name = type.Name
            }).ToList();
        }

        public async Task<TypeViewModel> GetByIdViewModel(int id)
        {
            var type = await _typeRepository
                .GetByIdAsync(id);

            TypeViewModel vm = new();
            vm.Id = type.Id;
            vm.Name = type.Name;

            return vm;
        }
    }
}
