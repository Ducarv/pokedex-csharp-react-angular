using Pokedex.Repositories;
using Pokedex.Models;

namespace Pokedex.Services
{
    public class ListPokemonByIdService : IListPokemonByIdService
    {
        private readonly IListPokemonByIdRepository _pokemonRepository;

        public ListPokemonByIdService(IListPokemonByIdRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        public async Task<Pokemon> ListById(int id)
        {
            var pokemon = await _pokemonRepository.ListById(id);

            return pokemon;
        }
    }
}