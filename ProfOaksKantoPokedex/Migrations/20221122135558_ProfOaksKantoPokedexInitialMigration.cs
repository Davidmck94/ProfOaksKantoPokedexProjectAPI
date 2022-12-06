using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProfOaksKantoPokedex.Migrations
{
    /// <inheritdoc />
    public partial class ProfOaksKantoPokedexInitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pokemon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    Ability = table.Column<string>(type: "TEXT", nullable: false),
                    BaseStatTotal = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovesLearnt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    LevelLearnt = table.Column<int>(type: "INTEGER", nullable: false),
                    TypeOfMove = table.Column<string>(type: "TEXT", nullable: false),
                    MoveCategory = table.Column<string>(type: "TEXT", nullable: false),
                    Power = table.Column<int>(type: "INTEGER", nullable: false),
                    Accuracy = table.Column<int>(type: "INTEGER", nullable: false),
                    PokemonId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovesLearnt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovesLearnt_Pokemon_PokemonId",
                        column: x => x.PokemonId,
                        principalTable: "Pokemon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovesLearnt_PokemonId",
                table: "MovesLearnt",
                column: "PokemonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovesLearnt");

            migrationBuilder.DropTable(
                name: "Pokemon");
        }
    }
}
