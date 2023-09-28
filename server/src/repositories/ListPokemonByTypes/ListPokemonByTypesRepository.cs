using Microsoft.EntityFrameworkCore;
using Pokedex.Data;
using Pokedex.Models;

namespace Pokedex.Repositories
{
    public class ListPokemonByTypesRepository : IListPokemonByTypesRepository
    {
        private readonly AppDbContext _context;

        public ListPokemonByTypesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Pokemon>> ListByTypes(List<string> types)
        {
            var allPokemon = await _context.Pokemons.ToListAsync();

            var matchingPokemon = allPokemon
                .Where(p => types.All(t => p.Types.Contains(t)))
                .ToList();

            return matchingPokemon;
        }
    }
}