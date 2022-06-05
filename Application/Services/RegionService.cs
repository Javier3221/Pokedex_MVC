﻿using Application.Repositories;
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
    public class RegionService
    {
        private readonly RegionRepository _regionRepository;

        public RegionService(ApplicationContext dbContext)
        {
            _regionRepository = new(dbContext);
        }

        public async Task Add(RegionViewModel vm)
        {
            Region region = new();
            region.Name = vm.Name;

            await _regionRepository.AddAsync(region);
        }

        public async Task Update(RegionViewModel vm)
        {
            Region region = new();
            region.Id = vm.Id;
            region.Name = vm.Name;

            await _regionRepository.EditAsync(region);
        }

        public async Task Delete(int id)
        {
            var region = await _regionRepository.GetByIdAsync(id);
            await _regionRepository.RemoveAsync(region);
        }

        public async Task<List<RegionViewModel>> GetAllViewModel()
        {
            var regionList = await _regionRepository.GetAllAsync();
            return regionList.Select(region => new RegionViewModel
            {
                Id = region.Id,
                Name = region.Name
            }).ToList();
        }

        public async Task<RegionViewModel> GetByIdViewModel(int id)
        {
            var region = await _regionRepository.GetByIdAsync(id);

            RegionViewModel vm = new();
            vm.Id = region.Id;
            vm.Name = region.Name;

            return vm;
        }
    }
}
