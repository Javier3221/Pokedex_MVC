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
    public class RegionService
    {
        private readonly RegionRepository _regionRepository;

        public RegionService(ApplicationContext dbContext)
        {
            _regionRepository = new(dbContext);
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
    }
}
