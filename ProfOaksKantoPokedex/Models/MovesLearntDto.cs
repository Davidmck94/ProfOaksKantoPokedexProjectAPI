namespace ProfOaksKantoPokedex.Models
{
    public class MovesLearntDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int LevelLearnt { get; set; }    
        public string TypeOfMove { get; set; } = string.Empty;
        public string MoveCategory { get; set; } = string.Empty;
        public int Power { get; set; }
        public int Accuracy { get; set; }

    }
}
