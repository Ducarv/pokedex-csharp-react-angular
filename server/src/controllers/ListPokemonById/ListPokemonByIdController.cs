using Microsoft.AspNetCore.Mvc;
using Pokedex.Services;

namespace Pokedex.Controllers
{
    [ApiController]
    [Route("/api/pokedex/pokemon")]
    public class ListPokemonByIdController : ControllerBase
    {
        private readonly IListPokemonByIdService _pokemonService;

        public ListPokemonByIdController(IListPokemonByIdService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ListById(int id)
        {
            var pokemon = await _pokemonService.ListById(id) ?? throw new Exception($"Pokemon {id} not found");

            return Ok(pokemon);
        }
    }
}