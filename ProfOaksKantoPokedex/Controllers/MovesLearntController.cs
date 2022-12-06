using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ProfOaksKantoPokedex.Models;
using ProfOaksKantoPokedex.Services;

namespace ProfOaksKantoPokedex.Controllers
{
    [Route("api/v{version:apiVersion}/pokemon/{pokemonId}/moveslearnt")]
    [Authorize]
    [ApiVersion("2.0")]
    [ApiController]
    public class MovesLearntController : ControllerBase
    {
        private readonly ILogger<MovesLearntController> _logger;
        private readonly IProfOaksKantoPokedexRepository _profOaksKantoPokedexRepository;
        private readonly IMapper _mapper;

        public MovesLearntController(ILogger<MovesLearntController> logger,
            IProfOaksKantoPokedexRepository profOaksKantoPokedexRepository,
            IMapper mapper)
        {
          
            _logger = logger ?? 
                throw new ArgumentNullException(nameof(logger));
            _profOaksKantoPokedexRepository = profOaksKantoPokedexRepository ?? 
                throw new ArgumentNullException(nameof(profOaksKantoPokedexRepository));
            _mapper = mapper ?? 
                throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Get a list of moves learnt by a specific Pokemon
        /// </summary>
        /// <param name="pokemonId">The id of the Pokemon to get</param>
        /// <returns>An ActionResult</returns>
        /// <response code="404">The Pokemon you are looking for could not be found</response>
        /// <response code="200">List of moves learnt by the Pokemon</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovesLearntDto>>> GetMovesLearnt(int pokemonId)
        {
            if(!await _profOaksKantoPokedexRepository.PokemonExistsAsync(pokemonId))
            {

                _logger.LogInformation(
                    $"Pokemon with id {pokemonId} was not found when accessing moves learnt.");
                return NotFound();
            }

            var movesLearntForPokemon = await _profOaksKantoPokedexRepository.GetMovesLearntAsync(pokemonId);

            return Ok(_mapper.Map<IEnumerable<MovesLearntDto>>(movesLearntForPokemon));
            
            
        }

        /// <summary>
        /// Get one move learnt by a sepcific Pokemon
        /// </summary>
        /// <param name="pokemonId">The id of the Pokemon to get</param>
        /// <param name="movesLearntId">The move id you want to get</param>
        /// <returns>An ActionResult</returns>
        /// <response code="404">The Pokemon you are looking for could not be found</response>
        /// <response code="200">Move learnt by Pokemon requested</response>
        [HttpGet("{moveslearntid}", Name = "GetMovesLearnt")]
        public async Task<ActionResult<MovesLearntDto>> GetOneMoveLearnt(int pokemonId, int movesLearntId)
        {
            if(!await _profOaksKantoPokedexRepository.PokemonExistsAsync(pokemonId))
            {
                return NotFound();
            }

            var specificMoveLearntForPokemon = await _profOaksKantoPokedexRepository.GetMoveLearntAsync(pokemonId, movesLearntId);

            if(specificMoveLearntForPokemon == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<MovesLearntDto>(specificMoveLearntForPokemon));
        }

        /// <summary>
        /// Create a new move for a specific Pokemon
        /// </summary>
        /// <param name="pokemonId">The id of the Pokemon to get</param>
        /// <param name="movesLearnt">DTO body request to create a new move</param>
        /// <returns>An ActionResult</returns>
        /// <response code="404">The Pokemon you are looking for could not be found</response>
        /// <response code="201">Success move created</response>
        [HttpPost]
        public async Task<ActionResult<MovesLearntDto>> CreateMoveLearnt(int pokemonId, MovesLearntForCreationDto movesLearnt)
        {
            if(!await _profOaksKantoPokedexRepository.PokemonExistsAsync(pokemonId))
            {
                return NotFound();
            }

            var finalMoveLearnt = _mapper.Map<Entities.MoveLearnt>(movesLearnt);

            await _profOaksKantoPokedexRepository.AddMoveLeantForPokemonAsync(
                pokemonId, finalMoveLearnt);

            await _profOaksKantoPokedexRepository.SaveChangesAsync();

            var createdMoveLearntToReturn =
                _mapper.Map<Models.MovesLearntDto>(finalMoveLearnt);

            return CreatedAtRoute("GetMovesLearnt",
                new
                {
                    pokemonId = pokemonId,
                    moveslearntid = createdMoveLearntToReturn.Id

                },
                createdMoveLearntToReturn);

        }

        /// <summary>
        /// Fully update a moves details
        /// </summary>
        /// <param name="pokemonId">The id of the Pokemon to get</param>
        /// <param name="movesLearntId">The move id you want to update</param>
        /// <param name="movesLearnt">DTO body request to update move</param>
        /// <returns>An ActionResult</returns>
        /// <response code="404">The Pokemon you are looking for could not be found</response>
        /// <response code="404">The Move you are looking for could not be found</response>
        /// <response code="204">Move updated successfully</response>
        [HttpPut("{moveslearntid}")]
        public async Task<ActionResult> UpdateMoveLearnt(int pokemonId, int movesLearntId, MovesLearntForUpdateDto movesLearnt)
        {
            if(!await _profOaksKantoPokedexRepository.PokemonExistsAsync(pokemonId))
            {
                return NotFound();
            }


            var moveLearntEntity = await _profOaksKantoPokedexRepository.GetMoveLearntAsync(pokemonId, movesLearntId);
            if(moveLearntEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(movesLearnt, moveLearntEntity);

            await _profOaksKantoPokedexRepository.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Partially update deatils of a specific move
        /// </summary>
        /// <param name="pokemonId">The id of the Pokemon to get</param>
        /// <param name="movesLearntId">The move id you want to partially update</param>
        /// <param name="patchDocument">Json patch document to update move</param>
        /// <returns>An ActionResult</returns>
        /// <response code="404">The Pokemon you are looking for could not be found</response>
        /// <response code="404">The Move you are looking for could not be found</response>
        /// <response code="400">Request not submitted in the correct format</response>
        /// <response code="400">Request not valid</response>
        /// <response code="204">Move updated successfully</response>
        [HttpPatch("{moveslearntid}")]
        public async Task<ActionResult> PartiallyUpdateMovesLearnt(int pokemonId, int movesLearntId, JsonPatchDocument<MovesLearntForUpdateDto> patchDocument)
        {
            if(!await _profOaksKantoPokedexRepository.PokemonExistsAsync(pokemonId))
            {
                return NotFound();
            }

            // find the move learnt
            var moveLearntEntity = await _profOaksKantoPokedexRepository
                .GetMoveLearntAsync(pokemonId, movesLearntId);
            if(moveLearntEntity == null)
            {
                return NotFound();
            }

            var moveLearntToPatch = _mapper.Map<MovesLearntForUpdateDto>(moveLearntEntity);
            

            patchDocument.ApplyTo(moveLearntToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(moveLearntToPatch))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(moveLearntToPatch, moveLearntEntity);
            await _profOaksKantoPokedexRepository.SaveChangesAsync();            

            return NoContent();
        }

        /// <summary>
        /// Delete a specific move learnt
        /// </summary>
        /// <param name="pokemonId">The id of the Pokemon to get</param>
        /// <param name="movesLearntId">The move id you want to delete</param>
        /// <returns>An ActionResult</returns>
        /// <response code="404">The Pokemon you are looking for could not be found</response>
        /// <response code="404">The Move you are looking for could not be found</response>
        /// <response code="204">Move deleted successfully</response>
        [HttpDelete("{moveslearntid}")]
        public async Task<ActionResult> DeleteMoveLearnt(int pokemonId, int movesLearntId)
        {
            if(!await _profOaksKantoPokedexRepository.PokemonExistsAsync(pokemonId))
            {
                return NotFound();
            }

            // find the move learnt
            var moveLearntEntity = await _profOaksKantoPokedexRepository
                .GetMoveLearntAsync(pokemonId, movesLearntId);

            if(moveLearntEntity == null)
            {
                return NotFound();
            }

            _profOaksKantoPokedexRepository.DeleteMoveLearnt(moveLearntEntity);
            await _profOaksKantoPokedexRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}
