using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProfOaksKantoPokedex.Models;
using ProfOaksKantoPokedex.Services;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ProfOaksKantoPokedex.Controllers
{
    // Configures controller with features aimed to assist development for API's
    [ApiController]
    [Authorize]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/pokemon")]
    
    
    public class PokemonController : ControllerBase
    {
        //private readonly PokemonDataStore _pokemonDataStore;
        private readonly IProfOaksKantoPokedexRepository _profOaksKantoPokedexRepository;
        private readonly IMapper _mapper;
        const int maxPokemonPageSize = 20;

        /// <summary>
        /// For the purpose of supressing XML warnings
        /// </summary>
        public PokemonController(IProfOaksKantoPokedexRepository profOaksKantoPokedexRepository,
            IMapper mapper)
        {
            _profOaksKantoPokedexRepository = profOaksKantoPokedexRepository ?? throw new ArgumentNullException(nameof(profOaksKantoPokedexRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Get a Pokemon without any moves learnt attached
        /// </summary>
        /// <param name="name">The name of the Pokemon</param>
        /// <param name="searchQuery">Please enter a query on the string search</param>
        /// <param name="pageNumber">Which page number would you like to view</param>
        /// <param name="pageSize">What is the size of the page</param>
        /// <returns>An ActionResult</returns>
        /// <response code="200">Returns the requested Pokemon without moves</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PokemonWithoutMovesLearntDto>>> GetPokemon(
            [FromQuery] string? name, [FromQuery] string? searchQuery, int pageNumber = 1, int pageSize = 10)
        {
            if(pageSize > maxPokemonPageSize)
            {
                pageSize = maxPokemonPageSize;
            }

            //Find all Pokemon
            // No need for a NotFound as an empty collection is a valid response body

            var (pokemonEntities, paginationMetadata) = await _profOaksKantoPokedexRepository.GetPokemonAsync(name, searchQuery, pageNumber, pageSize);

            Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(paginationMetadata));

            return Ok(_mapper.Map<IEnumerable<PokemonWithoutMovesLearntDto>>(pokemonEntities));


        }


        
        /// <summary>
        /// Get a Pokemon by Id
        /// </summary>
        /// <param name="id">The id of the Pokemon to get</param>
        /// <param name="includeMovesLearnt">Whether or not to include the moves learnt</param>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the requested Pokemon</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetSinglePokemon(int id, bool includeMovesLearnt = false)
        {
            //    //Find a single Pokemon 
            var pokemon = await _profOaksKantoPokedexRepository.GetPokemonAsync(id, includeMovesLearnt);
            if (pokemon == null)
            {
                return NotFound();  
            }

            if (includeMovesLearnt)
            {
                return Ok(_mapper.Map<PokemonDto>(pokemon));
            }

            return Ok(_mapper.Map<PokemonWithoutMovesLearntDto>(pokemon));
        }
    }
}
