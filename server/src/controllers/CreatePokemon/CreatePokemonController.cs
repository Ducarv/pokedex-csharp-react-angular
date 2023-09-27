using Microsoft.AspNetCore.Mvc;
using Pokedex.Models;
using Pokedex.Services;

namespace Pokedex.Controllers
{
    [ApiController]
    [Route("api/pokedex/register")]
    public class CreatePokemonController : ControllerBase
    {
        private readonly ICreatePokemonService _pokemonService;

        public CreatePokemonController(ICreatePokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] Pokemon pokemon)
        {
            if (string.IsNullOrWhiteSpace(pokemon.Name) || string.IsNullOrWhiteSpace(pokemon.Description) || string.IsNullOrWhiteSpace(pokemon.Type))
            {
                return BadRequest("Name, Description, and Type are required fields.");
            }

            await _pokemonService.Create(pokemon);
            return Ok();
        }
    }
}