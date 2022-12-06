namespace ProfOaksKantoPokedex.Models
{
    public class PokemonDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Ability { get; set; } = string.Empty; 
        public int BaseStatTotal { get; set; }
        public ICollection<MovesLearntDto> MovesLearnt { get;set; } = new List<MovesLearntDto>();


        public int NumberOfMovesLearntByLevelUp
        {
            get
            {
                return MovesLearnt.Count;
            }
        }

    }
}
