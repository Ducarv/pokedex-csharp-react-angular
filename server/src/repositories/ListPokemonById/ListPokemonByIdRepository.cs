using Pokedex.Data;
using Pokedex.Models;

namespace Pokedex.Repositories
{
    public class ListPokemonByIdRepository : IListPokemonByIdRepository
    {
        private readonly AppDbContext _context;

        public ListPokemonByIdRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Pokemon> ListById(int id)
        {
            var pokemon = await _context.Pokemons.FindAsync(id) ?? throw new Exception($"Pokemon {id} not found");

            return pokemon;
        }
    }
}