using Microsoft.EntityFrameworkCore;
using Pokedex.Data;
using Pokedex.Models;

namespace Pokedex.Repositories
{
    public class ListAllPokemonRepository : IListAllPokemonRepository
    {
       private readonly AppDbContext _context; 
       
       public ListAllPokemonRepository(AppDbContext context)
       {
        _context = context;
       }

       public async Task<List<Pokemon>> ListAll()
       {
        return await _context.Pokemons.ToListAsync();
       }
    }
}