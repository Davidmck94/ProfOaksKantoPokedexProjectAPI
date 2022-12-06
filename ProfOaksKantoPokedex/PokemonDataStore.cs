using ProfOaksKantoPokedex.Models;

namespace ProfOaksKantoPokedex
{
    public class PokemonDataStore
    {
        public List<PokemonDto> Pokemon { get; set; }

        //Static property to return an instance of pokemon data store
        //public static PokemonDataStore Current { get; } = new PokemonDataStore();

        public PokemonDataStore()
        {
            //Dummy data
            Pokemon = new List<PokemonDto>()
            {
                new PokemonDto()
                {
                    Id = 1,
                    Name = "Bulbasaur",
                    Type = "Grass, Posion",
                    Description = "There is a plant seed on its back right from the day this Pokémon is born. The seed slowly grows larger.",
                    Ability = "Overgrow",
                    BaseStatTotal = 318,
                    MovesLearnt = new List<MovesLearntDto>()
                    {
                        new MovesLearntDto()
                        {
                            Id = 1,
                            Name = "Growl",
                            Description = "Reduces the foe’s ATTACK.",
                            LevelLearnt = 1,
                            TypeOfMove = "Normal",
                            MoveCategory = "Status",
                            Power = 0,
                            Accuracy = 100
                        },
                        new MovesLearntDto()
                        {
                            Id = 2,
                            Name = "Tackle",
                            Description = "A full-body charge attack.",
                            LevelLearnt = 1,
                            TypeOfMove = "Normal",
                            MoveCategory = "Physical",
                            Power = 35,
                            Accuracy = 95
                        },
                        new MovesLearntDto()
                        {
                            Id = 3,
                            Name = "Leech Seed",
                            Description = "Steals HP from the foe on every turn.",
                            LevelLearnt = 7,
                            TypeOfMove = "Grass",
                            MoveCategory = "Status",
                            Power = 0,
                            Accuracy = 90
                        }
                    }
                },
                new PokemonDto()
                {
                    Id = 2,
                    Name = "Ivysaur",
                    Type = "Grass, Poison",
                    Description = "When the bulb on its back grows large, it appears to lose the ability to stand on its hind legs.",
                    Ability = "Overgrow",
                    BaseStatTotal = 405,
                    MovesLearnt = new List<MovesLearntDto>()
                    {
                        new MovesLearntDto()
                        {
                            Id = 4,
                            Name = "Growl",
                            Description = "Reduces the foe’s ATTACK.",
                            LevelLearnt = 1,
                            TypeOfMove = "Normal",
                            MoveCategory = "Status",
                            Power = 0,
                            Accuracy = 100
                        },
                        new MovesLearntDto()
                        {
                            Id = 5,
                            Name = "Leech Seed",
                            Description = "Steals HP from the foe on every turn.",
                            LevelLearnt = 7,
                            TypeOfMove = "Grass",
                            MoveCategory = "Status",
                            Power = 0,
                            Accuracy = 90
                        },
                        new MovesLearntDto()
                        {
                            Id = 6,
                            Name = "Tackle",
                            Description = "A full-body charge attack.",
                            LevelLearnt = 1,
                            TypeOfMove = "Normal",
                            MoveCategory = "Physical",
                            Power = 35,
                            Accuracy = 95
                        }

                    }
                },
                new PokemonDto()
                {
                    Id = 3,
                    Name = "Venusaur",
                    Type = "Grass, Poison",
                    Description = "Its plant blooms when it is absorbing solar energy. It stays on the move to seek sunlight.",
                    Ability = "Overgrow",
                    BaseStatTotal = 525,
                    MovesLearnt = new List<MovesLearntDto>()
                    {
                        new MovesLearntDto()
                        {
                            Id = 7,
                            Name = "Growl",
                            Description = "Reduces the foe’s ATTACK.",
                            LevelLearnt = 1,
                            TypeOfMove = "Normal",
                            MoveCategory = "Status",
                            Power = 0,
                            Accuracy = 100
                        },
                        new MovesLearntDto()
                        {
                            Id = 8,
                            Name = "Leech Seed",
                            Description = "Steals HP from the foe on every turn.",
                            LevelLearnt = 7,
                            TypeOfMove = "Grass",
                            MoveCategory = "Status",
                            Power = 0,
                            Accuracy = 90
                        },
                        new MovesLearntDto()
                        {
                            Id = 9,
                            Name = "Tackle",
                            Description = "A full-body charge attack.",
                            LevelLearnt = 1,
                            TypeOfMove = "Normal",
                            MoveCategory = "Physical",
                            Power = 35,
                            Accuracy = 95
                        }
                    }
                }
            };
        }
    }
}
