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
}