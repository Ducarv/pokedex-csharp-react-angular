using Pokedex.Models;

namespace Pokedex.Services
{
    public interface ICreatePokemonService
    {
        Task Create(Pokemon pokemon);
    }

    public interface IListAllPokemonService
    {
        Task<List<Pokemon>> ListAll();
    }

    public interface IListPokemonByIdService
    {
        Task<Pokemon> ListById(int id);
    }

    public interface IListPokemonByNameService
    {
        Task<List<Pokemon>> ListByName(string name);
    }
}