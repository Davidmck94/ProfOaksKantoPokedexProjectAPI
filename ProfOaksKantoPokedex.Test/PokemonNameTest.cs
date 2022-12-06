using ProfOaksKantoPokedex.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace ProfOaksKantoPokedex.Test
{
    public class PokemonNameTest : IDisposable
    {

        // Could in theory use Theories and member-data as both tests require the same object as a static method.
        // Or could have used ClassData instead by creating a seperate class with Test data


        private Pokemon _pokemon;

        private readonly ITestOutputHelper _testOutputHelper;

        public PokemonNameTest(ITestOutputHelper testOutputHelper, Pokemon pokemon)
        {
            _testOutputHelper = testOutputHelper ?? throw new ArgumentNullException(nameof(testOutputHelper));
            _pokemon = pokemon ?? throw new ArgumentNullException(nameof(pokemon));
        }

        public PokemonNameTest()
        {
            _pokemon = new Pokemon("Venusaur", "Grass, Posion", "Overgrow");
        }

        public void Dispose()
        {
            //Clean up the setup code, if required
        }

        [Fact]
        public void PokemonNameIsBelow50Characters()
        {
            //Arrange
            var newPokemon = _pokemon;

            //Act
            newPokemon.Name = "Charizard";

            //Assert
            Assert.True(newPokemon.Name.Length < 50, "Pokemon name is below 50 characters.");
        }

        [Fact]
        public void PokemonNameIsNotBelow50Characters()
        {
            //Arrange
            var newPokemon = _pokemon;

            //Act
            newPokemon.Name = "CharizardCharizardCharizardCharizardCharizardCharizardCharizardCharizard";

            //Assert
            Assert.False(newPokemon.Name.Length < 50, "Pokemon name is above 50 characters.");
        }
    }
}
