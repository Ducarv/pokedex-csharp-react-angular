using Microsoft.AspNetCore.Mvc;
using Pokedex.Models;
using Pokedex.Services;

namespace Pokedex.Controllers
{
    [ApiController]
    [Route("/api/pokedex/pokemon/edit")]
    public class EditPokemonByIdController : ControllerBase
    {
        private readonly IEditPokemonByIdService _pokemonService;

        public EditPokemonByIdController(IEditPokemonByIdService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pokemon>> EditById(int id, [FromBody] Pokemon updatedPokemon)
        {
            try
            {
                var editedPokemon = await _pokemonService.EditById(id, updatedPokemon);

                if (editedPokemon == null)
                {
                    return NotFound($"Pokemon with ID {id} not found.");
                }

                return Ok(editedPokemon);
            }
            catch (Exception)
            {
                return BadRequest("Failed to edit Pokemon.");
            }
        }
    }
}