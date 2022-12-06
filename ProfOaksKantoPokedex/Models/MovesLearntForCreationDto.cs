using System.ComponentModel.DataAnnotations;

namespace ProfOaksKantoPokedex.Models
{
    public class MovesLearntForCreationDto
    {
        [Required(ErrorMessage = "You should provide a name value.")]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        
        [MaxLength(200)]
        public string? Description { get; set; }
        public int LevelLearnt { get; set; }
        public string TypeOfMove { get; set; } = string.Empty;
        public string MoveCategory { get; set; } = string.Empty;
        public int Power { get; set; }
        public int Accuracy { get; set; }
    }
}
