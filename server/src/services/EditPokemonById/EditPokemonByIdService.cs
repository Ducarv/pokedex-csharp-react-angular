using Pokedex.Models;
using Pokedex.Repositories;

namespace Pokedex.Services
{
    public class EditPokemonByIdService : IEditPokemonByIdService
    {
        private readonly IEditPokemonByIdRepository _pokemonRepository;

        public EditPokemonByIdService(IEditPokemonByIdRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        public async Task<Pokemon> EditById(int id, Pokemon updatedPokemon)
        {
            return await _pokemonRepository.EditById(id, updatedPokemon);
        }
    }
}