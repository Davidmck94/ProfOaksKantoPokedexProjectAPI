namespace ProfOaksKantoPokedex.Models
{
    /// <summary>
    /// A DTO for a Pokemon without any moves learnt attached
    /// </summary>
    public class PokemonWithoutMovesLearntDto
    {
        /// <summary>
        /// The id of the Pokemon
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The name of the Pokemon
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// The target Pokemons typing
        /// </summary>
        public string Type { get; set; } = string.Empty;
        /// <summary>
        /// The description of the target Pokemon
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// The unique ability of the target Pokemon
        /// </summary>
        public string Ability { get; set; } = string.Empty;
        /// <summary>
        /// The base-stat total of the Pokemon
        /// </summary>
        public int BaseStatTotal { get; set; }
    }
}
