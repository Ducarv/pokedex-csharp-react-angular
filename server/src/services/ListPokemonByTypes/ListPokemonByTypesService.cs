using Pokedex.Models;
using Pokedex.Repositories;

namespace Pokedex.Services
{
   public class ListPokemonByTypesService : IListPokemonByTypesService
   {
    private readonly IListPokemonByTypesRepository _pokemonRepository;

    public ListPokemonByTypesService(IListPokemonByTypesRepository pokemonRepository)
    {
        _pokemonRepository = pokemonRepository;
    }

    public async Task<List<Pokemon>> ListByTypes(List<string> types)
    {
        var matchingPokemon = await _pokemonRepository.ListByTypes(types);

        //var filteredPokemon = matchingPokemon.Where(p => types.Any(t => p.Types.Contains(t))).ToList();

        return matchingPokemon;
    }
   } 
}