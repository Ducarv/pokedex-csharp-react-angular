using Microsoft.AspNetCore.Mvc;
using Pokedex.Models;
using Pokedex.Services;

namespace Pokedex.Controllers
{
    [ApiController]
    [Route("/api/pokedex/pokemon")]
    public class ListPokemonByTypesController : ControllerBase
    {
        private readonly IListPokemonByTypesService _pokemonService;

        public ListPokemonByTypesController(IListPokemonByTypesService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        [HttpGet("list-by-types")]
        public async Task<ActionResult<List<Pokemon>>> ListByTypes([FromQuery] List<string> types)
        {
            if(types == null || types.Count == 0)
            {
                return BadRequest("Query param 'types' is required.");
            }

            var pokemonList = await _pokemonService.ListByTypes(types);

            if(pokemonList.Count == 0)
            {
                return NotFound($"Any pokemon found with: {types}");
            }

            return Ok(pokemonList);
        }
    }
}