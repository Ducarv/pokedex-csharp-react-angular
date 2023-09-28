using Microsoft.EntityFrameworkCore;
using Pokedex.Data;

namespace Pokedex.Repositories
{
    public class DeletePokemonByIdRepository : IDeletePokemonByIdRepository
    {
        private readonly AppDbContext _context;

        public DeletePokemonByIdRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteById(int id)
        {
            var existingPokemon = await _context.Pokemons.FirstOrDefaultAsync(p => p.Id == id);

            if(existingPokemon == null)
            {
                return false;
            }

            try
            {
                _context.Pokemons.Remove(existingPokemon);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}