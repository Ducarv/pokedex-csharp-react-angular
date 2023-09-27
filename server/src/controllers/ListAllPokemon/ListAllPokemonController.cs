using Microsoft.AspNetCore.Mvc;
using Pokedex.Services;
using Pokedex.Models;

namespace Pokedex.Controllers
{
    [ApiController]
    [Route("/api/pokedex/all-pokemon")]
    public class ListAllPokemonController : ControllerBase
    {
        private readonly IListAllPokemonService _pokemonService;

        public ListAllPokemonController(IListAllPokemonService pokemonService) 
        {
            _pokemonService = pokemonService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<Pokemon>>> ListAll()
        {
            var result = await _pokemonService.ListAll();
            return Ok(result);
        }
    }
}