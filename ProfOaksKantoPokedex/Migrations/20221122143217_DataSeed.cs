using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProfOaksKantoPokedex.Migrations
{
    /// <inheritdoc />
    public partial class DataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Pokemon",
                columns: new[] { "Id", "Ability", "BaseStatTotal", "Description", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "Overgrow", 318, "There is a plant seed on its back right from the day this Pokémon is born. The seed slowly grows larger.", "Bulbasaur", "Grass, Posion" },
                    { 2, "Overgrow", 405, "When the bulb on its back grows large, it appears to lose the ability to stand on its hind legs.", "Ivysaur", "Grass, Posion" },
                    { 3, "Overgrow", 525, "Its plant blooms when it is absorbing solar energy. It stays on the move to seek sunlight.", "Venusaur", "Grass, Posion" }
                });

            migrationBuilder.InsertData(
                table: "MovesLearnt",
                columns: new[] { "Id", "Accuracy", "Description", "LevelLearnt", "MoveCategory", "Name", "PokemonId", "Power", "TypeOfMove" },
                values: new object[,]
                {
                    { 1, 100, "Reduces the foe’s ATTACK.", 1, "Status", "Growl", 1, 0, "Normal" },
                    { 2, 95, "A full-body charge attack.", 1, "Physical", "Tackle", 1, 35, "Normal" },
                    { 3, 90, "Steals HP from the foe on every turn.", 1, "Status", "Leech Seed", 1, 0, "Grass" },
                    { 4, 100, "Reduces the foe’s ATTACK.", 1, "Status", "Growl", 2, 0, "Normal" },
                    { 5, 90, "Steals HP from the foe on every turn.", 1, "Status", "Leech Seed", 2, 0, "Grass" },
                    { 6, 95, "A full-body charge attack.", 1, "Physical", "Tackle", 2, 35, "Normal" },
                    { 7, 100, "Reduces the foe’s ATTACK.", 1, "Status", "Growl", 3, 0, "Normal" },
                    { 8, 90, "Steals HP from the foe on every turn.", 1, "Status", "Leech Seed", 3, 0, "Grass" },
                    { 9, 95, "A full-body charge attack.", 1, "Physical", "Tackle", 3, 35, "Normal" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MovesLearnt",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MovesLearnt",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MovesLearnt",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MovesLearnt",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MovesLearnt",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MovesLearnt",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MovesLearnt",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MovesLearnt",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "MovesLearnt",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Pokemon",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pokemon",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pokemon",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
