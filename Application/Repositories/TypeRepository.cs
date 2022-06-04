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
    public class TypeRepository
    {
        private readonly ApplicationContext _dbContext;

        public TypeRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(PokemonType type)
        {
            await _dbContext.Type.AddAsync(type);
            await _dbContext.SaveChangesAsync();
        }
        public async Task EditAsync(PokemonType type)
        {
            _dbContext.Entry(type).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        public async Task RemoveAsync(PokemonType type)
        {
            _dbContext.Set<PokemonType>().Remove(type);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<List<PokemonType>> GetAllAsync()
        {
            return await _dbContext.Set<PokemonType>().ToListAsync();
        }
        public async Task<PokemonType> GetByIdAsync(int id)
        {
            return await _dbContext.Set<PokemonType>().FindAsync(id);
        }

        public string GetNameById(int id)
        {
            return _dbContext.Set<PokemonType>().FindAsync(id).Result.Name;
        }
    }
}
