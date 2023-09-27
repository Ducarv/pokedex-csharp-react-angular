using Pokedex.Models;
using Pokedex.Repositories;
using Pokedex.Services;

namespace Pokedex.Services
{
    public class ListPokemonByNameService : IListPokemonByNameService
    {
        private readonly IListPokemonByNameRepository _pokemonRepository;

        public ListPokemonByNameService(IListPokemonByNameRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        public async Task<List<Pokemon>> ListByName(string name)
        {
            var pokemonList = await _pokemonRepository.ListByName(name);

            return pokemonList;
        }
    }
}