using Microsoft.AspNetCore.Mvc;
using Pokedex.Models;
using Pokedex.Services;

namespace Pokedex.Controllers
{
    [ApiController]
    [Route("/api/pokedex/pokemon")]
    public class ListPokemonByNameController : ControllerBase
    {
        private readonly IListPokemonByNameService _pokemonService;

        public ListPokemonByNameController(IListPokemonByNameService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        [HttpGet()]
        public async Task<ActionResult<List<Pokemon>>> ListByName([FromQuery] string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("Query param 'name' is required.");
            }

            var pokemonList = await _pokemonService.ListByName(name);

            if(pokemonList.Count == 0)
            {
                return NotFound($"Any pokemon found with: ${name}");
            }

            return Ok(pokemonList);
        }
    }
}