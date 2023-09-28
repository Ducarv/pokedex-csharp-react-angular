using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Pokedex.Data;
using Pokedex.Models;
using System;
using System.Threading.Tasks;

namespace Pokedex.Repositories
{
    public class EditPokemonByIdRepository : IEditPokemonByIdRepository
    {
        private readonly AppDbContext _context;

        public EditPokemonByIdRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Pokemon> EditById(int id, Pokemon updatedPokemon)
        {
            var existingPokemon = await _context.Pokemons.FirstOrDefaultAsync(p => p.Id == id) ?? throw new Exception($"Pokemon not found with id: {id}");
            
            if (!string.IsNullOrWhiteSpace(updatedPokemon.Name))
            {
                existingPokemon.Name = updatedPokemon.Name;
            }

            if (!string.IsNullOrWhiteSpace(updatedPokemon.Description))
            {
                existingPokemon.Description = updatedPokemon.Description;
            }

            if (updatedPokemon.Types != null && updatedPokemon.Types.Count > 0)
            {
                existingPokemon.Types = updatedPokemon.Types;
            }

            try
            {
                await _context.SaveChangesAsync();
                return existingPokemon; // Pokémon atualizado com sucesso.
            }
            catch (Exception)
            {
                // Lidar com erros de atualização, se necessário.
                throw new Exception("Erro to edit pokemon!");
            }
        }
    }
}
