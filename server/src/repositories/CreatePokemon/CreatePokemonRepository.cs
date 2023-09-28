using System.Net;
using Microsoft.AspNetCore.Http.HttpResults;
using Pokedex.Data;
using Pokedex.Models;
using Pokedex.Types;

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
            // if(pokemon.Types != null && pokemon.Types.Any(type => !PokemonTypes.Types.Contains(type)))
            // {
            //     throw new HttpRequestException("One or more types are invalid.");
            // }

            _context.Pokemons.Add(pokemon);
            await _context.SaveChangesAsync();
        }
    }
}
