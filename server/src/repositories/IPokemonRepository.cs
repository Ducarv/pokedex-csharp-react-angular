using Pokedex.Models;

namespace Pokedex.Repositories
{
    public interface ICreatePokemonRepository
    {
        Task Create(Pokemon pokemon);
    }

    public interface IListAllPokemonRepository
    {
        Task<List<Pokemon>> ListAll();
    }

    public interface IListPokemonByIdRepository
    {
        Task<Pokemon> ListById(int id);
    }

    public interface IListPokemonByNameRepository
    {
        Task<List<Pokemon>> ListByName(string name);
    }

    public interface IListPokemonByTypesRepository
    {
        Task<List<Pokemon>> ListByTypes(List<string> types);
    }

    public interface IDeletePokemonByIdRepository
    {
        Task<bool> DeleteById(int id);
    }

    public interface IEditPokemonByIdRepository
    {
        Task<Pokemon> EditById(int id, Pokemon updatedPokemon);
    }
}