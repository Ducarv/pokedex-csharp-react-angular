using Pokedex.Models;
using Pokedex.Repositories;

namespace Pokedex.Services
{
    public class ListAllPokemonService : IListAllPokemonService
    {
        private readonly IListAllPokemonRepository _pokemonRepository;

        public ListAllPokemonService(IListAllPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        public async Task<List<Pokemon>> ListAll()
        {
            return await _pokemonRepository.ListAll();
        }
    }
}