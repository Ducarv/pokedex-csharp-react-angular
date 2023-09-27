using Pokedex.Data;
using Pokedex.Models;

namespace Pokedex.Repositories
{
    public class CreatePokemonRepository : ICreatePokemonRepository
    {
        private readonly AppDbContext _context;

        public CreatePokemonRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(Pokemon pokemon)
        {
            _context.Pokemons.Add(pokemon);
            await _context.SaveChangesAsync();
        }
    }
}
