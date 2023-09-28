using Microsoft.AspNetCore.Mvc;
using Pokedex.Services;

namespace Pokedex.Controllers
{
    [ApiController]
    [Route("/api/pokedex/pokemon/delete")]
    public class DeletePokemonByIdController : ControllerBase
    {
        private readonly IDeletePokemonByIdService _pokemonService;

        public DeletePokemonByIdController(IDeletePokemonByIdService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> DeleteById(int id)
        {
            try
            {
                await _pokemonService.DeleteById(id);
                return Ok();
            } catch(Exception)
            {
                return BadRequest();
            }
            
        }
    }
}