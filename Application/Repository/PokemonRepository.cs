using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class PokemonRepository
    {
        private readonly ApplicationContext _dbContext;

        public PokemonRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
