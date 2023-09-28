using Microsoft.AspNetCore.Mvc;
using Pokedex.Models;
using Pokedex.Services;
using Pokedex.Types;

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
        public async Task<IActionResult> Create([FromBody] Pokemon pokemonInput)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var validTypes = Enum.GetNames(typeof(PokemonTypes)).ToList();
            
            foreach (var type in pokemonInput.Types)
            {
                if(!validTypes.Contains(type))
                {
                    return BadRequest($"Invalid Pokemon type: {type}");
                }
            }

            var pokemon = new Pokemon
            {
                Name = pokemonInput.Name,
                Description = pokemonInput.Description,
                Types = pokemonInput.Types.ToList(),
            };

            await _pokemonService.Create(pokemon);
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}