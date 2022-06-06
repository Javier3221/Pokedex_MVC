using Database;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public class PokemonRepository
    {
        private readonly ApplicationContext _dbContext;

        public PokemonRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Pokemon pokemon)
        {
            await _dbContext.Pokemon.AddAsync(pokemon);
            await _dbContext.SaveChangesAsync();
        }
        public async Task EditAsync(Pokemon pokemon)
        {
            _dbContext.Entry(pokemon).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        public async Task RemoveAsync(Pokemon pokemon)
        {
            _dbContext.Set<Pokemon>().Remove(pokemon);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<List<Pokemon>> GetAllAsync()
        {
            return await _dbContext.Set<Pokemon>().ToListAsync();
        }
        public async Task<Pokemon> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Pokemon>().FindAsync(id);
        }

        public async Task<List<Pokemon>> GetAllByRegion(int region)
        {
            return await _dbContext.Set<Pokemon>()
                .Where(pokemon => pokemon.RegionId == region)
                .ToListAsync();
        }

        public async Task<List<Pokemon>> GetAllByName(string name)
        {
            return await _dbContext.Set<Pokemon>()
                .Where(pokemon => pokemon.Name.Contains(name))
                .ToListAsync();
        }
    }
}
