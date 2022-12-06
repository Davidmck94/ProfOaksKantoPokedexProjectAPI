using ProfOaksKantoPokedex.Entities;

namespace ProfOaksKantoPokedex.Services
{
    public interface IProfOaksKantoPokedexRepository
    {
        Task<IEnumerable<Pokemon>> GetPokemonAsync();
        Task<(IEnumerable<Pokemon>, PaginationMetadata)> GetPokemonAsync(string? name, string? searchQuery, int pageNumber, int pageSize);
        Task<Pokemon?> GetPokemonAsync(int pokemonId, bool includeMovesLearnt);
        Task<bool> PokemonExistsAsync(int pokemonId);
        Task<IEnumerable<MoveLearnt>> GetMovesLearntAsync(int pokemonId);
        Task<MoveLearnt?> GetMoveLearntAsync(int pokemonId, int movesLearntId);
        Task AddMoveLeantForPokemonAsync(int pokemonId, MoveLearnt moveLearnt);
        void DeleteMoveLearnt(MoveLearnt moveLearnt);
        Task<bool> SaveChangesAsync();

    }
}
