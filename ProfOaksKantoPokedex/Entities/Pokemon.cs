using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProfOaksKantoPokedex.Entities
{
    public class Pokemon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string Type { get; set; }
        [MaxLength(200)]
        public string? Description { get; set; }
        public string Ability { get; set; }
        public int BaseStatTotal { get; set; }
        public ICollection<MoveLearnt> MovesLearnt { get; set; } = new List<MoveLearnt>();

        public Pokemon(string name, string type, string ability)
        {
            Name = name;
            Type = type;
            Ability = ability;
        }
    }
}
