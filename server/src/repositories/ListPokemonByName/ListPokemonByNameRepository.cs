using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pokedex.Data;
using Pokedex.Models;

namespace Pokedex.Repositories
{
    public class ListPokemonByNameRepository : IListPokemonByNameRepository
    {
        private readonly AppDbContext _context;

        public ListPokemonByNameRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Pokemon>> ListByName(string name)
        {
            var pokemonList = await _context.Pokemons
                .Where(p => p.Name != null && p.Name.Contains(name))
                .ToListAsync();

            if(pokemonList.Count == 0)
            {
                throw new Exception($"Any pokemon found with: {name}");
            }

            return pokemonList;
        }
    }
}