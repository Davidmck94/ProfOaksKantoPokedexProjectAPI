using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProfOaksKantoPokedex.Entities
{
    public class MoveLearnt
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string? Description { get; set; }
        public int LevelLearnt { get; set; }
        public string TypeOfMove { get; set; }
        public string MoveCategory { get; set; }
        public int Power { get; set; }
        public int Accuracy { get; set; }

        [ForeignKey("PokemonId")]
        public Pokemon? Pokemon { get; set; }
        public int PokemonId { get; set; }

        public MoveLearnt(string name, string typeOfMove, string moveCategory)
        {
            Name = name;   
            TypeOfMove = typeOfMove;
            MoveCategory = moveCategory;
        }
    }
}
