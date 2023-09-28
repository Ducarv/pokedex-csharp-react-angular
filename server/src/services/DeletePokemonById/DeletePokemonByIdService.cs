using Pokedex.Repositories;

namespace Pokedex.Services
{
    public class DeletePokemonByIdService : IDeletePokemonByIdService
    {
        private readonly IDeletePokemonByIdRepository _pokemonRepository;

        public DeletePokemonByIdService(IDeletePokemonByIdRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        public async Task<bool> DeleteById(int id)
        {
            try
            {
                await _pokemonRepository.DeleteById(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}