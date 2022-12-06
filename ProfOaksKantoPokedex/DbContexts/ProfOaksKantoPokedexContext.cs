using Microsoft.EntityFrameworkCore;
using ProfOaksKantoPokedex.Entities;

namespace ProfOaksKantoPokedex.DbContexts
{
    public class ProfOaksKantoPokedexContext : DbContext
    {
        public DbSet<Pokemon> Pokemon { get; set; } = null!;
        public DbSet<MoveLearnt> MovesLearnt { get; set; } = null!;

        public ProfOaksKantoPokedexContext(DbContextOptions<ProfOaksKantoPokedexContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pokemon>()
                .HasData(
                new Pokemon("Bulbasaur", "Grass, Posion", "Overgrow")
                {
                    Id = 1,
                    Description = "There is a plant seed on its back right from the day this Pokémon is born. The seed slowly grows larger.",
                    BaseStatTotal = 318
                },
                new Pokemon("Ivysaur", "Grass, Posion", "Overgrow")
                {
                    Id = 2,
                    Description = "When the bulb on its back grows large, it appears to lose the ability to stand on its hind legs.",
                    BaseStatTotal = 405
                },
                new Pokemon("Venusaur", "Grass, Posion", "Overgrow")
                {
                    Id = 3,
                    Description = "Its plant blooms when it is absorbing solar energy. It stays on the move to seek sunlight.",
                    BaseStatTotal = 525
                });
            modelBuilder.Entity<MoveLearnt>()
                .HasData(
                new MoveLearnt("Growl", "Normal", "Status")
                {
                    Id = 1,
                    PokemonId = 1,
                    Description = "Reduces the foe’s ATTACK.",
                    LevelLearnt = 1,
                    Power = 0,
                    Accuracy = 100
                },
                new MoveLearnt("Tackle", "Normal", "Physical")
                {
                    Id = 2,
                    PokemonId = 1,
                    Description = "A full-body charge attack.",
                    LevelLearnt = 1,
                    Power = 35,
                    Accuracy = 95
                },
                new MoveLearnt("Leech Seed", "Grass", "Status")
                {
                    Id = 3,
                    PokemonId = 1,
                    Description = "Steals HP from the foe on every turn.",
                    LevelLearnt = 1,
                    Power = 0,
                    Accuracy = 90
                },
                new MoveLearnt("Growl", "Normal", "Status")
                {
                    Id = 4,
                    PokemonId = 2,
                    Description = "Reduces the foe’s ATTACK.",
                    LevelLearnt = 1,
                    Power = 0,
                    Accuracy = 100
                },
                new MoveLearnt("Leech Seed", "Grass", "Status")
                {
                    Id = 5,
                    PokemonId = 2,
                    Description = "Steals HP from the foe on every turn.",
                    LevelLearnt = 1,
                    Power = 0,
                    Accuracy = 90
                },
                new MoveLearnt("Tackle", "Normal", "Physical")
                {
                    Id = 6,
                    PokemonId = 2,
                    Description = "A full-body charge attack.",
                    LevelLearnt = 1,
                    Power = 35,
                    Accuracy = 95
                },
                new MoveLearnt("Growl", "Normal", "Status")
                {
                    Id = 7,
                    PokemonId = 3,
                    Description = "Reduces the foe’s ATTACK.",
                    LevelLearnt = 1,
                    Power = 0,
                    Accuracy = 100
                },
                new MoveLearnt("Leech Seed", "Grass", "Status")
                {
                    Id = 8,
                    PokemonId = 3,
                    Description = "Steals HP from the foe on every turn.",
                    LevelLearnt = 1,
                    Power = 0,
                    Accuracy = 90
                },
                new MoveLearnt("Tackle", "Normal", "Physical")
                {
                    Id = 9,
                    PokemonId = 3,
                    Description = "A full-body charge attack.",
                    LevelLearnt = 1,
                    Power = 35,
                    Accuracy = 95
                });


            base.OnModelCreating(modelBuilder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("connectionstring");
        //    base.OnConfiguring(optionsBuilder);
        //}



    }
}
