using Pokedex.Models;
using Pokedex.Repositories;

namespace Pokedex.Services
{
    public class CreatePokemonService : ICreatePokemonService
    {
        private readonly ICreatePokemonRepository _pokemonRepository;

        public CreatePokemonService(ICreatePokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        public async Task Create(Pokemon pokemon)
        {
            await _pokemonRepository.Create(pokemon);
        }
    }
}