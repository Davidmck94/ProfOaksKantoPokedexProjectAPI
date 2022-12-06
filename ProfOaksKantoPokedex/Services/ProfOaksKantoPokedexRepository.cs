using Microsoft.EntityFrameworkCore;
using ProfOaksKantoPokedex.DbContexts;
using ProfOaksKantoPokedex.Entities;

namespace ProfOaksKantoPokedex.Services
{
    public class ProfOaksKantoPokedexRepository : IProfOaksKantoPokedexRepository
    {
        private readonly ProfOaksKantoPokedexContext _context;

        public ProfOaksKantoPokedexRepository(ProfOaksKantoPokedexContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        

        public async Task<IEnumerable<Pokemon>> GetPokemonAsync()
        {
            return await _context.Pokemon.OrderBy(c => c.Id).ToListAsync();
        }

        public async Task<(IEnumerable<Pokemon>, PaginationMetadata)> GetPokemonAsync(string? name, string? searchQuery, int pageNumber, int pageSize)
        {
            
            // cast the Db dataset to an Iqueryable collection
            var collection = _context.Pokemon as IQueryable<Pokemon>;

            if (!string.IsNullOrWhiteSpace(name))
            {
                name = name.Trim();
                collection = collection.Where(p => p.Name == name);
            }

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                searchQuery = searchQuery.Trim();
                collection = collection.Where(c => c.Name.Contains(searchQuery)
                    || (c.Description != null && c.Description.Contains(searchQuery)));
            }

            var totalItemCount = await collection.CountAsync();

            var paginationMetadata = new PaginationMetadata(totalItemCount, pageSize, pageNumber);

            var collectionToReturn = await collection.OrderBy(c => c.Id)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();

            return (collectionToReturn, paginationMetadata);

        }

        public async Task<Pokemon?> GetPokemonAsync(int pokemonId, bool includeMovesLearnt)
        {
            if(includeMovesLearnt)
            {
                return await _context.Pokemon.Include(c => c.MovesLearnt)
                    .Where(c => c.Id == pokemonId).FirstOrDefaultAsync();
            }

            return await _context.Pokemon
                .Where(c => c.Id == pokemonId).FirstOrDefaultAsync();
        }

        public async Task<bool> PokemonExistsAsync(int pokemonId)
        {
            return await _context.Pokemon.AnyAsync(p => p.Id == pokemonId);
        }

        public async Task<MoveLearnt?> GetMoveLearntAsync(int pokemonId, int movesLearntId)
        {
            return await _context.MovesLearnt
                .Where(m => m.PokemonId == pokemonId && m.Id == movesLearntId)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<MoveLearnt>> GetMovesLearntAsync(int pokemonId)
        {
            return await _context.MovesLearnt
                .Where(m => m.PokemonId == pokemonId).ToListAsync();
        }

        public async Task AddMoveLeantForPokemonAsync(int pokemonId, MoveLearnt moveLearnt)
        {
            var pokemon = await GetPokemonAsync(pokemonId, false);
            if (pokemon != null)
            {
                pokemon.MovesLearnt.Add(moveLearnt);
            }
        }

        public void DeleteMoveLearnt(MoveLearnt moveLearnt)
        {
            _context.MovesLearnt.Remove(moveLearnt);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

        
    }
}
